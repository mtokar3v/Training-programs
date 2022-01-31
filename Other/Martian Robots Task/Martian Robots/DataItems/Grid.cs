namespace Martian_Robots
{
    public class Grid
    {
        private readonly int xSize;
        private readonly int ySize;
        public List<(int X, int Y, Orientation orientation)> Tracks { get; private set; }
        public Grid(int x, int y)
        { 
            xSize = x;
            ySize = y;
            Tracks = new List<(int X, int Y, Orientation orientation)>();
        }

        public bool CanDetect(int x, int y) => x >= 0 && x <= xSize && y >= 0 && y <= ySize;
        public bool HasTrack(int x, int y, Orientation orientation) => Tracks.Count(c => c.X == x && c.Y == y && c.orientation == orientation) != 0;
        public void SetTrack(int x, int y, Orientation orientation)
        {
            if(!HasTrack(x,y,orientation))
                Tracks.Add((x, y,orientation));
        }
    }
}
