namespace Martian_Robots.Commands
{
    public class MoveForward : Command
    {
        public MoveForward(Robot robot, Grid grid ) : base(robot, grid) { }

        override public bool TryExecute()
        {
            if (_grid.CanDetect(_robot.XCoord, _robot.YCoord))
            {
                if(!_grid.HasTrack(_robot.XCoord, _robot.YCoord))
                    _robot.MoveForward();

                if(!_grid.CanDetect(_robot.XCoord, _robot.YCoord))
                {
                    var oldCoords = _coordsHistory.Peek();
                    _grid.SetTrack(oldCoords.x, oldCoords.y);
                    return false;
                }

                _coordsHistory.Push((_robot.XCoord, _robot.YCoord, _robot.RobotOrientation));
                return true;
            }
            return false;
        }
    }
}
