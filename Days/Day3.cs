namespace AoC_2024.Days;

public class Day3
{
    private static bool s_enabled = true;
    public static void Part1()
    {
        var inputs = InputGetter.GetStringInputs();
        var sum = 0;
        foreach (var s in inputs)
        {
            var result = DoTheThing(s);
            Debug.Log(result);
            sum += result;
        }

        Debug.Answer(sum);
    }

    public static int DoTheThing(string s)
    {
        var prod = 0;
        for (var i = 0; i < s.Length; i++)
        {
            CheckEnabled(s,i);
            if (s[i] != 'm') continue;
            if (s[i + 1] != 'u') continue;
            if (s[i + 2] != 'l') continue;
            if (s[i + 3] != '(') continue;
            if(!s_enabled) continue;
            
            var l2 = false;
            List<int> n1 = [];
            List<int> n2 = [];
            var j = 4;
            Top:
            var newchar = s[i + j];
            if (IsNumber(newchar))
            {
                if (!l2)
                {
                    n1.Add(int.Parse(newchar.ToString()));
                }
                else
                {
                    n2.Add(int.Parse(newchar.ToString()));
                }

                j++;
                goto Top;
            }

            switch (newchar)
            {
                case ',':
                    l2 = true;
                    j++;
                    goto Top;
                case ')':
                {
                    if (n1.Count != 0 && n2.Count != 0)
                    {
                        var mult1 = n1.Select((t, k) => t * (int)Math.Pow(10,n1.Count -k-1)).Sum();
                        var mult2 = n2.Select((t, k) => t * (int)Math.Pow(10,n2.Count -k-1)).Sum();

                        prod += mult1 * mult2;
                    }

                    break;
                }
            }
        }

        return prod;
    }

    public static void Part2()
    {
        // oops! all part1
    }

    private static void CheckEnabled(string s, int i)
    {
        if (matchEnabled(s, i))
            s_enabled = true;
            
        if (matchDisabled(s,i))
            s_enabled = false;
    }

    private static bool matchEnabled(string s, int i)
    {
        try
        {
            if (s[i] != 'd') return false;
            if (s[i + 1] != 'o') return false;
            if (s[i + 2] != '(') return false;
            return s[i + 3] == ')';
        }
        catch
        {
            return false;
        }
    }

    private static bool matchDisabled(string s, int i)
    {
        try
        {
            if (s[i] != 'd') return false;
            if (s[i + 1] != 'o') return false;
            if (s[i + 2] != 'n') return false;
            if (s[i + 3] != '\'') return false;
            if (s[i + 4] != 't') return false;
            if (s[i + 5] != '(') return false;
            return s[i + 6] == ')';
        }
        catch
        {
            return false;
        }
    }

    private static bool IsNumber(char c)
    {
        return c switch
        {
            '1' => true,
            '2' => true,
            '3' => true,
            '4' => true,
            '5' => true,
            '6' => true,
            '7' => true,
            '8' => true,
            '9' => true,
            '0' => true,
            _ => false
        };
    }
}