using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover()
        {
            Position = 0;
            Mode = "Normal";
            GeneratorWatts = 110;
        }
        public Rover(int position)
        {
            Position = position;
            Mode = "Normal";
            GeneratorWatts = 110;
        }
        public Rover(int position, string mode)
        {
            Position = position;
            Mode = mode;
            GeneratorWatts = 110;
        }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

        public void ReceiveMessage(Message message)
        {
            Command command1 = new Command();

            Command[] commands = message.Commands;
              for (int i = 0; i < commands.Length; i++)
            {
                command1 = commands[i];

                if (command1.CommandType == "MODE_CHANGE")
                {
                    Mode = command1.NewMode; 
                }
                if (command1.CommandType == "MOVE" && Mode == "Normal")
                {
                   Position = command1.NewPosition;
                }
                if (command1.CommandType == "MOVE" && Mode == "LOW_POWER")
                {
                    Position = Position;
                }

            }



        }

    }
}
