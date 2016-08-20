namespace JobberLib
{
	public interface IJobber
	{
		void Setup();
		bool IsValid();
		string Resolve();
	}

    public class Jobber : IJobber
    {
		public void Setup()
		{

		}

		public bool IsValid()
		{
			return true;
		}

		public string Resolve()
		{
			return string.Empty;
		}
    }
}
