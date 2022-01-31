namespace Martian_Robots
{
    public class Robot
    { 
        public int XCoord { get; private set; }
        public int YCoord { get; private set; }
        public Orientation RobotOrientation { get; private set; }
        public Robot(int x, int y, Orientation orientation)
        {
            XCoord = x;
            YCoord = y;
            RobotOrientation = orientation;
        }

        public Robot(int x, int y, string orientation)
        {
            XCoord = x;
            YCoord = y;
            RobotOrientation = orientation switch
            {
                "N" => Orientation.North,
                "W" => Orientation.West,
                "S" => Orientation.South,
                "E" => Orientation.East,
                _ => throw new Exception("Unknown orientation input")
            };
        }
        public void RotateLeft()
        {
            RobotOrientation = RobotOrientation switch
            {
                Orientation.North => Orientation.West,
                Orientation.West =>  Orientation.South,
                Orientation.South => Orientation.East,
                Orientation.East =>  Orientation.North,
                _ => throw new Exception("Unknown orientation input")
            };
        }
        public void RotateRight()
        {
            RobotOrientation = RobotOrientation switch
            {
                Orientation.North => Orientation.East,
                Orientation.East =>  Orientation.South,
                Orientation.South => Orientation.West,
                Orientation.West =>  Orientation.North,
                _ => throw new Exception("Unknown orientation input")
            };
        }
        public void MoveForward()
        {
            switch (RobotOrientation)
            {
                case Orientation.North: YCoord++ ; break;
                case Orientation.West:  XCoord--; break;
                case Orientation.South: YCoord--; break;
                case Orientation.East:  XCoord++; break;
                default: throw new Exception("Unknown robot orientation");
            }
        }
    }
}
