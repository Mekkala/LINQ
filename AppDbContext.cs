using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace PracticeLINQ
{
    
    public class AppDbContext : DbContext
    {
       
        private const string ConnectionString = @"Data Source=MyFirstEfCoreDb.db";

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlite(ConnectionString); 
        }        

        public DbSet<Student> Students { get; set; }   
        
    }    
}