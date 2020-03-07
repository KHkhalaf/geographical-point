using geographical_point.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace geographical_point.ViewModels
{
    public class PolygonViewModel:INotifyPropertyChanged
    {
        public List<Polygon> _Polygons;
        //public DataAccess _dataAccess;
        public DataAccess dataAccess;
        public List<Polygon> Polygons { 
            get { return _Polygons; }
            set { 
                _Polygons = value;
                OnPropertyChanged();
            }
        }
        public PolygonViewModel()
        {
            dataAccess = new DataAccess();
            Polygons = dataAccess.GetPolygons();
        }
        public void AddPolygon(Polygon polygon)
        {
            dataAccess.AddPolygon(polygon);
            Polygons.Add(polygon);
        }
        public List<Polygon> SearchByName(string searchKey)
        {
            return Polygons = dataAccess.SearchByName(searchKey);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
