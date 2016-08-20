using System.Collections.Generic;

namespace JobberLib
{
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
		private Dictionary<char, string> _structure;

		// persist the job dependency structure
		public void Setup(Dictionary<char, string> structure)
		{
			_structure = structure;
		}

		// this will be determining whether the dependency structure is circular or not
		public bool IsValid()
		{
			return true;
		}

		private bool GotDependencies
		{
			get { return (_structure != null && _structure.Count > 0); }
		}

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
					}
				}

				return jobsDone;
			}
		}
	}
}
