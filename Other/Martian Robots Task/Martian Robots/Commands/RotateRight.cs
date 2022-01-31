namespace Martian_Robots.Commands
{
    public class RotateRight: Command
    {
        public RotateRight(Robot robot, Grid grid) : base(robot, grid) { }

        public override bool TryExecute()
        {
            if (!_grid.CanDetect(_robot.XCoord, _robot.YCoord)) return false;
            _robot.RotateRight();
            _coordsHistory.Push((_robot.XCoord, _robot.YCoord, _robot.RobotOrientation));
            return true;
        }
    }
}
