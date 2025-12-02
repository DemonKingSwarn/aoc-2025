namespace AoC.Day2PartOne
{
  using System.IO;

  public class Day2PartOne
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

      Console.WriteLine($"Part One: {sum}");
    }


    bool IsRepeatedTwice(string id)
    {
      if (id.Length % 2 != 0 || id[0] == '0') return false;

      int half = id.Length / 2;
      return id[..half] == id[half..];
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
          if(IsRepeatedTwice(s)) invalids.Add(s);
        }
      }
    }
  }
}
