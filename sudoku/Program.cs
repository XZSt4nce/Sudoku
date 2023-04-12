using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;

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
    static long k = 1296000;
    static long start = DateTime.Now.ToFileTime() / k;
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
        //int[][] matrix = new int[9][]
        //{
        //    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        //};

        int[][] matrix = new int[9][]
        {
            new int[9] { 0, 0, 5, 3, 0, 0, 0, 0, 0 },
            new int[9] { 8, 0, 0, 0, 0, 0, 0, 2, 0 },
            new int[9] { 0, 7, 0, 0, 1, 0, 5, 0, 0 },
            new int[9] { 4, 0, 0, 0, 0, 5, 3, 0, 0 },
            new int[9] { 0, 1, 0, 0, 7, 0, 0, 0, 6 },
            new int[9] { 0, 0, 3, 2, 0, 0, 0, 8, 0 },
            new int[9] { 0, 6, 0, 5, 0, 0, 0, 0, 9 },
            new int[9] { 0, 0, 4, 0, 0, 0, 0, 3, 0 },
            new int[9] { 0, 0, 0, 0, 0, 9, 7, 0, 0 }
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
                    pen_digits[i / 3 * 3 + j / 3][matrix[i][j] - 1]--;
                    allowed_columns[j][matrix[i][j] - 1] = false;
                    for (int k = 0; k < 9; k++)
                    {
                        allowed_cells[i][j][k] = false;
                        allowed_cells[i][k][matrix[i][j] - 1] = false;
                        allowed_cells[k][j][matrix[i][j] - 1] = false;
                    }
                    digits_left[matrix[i][j] - 1]--;
                    digits--;
                }
            }
        }
        return matrix;
    }
    public static int[][] Solve(int[][] matrix)
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
        for (int i = 0; i < 9; i++)
        {
            for (value = 0; value < 9; value++)
            {
                if (!allowed_rows[i][value])
                {
                    for (int j = 0; j < 9; j++)
                    {
                        allowed_cells[i][j][value] = false;
                        pen_digits[i / 3 + j / 3][value]--;
                    }
                }
                if (!allowed_columns[i][value])
                {
                    for (int j = 0; j < 9; j++)
                    {
                        allowed_cells[j][i][value] = false;
                        pen_digits[j / 3 + i / 3][value]--;
                    }
                }
                if (!allowed_in_square[i][value])
                {
                    for (int a = i / 3 * 3; a < i / 3 * 3 + 3; a++)
                    {
                        for (int b = i % 3 * 3; b < i % 3 * 3 + 3; b++)
                        {
                            allowed_cells[a][b][value] = false;
                        }
                    }
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
                                    if (matrix[a][b] == 0 && allowed_rows[a][value] && allowed_columns[b][value] && allowed_cells[a][b][value])
                                    {
                                        for (int c = 0; c < j * 3; c++) allowed_cells[a][c][value] = false;
                                        for (int c = j * 3 + 3; c < 9; c++) allowed_cells[a][c][value] = false;
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
                                        for (int c = 0; c < j * 3; c++) allowed_cells[c][a][value] = false;
                                        for (int c = j * 3 + 3; c < 9; c++) allowed_cells[c][a][value] = false;
                                        not_found = false;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
            for (int row = 0; row < 9; row++)
            {
                if (allowed_cells[row][0][value] || allowed_cells[row][1][value] || allowed_cells[row][2][value])
                {
                    if (allowed_cells[row][3][value] || allowed_cells[row][4][value] || allowed_cells[row][5][value]) continue;
                    if (allowed_cells[row][6][value] || allowed_cells[row][7][value] || allowed_cells[row][8][value]) continue;
                    for (int a = row / 3 * 3; a < row; a++)
                    {
                        allowed_cells[a][0][value] = false;
                        allowed_cells[a][1][value] = false;
                        allowed_cells[a][2][value] = false;
                    }
                    for (int a = row + 1; a <row / 3 * 3 + 3; a++)
                    {
                        allowed_cells[a][0][value] = false;
                        allowed_cells[a][1][value] = false;
                        allowed_cells[a][2][value] = false;
                    }
                }
                else if (allowed_cells[row][3][value] || allowed_cells[row][4][value] || allowed_cells[row][5][value])
                {
                    if (allowed_cells[row][6][value] || allowed_cells[row][7][value] || allowed_cells[row][8][value]) continue;
                    for (int a = row / 3 * 3; a < row; a++)
                    {
                        allowed_cells[a][3][value] = false;
                        allowed_cells[a][4][value] = false;
                        allowed_cells[a][5][value] = false;
                    }
                    for (int a = row + 1; a < row / 3 * 3 + 3; a++)
                    {
                        allowed_cells[a][3][value] = false;
                        allowed_cells[a][4][value] = false;
                        allowed_cells[a][5][value] = false;
                    }
                }
                else if (allowed_cells[row][6][value] || allowed_cells[row][7][value] || allowed_cells[row][8][value])
                {
                    for (int a = row / 3 * 3; a < row; a++)
                    {
                        allowed_cells[a][6][value] = false;
                        allowed_cells[a][7][value] = false;
                        allowed_cells[a][8][value] = false;
                    }
                    for (int a = row + 1; a < row / 3 * 3 + 3; a++)
                    {
                        allowed_cells[a][6][value] = false;
                        allowed_cells[a][7][value] = false;
                        allowed_cells[a][8][value] = false;
                    }
                }
            }
            for (int column = 0; column < 9; column++)
            {
                if (allowed_cells[0][column][value] || allowed_cells[1][column][value] || allowed_cells[2][column][value])
                {
                    if (allowed_cells[3][column][value] || allowed_cells[4][column][value] || allowed_cells[5][column][value]) continue;
                    if (allowed_cells[6][column][value] || allowed_cells[7][column][value] || allowed_cells[8][column][value]) continue;
                    for (int a = column / 3 * 3; a < column; a++)
                    {
                        allowed_cells[0][a][value] = false;
                        allowed_cells[1][a][value] = false;
                        allowed_cells[2][a][value] = false;
                    }
                    for (int a = column + 1; a < column / 3 * 3 + 3; a++)
                    {
                        allowed_cells[0][a][value] = false;
                        allowed_cells[1][a][value] = false;
                        allowed_cells[2][a][value] = false;
                    }
                }
                else if (allowed_cells[3][column][value] || allowed_cells[4][column][value] || allowed_cells[5][column][value])
                {
                    if (allowed_cells[6][column][value] || allowed_cells[7][column][value] || allowed_cells[8][column][value]) continue;
                    for (int a = column / 3 * 3; a < column; a++)
                    {
                        allowed_cells[3][a][value] = false;
                        allowed_cells[4][a][value] = false;
                        allowed_cells[5][a][value] = false;
                    }
                    for (int a = column + 1; a < column / 3 * 3 + 3; a++)
                    {
                        allowed_cells[3][a][value] = false;
                        allowed_cells[4][a][value] = false;
                        allowed_cells[5][a][value] = false;
                    }
                }
                else if (allowed_cells[6][column][value] || allowed_cells[7][column][value] || allowed_cells[8][column][value])
                {
                    for (int a = column / 3 * 3; a < column; a++)
                    {
                        allowed_cells[6][a][value] = false;
                        allowed_cells[7][a][value] = false;
                        allowed_cells[8][a][value] = false;
                    }
                    for (int a = column + 1; a < column / 3 * 3 + 3; a++)
                    {
                        allowed_cells[6][a][value] = false;
                        allowed_cells[7][a][value] = false;
                        allowed_cells[8][a][value] = false;
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
                            allowed_rows[k][value] = false;
                            allowed_columns[j][value] = false;
                            allowed_cells[k][j][value] = false;
                            for (int v = 0; v < 9; v++) allowed_cells[k][j][v] = false;
                            allowed_in_square[i][value] = false;
                            pen_digits[i][value] = 0;
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
                        allowed_rows[i][value] = false;
                        allowed_columns[j][value] = false;
                        allowed_cells[i][j][value] = false;
                        for (int v = 0; v < 9; v++) allowed_cells[i][j][v] = false;
                        allowed_in_square[i / 3 * 3 + j / 3][value] = false;
                        pen_digits[i / 3 * 3 + j / 3][value] = 0;
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
                        allowed_rows[j][value] = false;
                        allowed_columns[i][value] = false;
                        for (int v = 0; v < 9; v++) allowed_cells[j][i][v] = false;
                        allowed_in_square[j / 3 * 3 + i / 3][value] = false;
                        pen_digits[j / 3 * 3 + i / 3][value] = 0;
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
                            allowed_rows[j][value] = false;
                            allowed_columns[k][value] = false;
                            for (int v = 0; v < 9; v++) allowed_cells[j][k][v] = false;
                            allowed_in_square[i][value] = false;
                            pen_digits[i][value] = 0;
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
                            for (int v = 0; v < 9; v++) allowed_cells[j][k][v] = false;
                            allowed_rows[j][value] = false;
                            allowed_columns[k][value] = false;
                            allowed_in_square[sub_square][value] = false;
                            pen_digits[sub_square][value] = 0;
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
                    for (int v = 0; v < 9; v++) allowed_cells[probable[0][0]][probable[0][1]][v] = false;
                    allowed_rows[probable[0][0]][value] = false;
                    allowed_columns[probable[0][1]][value] = false;
                    allowed_in_square[sub_square][value] = false;
                    pen_digits[sub_square][value] = 0;
                    digits_left[value]--;
                    digits--;
                }
            }
        }
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                int last = 0;
                count = 0;
                for (value = 0; value < 9; value++)
                {
                    if (allowed_cells[i][j][value])
                    {
                        count++;
                        last = value;
                    }
                }
                if (count == 1)
                {
                    matrix[i][j] = last + 1;
                    for (int v = 0; v < 9; v++) allowed_cells[i][j][v] = false;
                    allowed_rows[i][last] = false;
                    allowed_columns[j][last] = false;
                    allowed_in_square[i / 3 * 3 + j / 3][last] = false;
                    pen_digits[i / 3 * 3 + j / 3][last] = 0;
                    digits_left[last]--;
                    digits--;
                }
            }
        }
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                count = 0;
                for (int a = i / 3 * 3; a < i / 3 * 3 + 3; a++)
                {
                    for (int b = i % 3 * 3; b < i % 3 * 3 + 3; b++)
                    {
                        if (allowed_cells[a][b][j]) count++;
                    }
                }
                pen_digits[i][j] = count;
            }
            for (int j = 0; j < 8; j++)
            {
                if (!allowed_in_square[i][j]) continue;
                for (int k = j + 1; k < 9; k++)
                {
                    if (pen_digits[i][j] == 2
                        && pen_digits[i][k] == 2
                        && allowed_in_square[i][k])
                    {
                        bool same = true;
                        for (int a = i / 3 * 3; a < i / 3 * 3 + 3 && same; a++)
                        {
                            for (int b = i % 3 * 3; b < i % 3 * 3 + 3 && same; b++)
                            {
                                if (allowed_cells[a][b][j])
                                {
                                    if (!allowed_cells[a][b][k]) same = false;
                                }
                                else if (allowed_cells[a][b][k]) same = false;
                            }
                        }
                        if (same)
                        {
                            for (int a = i / 3 * 3; a < i / 3 * 3 + 3 && same; a++)
                            {
                                for (int b = i % 3 * 3; b < i % 3 * 3 + 3 && same; b++)
                                {
                                    if (allowed_cells[a][b][j])
                                    {
                                        for (int c = 0; c < 9; c++)
                                        {
                                            if (c != j && c != k) allowed_cells[a][b][c] = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return matrix;
    }
    public static bool Is_not_correct (int[][] matrix)
    {
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int z = y + 1; z < 9; z++)
                {
                    if (matrix[x][y] == 0) continue;
                    if (matrix[x][y] == matrix[x][z]) return false;
                    if (matrix[y][x] == matrix[z][x]) return false;
                }
            }
        }
        for (int sub_square = 0; sub_square < 9; sub_square++)
        {
            for (int x = sub_square / 3 * 3; x < sub_square / 3 * 3 + 2; x++)
            {
                for (int y = sub_square % 3 * 3; y < sub_square % 3 * 3 + 2; y++)
                {
                    for (int a = x; a < sub_square / 3 * 3 + 3; a++)
                    {
                        for (int b = y; b < sub_square % 3 * 3 + 3; b++)
                        {
                            if (!(x == a && y == b) && matrix[x][y] == matrix[a][b] && matrix[x][y] != 0) 
                                return false;
                        }
                    }
                }
            }
        }
        return true;
    }
    private static void Main()
    {
        Dictionary< int, Dictionary<string, object> > save_points = new();
        int points = 0;
        int[][] matrix = Input(), saved_matrix = new int[9][]
        {
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9]
        }, saved_pen_digits = new int[9][]
        {
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9]
        };
        int tmp_digits;
        bool saved = false, not_found;
        bool[][][] saved_allowed_cells = new bool[9][][]
        {
            new bool[9][]
            {
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9]
            },
            new bool[9][]
            {
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9]
            },
            new bool[9][]
            {
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9]
            },
            new bool[9][]
            {
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9]
            },
            new bool[9][]
            {
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9]
            },
            new bool[9][]
            {
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9]
            },
            new bool[9][]
            {
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9]
            },
            new bool[9][]
            {
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9]
            },
            new bool[9][]
            {
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9],
                new bool[9]
            }
        };
        bool[][] saved_allowed_columns = new bool[9][]
        {
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9]
        }, saved_allowed_in_square = new bool[9][]
        {
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9]
        }, saved_allowed_rows = new bool[9][]
        {
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9],
            new bool[9]
        };
        int[] saved_digits_left = new int[9];
        int saved_digits = 0, x, y, attempt = 0, count;
        if (digits > 64)
        {
            Console.WriteLine("The square is unsolvable");
            Environment.Exit(0);
        }
        if (Is_not_correct(matrix))
        {
            Console.WriteLine("The square is unsolvable");
            Environment.Exit(0);
        }
        Stopwatch stopwatch = new();
        stopwatch.Start();
        while (digits > 0 && stopwatch.ElapsedMilliseconds < 300)
        {
            tmp_digits = digits;
            matrix = Solve(matrix);
            if (digits == tmp_digits)
            {
                attempt++;
                if (attempt == 3)
                {
                    attempt = 0;
                    if (saved)
                    {
                        Dictionary<string, object> save_point = save_points[--points];
                        saved_allowed_cells = (bool[][][])save_point["saved_allowed_cells"];
                        saved_allowed_columns = (bool[][])save_point["saved_allowed_columns"];
                        saved_allowed_in_square = (bool[][])save_point["saved_allowed_in_square"];
                        saved_allowed_rows = (bool[][])save_point["saved_allowed_rows"];
                        saved_matrix = (int[][])save_point["saved_matrix"];
                        saved_pen_digits = (int[][])save_point["saved_pen_digits"];
                        try
                        {
                            x = (int)save_point["x"];
                            y = (int)save_point["y"];
                            for (int a = 0; a < 9; a++)
                            {
                                for (int b = 0; b < 9; b++)
                                {
                                    Array.Copy(saved_allowed_cells[a][b], allowed_cells[a][b], 9);
                                }
                                Array.Copy(saved_allowed_columns[a], allowed_columns[a], 9);
                                Array.Copy(saved_allowed_in_square[a], allowed_in_square[a], 9);
                                Array.Copy(saved_allowed_rows[a], allowed_rows[a], 9);
                                Array.Copy(saved_matrix[a], matrix[a], 9);
                                Array.Copy(saved_pen_digits[a], pen_digits[a], 9);
                            }
                            Array.Copy(saved_digits_left, digits_left, 9);
                            digits = saved_digits;
                            saved = points > 0;
                            if (x < 9 && y < 9)
                            {
                                if (save_point.Keys.Contains("value"))
                                {
                                    allowed_cells[x][y][(int)save_point["value"]] = false;
                                }
                                else
                                {
                                    for (int value = 0; value < 9; value++)
                                    {
                                        if (allowed_cells[x][y][value])
                                        {
                                            allowed_cells[x][y][value] = false;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        catch (System.Collections.Generic.KeyNotFoundException)
                        {
                            Console.WriteLine("The square is unsolvable");
                            Environment.Exit(0);
                        }
                        save_points.Remove(points);
                    }
                    else
                    {
                        for (int a = 0; a < 9; a++)
                        {
                            for (int b = 0; b < 9; b++)
                            {
                                Array.Copy(allowed_cells[a][b], saved_allowed_cells[a][b], 9);
                            }
                            Array.Copy(allowed_columns[a], saved_allowed_columns[a], 9);
                            Array.Copy(allowed_in_square[a], saved_allowed_in_square[a], 9);
                            Array.Copy(allowed_rows[a], saved_allowed_rows[a], 9);
                            Array.Copy(matrix[a], saved_matrix[a], 9);
                            Array.Copy(pen_digits[a], saved_pen_digits[a], 9);
                        }

                        Array.Copy(digits_left, saved_digits_left, 9);
                        saved_digits = digits;
                        Dictionary<string, object> save_point = new()
                        {
                            { "saved_allowed_cells", saved_allowed_cells },
                            { "saved_allowed_columns", saved_allowed_columns },
                            { "saved_allowed_in_square", saved_allowed_in_square },
                            { "saved_allowed_rows", saved_allowed_rows },
                            { "saved_matrix", saved_matrix },
                            { "saved_pen_digits", saved_pen_digits },
                            { "saved_digits_left", saved_digits_left },
                            { "saved_digits", saved_digits }
                        };
                        saved = true;
                        not_found = true;
                        for (x = 0; x < 9 && not_found; x++)
                        {
                            for (y = 0; y < 9 && not_found; y++)
                            {
                                count = 0;
                                for (int value = 0; value < 9; value++)
                                {
                                    if (allowed_cells[x][y][value]) count++;
                                }
                                if (count == 2)
                                {
                                    save_point.Add("x", x);
                                    save_point.Add("y", y);
                                    not_found = false;
                                    for (int value = 0; value < 9; value++)
                                    {
                                        if (allowed_cells[x][y][value])
                                        {
                                            matrix[x][y] = value + 1;
                                            for (int v = 0; v < 9; v++) allowed_cells[x][y][v] = false;
                                            allowed_rows[x][value] = false;
                                            allowed_columns[y][value] = false;
                                            allowed_in_square[x / 3 * 3 + y / 3][value] = false;
                                            pen_digits[x / 3 * 3 + y / 3][value] = 0;
                                            digits_left[value]--;
                                            digits--;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        if (save_point.ContainsKey("x"))
                            save_points.Add(points++, save_point);
                        else
                        {
                            not_found = true;
                            for (int value = 0; value < 9 && not_found; value++)
                            {
                                for (int sub_square = 0; sub_square < 9 && not_found; sub_square++)
                                {
                                    count = 0;
                                    for (x = sub_square / 3 * 3; x < sub_square / 3 * 3 + 3; x++)
                                    {
                                        for (y = sub_square % 3 * 3; y < sub_square % 3 * 3 + 3; y++)
                                        {
                                            if (allowed_cells[x][y][value]) count++;
                                        }
                                    }
                                    if (count == 2)
                                    {
                                        for (x = sub_square / 3 * 3; x < sub_square / 3 * 3 + 3 && not_found; x++)
                                        {
                                            for (y = sub_square % 3 * 3; y < sub_square % 3 * 3 + 3 && not_found; y++)
                                            {
                                                if (allowed_cells[x][y][value])
                                                {
                                                    save_point.Add("x", x);
                                                    save_point.Add("y", y);
                                                    matrix[x][y] = value + 1;
                                                    for (int v = 0; v < 9; v++) allowed_cells[x][y][v] = false;
                                                    allowed_rows[x][value] = false;
                                                    allowed_columns[y][value] = false;
                                                    allowed_in_square[x / 3 * 3 + y / 3][value] = false;
                                                    pen_digits[x / 3 * 3 + y / 3][value] = 0;
                                                    digits_left[value]--;
                                                    digits--;
                                                    not_found = false;
                                                }
                                            }
                                        }
                                        save_point.Add("value", value);
                                    }
                                }
                            }
                            save_points.Add(points++, save_point);
                        }
                    }
                }
            }
            else attempt = 0;
        }
        stopwatch.Stop();
        if (stopwatch.ElapsedMilliseconds >= 300)
        {
            Console.WriteLine("The square is unsolvable");
            Environment.Exit(0);
        }
        Console.WriteLine("Solved sudoku:");
        Print_matrix(matrix);
        Environment.Exit(0);
    }
}