namespace AoC.Day1
{
  using System.IO;

  public class Day1
  {
    static int position = 50;
    static int countZeroP1 = 0;
    static int countZeroP2 = 0;
    
    public void Solve(string filePath)
    {
      string[] lines = File.ReadAllLines(filePath);

      foreach(string line in lines)
      {
        if (string.IsNullOrEmpty(line)) continue;
        string direction = line.Substring(0, 1);
        int value = int.Parse(line.Substring(1));

        if (direction == "L")
        {
          position = (position - value) % 100;
        }
        else
        {
          position = (position + value) % 100;
        }

        if (position == 0)
        {
          countZeroP1 += 1;
        }
      }

      Console.WriteLine($"Part One: {countZeroP1}");

      position = 50;
      foreach(string line in lines)
      {
        if (string.IsNullOrEmpty(line)) continue;

        string direction = line.Substring(0, 1);
        int value = int.Parse(line.Substring(1));

        int step = (direction == "L") ? -1 : 1;

        for (int i = 0; i < value; i++)
        {
          position += step;

          while (position < 0)
          {
            position += 100;
          }
          while (position >= 100)
          {
            position -= 100;
          }

          if (position == 0)
          {
            countZeroP2++;
          }
        }
      }

      Console.WriteLine($"Part Two: {countZeroP2}");
    }
  }
}
