namespace AoC.Day3
{
  using System.IO;
  using System.Linq;

  public class Day3
  {
    public void Solve(string filePath)
    {
      string[] lines = File.ReadAllLines(filePath);

      long p1 = 0;
      long p2 = 0;

      foreach(string line in lines)
      {
        p1 += PartOne(line);
        p2 += PartTwo(line);
      }

      Console.WriteLine($"Part One: {p1}");
      Console.WriteLine($"Part Two: {p2}");

    }

    long PartOne(string s)
    {
        var digits = s.Select(c => c - '0').ToList();
        long maxJolt = 0;
        for (int i = 0; i < digits.Count; i++)
        {
          for (int j = i + 1; j < digits.Count; j++)
          {
            long joltage = digits[i] * 10 + digits[j];
            if (joltage > maxJolt) maxJolt = joltage;
          }
        }
      
        return maxJolt;
    }

    long PartTwo(string s)
    {
      int target = 12;
      var digits = s.Select(c => c - '0').ToList();
      var chosen = new List<int>();

      int start = 0;
      int remaining = target;

      while (remaining > 0)
      {
        int end = digits.Count - remaining;

        int best = -1;
        int index = start;

        for (int i = start; i <= end; i++)
        {
          if (digits[i] > best)
          {
            best = digits[i];
            index = i;
          }
        }

        chosen.Add(best);
        start = index + 1;
        remaining--;
      }

      long maxJolt = 0;
      foreach(int d in chosen)
      {
        maxJolt = maxJolt * 10 + d;
      }

      return maxJolt;
    }
  }
}
