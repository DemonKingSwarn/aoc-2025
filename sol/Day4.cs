namespace AoC.Day4
{
  using System.Linq;
  using System.IO;

  public class Day4
  {
    public void Solve(string filePath)
    {
      string[] lines = File.ReadAllLines(filePath);
      
      int p1 = PartOne(lines);

      Console.WriteLine($"Part One: {p1}");
    }

    int PartOne(string[] input)
    {
      int maxWidth = input.Max(s => s.Length);
      char[][] m = input
        .Select(s => s.PadRight(maxWidth, ' ').ToCharArray())
        .ToArray();
      int R = input.Length;
      int C = input[0].Length;
      
      int good = 0;

      int[] dx = {-1,-1,-1, 0,0, 1,1,1};
      int[] dy = {-1, 0, 1,-1,1,-1,0,1};

      for (int x = 0; x < R; x++)
      {
        for (int y = 0; y < C; y++)
        {
          if (m[x][y] == '@')
          {
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
              int nx = x + dx[i];
              int ny = y + dy[i];
              if (nx >= 0 && nx < R && ny >= 0 && ny < C && m[nx][ny] == '@') count++;
            }
            if (count < 4) good++;
          }
        }
      }

      return good;
    }
  }
}
