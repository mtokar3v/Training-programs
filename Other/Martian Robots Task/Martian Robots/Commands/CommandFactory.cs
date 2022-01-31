namespace Martian_Robots.Commands
{
    public class CommandFactory
    {
        private Dictionary<string, Command> _commands;
        private Robot _robot;
        private Grid _grid;

        public CommandFactory(Robot robot, Grid grid)
        {
            _robot = robot;
            _grid = grid;
            _commands = new Dictionary<string, Command>();
        }

        public Command GetCommand(string command)
        {
            if(!_commands.ContainsKey(command))
            {
                Command commandAction = command switch
                {
                    "F" => new MoveForward(_robot, _grid),
                    "R" => new RotateRight(_robot, _grid),
                    "L" => new RotateLeft(_robot, _grid),
                    _ => throw new Exception("Unknown creating command")
                };

                _commands.Add(command, commandAction);
            }

            return _commands[command];
        }
    }
}
