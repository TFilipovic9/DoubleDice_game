using System.Globalization;

namespace Double_Dice;


public static class Board
{
    static List<int> nums = new List<int>();
    static Random random = new Random();

    public static int Roll()
    {
        return random.Next(1, 13);
    }

    public static void FillNumbers()
    {
        nums.Clear();
        for (int i = 1; i <= 12; i++)
        {
            nums.Add(i);
        }
    }

    public static void Try()
    {
        int currentNum = Roll();
        List<int[]> combinations = GetCombinations(currentNum);

        if (nums.Contains(currentNum))
        {
            nums.Remove(currentNum);
            return;
        }

        foreach (var comb in combinations)
        {
            if (nums.Contains(comb[0]) && nums.Contains(comb[1]))
            {
                nums.Remove(comb[0]);
                nums.Remove(comb[1]);
                return;
            }
        }
    }

    public static List<int[]> GetCombinations(int num)
    {
        List<int[]> possible = new List<int[]>();

        for (int i = 1; i <= num / 2; i++)
        {
            possible.Add(new int[] { num - i, i });
        }

        return possible;
    }

    public static int Play()
{
    int counter = 0;
    FillNumbers();

    while (nums.Count > 0)
    {
        Try();
        counter++;
    }

    return counter;
}

}
