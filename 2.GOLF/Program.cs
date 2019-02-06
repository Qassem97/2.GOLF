using _2.GOLF;
using System;
using System.Collections.Generic;

namespace Golf2
{
    class Program
    {
        static double swing = 0;
        static double maxSwings = 5;
        static double ballLocation = 0;
        static double goalLocation = 640;
        static double distanceBetween = 0;
        //static double angle = 0;
        //static double velocity = 0;
        static List<Swing> swings = new List<Swing>();



        static void Main(string[] args)
        {

            Console.WriteLine("  Welcome to your game GOLF\n\nPress any key to get started");
            Console.ReadKey(true);

            do
            {
                double angle = AngleM();
                double velocity = VelocityM();
                double distance = CalculateDistance(angle, velocity);
                setNewLocation(distance);
                swing = swing + 1;
                distanceBetween = Math.Abs(goalLocation - ballLocation);
                Console.WriteLine("ballLocation:" + ballLocation);
                Console.WriteLine(distanceBetween + " between the cup and the ball");
                Console.WriteLine(maxSwings - swing + " swings left");

                Swing SW = new Swing(angle, velocity, distance);
                swings.Add(SW);

                if (ballLocation == goalLocation)
                {
                    Console.WriteLine(" You win \nPress any key to show your score and double press to close the game"); // ballLocation = 0
                    Console.ReadKey();
                    break;
                }
                else if (distanceBetween > goalLocation)//the is after the goal > 640
                {
                    Console.WriteLine("You'r atfer the line of the cup, Game Over, try later\nPress any key to show your score and double press to close the game");//max 640, more = lose
                    Console.ReadKey(true);
                    break;
                }
                else if (swing >= maxSwings)
                {
                    Console.WriteLine(" You lose! bad luck, no more swings left\nPress any key to show your score and double press to close the game "); // 0 swings  game over
                    Console.ReadKey(true);
                    break;
                }
            } while (true);
            Console.Clear();
            foreach (var swing in swings)
            {

                Console.WriteLine("The historic ");
                Console.WriteLine("The angle: " + swing.Angle);
                Console.WriteLine("The velocity: " + swing.Velocity);
                Console.WriteLine("The distance: " + swing.Distance);

            }
            Console.ReadKey(true);
        }
        static double CalculateDistance(double angle, double velocity)
        {
            double GRAVITY = 9.8;

            return Math.Round(Math.Pow(velocity, 2) / GRAVITY * Math.Sin(2 * ((Math.PI / 180) * angle)));

        }

        static void setNewLocation(double distance)
        {
            if (ballLocation > goalLocation)
                ballLocation = ballLocation - distance;
            else
                ballLocation = ballLocation + distance;
        }

        static double AngleM()
        {
            double angle = 0;
            Console.WriteLine("Angle should be between 0,1 and 89");
            while (angle < 0.1 || angle > 89) 
            {
                try
                {
                    Console.WriteLine("Enter an angel :");
                    angle = Convert.ToDouble(Console.ReadLine());                
                }
                catch
                {
                    Console.WriteLine("Invalid input! Only numbers are valid.\nPlease try again!");
                }
            }
            return angle;

        }
        static double VelocityM()
        {
            double velocity = 0;
            Console.WriteLine("Velocity should be between 0,1 and 110");

            while (velocity < 0.1 || velocity > 109)
            {
                try
                {
                    Console.WriteLine("Enter velocity :");
                    velocity = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                   Console.WriteLine("Invalid input! Only numbers are valid.\nPlease try again!");
                }
            }
            return velocity;
        }
    }
}