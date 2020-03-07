using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace geographical_point.Models
{
    public class Polygon
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PolygonName { get; set; }
        public string Coordinates { get; set; }
    }
}
