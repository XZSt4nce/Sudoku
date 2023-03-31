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
    static bool[][][] allowed_cells = new bool[9][][]
    {
        new bool[9][]
        {
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
        },
        new bool[9][]
        {
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
        },
        new bool[9][]
        {
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
        },
        new bool[9][]
        {
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
        },
        new bool[9][]
        {
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
        },
        new bool[9][]
        {
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
        },
        new bool[9][]
        {
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
        },
        new bool[9][]
        {
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
        },
        new bool[9][]
        {
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
            new bool[9] { true, true, true, true, true, true, true, true, true },
        }
    };
    static int[][] pen_digits = new int[9][]
    {
        new int[9] { 9, 9, 9, 9, 9, 9, 9, 9, 9 },
        new int[9] { 9, 9, 9, 9, 9, 9, 9, 9, 9 },
        new int[9] { 9, 9, 9, 9, 9, 9, 9, 9, 9 },
        new int[9] { 9, 9, 9, 9, 9, 9, 9, 9, 9 },
        new int[9] { 9, 9, 9, 9, 9, 9, 9, 9, 9 },
        new int[9] { 9, 9, 9, 9, 9, 9, 9, 9, 9 },
        new int[9] { 9, 9, 9, 9, 9, 9, 9, 9, 9 },
        new int[9] { 9, 9, 9, 9, 9, 9, 9, 9, 9 },
        new int[9] { 9, 9, 9, 9, 9, 9, 9, 9, 9 }
    };
    static int[] digits_left = new int[9] { 9, 9, 9, 9, 9, 9, 9, 9, 9 };
    static int digits = 81;
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
        /*int[][] matrix = new int[9][]
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
        };*/

        int[][] matrix = new int[9][]
        {
            new int[9] { 0, 0, 0, 9, 0, 0, 0, 4, 0 },
            new int[9] { 7, 0, 0, 0, 5, 0, 0, 0, 0 },
            new int[9] { 0, 0, 0, 0, 0, 0, 0, 6, 8 },
            new int[9] { 9, 6, 0, 4, 0, 0, 0, 0, 0 },
            new int[9] { 0, 0, 0, 0, 0, 7, 2, 0, 0 },
            new int[9] { 0, 8, 0, 0, 0, 0, 0, 0, 0 },
            new int[9] { 0, 0, 0, 8, 2, 0, 0, 0, 0 },
            new int[9] { 3, 0, 0, 0, 0, 0, 7, 0, 0 },
            new int[9] { 0, 0, 0, 6, 0, 0, 0, 0, 0 }
        };

        int a = 0, b = 0, value, prev_value = 0;
        matrix[a][b] = 10;
        ConsoleKeyInfo key = new();
        while (key.Key != ConsoleKey.Enter)
        {
            Console.WriteLine("Put values in Sudoku square.");
            Console.WriteLine("Use the WASD buttons or arrows to move through the cells.");
            Console.WriteLine("To clear the cell, press Backspace");
            Console.WriteLine("To finish filling, press Enter.");
            prev_value = matrix[a][b];
            if (prev_value == 10) prev_value = 0;
            matrix[a][b] = 10;
            Print_matrix(matrix);
            Console.CursorVisible = false;
            key = Console.ReadKey(true);
            Console.CursorVisible = true;
            value = Convert.ToInt32(key.KeyChar) - 48;
            if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow)
            {
                matrix[a][b] = prev_value;
                if (a != 0) a--;
                else a = 8;
            }
            if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow)
            {
                matrix[a][b] = prev_value;
                if (a != 8) a++;
                else a = 0;
            }
            if (key.Key == ConsoleKey.D || key.Key == ConsoleKey.RightArrow)
            {
                matrix[a][b] = prev_value;
                if (b != 8) b++;
                else b = 0;
            }
            if (key.Key == ConsoleKey.A || key.Key == ConsoleKey.LeftArrow)
            {
                matrix[a][b] = prev_value;
                if (b != 0) b--;
                else b = 8;
            }
            if (value >= 0 && value < 10)
            {
                matrix[a][b] = value;
                allowed_rows[a][value - 1] = false;
                allowed_columns[b][value - 1] = false;
                allowed_in_square[a / 3 * 3 + b / 3][value - 1] = false;
                if (b == 8)
                {
                    b = 0;
                    a++;
                    a %= 9;
                }
                else b++;
            }
            Console.Clear();
        }
        matrix[a][b] = prev_value;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (matrix[i][j] != 0)
                {
                    allowed_rows[i][matrix[i][j] - 1] = false;
                    allowed_in_square[i / 3 * 3 + j / 3][matrix[i][j] - 1] = false;
                    allowed_columns[j][matrix[i][j] - 1] = false;
                    allowed_cells[i][j][matrix[i][j] - 1] = false;
                    digits_left[matrix[i][j] - 1]--;
                    digits--;
                }
            }
        }
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (!allowed_rows[i][j])
                {
                    for (int k = 0; k < 9; k++)
                    {
                        allowed_cells[i][k][j] = false;
                    }
                }
                if (!allowed_columns[i][j])
                {
                    for (int k = 0; k < 9; k++)
                    {
                        allowed_cells[k][i][j] = false;
                    }
                }
            }
        }
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (matrix[i][j] != 0)
                {
                    for (int k = 0; k < 9; k++) allowed_cells[i][j][k] = false;
                }
            }
        }
        return matrix;
    }
    public static int[][] Exact(int[][] matrix)
    {
        int count, value;
        bool not_found;
        for (value = 0; value < 9; value++)
        {
            if (digits_left[value] > 0) continue;
            for (int i = 0; i < 9; i++)
            {
                allowed_in_square[i][value] = false;
                allowed_columns[i][value] = false;
                allowed_rows[i][value] = false;
                for (int j = 0; j < 9; j++)
                {
                    allowed_cells[i][j][value] = false;
                }
            }
        }
        for (value = 0; value < 9; value++)
        {
            for (int i = 0; i < 3; i++)
            {
                if (allowed_rows[i * 3][value] && allowed_rows[i * 3 + 1][value] ||
                    allowed_rows[i * 3][value] && allowed_rows[i * 3 + 2][value] ||
                    allowed_rows[i * 3 + 1][value] && allowed_rows[i * 3 + 2][value])
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (!allowed_in_square[i * 3 + j][value]) continue;
                        count = 0;
                        for (int a = i * 3; a < i * 3 + 3; a++)
                        {
                            for (int b = j * 3; b < j * 3 + 3; b++)
                            {
                                if (matrix[a][b] == 0 && allowed_rows[a][value] && allowed_columns[b][value] && allowed_cells[a][b][value])
                                {
                                    count++;
                                    break;
                                }
                            }
                        }
                        if (count == 1)
                        {
                            not_found = true;
                            for (int a = i * 3; a < i * 3 + 3 && not_found; a++)
                            {
                                for (int b = j * 3; b < j * 3 + 3 && not_found; b++)
                                {
                                    // breakpoint: value == 7 && i == 1 && j == 0 && a == 4 && b == 0
                                    if (matrix[a][b] == 0 && allowed_rows[a][value] && allowed_columns[b][value] && allowed_cells[a][b][value])
                                    {
                                        for (int c = 0; c < j * 3; c++)
                                        {
                                            allowed_cells[a][c][value] = false;
                                        }
                                        for (int c = j * 3 + 3; c < 9; c++)
                                        {
                                            allowed_cells[a][c][value] = false;
                                        }
                                        not_found = false;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
                if (allowed_columns[i * 3][value] && allowed_columns[i * 3 + 1][value] ||
                    allowed_columns[i * 3][value] && allowed_columns[i * 3 + 2][value] ||
                    allowed_columns[i * 3 + 1][value] && allowed_columns[i * 3 + 2][value])
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (!allowed_in_square[j * 3 + i][value]) continue;
                        count = 0;
                        for (int a = i * 3; a < i * 3 + 3; a++)
                        {
                            for (int b = j * 3; b < j * 3 + 3; b++)
                            {
                                if (matrix[b][a] == 0 && allowed_columns[a][value] && allowed_rows[b][value] && allowed_cells[b][a][value])
                                {
                                    count++;
                                    break;
                                }
                            }
                        }
                        if (count == 1)
                        {
                            not_found = true;
                            for (int a = i * 3; a < i * 3 + 3 && not_found; a++)
                            {
                                for (int b = j * 3; b < j * 3 + 3 && not_found; b++)
                                {
                                    if (matrix[b][a] == 0 && allowed_columns[a][value] && allowed_rows[b][value] && allowed_cells[b][a][value])
                                    {
                                        for (int c = 0; c < j * 3; c++)
                                        {
                                            allowed_cells[c][a][value] = false;
                                        }
                                        for (int c = j * 3 + 3; c < 9; c++)
                                        {
                                            allowed_cells[c][a][value] = false;
                                        }
                                        not_found = false;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
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
                        value = j;
                        break;
                    }
                }
                not_found = true;
                for (int j = i % 3 * 3; j < i % 3 * 3 + 3 && not_found; j++)
                {
                    for (int k = i / 3 * 3; k < i / 3 * 3 + 3 && not_found; k++)
                    {
                        if (matrix[k][j] == 0)
                        {
                            matrix[k][j] = value + 1;
                            Console.Clear();
                            Print_matrix(matrix);
                            allowed_rows[k][value] = false;
                            allowed_columns[j][value] = false;
                            allowed_cells[k][j][value] = false;
                            for (int v = 0; v < 9; v++)
                            {
                                allowed_cells[k][j][v] = false;
                            }
                            allowed_in_square[i][value] = false;
                            digits_left[value]--;
                            digits--;
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
                        value = j;
                        break;
                    }
                }
                not_found = true;
                for (int j = 0; j < 9 && not_found; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][j] = value + 1;
                        Console.Clear();
                        Print_matrix(matrix);
                        allowed_rows[i][value] = false;
                        allowed_columns[j][value] = false;
                        allowed_cells[i][j][value] = false;
                        for (int v = 0; v < 9; v++)
                        {
                            allowed_cells[i][j][v] = false;
                        }
                        allowed_in_square[i / 3 * 3 + j / 3][matrix[i][j] - 1] = false;
                        digits_left[value]--;
                        digits--;
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
                        value = j;
                        break;
                    }
                }
                not_found = true;
                for (int j = 0; j < 9 && not_found; j++)
                {
                    if (matrix[j][i] == 0)
                    {
                        matrix[j][i] = value + 1;
                        Console.Clear();
                        Print_matrix(matrix);
                        allowed_rows[j][value] = false;
                        allowed_columns[i][value] = false;
                        for (int v = 0; v < 9; v++)
                        {
                            allowed_cells[j][i][v] = false;
                        }
                        allowed_in_square[j / 3 * 3 + i / 3][value] = false;
                        digits_left[value]--;
                        digits--;
                        not_found = false;
                    }
                }
            }

            count = 0;
            for (int j = 0; j < 9; j++)
            {
                if (allowed_in_square[i][j]) count++;
            }
            if (count == 1)
            {
                not_found = true;
                for (int j = 0; j < 9; j++)
                {
                    if (allowed_in_square[i][j]) value = j;
                }
                for (int j = i / 3 * 3; j < i / 3 * 3 + 3 && not_found; j++)
                {
                    for (int k = i % 3 * 3; k < i % 3 * 3 + 3 && not_found; k++)
                    {
                        if (matrix[j][k] == 0)
                        {
                            matrix[j][k] = value + 1;
                            Console.Clear();
                            Print_matrix(matrix);
                            allowed_rows[j][value] = false;
                            allowed_columns[k][value] = false;
                            for (int v = 0; v < 9; v++)
                            {
                                allowed_cells[j][k][v] = false;
                            }
                            allowed_in_square[i][value] = false;
                            digits_left[value]--;
                            digits--;
                            not_found = false;
                        }
                    }
                }
            }
        }
        for (int sub_square = 0; sub_square < 9; sub_square++)
        {
            count = 0;
            for (int j = 0; j < 9; j++)
            {
                if (allowed_in_square[sub_square][j]) count++;
            }
            if (count == 1)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (allowed_in_square[sub_square][j]) value = j;
                }
                not_found = true;
                for (int j = sub_square / 3 * 3; j < sub_square / 3 * 3 + 3 && not_found; j++)
                {
                    for (int k = sub_square % 3 * 3; k < sub_square % 3 * 3 + 3 && not_found; k++)
                    {
                        if (matrix[j][k] == 0)
                        {
                            matrix[j][k] = value + 1;
                            Console.Clear();
                            Print_matrix(matrix);
                            for (int v = 0; v < 9; v++)
                            {
                                allowed_cells[j][k][v] = false;
                            }
                            allowed_rows[j][value] = false;
                            allowed_columns[k][value] = false;
                            allowed_in_square[sub_square][value] = false;
                            digits_left[value]--;
                            digits--;
                            not_found = false;
                        }
                    }
                }
            }

            for (value = 0; value < 9; value++)
            {
                if (!allowed_in_square[sub_square][value]) continue;
                int[][] probable = new int[9][];
                int ptr = 0;
                for (int row = sub_square / 3 * 3; row < sub_square / 3 * 3 + 3; row++)
                {
                    for (int column = sub_square % 3 * 3; column < sub_square % 3 * 3 + 3; column++)
                    {
                        if (allowed_cells[row][column][value] && allowed_columns[column][value] && allowed_rows[row][value])
                        {
                            probable[ptr] = new int[2] { row, column };
                            ptr++;
                        }
                    }
                }
                if (ptr == 1)
                {
                    matrix[probable[0][0]][probable[0][1]] = value + 1;
                    Console.Clear();
                    Print_matrix(matrix);
                    for (int v = 0; v < 9; v++)
                    {
                        allowed_cells[probable[0][0]][probable[0][1]][v] = false;
                    }
                    allowed_rows[probable[0][0]][value] = false;
                    allowed_columns[probable[0][1]][value] = false;
                    allowed_in_square[sub_square][value] = false;
                    digits_left[value]--;
                    digits--;
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
                        if (matrix[i][j] != 0) row1++;
                    }
                    else if (i / 3 == 1)
                    {
                        if (matrix[i][j] != 0) row2++;
                    }
                    else
                    {
                        if (matrix[i][j] != 0) row3++;
                    }
                }
            }
            bool solvable;
            if (row1 >= 6)
            {
                if (row2 >= 6) solvable = row3 >= 5;
                else if (row2 == 5) solvable = row3 >= 6;
                else solvable = false;
            }
            else if (row1 == 5)
                solvable = row2 >= 6 && row3 >= 6;
            else solvable = false;

            if (!solvable)
            {
                return false;
            }
        }
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int k = j + 1; k < 9; k++)
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
        while (digits > 0) matrix = Exact(matrix);
        Console.Clear();
        Console.WriteLine("Solved sudoku:");
        Print_matrix(matrix);
    }
}