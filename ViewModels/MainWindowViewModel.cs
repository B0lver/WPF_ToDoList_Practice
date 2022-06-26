using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ToDoList.Models;

namespace WPF_ToDoList.ViewModels
{
    internal class MainWindowViewModel  :Base.BaseViewModel
    {

        #region Поля

        #region SelectedToDoItem - Выбранное дело

        private ToDoItem _SelectedToDoItem;

        ///<summary> Выбранное дело </summary>
        public ToDoItem SelectedToDoItem
        {
            get => _SelectedToDoItem;
            set => Set<ToDoItem>(ref _SelectedToDoItem, value);
        }

        #endregion

        #region ToDoList - Список дел

        private ObservableCollection<ToDoItem> _ToDoList;

        ///<summary> Список дел </summary>
        public ObservableCollection<ToDoItem> ToDoList
        {
            get => _ToDoList;
            set => Set<ObservableCollection<ToDoItem>>(ref _ToDoList, value);
        }

        #endregion

        #endregion


        public MainWindowViewModel()
        {
            Title = "Новый заголовок окна";
            InitToDoList();
            SelectedToDoItem = ToDoList[0];
        }

        private void InitToDoList()
        {
            ToDoList = new ObservableCollection<ToDoItem>();
            for (int i = 0; i < 10; i++)
            {
                ToDoList.Add(new ToDoItem() 
                {
                    Name = $"Дело {i}",
                    Description = $"Описание {i}"
                });
            }
        }

    }
}
