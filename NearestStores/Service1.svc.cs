using System.Collections.Generic;
using Newtonsoft.Json;

namespace NearestStores
{
    public class Service1 : IService1
    {
        // Author: Harith Neralla
        // ASU CSE 445 Summer 2017
        // 06/10/2017

        // Service obtains the nearest store using a ZIP code and a storeName keyword as the parameters.
        // Google Places API is used to get data. 
        // This web service parses JSON responses from the API services using the JSON.NET library

        public string findNearestStore(string zipcode, string storeName)
        {
            List<string> list = new List<string>();
            string url = "http://maps.googleapis.com/maps/api/geocode/json?components=postal_code:" + zipcode + "&sensor=false"; // invokes service to obtain lat and long of given zipcode
            LatLonRootObject latLonobj = new LatLonRootObject(); // Creates object to deserialize JSON doc into
            StoreObject storeobj = new StoreObject(); // Creates object to deserialize JSON doc into
            string location; // string to store the lattitude and longitude
            string finalData = "";

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url); // Retrieves JSON Document

                latLonobj = JsonConvert.DeserializeObject<LatLonRootObject>(json); // Deserializes the JSON document

                if (latLonobj.status == "OK") // makes sure that the zipcode is valid
                {
                    location = latLonobj.results[0].geometry.bounds.northeast.lat.ToString() + ","
                                + latLonobj.results[0].geometry.bounds.northeast.lng.ToString();

                    // Builds url to invoke the Google Places API nearbysearch(...)
                    url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location="
                        + location + "&radius=30000&keyword=" + storeName + "&key=AIzaSyBbMR7vT32QLg4Vc6isTSflZq9Lh3l_mjM";

                    json = webClient.DownloadString(url);

                    storeobj = JsonConvert.DeserializeObject<StoreObject>(json); // Deserializes the JSON document

                    if (storeobj.status == "OK") // Makes sure that the store name is valid
                    {
                        list.Add(storeobj.results[0].icon); // URL for the icon 
                        list.Add(storeobj.results[0].name); // Adds the store name
                        list.Add(storeobj.results[0].rating.ToString()); // Adds the store rating
                        list.Add(storeobj.results[0].vicinity); // Adds the street address 
                    }
                    else
                    {
                        list.Add(storeName + " does not exist in the area."); // store name is does not exist in the area
                    }   
                }else
                    list.Add("Not a valid location"); // zip code was not valid
            }

            // Builds a string with all the data in
            foreach (string str in list)
            {
                finalData += str + "|"; // Adds a '|' between each data element
            }

            finalData = finalData.TrimEnd( '|' ); // Removes an extra '|' from the end of the string
            return finalData;
        }
    }

    // The code below provides class definitions for the JSON documents to be loaded into

    // Class definitions for the first service invocation (for the latitude and longitude)
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

    // Class definitions for the second service invocation (for store details)
    public class StoreObject
    {
        public Result[] results { get; set; }
        public string status { get; set; }

        public class Result
        {
            public string icon { get; set; }
            public string name { get; set; }
            public float rating { get; set; }
            public string vicinity { get; set; }
        }
    }
}
