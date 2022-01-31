namespace Martian_Robots.Commands
{
    public class RotateLeft : Command
    {
        public RotateLeft(Robot robot, Grid grid) : base(robot, grid) { }

        public override bool TryExecute()
        {
            if (!_grid.CanDetect(_robot.XCoord, _robot.YCoord)) return false;
            _robot.RotateLeft();
            _coordsHistory.Push((_robot.XCoord, _robot.YCoord, _robot.RobotOrientation));
            return true;
        }
    }
}
