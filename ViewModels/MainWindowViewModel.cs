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
        private int _newItems_TestIndex = 0;

        #region Поля

        #region SelectedToDoItem - Выбранное дело

        private ToDoItem _SelectedToDoItem;

        ///<summary> Выбранное дело </summary>
        public ToDoItem SelectedToDoItem
        {
            get => _SelectedToDoItem;
            set
            {
                IsSelectedElementEditing = false;
                Set<ToDoItem>(ref _SelectedToDoItem, value);
            }
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

        #region IsSelectedElementChanging - Состояние изменения выбранного элемента

        private bool _IsSelectedElementChanging = false;

        ///<summary> Состояние изменения выбранного элемента </summary>
        public bool IsSelectedElementEditing
        {
            get => _IsSelectedElementChanging;
            set => Set<bool>(ref _IsSelectedElementChanging, value);
        }

        #endregion

        #endregion

        #region Команды

        #region AddNewToDoItemCommand - Добавление нового элемента к списку дел

        private void OnAddNewToDoItemCommandExecuted(object p)
        {
            ToDoList.Add(new ToDoItem()
            {
                Name = $"Новое дело {_newItems_TestIndex}",
                Description = $"Описание нового дела {_newItems_TestIndex++}"
            });
            SelectedToDoItem = ToDoList.Last();
        }

        private bool CanAddNewToDoItemCommandExecute(object p) => true;

        ///<summary> Добавление нового элемента к списку дел </summary>
        public ICommand AddNewToDoItemCommand { get; }

        #endregion

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

        #region StartEditingElementCommand - Начало редактирования элемента

        private void OnStartEditingElementCommandExecuted(object p) 
        {
            if (!(p is ToDoItem item))
            {
                return;
            }
            IsSelectedElementEditing = true;
        }

        private bool CanStartEditingElementCommandExecute(object p) => (p is ToDoItem item) && ToDoList.Contains(item);

        ///<summary> Начало редактирования элемента </summary>
        public ICommand StartEditingElementCommand { get; }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            
            Title = "Новый заголовок окна";
            InitToDoList();

            #region Команды

            DeleteToDoListElementCommand = new LambdaCommand(OnDeleteToDoListElementCommandExecuted, CanDeleteToDoListElementCommandExecute);
            AddNewToDoItemCommand = new LambdaCommand(OnAddNewToDoItemCommandExecuted, CanAddNewToDoItemCommandExecute);
            StartEditingElementCommand = new LambdaCommand(OnStartEditingElementCommandExecuted, CanStartEditingElementCommandExecute);

            #endregion

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
