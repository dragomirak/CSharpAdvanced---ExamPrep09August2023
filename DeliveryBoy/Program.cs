namespace DeliveryBoy;

public class Program
{
    static void Main()
    {
        int[] sizes = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        char[,] field = new char[sizes[0], sizes[1]];

        int currentRow = -1;
        int currentCol = -1;
        int initialRow = 0;
        int initialCol = 0;

        for (int row = 0; row < field.GetLength(0); row++)
        {
            char[] rowData = Console.ReadLine().ToCharArray();
            for (int col = 0; col < field.GetLength(1); col++)
            {
                field[row, col] = rowData[col];
                if (field[row, col] == 'B')
                {
                    currentRow = row;
                    currentCol = col;
                    initialRow = row;
                    initialCol = col;
                }
            }
        }

        bool hasLeftField = false;
        while (field[currentRow, currentCol] != 'A')
        {
            string direction = Console.ReadLine();

            if (currentRow == 0 && direction == "up"
                || currentRow == field.GetLength(0) - 1 && direction == "down"
                || currentCol == 0 && direction == "left"
                || currentCol == field.GetLength(1) - 1 && direction == "right")
            {
                hasLeftField = true;
                if (field[currentRow, currentCol] != 'R')
                {
                    field[currentRow, currentCol] = '.';
                }
                Console.WriteLine("The delivery is late. Order is canceled.");
                break;
            }

            if (field[currentRow, currentCol] != 'R')
            {
                field[currentRow, currentCol] = '.';
            }
            

            if (direction == "up" && field[currentRow - 1, currentCol] != '*')
            {
                currentRow--;
            }
            else if (direction == "down" && field[currentRow + 1, currentCol] != '*')
            {
                currentRow++;
            }
            else if (direction == "left" && field[currentRow, currentCol - 1] != '*')
            {
                currentCol--;
            }
            else if (direction == "right" && field[currentRow, currentCol + 1] != '*')
            {
                currentCol++;
            }

            if (field[currentRow, currentCol] == '-')
            {
                field[currentRow, currentCol] = '.';
                continue;
            }
            else if (field[currentRow, currentCol] == '.')
            {
                continue;
            }
            else if (field[currentRow, currentCol] == 'P')
            {
                field[currentRow, currentCol] = 'R';
                Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                continue;
            }
            else if (field[currentRow, currentCol] == 'A')
            {
                field[currentRow, currentCol] = 'P';
                Console.WriteLine("Pizza is delivered on time! Next order...");
                break;
            }
        }

        if (hasLeftField)
        {
            field[initialRow, initialCol] = ' ';
        }
        else
        {
            field[initialRow, initialCol] = 'B';
        }

        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                Console.Write(field[row,col]);
            }

            Console.WriteLine();
        }


    }

}