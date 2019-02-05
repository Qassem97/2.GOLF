using System;
using System.Collections.Generic;
using System.Text;

namespace _2.GOLF
{
    class Swing
    {
        public double Angle;
        public double Velocity;
        public double Distance;

        public Swing(double angle, double velocity, double distance)
        {
            this.Angle = angle;
            this.Velocity = velocity;
            this.Distance = distance;
        }
    }
}