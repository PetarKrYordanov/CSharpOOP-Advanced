namespace P06.TrafficLights.Models
{
    using System;
    using Contracts;
    public class TrafficLight : ITrafficLights
    {
        private Color color;

        public TrafficLight(string color)
        {
            this.color = Enum.Parse<Color>(color, true);
        }

        public void ChangeLights()
        {
            this.color += 1;

            if ((int)this.color > 2)
            {
                this.color = 0;
            }
        }

        public override string ToString()
        {
            return this.color.ToString();
        }
    }
}
