using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace csharp_and_the_strava_web_api
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Strava strava = new Strava("youraccesstoken");
            IEnumerable<Activity> rides = await strava.GetStravaRides();

            foreach (Activity ride in rides)
            {
                Console.WriteLine($"On {ride.Date} you rode {ride.Distance} km with an average of {ride.AverageSpeed} km/h and max {ride.MaxSpeed} km/h.");
            }

            Console.ReadLine();
        }
    }
}
