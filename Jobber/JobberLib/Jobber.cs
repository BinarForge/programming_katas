using System.Collections.Generic;


/**
	Jobber class was create in order to help resolving the correct order of jobs, 
	with a respect to the dependencies structured between the jobs
*/
namespace JobberLib
{
	// Custom exception type thrown when the circular dependency occurs
	// The scenario when a job depends on itself is being understood as a circular as well
	public class CircularJobDependencyException : System.Exception
	{
		public CircularJobDependencyException(string message = "Circular job dependency ocurred!")
			: base(message)
		{
		}
	}

	public interface IJobber
	{
		void Setup(Dictionary<char, string> structure);
		bool IsValid();
		string Resolve(string jobSequence);
	}

	public class Jobber : IJobber
	{
		/**
			Dependencies are stored as a dictionary:
			- The key is the job and the value string (list of chars) is a list of other jobs
			  that need to be completed before the key job can be started.
		*/
		private Dictionary<char, string> _structure;
		private bool _isValid = true;

		// Load the job dependency structure
		public void Setup(Dictionary<char, string> structure)
		{
			_structure = structure;
		}

		// The validation feedback is being kept even after the resolving process
		public bool IsValid()
		{
			return _isValid;
		}

		// Clear the validation feedback and the structure to start again fresh
		public void Reset()
		{
			_isValid = true;
			_structure.Clear();
		}

		private bool GotDependencies
		{
			get { return (_structure != null && _structure.Count > 0); }
		}

		/**
			Resolution algorithm is not pre-validating the structure, but instead it throws the exception
			whenever it detects the circular dependency.
			The strategy is to resolve all the `dependency-free` jobs first, which increases the chance
			that the next dependent job in the queue will be ready to go.

			The method takes the job sequence and if succeeds, it returns the same sequence but correctly ordered.
			If anything goes wrong, there is no returning value, as the exception occurs instead.
		*/
		public string Resolve(string jobSequence)
		{
			if (jobSequence == string.Empty)
				return string.Empty;
			else if (jobSequence.Length == 1 || !GotDependencies)
				return jobSequence;
			else {
				string jobsDone = string.Empty;
				string workingQueue = jobSequence;

				while (!string.IsNullOrEmpty(workingQueue)) {
					bool removedSomething = false;
					
					for (int idx = 0; idx < workingQueue.Length; idx++) {
						var curr = workingQueue[idx];

						if (!_structure.ContainsKey(curr)) {
							jobsDone += curr;
							workingQueue = workingQueue.Remove(idx, 1);
							removedSomething = true;
						} else {
							bool readyToGo = true;
							foreach (var dependency in _structure[curr]) {
								if (!jobsDone.Contains(dependency.ToString()))
									readyToGo = false;
							}

							if (readyToGo) {
								jobsDone += curr;
								workingQueue = workingQueue.Remove(idx, 1);
								removedSomething = true;
							}
						}
					}

					if (!removedSomething) {
						// this will break the infinite loop when needed
						throw new CircularJobDependencyException();
						_isValid = false;
					}
				}

				return jobsDone;
			}
		}
	}
}
