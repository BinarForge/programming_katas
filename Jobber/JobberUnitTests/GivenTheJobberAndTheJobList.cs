using NUnit.Framework;
using JobberLib;
using System.Collections.Generic;

namespace JobberUnitTests
{
	[TestFixture]
	public class GivenTheJobberInstanceAndNoStructure
	{
		IJobber _subject;

		[SetUp]
		public void SetUpTheStructure()
		{
			_subject = new Jobber();
		}

		[Test]
		public void WhenPassingAnEmptyStringItResolvesWithEmptySequence()
		{
			var result = _subject.Resolve(string.Empty);

			Assert.That(result == string.Empty, Is.True, "The resolved sequence is not empty.");
		}

		[Test]
		public void WhenPassingOneJobSequenceItShouldResolveWithThisOneJob()
		{
			var result = _subject.Resolve("A");

			Assert.That(result == "A", Is.True, "The resolved sequence is not the same as input.");
		}

		[Test]
		public void WhenPassingSequenceOfFewJobsItShouldResolveWithoutAffectingTheOrder()
		{
			var result = _subject.Resolve("ABC");

			Assert.That(result == "ABC", Is.True, "The resolved sequence is not the same as input.");
		}
	}

	[TestFixture]
	public class GivenTheJobberInstanceAndSingleDependency
	{
		IJobber _subject;

		[SetUp]
		public void SetUpTheStructure()
		{
			_subject = new Jobber();
			_subject.Setup(new Dictionary<char, string> { { 'B', "C" } });
		}

		[Test]
		public void WhenPassingSequenceOfThreeJobsItResolvesTheCorrectOrder()
		{
			var result = _subject.Resolve("ABC");

			Assert.That(result == "CAB", Is.True, "The resolved order is incorrect.");
		}
	}

	[TestFixture]
	public class GivenTheJobberInstanceAndSingleDependencyOnItself
	{
		IJobber _subject;

		[SetUp]
		public void SetUpTheValidStructure()
		{
			_subject = new Jobber();
			_subject.Setup(new Dictionary<char, string> { { 'C', "C" } });
		}

		[Test]
		public void WhenResolvingTheIncorrectJobsStructureItThrowsAnError()
		{
			var result = _subject.Resolve("AC");
			Assert.Throws<CircularJobDependencyException>(() => { }, "The circular dependency has not been detected when expected!");
		}
	}

	[TestFixture]
	public class GivenTheJobberInstanceAndMultipleValidDependenciesBetweenJobs
	{
		IJobber _subject;

		[SetUp]
		public void SetUpTheStructure()
		{
			_subject = new Jobber();
			_subject.Setup(new Dictionary<char, string> {
				{ 'B', "C" },
				{ 'C', "F" },
				{ 'D', "A" },
				{ 'E', "B" }
			});
		}

		[Test]
		public void WhenResolvingMultipleJobsDependenciesItReturnsTheCorrectOrderOfJobs()
		{
			var result = _subject.Resolve("ABCDEF");
			
			Assert.That(result == "AFCDBE" || result == "FACDBE" || result == "AFDCBE" || result == "FADCBE", Is.True, "The resolved order is incorrect.");
		}
	}

	public class GivenTheJobberInstanceAndTheStructureWithCircularDependencies
	{
		IJobber _subject;

		[SetUp]
		public void SetUpTheInvalidStructure()
		{
			_subject = new Jobber();
			_subject.Setup(new Dictionary<char, string> {
				{ 'B', "C" },
				{ 'C', "F" },
				{ 'D', "A" },
				{ 'F', "B" }
			});
		}

		[Test]
		public void WhenResolvingTheIncorrectJobsStructureItDetectsTheCircularDependencyAndThrowsAnError()
		{
			var result = _subject.Resolve("ABC");

			Assert.Throws<CircularJobDependencyException>(() => { }, "The circular dependency has not been detected when expected!");
		}
	}
}
