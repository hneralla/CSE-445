using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherConditions
{
    public class Service1 : IService1
    {
        public string[] getLocationDetails(string zipcode)
        {
            List<string> details = new List<string>();
            string url = "http://api.wunderground.com/api/a88ec4d422339198/geolookup/q/" + zipcode + ".json";

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url);
                ZIPRootObj obj = new ZIPRootObj();
                obj = JsonConvert.DeserializeObject<ZIPRootObj>(json);

                if (obj.response.error == null)
                {
                    details.Add("City: " + obj.location.city + ", " + obj.location.state);

                    string cities = "Nearby Cities: ";
                    foreach (Station station in obj.location.nearby_weather_stations.airport.station)
                    {
                        cities += station.city + ", ";
                    }
                    cities = cities.TrimEnd(' ').TrimEnd(',');
                    details.Add(cities);

                    url = "http://api.wunderground.com/api/a88ec4d422339198/conditions/q/" + obj.location.state + "/" + obj.location.city + ".json";
                    json = webClient.DownloadString(url);
                    WeatherRootObj obj1 = new WeatherRootObj();
                    obj1 = JsonConvert.DeserializeObject<WeatherRootObj>(json);
                    details.Add("Elevation: " + obj1.current_observation.observation_location.elevation);
                    details.Add("Current Temperature: " + obj1.current_observation.temperature_string);
                    details.Add("Feels Like: " + obj1.current_observation.feelslike_string);
                    details.Add("Relative Humidity: " + obj1.current_observation.relative_humidity);

                    string wind = "Wind " + obj1.current_observation.wind_string + " ";// + obj1.current_observation.wind_mph.ToString() + "mph " + obj1.current_observation.wind_dir;
                    details.Add(wind);
                    details.Add(obj1.current_observation.forecast_url);
                }
                else
                {
                    details.Add(obj.response.error.description);
                }
            }

            return details.ToArray(); ;
        }

        public class WeatherRootObj
        {
            public Current_Observation current_observation { get; set; }
        }

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


        //BREAK

        public class Error
        {
            public string description { get; set; }
        }

        public class ZIPRootObj
        {
            public Response response { get; set; }
            public Location location { get; set; }
        }

        public class Response
        {
            public Error error { get; set; }
        }

        public class Location
        {
            public string type { get; set; }
            public string state { get; set; }
            public string city { get; set; }
            public Nearby_Weather_Stations nearby_weather_stations { get; set; }
        }

        public class Nearby_Weather_Stations
        {
            public Airport airport { get; set; }
        }

        public class Airport
        {
            public Station[] station { get; set; }
        }

        public class Station
        {
            public string city { get; set; }
        }

    }

}
