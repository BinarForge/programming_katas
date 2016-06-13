using System;
using System.Collections.Generic;

namespace GormanianCalendar
{
    public class GormanicDate
    {
        private readonly int _month;

        static readonly List<string> Months = new List<string>{"March", "April", "May", "June", "Quintilis", "Sextilis", "September", "October", "November", "December", "January", "February", "Gormanuary"};
        public static int MonthsInyear => Months.Count;
        private static readonly int DaysinMonth = 28;

        public GormanicDate(DateTime gregorianDate)
        {
            var dayOfTheYear = DayOfTheYear(gregorianDate);
            Year = gregorianDate.Year;
            _month = dayOfTheYear/DaysinMonth;
            Day = dayOfTheYear%DaysinMonth;
        }

        public static int DayOfTheYear(DateTime gregorianDate)
        {
            return gregorianDate.DayOfYear;
        }
        
        public int Year { get; }
        public string MonthName { get { return Months[_month]; } }
        public int Day { get; }

        public object IsIntermission
        {
            get
            {
                var dayInGormanicYear = ( _month*DaysinMonth + Day );
                if (DateTime.IsLeapYear(Year))
                    return dayInGormanicYear >= DaysinMonth*MonthsInyear;
                else
                    return dayInGormanicYear > DaysinMonth * MonthsInyear;
            }
        }

        public override string ToString()
        {
            var dayAsString = Day.ToString();
            var lastChar = dayAsString[dayAsString.Length - 1];

            var stuff = "th";
            if (lastChar == '1')
                stuff = "st";
            else if (lastChar == '2')
                stuff = "nd";
            else if (lastChar == '3')
                stuff = "rd";

            return $"{Day}{stuff} {MonthName} {Year}";
        }

        public static bool IsValid(int gormanicYear, int gormanicMonth, int gormanicDay)
        {
            return ( gormanicMonth < MonthsInyear && gormanicDay <= DaysinMonth );
        }
    }
}