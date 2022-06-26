using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ToDoList.Models
{
    internal class Week
    {
        public ObservableCollection<Day> Days { get; set; }

        public Week()
        {
            Days = new ObservableCollection<Day>();
            for (int i = 0; i < 7; i++)
            {
                Days.Add(new Day((DayOfWeek)i));
            }
        }
    }
}
