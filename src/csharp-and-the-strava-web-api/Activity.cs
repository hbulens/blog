using System;
using Newtonsoft.Json;

namespace csharp_and_the_strava_web_api
{
    public class Activity
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("resource_state")]
        public int? ResourceState { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("upload_id")]
        public int? UploadId { get; set; }

        [JsonProperty("athlete")]
        public Athlete Athlete { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        private double? _distance;

        [JsonProperty("distance")]
        public double? Distance
        {
            get
            {
                return _distance / 1000;
            }
            set
            {
                _distance = value;
            }
        }

        private int? _movingTime = 0;

        [JsonProperty("moving_time")]
        public string MovingTime
        {
            get
            {
                if (_movingTime != null)
                {
                    TimeSpan ts = TimeSpan.FromSeconds((int)_movingTime);
                    return ts.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                _movingTime = int.Parse(value);
            }
        }

        [JsonProperty("elapsed_time")]
        public int? ElapsedTime { get; set; }

        [JsonProperty("total_elevation_gain")]
        public double? TotalElevationGain { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("start_date_local")]
        public string StartDateLocal { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("start_latlng")]
        public double?[] StartLatlng { get; set; }

        [JsonProperty("end_latlng")]
        public double?[] EndLatlng { get; set; }

        [JsonProperty("location_city")]
        public string LocationCity { get; set; }

        [JsonProperty("location_state")]
        public string LocationState { get; set; }

        [JsonProperty("location_country")]
        public string LocationCountry { get; set; }

        [JsonProperty("start_latitude")]
        public double? StartLatitude { get; set; }

        [JsonProperty("start_longitude")]
        public double? StartLongitude { get; set; }

        [JsonProperty("achievement_count")]
        public int? AchievementCount { get; set; }

        [JsonProperty("kudos_count")]
        public int? KudosCount { get; set; }

        [JsonProperty("comment_count")]
        public int? CommentCount { get; set; }

        [JsonProperty("athlete_count")]
        public int? AthleteCount { get; set; }

        [JsonProperty("photo_count")]
        public int? PhotoCount { get; set; }

        [JsonProperty("trainer")]
        public bool Trainer { get; set; }

        [JsonProperty("commute")]
        public bool Commute { get; set; }

        [JsonProperty("manual")]
        public bool Manual { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }

        [JsonProperty("flagged")]
        public bool Flagged { get; set; }

        [JsonProperty("gear_id")]
        public object GearId { get; set; }

        private double? _averageSpeed;
        [JsonProperty("average_speed")]
        public double AverageSpeed
        {
            get
            {
                return _averageSpeed != null ? (double)_averageSpeed * 3.6 : 0;
            }
            set
            {
                _averageSpeed = value;
            }
        }

        private double? _maxSpeed;

        [JsonProperty("max_speed")]
        public double? MaxSpeed
        {
            get
            {
                return _maxSpeed != null ? (double)_maxSpeed * 3.6 : 0;
            }
            set
            {
                _maxSpeed = value;
            }
        }

        [JsonProperty("average_watts")]
        public double? AverageWatts { get; set; }

        [JsonProperty("kilojoules")]
        public double? Kilojoules { get; set; }

        [JsonProperty("device_watts")]
        public bool DeviceWatts { get; set; }

        [JsonProperty("truncated")]
        public object Truncated { get; set; }

        [JsonProperty("has_kudoed")]
        public bool HasKudoed { get; set; }

        public DateTime Date
        {
            get
            {
                return DateTime.Parse(this.StartDate);
            }
        }
    }
}