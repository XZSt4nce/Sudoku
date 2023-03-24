using System;
class Program
{
    public static void Print_matrix(int[][] matrix)
    {
        Console.WriteLine("=====================================");
        for (int i = 0; i < 9; i++)
        {
            Console.Write("▌ ");
            for (int j = 0; j < 9; j++)
            {
                int value = matrix[i][j];
                if (value == 0) Console.Write(" ");
                else if (value == 10) Console.Write("^");
                else Console.Write(value);
                if (j % 3 == 2) Console.Write(" ▌ ");
                else Console.Write(" | ");
            }
            if (i % 3 == 2) Console.WriteLine("\n=====================================");
            else Console.WriteLine("\n-------------------------------------");

        }
    }
    /*
    ========================================
    ❚   |   |   ❚   |   |   ❚   |   |   ❚
    ----------------------------------------
    ❚   |   |   ❚   |   |   ❚   |   |   ❚
    ----------------------------------------
    ❚   |   |   ❚   |   |   ❚   |   |   ❚
    ========================================
    ❚   |   |   ❚   |   |   ❚   |   |   ❚
    ----------------------------------------
    ❚   |   |   ❚   |   |   ❚   |   |   ❚
    ----------------------------------------
    ❚   |   |   ❚   |   |   ❚   |   |   ❚
    ========================================
    ❚   |   |   ❚   |   |   ❚   |   |   ❚
    ----------------------------------------
    ❚   |   |   ❚   |   |   ❚   |   |   ❚
    ----------------------------------------
    ❚   |   |   ❚   |   |   ❚   |   |   ❚
    ========================================
    */
    public static int Input(string invitation)
    {
        int result;
        while (true)
        {
            try
            {
                Console.Write(invitation);
                string? str = Console.ReadLine();
                if (str == null)
                {
                    Console.WriteLine("Invalid input! Try again");
                    continue;
                }
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
            catch (Exception)
            {
                Console.WriteLine("Invalid input! Try again");
            }
        }
        return result;
    }
    private static void Main()
    {
        bool[][] allowed_rows = new bool[9][] {
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true }
        };
        bool[][] allowed_columns = allowed_rows;
        bool[][] allowed_in_square = allowed_rows;
        int row1 = 0, row2 = 0, row3 = 0;
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
                Print_matrix(matrix);
                matrix[i][j] = Input($"Enter a value in {i + 1} row in {j + 1} column: ");
                if (matrix[i][j] != 0)
                {
                    allowed_rows[i][matrix[i][j] - 1] = false;
                    allowed_columns[j][matrix[i][j] - 1] = false;
                    allowed_in_square[i / 3 * 3 + j / 3][matrix[i][j] - 1] = false;
                }
                Console.Clear();
            }
        }/*
        int hints = 0;
        for (int i = 0; i < 81; i++)
        {
            if (matrix[i % 9][i / 9] != 0)
            {
                hints++;
            }
        }
        if (hints < 17)
        {
            Console.WriteLine("Too few hints!");
            Environment.Exit(0);
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i / 3 == 0)
                    {
                        if (!allowed_rows[i][j]) row1++;
                    }
                    else if (i / 3 == 1)
                    {
                        if (!allowed_rows[i][j]) row2++;
                    }
                    else
                    {
                        if (!allowed_rows[i][j]) row3++;
                    }
                }
            }
            bool solvable = false;
            if (row1 >= 6)
            {
                if (row2 >= 6) solvable = row3 == 5;
                else if (row2 == 5) solvable = row3 >= 6;
                else solvable = false;
            }
            else if (row1 == 5) 
                solvable = row2 >= 6 && row3 >= 6;

            if (!solvable)
            {
                Console.WriteLine("The square is unsolvable!");
                Environment.Exit(0);
            }
        }
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int k = j; k < 9; k++)
                {
                    if (matrix[i][j] == matrix[i][k] && matrix[i][j] != 0)
                    {
                        Console.WriteLine("The square is unsolvable!");
                        Environment.Exit(0);
                    }
                }
            }
        }
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int k = j + 1; k < 9; k++)
                {
                    if (matrix[j][i] == matrix[k][i] && matrix[j][i] != 0 ||
                        matrix[i][j] == matrix[i][k] && matrix[i][j] != 0)
                    {
                        Console.WriteLine("The square is unsolvable!");
                        Environment.Exit(0);
                    }
                }
            }
        }*/
        for (int i = 0; i < 9; i++)
        {
            int count = 0;
            for (int j = 0 ; j < 9; j++)
            {
                if (allowed_in_square[i][j]) count++;
            }
            if (count == 1)
            {
                int value = 0;
                for (int j = 0; j < 9; j++)
                {
                    if (allowed_in_square[i][j])
                    {
                        value = j + 1;
                        break;
                    }
                }
                bool not_found = true;
                for (int j = i % 3 * 3; j < i % 3 * 3 + 3 && not_found; j++)
                {
                    for (int k = i / 3; k < i / 3 + 3 && not_found; k++)
                    {
                        if (matrix[k][j] == 0)
                        {
                            matrix[k][j] = value;
                            not_found = false;
                        }
                    }
                }
            }
        }
        Print_matrix(matrix);
    }
}