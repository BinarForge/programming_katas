using NUnit.Framework;
using JobberLib;

namespace JobberUnitTests
{
	[TestFixture]
	public class GivenTheJobberClass
	{
		[Test]
		public void TestThatTheClassExists()
		{
			var subject = new Jobber();
			subject.Setup();

			Assert.NotNull(subject, "Jobber class exists");
		}
	}
}
