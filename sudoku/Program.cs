using System;
class Program
{
    public static void print_matrix(int[][] matrix)
    {
        Console.WriteLine("-------------------------------------");
        foreach (int[] row in matrix)
        {
            Console.Write("| ");
            foreach (int value in row)
            {
                if (value == 0) Console.Write(" ");
                else if (value == 10) Console.Write("^");
                else Console.Write(value);
                Console.Write(" | ");
            }
            Console.WriteLine("\n-------------------------------------");

        }
    }
    public static int input(string invitation)
    {
        int result;
        while (true)
        {
            try
            {
                Console.Write(invitation);
                string str = Console.ReadLine();
                if (str == "")
                {
                    result = 0;
                    break;
                }
                result = int.Parse(str);
                if (result < 0 || result > 9)
                {
                    Console.WriteLine("Invalid input! Try again");
                    continue;
                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input! Try again");
            }
        }
        return result;
    }
    private static void Main(string[] args)
    {
        int value;
        int[][] matrix = new int[9][]
        {
            new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.WriteLine("Put values in Sudoku square");
                Console.WriteLine("To leave a cell blank, type 0 or press Enter");
                matrix[i][j] = 10;
                print_matrix(matrix);
                matrix[i][j] = input($"Enter a value in {i + 1} row in {j + 1} column: ");
                Console.Clear();
            }
        }
        Environment.Exit(0);
    }
}