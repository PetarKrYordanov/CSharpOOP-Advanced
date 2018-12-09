namespace P06.TrafficLights.Core
{
    using System;
    using System.Collections.Generic;

    using P06.TrafficLights.Models;

    public class Engine
    {
        private List<TrafficLight> trafficLights;
        public Engine()
        {
            this.trafficLights = new List<TrafficLight>();
        }
        public void Run()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int countOfRolls = int.Parse(Console.ReadLine());

            foreach (var colorString in input)
            {
                trafficLights.Add(new TrafficLight(colorString));
            }

            for (int i = 0; i < countOfRolls; i++)
            {
                foreach (var item in trafficLights)
                {
                    item.ChangeLights();
                }

                Console.WriteLine(string.Join(' ', trafficLights));
            }
        }
    }
}
