namespace Martian_Robots.DataItems
{
    public class CoordsHistory
    {
        private static Stack<(int x, int y, Orientation Orientation)>? coordsHistory;
        private CoordsHistory() { }

        public static Stack<(int x, int y, Orientation Orientation)> GetInstance()
        {
            if (coordsHistory == null)
                coordsHistory = new Stack<(int x, int y, Orientation Orientation)>();
            return coordsHistory;
        }

        public static void DeleteInstance() => coordsHistory = null;
    }
}
