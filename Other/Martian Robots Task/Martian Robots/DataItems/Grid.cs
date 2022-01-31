namespace Martian_Robots
{
    public class Grid
    {
        private readonly int xSize;
        private readonly int ySize;
        public List<(int X, int Y)> Tracks { get; private set; }
        public Grid(int x, int y)
        { 
            xSize = x;
            ySize = y;
            Tracks = new List<(int X, int Y)>();
        }

        public bool CanDetect(int x, int y) => x >= 0 && x <= xSize && y >= 0 && y <= ySize;
        public bool HasTrack(int x, int y) => Tracks.Count(c => c.X == x && c.Y == y) != 0;
        public void SetTrack(int x, int y)
        {
            if(!HasTrack(x,y))
                Tracks.Add((x, y));
        }
    }
}
