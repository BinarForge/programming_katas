using System;
using System.Globalization;
using NUnit.Framework;


namespace GormanianCalendar.Tests
{
    [TestFixture]
    public class GivenAGregorianDateTime
    {
        private DateTime _date;

        [SetUp]
        public void WhenDeterminingSpecificDate()
        {
            _date = new DateTime(2016, 1, 31, new GregorianCalendar());
        }

        [Test]
        public void ThenTheGormanicDayOfTheYearIsCorrect()
        {
            Assert.That(GormanicDate.DayOfTheYear(_date), Is.EqualTo(31));
        }
    }

    [TestFixture]
    public class GivenAGormanicDate
    {
        [Test]
        public void ThenTheMonthCountIsCorrect()
        {
            Assert.That(GormanicDate.MonthsInyear, Is.EqualTo(13));
        }

        [TestCase(2016,1,1, 2016, "March", 1)]
        [TestCase(2015, 11, 5, 2015, "February", 1)]
        [TestCase(2014, 4, 1, 2014, "June", 7)]
        [TestCase(2014, 3, 2, 2014, "May", 5)]
        public void ThenTheDateIsConvertedCorrectly(int gregorianYear, int gregorianMonth, int gregorianDay, int expectedYear, string expectedMonth, int expectedDay)
        {
            var gregorianDate = new DateTime(gregorianYear, gregorianMonth, gregorianDay, new GregorianCalendar());
            var gormanicDate = new GormanicDate(gregorianDate);

            Assert.That(gormanicDate.Year, Is.EqualTo(gregorianDate.Year));
            Assert.That(gormanicDate.MonthName, Is.EqualTo(expectedMonth));
            Assert.That(gormanicDate.Day, Is.EqualTo(expectedDay));
        }

        [TestCase(2010, 12, 31, true)]
        [TestCase(2016, 12, 30, true)] // leap year I guess
        [TestCase(2010, 12, 30, false)]
        [TestCase(2014, 4, 1, false)]
        public void ThenTheIntermissionIsDetermined(int gregorianYear, int gregorianMonth, int gregorianDay, bool expectIntermission)
        {
            var gregorianDate = new DateTime(gregorianYear, gregorianMonth, gregorianDay, new GregorianCalendar());
            var gormanicDate = new GormanicDate(gregorianDate);

            Assert.That(gormanicDate.IsIntermission, Is.EqualTo(expectIntermission));
        }

        [TestCase(2016, 1, 1, "1st March 2016")]
        [TestCase(2015, 11, 5, "1st February 2015")]
        [TestCase(2014, 4, 1, "7th June 2014")]
        [TestCase(2014, 3, 2, "5th May 2014")]
        public void ThenTheGormanicDateIsCorrectlyRenderedAsString(int gregorianYear, int gregorianMonth, int gregorianDay, string expectedWording)
        {
            var gregorianDate = new DateTime(gregorianYear, gregorianMonth, gregorianDay, new GregorianCalendar());
            var gormanicDate = new GormanicDate(gregorianDate);

            Assert.That(gormanicDate.ToString(), Is.EqualTo(expectedWording));
        }

        [TestCase(2016, 1, 1, true)]
        [TestCase(2016, 1, 30, false)]
        [TestCase(2016, 30, 1, false)]
        [TestCase(2016, 30, 30, false)]
        public void ThenTheGormanicDateIsValidatedCorrectly(int gregorianYear, int gregorianMonth, int gregorianDay, bool isValid)
        {
            Assert.That(GormanicDate.IsValid(gregorianYear, gregorianMonth, gregorianDay), Is.EqualTo(isValid));
        }

        [Test]
        public void ThenTheNextDayIsGivenCorrectly()
        {
            var gregorianDate = new DateTime(2016, 1, 31, new GregorianCalendar());
            var gormanicDate = new GormanicDate(gregorianDate);
            // todo: finish this maybe
        }
    }
}
