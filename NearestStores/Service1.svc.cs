using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

namespace NearestStores
{
    public class Service1 : IService1
    {
        public string findNearestStore(string zipcode, string storeName)
        {
            List<string> list = new List<string>();
            string url = "http://maps.googleapis.com/maps/api/geocode/json?components=postal_code:" + zipcode + "&sensor=false";
            LatLonRootObject latLonobj = new LatLonRootObject(); // Create object to deserialize JSON doc into
            StoreObject storeobj = new StoreObject();
            string location;
            string finalData = "";

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url); // Retrieves JSON Document

                latLonobj = JsonConvert.DeserializeObject<LatLonRootObject>(json); // Deserializes the JSON document

                if (latLonobj.status == "OK")
                {
                    location = latLonobj.results[0].geometry.bounds.northeast.lat.ToString() + ","
                                + latLonobj.results[0].geometry.bounds.northeast.lng.ToString();

                    url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location="
                        + location + "&radius=30000&keyword=" + storeName + "&key=AIzaSyBbMR7vT32QLg4Vc6isTSflZq9Lh3l_mjM";

                    json = webClient.DownloadString(url);

                    storeobj = JsonConvert.DeserializeObject<StoreObject>(json);
                    if (storeobj.status == "OK")
                    {
                        list.Add(storeobj.results[0].icon); // URL for the icon 
                        list.Add(storeobj.results[0].name); // Adds the store name
                        list.Add(storeobj.results[0].rating.ToString()); // Adds the store rating
                        list.Add(storeobj.results[0].vicinity); // Adds the street address 
                    }   
                }
                list.Add("Not a valid location");
            }

            foreach (string str in list)
            {
                finalData += str + "|";
            }

            finalData = finalData.TrimEnd( '|' );
            return finalData;
        }
    }


    public class LatLonRootObject
    {
        public Result[] results { get; set; }
        public string status { get; set; }

        public class Result
        {
            public Geometry geometry { get; set; }
            public class Geometry
            {
                public Bounds bounds { get; set; }
                public class Bounds
                {
                    public Northeast northeast { get; set; }
                    public class Northeast
                    {
                        public float lat { get; set; }
                        public float lng { get; set; }
                    }
                }
            }
        }
    }


    public class StoreObject
    {
        public object[] html_attributions { get; set; }
        public string next_page_token { get; set; }
        public Result[] results { get; set; }
        public string status { get; set; }
    }

    public class Result
    {
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public Opening_Hours opening_hours { get; set; }
        public Photo[] photos { get; set; }
        public string place_id { get; set; }
        public float rating { get; set; }
        public string reference { get; set; }
        public string scope { get; set; }
        public string[] types { get; set; }
        public string vicinity { get; set; }
        public int price_level { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
        public Viewport viewport { get; set; }
    }

    public class Location
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Northeast
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Southwest
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Opening_Hours
    {
        public bool open_now { get; set; }
        public object[] weekday_text { get; set; }
    }

    public class Photo
    {
        public int height { get; set; }
        public string[] html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }

}
