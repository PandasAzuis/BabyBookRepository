using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BabyBook.Model
{
    public class FirstMoments
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string  Name { get; set; }
        public byte[] Photo { get; set; }
        public int BabyId { get; set; }
    }
}
