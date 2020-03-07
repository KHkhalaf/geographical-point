using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace geographical_point.Models
{
    public class DataAccess
    {
        public SQLiteConnection connection { get; set; }
        public DataAccess()
        {
            try
            {
                connection = DependencyService.Get<Isqlite>().GetConnection();
                connection.CreateTable<Polygon>();
            }
            catch (Exception)
            {
                DependencyService.Get<SnackBar>().ShowSnackBar("Error ... Something went wrong");
            }
        }

        public List<Polygon> GetPolygons()
        {
            try
            {
                return connection.Table<Polygon>().ToList();
            }
            catch (Exception)
            {
                DependencyService.Get<SnackBar>().ShowSnackBar("Error ... Something went wrong");
                return new List<Polygon>();
            }
        }
        public void AddPolygon(Polygon polygon)
        {
            try
            { 
                connection.Insert(polygon);
            }
            catch (Exception)
            {
                DependencyService.Get<SnackBar>().ShowSnackBar("Error ... Something went wrong");
            }
        }
        public List<Polygon> SearchByName(string searchKey)
        {
            if(searchKey == "" || searchKey == null)
            {
                try
                {
                    return connection.Table<Polygon>().ToList();
                }
                catch (Exception)
                {
                    DependencyService.Get<SnackBar>().ShowSnackBar("Error ... Something went wrong");
                    return new List<Polygon>();
                }
            }
            if (String.IsNullOrWhiteSpace(searchKey))
            {
                return new List<Polygon>();
            }

            try
            {
                return connection.Table<Polygon>().ToList().Where(p => p.PolygonName.Contains(searchKey)).ToList();
            }
            catch (Exception)
            {
                DependencyService.Get<SnackBar>().ShowSnackBar("Error ... Something went wrong");
            }
            return new List<Polygon>();
        }
    }
}
