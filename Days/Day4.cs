namespace AoC_2024.Days;

public class Day4
{
    public static void Part1()
    {
        var inputs = InputGetter.GetStringInputs();
        var transpose = InvertStringArray(inputs);
        var total = 0;
        total += inputs.Sum(input => CountCharSequence(input, "XMAS".ToCharArray()));
        total += inputs.Sum(input => CountCharSequence(input, "SAMX".ToCharArray()));
        total += transpose.Sum(input => CountCharSequence(input, "XMAS".ToCharArray()));
        total += transpose.Sum(input => CountCharSequence(input, "SAMX".ToCharArray()));
        total += CountDownDiagonalCharSequence(inputs, "SAMX".ToCharArray());
        total += CountDownDiagonalCharSequence(inputs, "XMAS".ToCharArray());
        total += CountUpDiagonalCharSequence(inputs, "SAMX".ToCharArray());
        total += CountUpDiagonalCharSequence(inputs, "XMAS".ToCharArray());

        Debug.Answer(total);
    }

    public static void Part2()
    {
        var inputs = InputGetter.GetStringInputs();
        var charArray = new char[inputs.Length][];
        var total = 0;
        
        for(var i = 0; i < charArray.Length; i++)
            charArray[i] = inputs[i].ToCharArray();

        for (var i = 0; i < charArray.Length; i++)
        {
            for (var j = 0; j < charArray[i].Length; j++)
            {
                if(CheckSAMSAM(charArray, i, j)) total++;
                if(CheckSAMMAS(charArray, i, j)) total++;
                if(CheckMASSAM(charArray, i, j)) total++;
                if(CheckMASMAS(charArray, i, j)) total++;
            }
        }

        Debug.Answer(total);
    }

    #region Part 1

    private static string[] InvertStringArray(string[] input)
    {
        List<string> output = [];
        for (int i = 0; i < input[0].Length; i++)
        {
            var str = "";
            foreach (string s in input)
            {
                str += s[i];
            }

            output.Add(str);
        }

        return output.ToArray();
    }

    private static int CountCharSequence(string s, char[] args)
    {
        var instances = 0;
        for (var i = 0; i < s.Length; i++)
        {
            Start:
            try
            {
                for (var j = 0; j < args.Length; j++)
                {
                    if (s[i + j] == args[j]) continue;

                    i++;
                    goto Start;
                }

                instances++;
            }
            catch // on run out of line
            {
                return instances;
            }
        }

        return instances;
    }

    private static int CountDownDiagonalCharSequence(string[] s, char[] args)
    {
        var instances = 0;
        for (var i = 0; i < s.Length; i++)
        {
            for (var j = 0; j < s[i].Length; j++)
            {
                try
                {
                    Top:
                    for (var k = 0; k < args.Length; k++)
                    {
                        if (s[i + k][j + k] == args[k]) continue;

                        j++;
                        goto Top;
                    }

                    instances++;
                }
                catch
                {
                    continue;
                }
            }
        }

        return instances;
    }

    private static int CountUpDiagonalCharSequence(string[] s, char[] args)
    {
        var instances = 0;
        for (var i = 0; i < s.Length; i++)
        {
            for (var j = 0; j < s[i].Length; j++)
            {
                try
                {
                    Top:
                    for (var k = 0; k < args.Length; k++)
                    {
                        if (s[i - k][j + k] == args[k]) continue;

                        j++;
                        goto Top;
                    }

                    instances++;
                }
                catch
                {
                    continue;
                }
            }
        }

        return instances;
    }

    #endregion

    #region Part 2

    private static bool CheckSAMSAM(char[][] charArray, int i, int j)
    {
        if (charArray[i][j] != 'A') return false;
        try
        {
            if (charArray[i-1][j-1] != 'S') return false;
            if (charArray[i+1][j+1] != 'M') return false;
            
            if (charArray[i+1][j-1] != 'S') return false;
            if (charArray[i-1][j+1] != 'M') return false;
        }
        catch
        {
            return false;
        }

        return true;
    }
    
    private static bool CheckMASMAS(char[][] charArray, int i, int j)
    {
        if (charArray[i][j] != 'A') return false;
        try
        {
            if (charArray[i-1][j-1] != 'M') return false;
            if (charArray[i+1][j+1] != 'S') return false;
            
            if (charArray[i-1][j+1] != 'M') return false;
            if (charArray[i+1][j-1] != 'S') return false;
        }
        catch
        {
            return false;
        }

        return true;
    }
    
    private static bool CheckSAMMAS(char[][] charArray, int i, int j)
    {
        if (charArray[i][j] != 'A') return false;
        try
        {
            if (charArray[i-1][j-1] != 'S') return false;
            if (charArray[i+1][j+1] != 'M') return false;
            
            if (charArray[i-1][j+1] != 'S') return false;
            if (charArray[i+1][j-1] != 'M') return false;
        }
        catch
        {
            return false;
        }

        return true;
    }
    
    private static bool CheckMASSAM(char[][] charArray, int i, int j)
    {
        if (charArray[i][j] != 'A') return false;
        try
        {
            if (charArray[i-1][j-1] != 'M') return false;
            if (charArray[i+1][j+1] != 'S') return false;
            
            if (charArray[i-1][j+1] != 'S') return false;
            if (charArray[i+1][j-1] != 'M') return false;
        }
        catch
        {
            return false;
        }

        return true;
    }
    
    #endregion
}