using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Proyecto2_2.Models
{
    internal class Signature
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public String Name { get; set; }
        public String Description { get; set; }
        public String ImagePath { get; set; }

        public DateTime Date { get; set; }
    }
}
