using System;
using SQLite;
namespace App1.Models
{
    public class Monument
    {
        
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location {get; set;}
        public string Description { get; set; }
    }
}