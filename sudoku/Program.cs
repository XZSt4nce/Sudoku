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
            new int[9] { 5, 8, 6, 0, 0, 7, 0, 9, 0 },
            new int[9] { 2, 0, 9, 0, 0, 0, 0, 7, 3 },
            new int[9] { 0, 0, 1, 0, 0, 9, 0, 0, 5 },
            new int[9] { 8, 0, 0, 0, 9, 0, 4, 6, 0 },
            new int[9] { 4, 0, 3, 6, 0, 5, 9, 0, 8 },
            new int[9] { 0, 9, 7, 0, 8, 0, 0, 0, 1 },
            new int[9] { 1, 0, 0, 7, 0, 0, 2, 0, 0 },
            new int[9] { 3, 7, 0, 0, 0, 0, 5, 0, 6 },
            new int[9] { 0, 2, 0, 8, 0, 0, 7, 1, 4 }
        };
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
        /*int i = 0, j = 0, value, prev_value;
        matrix[i][j] = 10;
        ConsoleKeyInfo key = new ConsoleKeyInfo();
        while (key.Key != ConsoleKey.Enter)
        {
            Console.WriteLine("Put values in Sudoku square.");
            Console.WriteLine("Use the WASD buttons or arrows to move through the cells.");
            Console.WriteLine("To clear the cell, press Backspace");
            Console.WriteLine("To finish filling, press Enter.");
            prev_value = matrix[i][j];
            if (prev_value == 10) prev_value = 0;
            matrix[i][j] = 10;
            Print_matrix(matrix);
            key = Console.ReadKey(true);
            value = Convert.ToInt32(key.KeyChar) - 48;
            if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow)
            {
                matrix[i][j] = prev_value;
                if (i != 0) i--;
                else i = 8;
            }
            if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow)
            {
                matrix[i][j] = prev_value;
                if (i != 8) i++;
                else i = 0;
            }
            if (key.Key == ConsoleKey.D || key.Key == ConsoleKey.RightArrow)
            {
                matrix[i][j] = prev_value;
                if (j != 8) j++;
                else j = 0;
            }
            if (key.Key == ConsoleKey.A || key.Key == ConsoleKey.LeftArrow)
            {
                matrix[i][j] = prev_value;
                if (j != 0) j --;
                else j = 8;
            }
            if (value >= 0 && value < 10)
            {
                matrix[i][j] = value;
                allowed_rows[i][value - 1] = false;
                allowed_columns[j][value - 1] = false;
                allowed_in_square[i / 3 * 3 + j / 3][value - 1] = false;
                if (j == 8)
                {
                    j = 0;
                    i++;
                    i %= 9;
                }
                else j++;
            }
            Console.Clear();
        }
        return matrix;*/
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
                        count = 0;
                        for (int a = i * 3; a < i * 3 + 3; a++)
                        {
                            for (int b = j * 3; b < j * 3 + 3; b++)
                            {
                                if (matrix[a][b] == 0 && allowed_rows[a][value])
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
                                    if (matrix[a][b] == 0 && allowed_rows[a][value])
                                    {
                                        allowed_rows[a][value] = false;
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
                        count = 0;
                        for (int a = i * 3; a < i * 3 + 3; a++)
                        {
                            for (int b = j * 3; b < j * 3 + 3; b++)
                            {
                                if (matrix[b][a] == 0 && allowed_columns[a][value])
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
                                    if (matrix[b][a] == 0 && allowed_columns[a][value])
                                    {
                                        allowed_columns[a][value] = false;
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
                    for (int k = i / 3; k < i / 3 + 3 && not_found; k++)
                    {
                        if (matrix[k][j] == 0)
                        {
                            matrix[k][j] = value + 1;
                            allowed_rows[k][value] = false;
                            allowed_columns[j][value] = false;
                            allowed_cells[k][j][value] = false;
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
                        allowed_rows[i][value] = false;
                        allowed_columns[j][value] = false;
                        allowed_cells[i][j][value] = false;
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
                        allowed_rows[j][value] = false;
                        allowed_columns[i][value] = false;
                        allowed_cells[j][i][value] = false;
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
                    for (int k = i / 3; k < i / 3 + 3 && not_found; k++)
                    {
                        if (matrix[j][k] == 0)
                        {
                            matrix[j][k] = value + 1;
                            allowed_rows[j][value] = false;
                            allowed_columns[k][value] = false;
                            allowed_cells[j][k][value] = false;
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
            for (value = 0; value < 9; value++)
            {
                if (!allowed_in_square[sub_square][value]) continue;
                int[][] probable = new int[9][];
                int ptr = 0;
                for (int row = sub_square / 3 * 3; row < sub_square / 3 * 3 + 3; row++)
                {
                    for (int column = sub_square * 3 % 9; column < sub_square * 3 % 9 + 3; column++)
                    {
                        if (allowed_cells[row][column][value]) 
                        {
                            probable[ptr] = new int[2] { row, column };
                            ptr++;
                        }
                    }
                }
                if (ptr == 1)
                {
                    matrix[probable[0][0]][probable[0][1]] = value + 1;
                    allowed_cells[probable[0][0]][probable[0][1]][value] = false;
                    allowed_rows[probable[0][0]][value] = false;
                    allowed_columns[probable[0][1]][value] = false;
                    allowed_in_square[sub_square][value] = false;
                    digits_left[value]--;
                    digits--;
                }
            }

            count = 0;
            for (int j = 0; j < 9; j++)
            {
                if (allowed_in_square[sub_square][j]) count++;
            }
            if (count == 1)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (allowed_in_square[sub_square][j]) value = j + 1;
                }
                not_found = true;
                for (int j = sub_square / 3 * 3; j < sub_square / 3 * 3 + 3 && not_found; j++)
                {
                    for (int k = sub_square % 3 * 3; k < sub_square % 3 * 3 + 3 && not_found; k++)
                    {
                        if (matrix[j][k] == 0)
                        {
                            matrix[j][k] = value;
                            allowed_cells[j][k][value] = false;
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
        matrix = Exact(matrix);
        matrix = Exact(matrix);
        Console.WriteLine("Solved sudoku:");
        Print_matrix(matrix);
    }
}