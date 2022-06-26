using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_ToDoList.Commands;
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

        #region Команды

        #region DeleteToDoListElementCommand - Удаление элемента из списка дел

        private void OnDeleteToDoListElementCommandExecuted(object p) 
        {
            if (!(p is ToDoItem item))
            {
                return;
            }
            int index = ToDoList.IndexOf(item);
            ToDoList.Remove(item);
            int count = ToDoList.Count;
            if (index == count && count > 0)
            {
                SelectedToDoItem = ToDoList[index - 1];
            }
            else
            {
                if (index < ToDoList.Count)
                {
                    SelectedToDoItem = ToDoList[index];
                }
            }
        }

        private bool CanDeleteToDoListElementCommandExecute(object p) => (p is ToDoItem item);

        ///<summary> Удаление элемента из списка дел </summary>
        public ICommand DeleteToDoListElementCommand { get; }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            
            Title = "Новый заголовок окна";
            InitToDoList();
            #region Команды

            DeleteToDoListElementCommand = new LambdaCommand(OnDeleteToDoListElementCommandExecuted, CanDeleteToDoListElementCommandExecute);

            #endregion
            //SelectedToDoItem = ToDoList[0];
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
