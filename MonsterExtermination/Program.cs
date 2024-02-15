namespace MonsterExtermination;

public class Program
{
    static void Main()
    {
        int[] monstersArray = Console.ReadLine()
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[] soldiersArray = Console.ReadLine()
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Queue<int> monsters = new Queue<int>(monstersArray);
        Stack<int> soldiers = new Stack<int>(soldiersArray);
        int killedMonsters = 0;

        while (monsters.Count > 0 && soldiers.Count > 0)
        {
            int currentMonster = monsters.Peek();
            int currentSoldier = soldiers.Peek();
            if (currentSoldier >= currentMonster)
            {
                currentSoldier -= currentMonster;
                if (currentSoldier > 0 && soldiers.Count > 1)
                {
                    soldiers.Pop();
                    soldiers.Push(soldiers.Pop() + currentSoldier);
                }
                else if (currentSoldier == 0)
                {
                    soldiers.Pop();
                }
                monsters.Dequeue();
                killedMonsters++;
            }
            else if (currentSoldier < currentMonster)
            {
                currentMonster -= currentSoldier;
                monsters.Enqueue(monsters.Dequeue());
                soldiers.Pop();
            }
        }

        if (monsters.Count == 0)
        {
            Console.WriteLine("All monsters have been killed!");
        }

        if (soldiers.Count == 0)
        {
            Console.WriteLine("The soldier has been defeated.");
        }

        Console.WriteLine($"Total monsters killed: {killedMonsters}");
    }


}