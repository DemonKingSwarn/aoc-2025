using System.IO;
using AoC.Day1;
using AoC.Day2PartOne;
using AoC.Day2PartTwo;
using AoC.Day3;

using DemonKingSwarn.utils.fzf.Options;
using DemonKingSwarn.utils.fzf.process;

public class Program
{
  static List<string> days;

  static void Main(String[] args)
  {
    Day1 day1 = new Day1();
    Day2PartOne day2Part1 = new Day2PartOne();
    Day2PartTwo day2Part2 = new Day2PartTwo();
    Day3 day3 = new Day3();
    
    days = new List<string>
    {
      "Day 1",
      "Day 2 Part 1",
      "Day 2 Part 2",
      "Day 3",
    };

    var opts = FzfOptions.GetOpts(
      promptString: "Select a day: ",
      borderStyle: BorderStyle.Rounded,
      header: "Choose The Solution to run from a specific day",
      height: "40%",
      infoStyle: InfoStyle.Inline,
      ansi: true
    );

    using var fzf = new Fzf("fzf", opts);
    fzf.AddLines(days, flushLast: true);

    var output = fzf.GetOutput();

    if (string.IsNullOrEmpty(output)) return;

    string inputFile = "";
    if (args != null && args.Length > 0)
    {
      inputFile = args[0];
    }
    else
    {
      var inputFiles = Directory.GetFiles("inputs");
      var inputOpts = FzfOptions.GetOpts(
        promptString: "Select input: ",
        borderStyle: BorderStyle.Rounded,
        header: "Choose the input file",
        height: "40%",
        infoStyle: InfoStyle.Inline,
        ansi: true
      );

      using var inputFzf = new Fzf("fzf", inputOpts);
      inputFzf.AddLines(inputFiles, flushLast: true);
      inputFile = inputFzf.GetOutput();
    }

    if (string.IsNullOrEmpty(inputFile)) return;

    switch(output)
    {
      case "Day 1":
        day1.Solve(inputFile);
        break;
      case "Day 2 Part 1":
        day2Part1.Solve(inputFile);
        break;
      case "Day 2 Part 2":
        day2Part2.Solve(inputFile);
        break;
      case "Day 3":
        day3.Solve(inputFile);
        break;
    }
  }
}
