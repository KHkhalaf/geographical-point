using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace geographical_point.Models
{
    class Geojson
    {
        public string ReadGeoJson(Pin pin)
        {
            var client = new RestClient("https://spacenus-api.azurewebsites.net/boundary_detections.json");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("apikey", "30wLjRr5CG1nNCz");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("accuracy", "3");
            request.AddParameter("latitude", pin.Position.Latitude);
            request.AddParameter("longitude", pin.Position.Longitude);
            request.AddParameter("fallback_boundary", "false");
            IRestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}
