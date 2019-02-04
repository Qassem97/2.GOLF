using System;
using System.Collections.Generic;

namespace Golf2
{
    class Program
    {
        static double swing = 0;
        static double maxSwings = 4;
        static double ballLocation = 0;
        static double goalLocation = 640;
        static double distanceBetween = 0;
        static double angle = 0;
        static double velocity = 0;
        static void Main(string[] args)
        {
            bool stayAlive = true;
            SwingLoop(stayAlive);

        }
        static void SwingLoop(bool stayAlive)
        {
            Console.WriteLine("  Welcome to your game GOLF\n\nPress any key to get started");
            Console.ReadKey(true);
            while (stayAlive)
            {
                try
                {

                    Console.WriteLine("Enter an angel :");
                    angle = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter velocity :");
                    velocity = Convert.ToDouble(Console.ReadLine());
                    var Distance = CalculateDistance(angle, velocity);// var ersätter tydigare typen (double)
                    setNewLocation(Distance);
                    Console.WriteLine(Distance);
                    swing = swing + 1; // reduce your try(swings)

                    distanceBetween = Math.Abs(goalLocation - ballLocation);

                    Console.WriteLine("ballLocation:" + ballLocation);
                    Console.WriteLine(distanceBetween + " between the cup and the ball");
                    Console.WriteLine(maxSwings - swing + " swings left");
                    if (ballLocation == goalLocation)
                    {
                        Console.WriteLine(" You win \nPress any key to close the game"); // ballLocation = 0
                        Console.ReadKey();
                        System.Environment.Exit(0);
                    }
                    else if (ballLocation >= goalLocation)//the is after the goal > 640
                    {
                        Console.WriteLine("You'r atfer the line of the cup, Game Over, try later\n Press any key to end");//max 640, more = lose
                        Console.ReadKey(true);
                        System.Environment.Exit(0);
                    }
                    else if (swing > maxSwings)
                    {
                        Console.WriteLine(" You lose! bad luck, no more swings left\nPress any key to close "); // 0 swings  game over
                        Console.ReadKey(true);
                        System.Environment.Exit(0);
                    }

                }
                catch
                {

                }

            }
        }
        static double CalculateDistance(double angle, double velocity)
        {
            double GRAVITY = 9.8;

            return Math.Pow(velocity, 2) / GRAVITY * Math.Sin(2 * ((Math.PI / 180) * angle));

        }

        static void setNewLocation(double distance)
        {
            ballLocation = ballLocation + distance;

        }
    }
}