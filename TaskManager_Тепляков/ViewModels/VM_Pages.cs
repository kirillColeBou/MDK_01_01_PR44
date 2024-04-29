using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TaskManager_Тепляков.Classes;
using TaskManager_Тепляков.Context;
using TaskManager_Тепляков.Models;

namespace TaskManager_Тепляков.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Tasks vm_tasks = new VM_Tasks();

        public VM_Pages() => MainWindow.init.frame.Navigate(new View.Main(vm_tasks));

        public RealyCommand OnClose
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    MainWindow.init.Close();
                });
            }
        }
    }
}
