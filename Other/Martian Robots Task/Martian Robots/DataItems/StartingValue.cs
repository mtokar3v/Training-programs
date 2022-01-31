namespace Martian_Robots.DataItems
{
    public class PositionAndCommands
    {
        public string positionLine { get; set; }
        public string commandsLine { get; set; }
    }

    public class StartingValue
    {
        public string GridSizeLine { get; set; }
        public List<PositionAndCommands> PositionAndCommandsList { get; set; } = new List<PositionAndCommands>();
    }
}
