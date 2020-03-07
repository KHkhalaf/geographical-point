using geographical_point.Models;
using geographical_point.ViewModels;
using GeoJSON.Net.Feature;
using Newtonsoft.Json;
using RestSharp;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace geographical_point
{

    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        private FeatureCollection Polygons;
        PolygonViewModel polygonViewModel;
        public MainPage()
        {
            InitializeComponent();
            polygonViewModel = new PolygonViewModel();
            BindingContext = polygonViewModel;

            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(51, 09),
                Distance.FromMiles(50)));
        }
        private async void Map_OnTap(object sender, TapEventArgs e)
        {
            Position _position = new Position();
            _position = e.Position;
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = e.Position,
                Label = " Cliked ",
                Address = e.Position.Latitude + " X " + e.Position.Latitude,
            };

            //  Get Coordinates Polygon as json string then Deserialize it
            var jsonCoordinates = new Geojson().ReadGeoJson(pin);
            Polygons = JsonConvert.DeserializeObject<FeatureCollection>(jsonCoordinates);
            if (Polygons == null)
            {
                DependencyService.Get<SnackBar>().ShowSnackBar("There is no detected area");
                return;
            }
            map.Pins.Add(pin);
            DrawPolygon();
            string result = await DisplayPromptAsync("Info", "if you want to save this area ? enter name it",
                 "OK", "CANCEL", keyboard: Keyboard.Text);
            if (result != null)
            {
                Models.Polygon polygon = new Models.Polygon();
                polygon.PolygonName = result;
                polygon.Coordinates = jsonCoordinates;
                polygon.Latitude = _position.Latitude;
                polygon.Longitude = _position.Longitude;
                polygonViewModel.AddPolygon(polygon);
                listPolygon.ItemsSource = null;
                listPolygon.ItemsSource = polygonViewModel.Polygons;
            }
        }

        // it's event When User Tap On List To Draw The Selected Polygon  
        private void DrawPolygonById(object sender, ItemTappedEventArgs e)
        {
            listPolygon.SelectedItem = null;
            Models.Polygon polygon = e.Item as Models.Polygon;
            Polygons = JsonConvert.DeserializeObject<FeatureCollection>(polygon.Coordinates);
            DrawPolygon();
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(polygon.Latitude, polygon.Longitude),
                Label = " Cliked ",
                Address = polygon.Latitude + " X " + polygon.Longitude,
            };
            pin.Position = new Position(polygon.Latitude, polygon.Longitude);
            map.Pins.Add(pin);
            tappedPage.CurrentPage = MapContent;
        }

        // it's event Search Polygon By it Name in The List
        private void SearchByName(object sender, TextChangedEventArgs e)
        {
            polygonViewModel.SearchByName(e.NewTextValue);
            listPolygon.ItemsSource = null;
            listPolygon.ItemsSource = polygonViewModel.Polygons;
        }

        //it's Function for Draw The Polygon By Polygons (it type is FeatureCollection) That Contains Ploygon Coordinates 
        private void DrawPolygon()
        {
            for (int i = 0; i < Polygons.Features.Count; i++)
            {
                var coord = ((GeoJSON.Net.Geometry.Polygon)Polygons.Features[i].Geometry).Coordinates;

                var positions = new List<Position>();
                Xamarin.Forms.Maps.Polygon polygon = new Xamarin.Forms.Maps.Polygon
                {
                    StrokeColor = Color.FromHex("#1BA1E2"),
                    StrokeWidth = 8,
                    FillColor = Color.FromHex("#881BA1E2")
                };
                for (int j = 0; j < coord[0].Coordinates.Count; j++)
                {
                    var _lat = coord[0].Coordinates[j].Latitude;
                    var _long = coord[0].Coordinates[j].Longitude;
                    positions.Add(new Position(_lat, _long));
                    polygon.Geopath.Add(new Position(_lat, _long));
                }
                map.MapElements.Add(polygon);
            }
        }
    }
}
