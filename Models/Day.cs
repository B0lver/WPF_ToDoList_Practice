using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
