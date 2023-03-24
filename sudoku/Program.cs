using System;
class Program
{
    static bool[][] allowed_rows = new bool[9][] {
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
    static bool[][] allowed_columns = new bool[9][] {
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
    static bool[][] allowed_in_square = new bool[9][] {
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
    public static int[][] Input()
    {
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
        int i = 0, j = 0, value, prev_value;
        matrix[i][j] = 10;
        ConsoleKeyInfo key = new ConsoleKeyInfo();
        while (key.Key != ConsoleKey.Enter)
        {
            Console.WriteLine("Put values in Sudoku square.");
            Console.WriteLine("Use the WASD buttons or arrows to move through the cells.");
            Console.WriteLine("To finish filling, press Enter.");
            prev_value = matrix[i][j];
            if (prev_value == 10) prev_value = 0;
            matrix[i][j] = 10;
            Print_matrix(matrix);
            key = Console.ReadKey(true);
            value = Convert.ToInt32(key.KeyChar) - 48;
            if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow)
            {
                if (i != 0)
                {
                    matrix[i][j] = prev_value;
                    i--;
                }
            }
            if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow)
            {
                if (i != 8)
                {
                    matrix[i][j] = prev_value;
                    i++;
                }
            }
            if (key.Key == ConsoleKey.D || key.Key == ConsoleKey.RightArrow)
            {
                if (j != 8)
                {
                    matrix[i][j] = prev_value;
                    j++;
                }
            }
            if (key.Key == ConsoleKey.A || key.Key == ConsoleKey.LeftArrow)
            {
                if (j != 0)
                {
                    matrix[i][j] = prev_value;
                    j--;
                }
            }
            if (value >= 0 && value < 10)
            {
                matrix[i][j] = value;
                allowed_rows[i][value - 1] = false;
                allowed_columns[j][value - 1] = false;
                allowed_in_square[i / 3 * 3 + j / 3][value - 1] = false;
                if (j == 8) j--;
                else j++;
            }
            Console.Clear();
        }
        return matrix;
    }
    public static int[][] Exact(int[][] matrix)
    {
        int count, value;
        bool not_found;
        for (int i = 0; i < 9; i++)
        {
            count = 0;
            for (int j = 0; j < 9; j++)
            {
                if (allowed_in_square[i][j]) count++;
            }
            if (count == 1)
            {
                value = 0;
                for (int j = 0; j < 9; j++)
                {
                    if (allowed_in_square[i][j])
                    {
                        value = j + 1;
                        break;
                    }
                }
                not_found = true;
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

            count = 0;
            for (int j = 0; j < 9; j++)
            {
                if (allowed_rows[i][j]) count++;
            }
            if (count == 1)
            {
                value = 0;
                for (int j = 0; j < 9; j++)
                {
                    if (allowed_rows[i][j])
                    {
                        value = j + 1;
                        break;
                    }
                }
                not_found = true;
                for (int j = 0; j < 9 && not_found; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][j] = value;
                        not_found = false;
                    }
                }
            }

            count = 0;
            for (int j = 0; j < 9; j++)
            {
                if (allowed_columns[i][j]) count++;
            }
            if (count == 1)
            {
                value = 0;
                for (int j = 0; j < 9; j++)
                {
                    if (allowed_columns[i][j])
                    {
                        value = j + 1;
                        break;
                    }
                }
                not_found = true;
                for (int j = 0; j < 9 && not_found; j++)
                {
                    if (matrix[j][i] == 0)
                    {
                        matrix[j][i] = value;
                        not_found = false;
                    }
                }
            }
        }
        return matrix;
    }
    public static bool Check(int[][] matrix)
    {
        int row1 = 0, row2 = 0, row3 = 0;
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
            return false;
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
                return false;
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
                        return false;
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
                        return false;
                    }
                }
            }
        }
        return true;
    }
    private static void Main()
    {
        int[][] matrix = Input();
        Console.Clear();
        if (!Check(matrix))
        {
            Console.WriteLine("The square is unsolvable");
            Environment.Exit(0);
        }
        matrix = Exact(matrix);
        Console.WriteLine("Solved sudoku:");
        Print_matrix(matrix);
    }
}