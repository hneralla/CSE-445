using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherConditions
{
    public class Service1 : IService1
    {
        // Author: Harith Neralla
        // ASU CSE 445 Summer 2017
        // 06/10/2017

        // Service obtains the weather conditions and location details using a ZIP code as parameter.
        // External services used are from the Weather Underground API. 
        // External services invoked: Geo-lookup (returns location details) and Current Conditions (returns weather details).
        // This web service parses JSON responses from the API services using the JSON.NET library

        public string[] getLocationDetails(string zipcode)
        {
            List<string> details = new List<string>(); // List of strings to return later
            ZIPRootObject obj = new ZIPRootObject(); // Creates object to deserialize JSON doc into
            WeatherRootObject obj1 = new WeatherRootObject(); // Creates object to deserialize JSON doc into
            string wind;
            string nearbyCities;
            string url = "http://api.wunderground.com/api/a88ec4d422339198/geolookup/q/" + zipcode + ".json"; // Builds the url to load from (includes developer API key)

            using (var webClient = new System.Net.WebClient()) 
            {
                var json = webClient.DownloadString(url); // Retrieves JSON Document
                
                obj = JsonConvert.DeserializeObject<ZIPRootObject>(json); // Deserializes the JSON document
                 
                if (obj.response.error == null) // Makes sure no error was returned 
                {
                    details.Add("City: " + obj.location.city + ", " + obj.location.state); // Adds "City, State" to the list

                    // Builds the nearby cities string
                    nearbyCities = "Nearby Cities: "; 
                    foreach (ZIPRootObject.Location.Nearby_Weather_Stations.Airport.Station station in obj.location.nearby_weather_stations.airport.station)
                    {
                        nearbyCities += station.city + ", ";
                    }
                    nearbyCities = nearbyCities.TrimEnd(' ').TrimEnd(','); // Removes the extra comma 
                    details.Add(nearbyCities); // Adds the cities to the list

                    //Rebuilds URL to retrieve the weather conditions
                    url = "http://api.wunderground.com/api/a88ec4d422339198/conditions/q/" + obj.location.state + "/" + obj.location.city + ".json";
                    json = webClient.DownloadString(url);
                   
                    obj1 = JsonConvert.DeserializeObject<WeatherRootObject>(json); // Deserializes the JSON document
                    wind = "Wind " + obj1.current_observation.wind_string + " "; // Builds the wind string
                    
                    // Adds various different details to the list
                    details.Add("Elevation: " + obj1.current_observation.observation_location.elevation);
                    details.Add("Current Temperature: " + obj1.current_observation.temperature_string);
                    details.Add("Feels Like: " + obj1.current_observation.feelslike_string);
                    details.Add("Relative Humidity: " + obj1.current_observation.relative_humidity);                     
                    details.Add(wind); 
                    details.Add(obj1.current_observation.forecast_url); // Adds URL for user to access more information
                }
                else
                {
                    details.Add(obj.response.error.description); // adds the error message into the list
                }
            }

            return details.ToArray(); 
        }


        // The code below provides class definitions for the JSON documents to be loaded into

        // Class definitions for the first service invocation (for the location details)
        public class ZIPRootObject
        {
            public Response response { get; set; }
            public Location location { get; set; }

            public class Response
            {
                public Error error { get; set; }

                public class Error
                {
                    public string description { get; set; }
                }
            }

            public class Location
            {
                public string type { get; set; }
                public string state { get; set; }
                public string city { get; set; }
                public Nearby_Weather_Stations nearby_weather_stations { get; set; }

                public class Nearby_Weather_Stations
                {
                    public Airport airport { get; set; }

                    public class Airport
                    {
                        public Station[] station { get; set; }

                        public class Station
                        {
                            public string city { get; set; }
                        }
                    }
                }
            }
        }


        // Class definitions for the second service invocation (for the weather details)
        public class WeatherRootObject
        {
            public Current_Observation current_observation { get; set; }
            public class Current_Observation
            {
                public Observation_Location observation_location { get; set; }
                public string temperature_string { get; set; }
                public string relative_humidity { get; set; }
                public string wind_string { get; set; }
                public string wind_dir { get; set; }
                public float wind_mph { get; set; }
                public string feelslike_string { get; set; }
                public string forecast_url { get; set; }
            }

            public class Observation_Location
            {
                public string elevation { get; set; }
            }
        }
    }

}
