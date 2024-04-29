using System;
using System.Collections.Generic;
using System.Text;
using TaskManager_Тепляков.Classes;

namespace TaskManager_Тепляков.Models
{
    public class Priority : Notification
    {
        public int Id { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
