using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence_cd
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public long Year { get; set; }
        public string Genre { get; set; }
        public long Price { get; set; }
        public TodoItem()
        {
        }
    }
}
