using Martian_Robots;
using Martian_Robots.DataItems;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Martian_Robots_Tests
{
    public class InputTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void TestInput(StartingValue startingValue)
        {
            //arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            Program.RunMartianRobotsTask(startingValue);

            //assert
            var output = stringWriter.ToString()
                .Replace("\r", "")
                .Replace("\n","")
                .Replace(" ", "");
            Assert.Equal(@"11E33NLOST23S", output);
        }

        public static IEnumerable<object[]> Data()
        {

            var test1PAndC = new List<PositionAndCommands>();
            test1PAndC.Add(new PositionAndCommands
            {
                positionLine = "1 1 E",
                commandsLine = "RFRFRFRF"
            });
            test1PAndC.Add(new PositionAndCommands
            {
                positionLine = "3 2 N",
                commandsLine = "FRRFLLFFRRFLL"
            });
            test1PAndC.Add(new PositionAndCommands
            {
                positionLine = "0 3 W",
                commandsLine = "LLFFFLFLFL"
            });
            var test1 = new StartingValue
            {
                GridSizeLine = "5 3",
                PositionAndCommandsList = test1PAndC
            };

            yield return new object[] { test1 };
        }
    }
}