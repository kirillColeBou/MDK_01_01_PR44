﻿using System;
using System.Collections.Generic;
using System.Text;
using TaskManager_Тепляков.Classes;

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
