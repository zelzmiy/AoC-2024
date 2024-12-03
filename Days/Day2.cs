namespace AoC_2024.Days;

public class Day2
{
    public static void Part1()
    {
        var inputs = InputGetter.GetStringInputs();
        var @unsafe = 0;
        var total = 0;
        foreach (var report in inputs)
        {
            var values = report.Split(" ").Select(int.Parse).ToList();
            if (!IsSafe(values))
            {
                @unsafe++;
            }
            total++;
        }
        Debug.Answer(total-@unsafe);
    }

    public static void Part2()
    {
        var inputs = InputGetter.GetStringInputs();
        var @unsafe = 0;
        var total = 0;
        foreach (var report in inputs)
        {
            var values = report.Split(" ").Select(int.Parse).ToList();
            if (!IsSafe(values))
            {
                var safe = false;
                for (var i = 0; i < values.Count; i++)
                {
                    var newValues = values.ToList();
                    newValues.RemoveAt(i);
                    if (IsSafe(newValues))
                    {
                        safe = true;
                    }
                }
                if(!safe)
                    @unsafe++;
            }
            total++;
        }
        
        Debug.Answer(total - @unsafe);
    }

    private static bool IsSafe(List<int> sequence)
    {
        var dir = Direction.NotCalculated;
        for (var i = 0; i < sequence.Count - 1; i++)
        {
            var (dir1, dist) = CalculateStep(sequence[i], sequence[i + 1]);
            
            if (dir == Direction.NotCalculated)
                dir = dir1;
                
            if (dir == dir1 && dist <= 3 && dist != 0) continue;
            return false;
        }

        return true;
    }

    private static (Direction, int) CalculateStep(int a, int b)
    {
        return a > b ? (Direction.Decreasing, a - b) : (Direction.Increasing, b - a);
    }

    private enum Direction
    {
        NotCalculated,
        Increasing,
        Decreasing
    }
}