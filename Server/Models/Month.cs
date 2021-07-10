using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Month
    {
        string month;
        int firstDaysToSkip;
        public readonly int numOfDays;
        Calendar cal;
        Day[] daysWithToDos;

        public Month(DateTime date)
        {
            cal = CultureInfo.InvariantCulture.Calendar;
            month = date.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-GB"));
            numOfDays = cal.GetDaysInMonth(date.Year,date.Month);

            firstDaysToSkip = (int)new DateTime(cal.GetYear(date), cal.GetMonth(date), 1).DayOfWeek-1;
            
            // Sunday
            if (firstDaysToSkip < 0) firstDaysToSkip = 6;

            daysWithToDos = new Day[numOfDays];

            for (int i = 0; i < numOfDays; i++)
            {
                int j = i;
                daysWithToDos[i] = new Day(new DateTime(cal.GetYear(date), cal.GetMonth(date), j + 1), new List<ToDo>());
            }
        }

        public Day this[int i]
        {
            get { return daysWithToDos[i]; }
            set { daysWithToDos[i] = value; }
        }

        public string GetName => month;

        public int FirstDaysToSkip => firstDaysToSkip;

        public double Rows { get { return Math.Ceiling((firstDaysToSkip + numOfDays) / 7.0); }}

        


    }
}
