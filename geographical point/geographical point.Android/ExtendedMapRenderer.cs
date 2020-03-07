using Android.Gms.Maps;
using geographical_point;
using geographical_point.Droid;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedMap), typeof(ExtendedMapRenderer))]
namespace geographical_point.Droid
{
    public class ExtendedMapRenderer : MapRenderer, IOnMapReadyCallback
    {
        private GoogleMap _map;
        private bool checkNotNull = false;

        public ExtendedMapRenderer()
        {
        }

        protected override void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;

            _map.UiSettings.ZoomControlsEnabled = true;
            _map.UiSettings.MyLocationButtonEnabled = true;

            if (_map != null)
                _map.MapClick += googleMap_MapClick;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            if (_map != null)
                _map.MapClick -= googleMap_MapClick;

            base.OnElementChanged(e);

            if (Control != null)
                ((MapView)Control).GetMapAsync(this);

        }

        private void googleMap_MapClick(object sender, GoogleMap.MapClickEventArgs e)
        {
            ((ExtendedMap)Element).OnTap(new Position(e.Point.Latitude, e.Point.Longitude));
        }
    }
}