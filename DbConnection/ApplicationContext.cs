using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ToDoList.Models;

namespace WPF_ToDoList.DbConnection
{
    public class ApplicationContext : DbContext
    {
        private const string ConnectionString = @"Data Source = DESKTOP-FRSJ73N\SQLEXPRESS\WPF_ToDoApp";

        public DbSet<ToDoItem> Items => Set<ToDoItem>();
        public ApplicationContext() => Database.OpenConnection();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }
    }
}
