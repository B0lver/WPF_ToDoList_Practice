using System;
using System.Collections.ObjectModel;

namespace WPF_ToDoList.Models
{
    internal class Week
    {
        public ObservableCollection<Day> Days { get; set; }

        public Week(int offset = 1)
        {
            Days = new ObservableCollection<Day>();
            for (int i = 0; i < 7; i++)
            {
                int dayNumber = (i + offset)%7;
                Days.Add(new Day((DayOfWeek)dayNumber));
            }
        }
    }
}
