﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager_Тепляков.Classes.Database
{
    public class Config
    {
        public static readonly string connection = "server=127.0.0.1;uid=root;database=TaskManager;";
        public static readonly MySqlServerVersion version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
