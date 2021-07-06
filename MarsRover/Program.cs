using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Rover myRover = new Rover(20);
            //Console.WriteLine(myRover.ToString());

            Rover newRover = new Rover(9534);
            Command[] commands = { new Command("MOVE", 5000), new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 10000) };   
            Message newMessage = new Message("Test message with one command", commands);
                

            Console.WriteLine(newRover.ToString());

            newRover.ReceiveMessage(newMessage);
            Console.WriteLine(newRover.ToString());

        }
    }
}
