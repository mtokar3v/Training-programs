using Martian_Robots.DataItems;

namespace Martian_Robots.Commands
{
    public abstract class Command
    {
        protected Robot _robot;
        protected Grid _grid;
        protected Stack<(int x, int y, Orientation Orientation)> _coordsHistory;
        public Command(Robot robot, Grid grid)
        {
            _robot = robot;
            _grid = grid;
            _coordsHistory = CoordsHistory.GetInstance();
        }
        public abstract bool TryExecute();
    }
}
