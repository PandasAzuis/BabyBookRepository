﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BabyBook.Model
{
    public class Baby
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string BirthTime { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string MaternityHospital { get; set; }
        public string BloodType { get; set; }
        public byte[] FistPhoto { get; set; }
    }
}