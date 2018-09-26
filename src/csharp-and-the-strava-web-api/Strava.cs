using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace csharp_and_the_strava_web_api
{
    class Strava
    {
        private readonly string _accessToken;

        public Strava(string accessToken)
        {
            _accessToken = accessToken;
        }

        private async Task<T> GetStravaData<T>(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                using (WebResponse response = await request.GetResponseAsync())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            string result = await reader.ReadToEndAsync();
                            return JsonConvert.DeserializeObject<T>(result);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                using (WebResponse errorResponse = ex.Response)
                {
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")))
                        {
                            string errorText = reader.ReadToEnd();
                        }
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Activity>> GetStravaRides()
        {
            try
            {
                string url = string.Format("https://www.strava.com/api/v3/athlete/activities?access_token={0}&per_page=200", _accessToken);
                return await this.GetStravaData<IEnumerable<Activity>>(url);
            }
            catch (Exception ex)
            {
                return new List<Activity>();
            }
        }

        public async Task<Athlete> GetAthlete()
        {
            string url = string.Format("https://www.strava.com/api/v3/athlete?access_token={0}&per_page=200", _accessToken);
            return await this.GetStravaData<Athlete>(url);
        }
    }
}
