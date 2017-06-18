using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace FindDistance
{
    public class Service1 : IService1
    {
        // Author: Harith Neralla
        // ASU CSE 445 Summer 2017
        // 06/17/2017

        // This RESTful service obtains the distance and duration between two points. Valid parameters are ZIP codes and addresses
        // External services used are from the Google Maps API.
        // External services invoked: Geocode (returns the place id of the location) and Distance Matrix (returns distance and travel duration).
        // This web service parses JSON responses from the API services using the JSON.NET library

        public string[] findDistance(string origin, string dest)
        {
            List<string> dataList = new List<string>();
            PlaceIdObject originID = new PlaceIdObject(); // Place ID object to read in the JSON response for the origin place id request
            PlaceIdObject destID = new PlaceIdObject(); // Place ID object to read in the JSON response for the dest place id request
            DistanceObject distObj = new DistanceObject(); // Distance Object to read in the JSON response for distance and duration
            string distance = "";
            string duration = "";
            string placeIDURL = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            string distURL = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=place_id:";
            string originIdUrl = ""; // + 1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=YOUR_API_KEY"; // Obtains the google place id for the origin
            string originPlaceID = "";
            string originStreetAddress = "";
            string originCity;
            string destIdUrl = ""; // Obtains the google place id for the destination
            string destPlaceID = "";
            string destStreetAddress = "";
            string destCity;
            string idAPIKEY = "&key=AIzaSyA2pSrM0f1F5aREkfKmn2uGUXJmTFebSRo"; // API Key to access the google maps API to obtain the place id
            string distAPIKEY = "&key=AIzaSyDXBnL0YvQp-nK89frD5Kv_X4nuVqcgEKs";

            // Parses the origin parameter and extracts the zipcode/address elements
            var originArr = origin.Split(':'); // Splits the origin using ':'
            if (originArr[0] == "ZIP")
            {
                origin = originArr[1];
            }
            else if (originArr[0] == "ADD")
            {
                var streetAdd = originArr[1].Split(' ');
                foreach (string element in streetAdd)
                {
                    originStreetAddress += element + "+"; // Builds the element to be used in the URL
                }

                originStreetAddress = originStreetAddress.TrimEnd('+'); // Removes the extra '+' from the end of the string
                originCity = originArr[2];
                origin = originStreetAddress + ",+" + originCity;
            }

            // Parses the destination parameter and extracts the zipcode/address elements
            var destArr = dest.Split(':'); // Splits the origin using ':'
            if (destArr[0] == "ZIP")
            {
                dest = destArr[1]; // sets the destination to the zip code
            }
            else if (destArr[0] == "ADD")
            {
                var streetAdd = destArr[1].Split(' '); // splits the address by spaces
                destCity = destArr[2]; // sets the destination city

                foreach (string element in streetAdd)
                {
                    destStreetAddress += element + "+"; // Builds the element to be used in the URL
                }

                destStreetAddress = destStreetAddress.TrimEnd('+'); // Removes the extra '+' from the end of the string

                dest = destStreetAddress + ",+" + destCity; // builds the destination element for the url
            }

            originIdUrl = placeIDURL + origin + idAPIKEY; // URL to get the place ID of the origin
            destIdUrl = placeIDURL + dest + idAPIKEY; // URL to get the place ID of the destination

            // Obtains the place id's for the origin and destination
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(originIdUrl); // loads the JSON string from the url
                originID = JsonConvert.DeserializeObject<PlaceIdObject>(json); // loads the JSON string into the PlaceIdObject

                if (originID.status == "OK") // makes sures that the request went through
                {
                    originPlaceID = originID.results[0].place_id; // sets to variable to the placeId
                }

                json = webClient.DownloadString(destIdUrl);  // loads the JSON string from the url
                destID = JsonConvert.DeserializeObject<PlaceIdObject>(json); // loads the JSON string into the PlaceIdObject

                if (destID.status == "OK") // makes sures that the request went through
                {
                    destPlaceID = destID.results[0].place_id; // sets to variable to the placeId
                }
            }

            distURL += originPlaceID + "&destinations=place_id:" + destPlaceID + distAPIKEY; // builds the URL to get the distance and duration from
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(distURL); // loads the JSON string from the url
                distObj = JsonConvert.DeserializeObject<DistanceObject>(json); // loads the JSON string into the DistanceObject

                if (distObj.status == "OK") // Makes sure that the request was valid
                {
                    if (distObj.rows[0].elements[0].status == "OK") // makes sure the distance and duration were found
                    {
                        distance = distObj.rows[0].elements[0].distance.text;
                        duration = distObj.rows[0].elements[0].duration.text;

                        dataList.Add("OK"); // lets the client know that there are no errors
                        dataList.Add("Distance: " + distance);
                        dataList.Add("Travel Duration: " + duration);
                    }
                    else
                    {
                        dataList.Add("Invalid origin and destination. One of both of the parameters are invalid.");
                    }
                }
                else
                {
                    dataList.Add("Invalid Request.");
                }
            }

            return dataList.ToArray();
        }

        // The code below provides class definitions for the JSON documents to be loaded into

        // Class definitions for the first service invocation (for the place id)
        public class PlaceIdObject
        {
            public Result[] results { get; set; }
            public string status { get; set; }
            public class Result
            {
                public string place_id { get; set; }
            }
        }

        // Class definitions for the second service invocation (for the distance and duration)
        public class DistanceObject
        {
            public Row[] rows { get; set; }
            public string status { get; set; }

            public class Row
            {
                public Element[] elements { get; set; }

                public class Element
                {
                    public Distance distance { get; set; }
                    public Duration duration { get; set; }
                    public string status { get; set; }
                    public class Distance
                    {
                        public string text { get; set; }
                    }

                    public class Duration
                    {
                        public string text { get; set; }
                    }
                }
            }
        }
    }

}
