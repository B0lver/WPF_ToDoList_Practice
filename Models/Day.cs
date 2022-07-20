using System;
using System.Globalization;
using WPF_ToDoList.Services;

namespace WPF_ToDoList.Models
{
    internal class Day
    {
        public string Name { get; set; }
        public int MonthDate { get; set; }
        public string Month { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public Day(DayOfWeek dayOfWeek)
        {
            this.DayOfWeek = dayOfWeek;
            var dayName = DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek);
            Name = StringExtentions.FirstLetterToUpper(dayName);
        }

    }
}
