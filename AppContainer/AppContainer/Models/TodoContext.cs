using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using AppContainer.Models;

namespace AppContainer.Model
{
    public class ToDoContext : DbContext
    {

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        public DbSet<ToDoList> ToDoLists { get; set; }
    }
}