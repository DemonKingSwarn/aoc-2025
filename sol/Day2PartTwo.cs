namespace AoC.Day2PartTwo
{
  using System.IO;

  public class Day2
  {

    List<string> incorrectIds;
    List<string> invalids;

    public void Solve(string filePath)
    {
      string lines = File.ReadAllText(filePath);
      string[] ids = lines.Split(',');

      incorrectIds = new List<string>();
      invalids = new List<string>();

      long sum = 0;

      FindInvalidIds(ids);

      foreach (string invalid in invalids)
      {
        incorrectIds.Add(invalid);
      }
      
      foreach (string incorrectId in incorrectIds)
      {
        //Console.WriteLine(incorrectId);
        sum += long.Parse(incorrectId);
      }

      Console.WriteLine($"Part Two: {sum}");
    }


    bool IsRepeatedPattern(string id)
    {
      int len = id.Length;

      if (id[0] == '0') return false;

      for (int k = 1; k <= len / 2; k++)
      {
        if (len % k != 0) continue;

        string pattern = id[..k];
        int repeats = len / k;
        string built = string.Concat(Enumerable.Repeat(pattern, repeats));

        if (built == id) return true;
      }

      return false;
    }

    void FindInvalidIds(string[] ranges)
    {
      foreach (string r in ranges)
      {
        var parts = r.Split('-');
        long start = long.Parse(parts[0]);
        long end = long.Parse(parts[1]);

        for(long n = start; n <= end; n++)
        {
          string s = n.ToString();
          if(IsRepeatedPattern(s)) invalids.Add(s);
        }
      }
    }
  }
}
