using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Windows.Input;
using TaskManager_Тепляков.Classes;
using TaskManager_Тепляков.Context;
using TaskManager_Тепляков.Models;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager_Тепляков.ViewModels
{
    public class VM_Tasks : Notification
    {
        public TasksContext tasksContext = new TasksContext();

        public ObservableCollection<Tasks> Tasks { get; set; }

        public VM_Tasks() => Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.OrderBy(x => x.Done));

        public RealyCommand OnAddTask
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Tasks NewTask = new Tasks()
                    {
                        DateExecute = DateTime.Now
                    };
                    Tasks.Add(NewTask);
                    tasksContext.Tasks.Add(NewTask);
                    tasksContext.SaveChanges();
                });

            }
        }

        private string search;

        public string Search
        {
            get => search;
            set => search = value;
        }

        public RealyCommand OnSearch
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    if (string.IsNullOrEmpty(search)) Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.OrderBy(x => x.Done));
                    else Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.Where(x => x.Name == search));
                    MainWindow.init.frame.Navigate(new View.Main(this));
                });

            }
        }

        private int sort;

        public int Sort
        {
            get { return sort; }
            set
            {
                if (sort != value)
                {
                    sort = value;
                    OnPropertyChanged("Sort");
                    OnSort.Execute(null);
                }
            }
        }

        public RealyCommand OnSort
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    if (sort == 1) Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.Where(x => x.PriorityId == 1));
                    else if (sort == 2) Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.Where(x => x.PriorityId == 2));
                    else if (sort == 3) Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.Where(x => x.PriorityId == 3));
                    MainWindow.init.frame.Navigate(new View.Main(this));
                });
            }
        }


        [Schema.NotMapped]
        public ObservableCollection<Priority> SortValues
        {
            get
            {
                return new ObservableCollection<Priority>(new PriorityContext().Priority);
            }
        }
    }
}
