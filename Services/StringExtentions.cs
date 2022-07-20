using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ToDoList.Services
{
    public static class StringExtentions
    {
        public static string FirstLetterToUpper(string input)
        {
            return input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"String cannot be empty: {nameof(input)}"),
                _ => String.Concat(input[0].ToString().ToUpper(), input.AsSpan(2))
            };
        }
    }
}
