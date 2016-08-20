using System.Collections.Generic;

namespace JobberLib
{
	public class CircularJobDependencyException : System.Exception
	{
		public CircularJobDependencyException(string message = "Circular job dependency ocurred!")
			:base(message)
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
		public void Setup(Dictionary<char, string> structure)
		{

		}

		public bool IsValid()
		{
			return true;
		}

		public string Resolve(string jobSequence)
		{
			return string.Empty;
		}
    }
}
