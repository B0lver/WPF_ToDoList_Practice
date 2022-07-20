using System;
using System.Globalization;

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
            Name = DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek);
        }

    }
}
