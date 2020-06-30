using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;

namespace BabyBook.Model
{
    public class Baby
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string BirthTime { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string MaternityHospital { get; set; }
        public string BloodType { get; set; }
        public byte[] FistPhoto { get; set; }

        // Singleton
        private static Baby _instance;

        public static Baby Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

    }
}
