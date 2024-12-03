public static class Day1 { 
    public static void part1()
    {
        var inputs = InputGetter.GetStringInputs();
        List<int> firstList = [];
        List<int> secondList = [];
        foreach (var input in inputs)
        {
            var split =input.Split("   ");
            firstList.Add(int.Parse(split[0]));
            secondList.Add(int.Parse(split[1]));
        }
        
        Stack<int> stack1 = new(firstList.Order().Reverse());
        Stack<int> stack2 = new(secondList.Order().Reverse());

        var sum = 0;
        while (stack1.Count > 0)
        {
            if (stack1.Peek() > stack2.Peek())
                sum += stack1.Pop() - stack2.Pop();
            else
                sum += stack2.Pop() - stack1.Pop();
        }

        Debug.Answer(sum);
    }

    public static void part2()
    {
        var inputs = InputGetter.GetStringInputs();
        List<int> firstList = [];
        List<int> secondList = [];
        foreach (var input in inputs)
        {
            var split =input.Split("   ");
            firstList.Add(int.Parse(split[0]));
            secondList.Add(int.Parse(split[1]));
        }

        var totalSimilarity = firstList.Sum(num => num * secondList.Count(x=> x == num));
        
        Debug.Answer(totalSimilarity);
    }
}
