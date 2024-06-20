using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmallMVVM
{
    public class MainWindowViewModel: ViewModelBase
    {
        public ObservableCollection<Task> Tasks { get; set; }
        private string _name { get; set; }
        private string _iscomplete { get; set; }

        private Task _selectedTask { get; set; }
        public ICommand AddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        public MainWindowViewModel()
        {
            Tasks = new ObservableCollection<Task>() {
            
                new Task(){
                    Id = 1,
                    Name = "Description 1",
                    IsComplete = false },
                new Task(){
                    Id = 2,
                    Name = "Description 2",
                    IsComplete = false },
                new Task(){
                    Id = 3,
                    Name = "Description 3",
                    IsComplete = true },
            };

            AddTaskCommand = new RelayCommand(AddTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask, CanDeleteTask);
        }

        public Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string IsDone
        {
            get
            {
                return _iscomplete;
            }
            set
            {
                if (_iscomplete != value)
                {
                    _iscomplete = value;
                    OnPropertyChanged("IsComplete");
                }
            }
        }

        private void AddTask(object parameter)
        {
            var newTask = new Task
            {
                Id = Tasks.Count > 0 ? Tasks[Tasks.Count - 1].Id + 1 : 1,
                Name = "New Task",
                IsComplete = false
            };
            Tasks.Add(newTask);
        }

        private void DeleteTask(object parameter)
        {
            if (SelectedTask != null)
            {
                Tasks.Remove(SelectedTask);
            }
        }

        private bool CanDeleteTask(object parameter)
        {
            return SelectedTask != null;
        }

    }
}
