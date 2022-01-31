using Martian_Robots.Commands;
using Martian_Robots.DataItems;

namespace Martian_Robots
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var value = new StartingValue();
            value.GridSizeLine = Console.ReadLine();
            var flag = value.GridSizeLine != "";
            while(flag)
            {
                var positionLine = Console.ReadLine();
                if (positionLine == "")
                {
                    flag = false;
                    break;
                }

                var commandsLine = Console.ReadLine();
                if (commandsLine == "")
                {
                    flag = false;
                    break;
                }

                value.PositionAndCommandsList.Add(new PositionAndCommands
                {
                    positionLine = positionLine,
                    commandsLine = commandsLine
                });
            };

            RunMartianRobotsTask(value);
        }

        public static void RunMartianRobotsTask(StartingValue startingValue)
        {
            var runningStatus = true;
            var gridSize = startingValue.GridSizeLine.Split(' ').ToList();
            var grid = new Grid(int.Parse(gridSize[0]), int.Parse(gridSize[1]));

            foreach(var someValue in startingValue.PositionAndCommandsList)
            {
                var robotCoords = someValue.positionLine.Split(' ').ToList();
                var robot = new Robot(int.Parse(robotCoords[0]), int.Parse(robotCoords[1]), robotCoords[2]);

                var commandsLine = someValue.commandsLine;
                var commandFactory = new CommandFactory(robot, grid);

                foreach (var command in commandsLine)
                {
                    var commandAction = commandFactory.GetCommand(command.ToString());
                    var success = commandAction.TryExecute();

                    if (!success) break;
                }

                var coordsHistory = CoordsHistory.GetInstance();
                var lastCoords = coordsHistory.Peek();
                var isLost = coordsHistory.Count() < commandsLine.Length ? "LOST" : "";

                Console.WriteLine($"{lastCoords.x} {lastCoords.y} {lastCoords.Orientation.ToString()[0]} {isLost}");
                CoordsHistory.DeleteInstance();
            }
        }
    }
}