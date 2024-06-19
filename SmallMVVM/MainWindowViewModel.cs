using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallMVVM
{
    public class MainWindowViewModel: ViewModelBase
    {
        public ObservableCollection<Task> Tasks { get; set; }
        private string _name { get; set; }
        private string _iscomplete { get; set; }

        private Task _selectedTask { get; set; }

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

    }
}
