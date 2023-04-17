using System.Collections.Generic;
using System;
using System.Diagnostics;

class SudokuSolver
{
    private bool[][][] m_allowedCells = new bool[9][][]
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
    private bool[][] m_allowedRows = new bool[9][]
    {
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
    private bool[][] m_allowedColumns = new bool[9][]
    {
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
    private bool[][] m_allowedInSubSquare = new bool[9][]
    {
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
    private bool m_saved = false;
    //private int[][] m_matrix = new int[9][]
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
    private int[][] m_matrix = new int[9][]
    {
        new int[9] { 0, 0, 0, 0, 0, 3, 0, 7, 4 },
        new int[9] { 8, 0, 0, 6, 0, 0, 0, 0, 0 },
        new int[9] { 0, 0, 0, 0, 0, 0, 0, 9, 0 },
        new int[9] { 0, 6, 0, 8, 0, 0, 2, 0, 0 },
        new int[9] { 0, 0, 9, 0, 0, 0, 0, 0, 0 },
        new int[9] { 0, 0, 0, 0, 5, 0, 0, 0, 0 },
        new int[9] { 2, 8, 0, 0, 0, 0, 6, 0, 0 },
        new int[9] { 0, 0, 0, 0, 0, 9, 1, 0, 0 },
        new int[9] { 0, 0, 0, 0, 7, 0, 0, 0, 0 }
    };
    private int[][] m_penDigits = new int[9][]
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
    private int[] m_digitsLeft = new int[9] { 9, 9, 9, 9, 9, 9, 9, 9, 9 };
    private int m_allDigits = 81, m_points = 0;
    Dictionary<int, Dictionary<string, object>> m_savePoints = new Dictionary<int, Dictionary<string, object>>();

    public SudokuSolver() { }

    public bool[][][] AllowedCells
    {
        get { return m_allowedCells; }
    }

    public bool[][] AllowedRows
    {
        get { return m_allowedRows; }
    }

    public bool[][] AllowedColumns
    {
        get { return m_allowedColumns; }
    }

    public bool[][] AllowedInSubSquare
    {
        get { return m_allowedInSubSquare; }
    }

    public bool Saved
    {
        get { return m_saved; }
    }

    public int[][] Matrix
    {
        get { return m_matrix; }
    }
    
    public int[][] PenDigits
    {
        get { return m_penDigits; }
    }

    public int[] DigitsLeft
    {
        get { return m_digitsLeft; }
    }

    public int AllDigits
    {
        get { return m_allDigits; }
    }

    public int Points
    {
        get { return m_points; }
    }

    public Dictionary<int, Dictionary<string, object>> SavePoints
    {
        get { return m_savePoints; }
    }

    public void PrintMatrix()
    {
        int value;
        Console.WriteLine("=====================================");
        for (int i = 0; i < 9; i++)
        {
            Console.Write("▌ ");
            for (int j = 0; j < 9; j++)
            {
                value = m_matrix[i][j];
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

    public void Input()
    {
        int value, row_index = 0, column_index = 0, previous_value = 0;
        m_matrix[row_index][column_index] = 10;
        ConsoleKeyInfo key = new ConsoleKeyInfo();
        while (key.Key != ConsoleKey.Enter)
        {
            Console.WriteLine("Put values in Sudoku square.");
            Console.WriteLine("Use the WASD buttons or arrows to move through the cells.");
            Console.WriteLine("To clear the cell, press Backspace");
            Console.WriteLine("To finish filling, press Enter.");
            previous_value = m_matrix[row_index][column_index];
            if (previous_value == 10) previous_value = 0;
            m_matrix[row_index][column_index] = 10;
            PrintMatrix();
            Console.CursorVisible = false;
            key = Console.ReadKey(true);
            Console.CursorVisible = true;
            value = Convert.ToInt32(key.KeyChar) - 48;
            if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow)
            {
                m_matrix[row_index][column_index] = previous_value;
                if (row_index != 0) row_index--;
                else row_index = 8;
            }
            if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow)
            {
                m_matrix[row_index][column_index] = previous_value;
                if (row_index != 8) row_index++;
                else row_index = 0;
            }
            if (key.Key == ConsoleKey.D || key.Key == ConsoleKey.RightArrow)
            {
                m_matrix[row_index][column_index] = previous_value;
                if (column_index != 8) column_index++;
                else column_index = 0;
            }
            if (key.Key == ConsoleKey.A || key.Key == ConsoleKey.LeftArrow)
            {
                m_matrix[row_index][column_index] = previous_value;
                if (column_index != 0) column_index--;
                else column_index = 8;
            }
            if (value >= 0 && value < 10)
            {
                m_matrix[row_index][column_index] = value;
                if (column_index == 8)
                {
                    column_index = 0;
                    row_index++;
                    row_index %= 9;
                }
                else column_index++;
            }
            Console.Clear();
        }
        m_matrix[row_index][column_index] = previous_value;
        for (int row = 0; row < 9; row++)
        {
            for (int column = 0; column < 9; column++)
            {
                value = m_matrix[row][column] - 1;
                if (value >= 0)
                {
                    m_allowedRows[row][value] = false;
                    m_allowedInSubSquare[row / 3 * 3 + column / 3][value] = false;
                    m_penDigits[row / 3 * 3 + column / 3][value] = 0;
                    m_allowedColumns[column][value] = false;
                    for (int values = 0; values < 9; values++)
                    {
                        m_allowedCells[row][column][values] = false;
                        m_allowedCells[row][values][value] = false;
                        m_allowedCells[values][column][value] = false;
                    }
                    m_digitsLeft[value]--;
                    m_allDigits--;
                }
            }
        }
    }

    public void SetPens()
    {
        int count;
        for (int sub_square = 0; sub_square < 9; sub_square++)
        {
            for (int value = 0; value < 9; value++)
            {
                if (PenDigits[sub_square][value] == 0) continue;
                count = 0;
                for (int row = sub_square / 3 * 3; row < sub_square / 3 * 3 + 3; row++)
                {
                    for (int column = sub_square % 3 * 3; column < sub_square % 3 * 3 + 3; column++)
                    {
                        if (AllowedCells[row][column][value])
                        {
                            count++;
                        }
                    }
                }
                m_penDigits[sub_square][value] = count;
            }
        }
    }

    public void ProhibitNullNumbers()
    {
        for (int value = 0; value < 9; value++)
        {
            if (m_digitsLeft[value] == 0)
            {
                for (int i = 0; i < 9; i++)
                {
                    m_allowedInSubSquare[i][value] = false;
                    m_allowedColumns[i][value] = false;
                    m_allowedRows[i][value] = false;
                    m_penDigits[i][value] = 0;
                    for (int j = 0; j < 9; j++)
                    {
                        m_allowedCells[i][j][value] = false;
                    }
                }
            }
        }
    }

    public void ProhibitCells()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int value = 0; value < 9; value++)
            {
                if (!m_allowedInSubSquare[i][value])
                {
                    for (int a = i / 3 * 3; a < i / 3 * 3 + 3; a++)
                    {
                        for (int b = i % 3 * 3; b < i % 3 * 3 + 3; b++)
                        {
                            m_allowedCells[a][b][value] = false;
                        }
                    }
                }
            }
            for (int value = 0; value < 9; value++)
            {
                if (!m_allowedRows[i][value])
                {
                    for (int j = 0; j < 9; j++)
                    {
                        m_allowedCells[i][j][value] = false;
                    }
                }
                if (!m_allowedColumns[i][value])
                {
                    for (int j = 0; j < 9; j++)
                    {
                        m_allowedCells[j][i][value] = false;
                    }
                }
            }
        }
    }

    public void ProhibitOneChildRowAndColumn()
    {
        bool not_found;
        int count;
        for (int value = 0; value < 9; value++)
        {
            for (int i = 0; i < 3; i++)
            {
                if (m_allowedRows[i * 3][value] && m_allowedRows[i * 3 + 1][value] ||
                    m_allowedRows[i * 3][value] && m_allowedRows[i * 3 + 2][value] ||
                    m_allowedRows[i * 3 + 1][value] && m_allowedRows[i * 3 + 2][value])
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (!m_allowedInSubSquare[i * 3 + j][value]) continue;
                        count = 0;
                        for (int a = i * 3; a < i * 3 + 3; a++)
                        {
                            for (int b = j * 3; b < j * 3 + 3; b++)
                            {
                                if (m_matrix[a][b] == 0 && m_allowedRows[a][value] && m_allowedColumns[b][value] && m_allowedCells[a][b][value])
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
                                    if (m_matrix[a][b] == 0 && m_allowedRows[a][value] && m_allowedColumns[b][value] && m_allowedCells[a][b][value])
                                    {
                                        for (int c = 0; c < j * 3; c++) m_allowedCells[a][c][value] = false;
                                        for (int c = j * 3 + 3; c < 9; c++) m_allowedCells[a][c][value] = false;
                                        not_found = false;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
                if (m_allowedColumns[i * 3][value] && m_allowedColumns[i * 3 + 1][value] ||
                    m_allowedColumns[i * 3][value] && m_allowedColumns[i * 3 + 2][value] ||
                    m_allowedColumns[i * 3 + 1][value] && m_allowedColumns[i * 3 + 2][value])
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (!m_allowedInSubSquare[j * 3 + i][value]) continue;
                        count = 0;
                        for (int a = i * 3; a < i * 3 + 3; a++)
                        {
                            for (int b = j * 3; b < j * 3 + 3; b++)
                            {
                                if (m_matrix[b][a] == 0 && m_allowedColumns[a][value] && m_allowedRows[b][value] && m_allowedCells[b][a][value])
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
                                    if (m_matrix[b][a] == 0 && m_allowedColumns[a][value] && m_allowedRows[b][value] && m_allowedCells[b][a][value])
                                    {
                                        for (int c = 0; c < j * 3; c++) m_allowedCells[c][a][value] = false;
                                        for (int c = j * 3 + 3; c < 9; c++) m_allowedCells[c][a][value] = false;
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
    }

    public void ExcludeValuesInRowsAndColumns()
    {
        for (int value = 0; value < 9; value++)
        {
            for (int row = 0; row < 9; row++)
            {
                if (m_allowedCells[row][0][value] || m_allowedCells[row][1][value] || m_allowedCells[row][2][value])
                {
                    if (m_allowedCells[row][3][value] || m_allowedCells[row][4][value] || m_allowedCells[row][5][value]) continue;
                    if (m_allowedCells[row][6][value] || m_allowedCells[row][7][value] || m_allowedCells[row][8][value]) continue;
                    for (int a = row / 3 * 3; a < row; a++)
                    {
                        m_allowedCells[a][0][value] = false;
                        m_allowedCells[a][1][value] = false;
                        m_allowedCells[a][2][value] = false;
                    }
                    for (int a = row + 1; a < row / 3 * 3 + 3; a++)
                    {
                        m_allowedCells[a][0][value] = false;
                        m_allowedCells[a][1][value] = false;
                        m_allowedCells[a][2][value] = false;
                    }
                }
                else if (m_allowedCells[row][3][value] || m_allowedCells[row][4][value] || m_allowedCells[row][5][value])
                {
                    if (m_allowedCells[row][6][value] || m_allowedCells[row][7][value] || m_allowedCells[row][8][value]) continue;
                    for (int a = row / 3 * 3; a < row; a++)
                    {
                        m_allowedCells[a][3][value] = false;
                        m_allowedCells[a][4][value] = false;
                        m_allowedCells[a][5][value] = false;
                    }
                    for (int a = row + 1; a < row / 3 * 3 + 3; a++)
                    {
                        m_allowedCells[a][3][value] = false;
                        m_allowedCells[a][4][value] = false;
                        m_allowedCells[a][5][value] = false;
                    }
                }
                else if (m_allowedCells[row][6][value] || m_allowedCells[row][7][value] || m_allowedCells[row][8][value])
                {
                    for (int a = row / 3 * 3; a < row; a++)
                    {
                        m_allowedCells[a][6][value] = false;
                        m_allowedCells[a][7][value] = false;
                        m_allowedCells[a][8][value] = false;
                    }
                    for (int a = row + 1; a < row / 3 * 3 + 3; a++)
                    {
                        m_allowedCells[a][6][value] = false;
                        m_allowedCells[a][7][value] = false;
                        m_allowedCells[a][8][value] = false;
                    }
                }
            }
            for (int column = 0; column < 9; column++)
            {
                if (m_allowedCells[0][column][value] || m_allowedCells[1][column][value] || m_allowedCells[2][column][value])
                {
                    if (m_allowedCells[3][column][value] || m_allowedCells[4][column][value] || m_allowedCells[5][column][value]) continue;
                    if (m_allowedCells[6][column][value] || m_allowedCells[7][column][value] || m_allowedCells[8][column][value]) continue;
                    for (int a = column / 3 * 3; a < column; a++)
                    {
                        m_allowedCells[0][a][value] = false;
                        m_allowedCells[1][a][value] = false;
                        m_allowedCells[2][a][value] = false;
                    }
                    for (int a = column + 1; a < column / 3 * 3 + 3; a++)
                    {
                        m_allowedCells[0][a][value] = false;
                        m_allowedCells[1][a][value] = false;
                        m_allowedCells[2][a][value] = false;
                    }
                }
                else if (m_allowedCells[3][column][value] || m_allowedCells[4][column][value] || m_allowedCells[5][column][value])
                {
                    if (m_allowedCells[6][column][value] || m_allowedCells[7][column][value] || m_allowedCells[8][column][value]) continue;
                    for (int a = column / 3 * 3; a < column; a++)
                    {
                        m_allowedCells[3][a][value] = false;
                        m_allowedCells[4][a][value] = false;
                        m_allowedCells[5][a][value] = false;
                    }
                    for (int a = column + 1; a < column / 3 * 3 + 3; a++)
                    {
                        m_allowedCells[3][a][value] = false;
                        m_allowedCells[4][a][value] = false;
                        m_allowedCells[5][a][value] = false;
                    }
                }
                else if (m_allowedCells[6][column][value] || m_allowedCells[7][column][value] || m_allowedCells[8][column][value])
                {
                    for (int a = column / 3 * 3; a < column; a++)
                    {
                        m_allowedCells[6][a][value] = false;
                        m_allowedCells[7][a][value] = false;
                        m_allowedCells[8][a][value] = false;
                    }
                    for (int a = column + 1; a < column / 3 * 3 + 3; a++)
                    {
                        m_allowedCells[6][a][value] = false;
                        m_allowedCells[7][a][value] = false;
                        m_allowedCells[8][a][value] = false;
                    }
                }
            }
        }
    }

    public void RemainingInSubSquare()
    {
        int count, value = 0;
        for (int sub_square = 0; sub_square < 9; sub_square++)
        {
            count = 0;
            for (int values = 0; values < 9; values++)
            {
                if (m_allowedInSubSquare[sub_square][values])
                {
                    count++;
                    value = values;
                }
            }
            if (count == 1)
            {
                for (int row = sub_square / 3 * 3; row < sub_square / 3 * 3 + 3; row++)
                {
                    for (int column = sub_square % 3 * 3; column < sub_square % 3 * 3 + 3; column++)
                    {
                        if (m_matrix[row][column] == 0)
                        {
                            m_matrix[row][column] = value + 1;
                            m_allowedRows[row][value] = false;
                            m_allowedColumns[column][value] = false;
                            m_allowedCells[row][column][value] = false;
                            for (int values = 0; values < 9; values++) m_allowedCells[row][column][values] = false;
                            m_allowedInSubSquare[sub_square][value] = false;
                            m_penDigits[sub_square][value] = 0;
                            m_digitsLeft[value]--;
                            m_allDigits--;
                            break;
                        }
                    }
                }
            }
        }
    }

    public void RemainingInRow()
    {
        int count, value = 0;
        for (int row = 0; row < 9; row++)
        {
            count = 0;
            for (int values = 0; values < 9; values++)
            {
                if (m_allowedRows[row][values])
                {
                    count++;
                    value = values;
                }
            }
            if (count == 1)
            {
                for (int column = 0; column < 9; column++)
                {
                    if (m_matrix[row][column] == 0)
                    {
                        m_matrix[row][column] = value + 1;
                        m_allowedRows[row][value] = false;
                        m_allowedColumns[column][value] = false;
                        m_allowedCells[row][column][value] = false;
                        for (int values = 0; values < 9; values++) m_allowedCells[row][column][values] = false;
                        m_allowedInSubSquare[row / 3 * 3 + column / 3][value] = false;
                        m_penDigits[row / 3 * 3 + column / 3][value] = 0;
                        m_digitsLeft[value]--;
                        m_allDigits--;
                        break;
                    }
                }
            }
        }
    }

    public void RemainingInColumn()
    {
        int count, value = 0;
        for (int column = 0; column < 9; column++)
        {
            count = 0;
            for (int values = 0; values < 9; values++)
            {
                if (m_allowedColumns[column][values])
                {
                    count++;
                    value = values;
                }
            }
            if (count == 1)
            {
                for (int row = 0; row < 9; row++)
                {
                    if (m_matrix[row][column] == 0)
                    {
                        m_matrix[row][column] = value + 1;
                        m_allowedRows[row][value] = false;
                        m_allowedColumns[column][value] = false;
                        for (int values = 0; values < 9; values++) m_allowedCells[row][column][values] = false;
                        m_allowedInSubSquare[row / 3 * 3 + column / 3][value] = false;
                        m_penDigits[row / 3 * 3 + column / 3][value] = 0;
                        m_digitsLeft[value]--;
                        m_allDigits--;
                        break;
                    }
                }
            }
        }
    }

    public void RemainingInCell()
    {
        int count, value = 0;
        for (int row = 0; row < 9; row++)
        {
            for (int column = 0; column < 9; column++)
            {
                count = 0;
                for (int values = 0; values < 9; values++)
                {
                    if (AllowedCells[row][column][values])
                    {
                        count++;
                        value = values;
                    }
                }
                if (count == 1)
                {
                    m_matrix[row][column] = value + 1;
                    m_allowedRows[row][value] = false;
                    m_allowedColumns[column][value] = false;
                    for (int values = 0; values < 9; values++) m_allowedCells[row][column][values] = false;
                    m_allowedInSubSquare[row / 3 * 3 + column / 3][value] = false;
                    m_penDigits[row / 3 * 3 + column / 3][value] = 0;
                    m_digitsLeft[value]--;
                    m_allDigits--;
                }
            }
        }
    }

    public void LastInSubSquare()
    {
        for (int sub_square = 0; sub_square < 9; sub_square++)
        {
            for (int value = 0; value < 9; value++)
            {
                if (m_allowedInSubSquare[sub_square][value])
                {
                    if (m_penDigits[sub_square][value] == 1)
                    {
                        bool not_found = true;
                        int row = 0, column = 0;
                        for (row = sub_square / 3 * 3; row < sub_square / 3 * 3 + 3 && not_found; row++)
                        {
                            for (column = sub_square % 3 * 3; column < sub_square % 3 * 3 + 3 && not_found; column++)
                            {
                                if (m_allowedCells[row][column][value]) not_found = false;
                            }
                        }
                        row--; column--;
                        m_matrix[row][column] = value + 1;
                        for (int values = 0; values < 9; values++) m_allowedCells[row][column][values] = false;
                        m_allowedRows[row][value] = false;
                        m_allowedColumns[column][value] = false;
                        m_allowedInSubSquare[sub_square][value] = false;
                        m_penDigits[sub_square][value] = 0;
                        m_digitsLeft[value]--;
                        m_allDigits--;
                    }
                }
            }
        }
    }

    public void LeaveTwoPensInTheSubSquare()
    {
        bool same_cells;
        for (int sub_square = 0; sub_square < 9; sub_square++)
        {
            for (int first_value = 0; first_value < 8; first_value++)
            {
                if (m_allowedInSubSquare[sub_square][first_value])
                {
                    for (int second_value = first_value + 1; second_value < 9; second_value++)
                    {
                        if (m_penDigits[sub_square][first_value] == 2
                            && m_penDigits[sub_square][second_value] == 2
                            && m_allowedInSubSquare[sub_square][second_value])
                        {
                            same_cells = true;
                            for (int row = sub_square / 3 * 3; row < sub_square / 3 * 3 + 3 && same_cells; row++)
                            {
                                for (int column = sub_square % 3 * 3; column < sub_square % 3 * 3 + 3 && same_cells; column++)
                                {
                                    if (m_allowedCells[row][column][first_value])
                                    {
                                        if (!m_allowedCells[row][column][second_value]) same_cells = false;
                                    }
                                    else if (m_allowedCells[row][column][second_value]) same_cells = false;
                                }
                            }
                            if (same_cells)
                            {
                                for (int a = sub_square / 3 * 3; a < sub_square / 3 * 3 + 3 && same_cells; a++)
                                {
                                    for (int b = sub_square % 3 * 3; b < sub_square % 3 * 3 + 3 && same_cells; b++)
                                    {
                                        if (m_allowedCells[a][b][first_value])
                                        {
                                            for (int c = 0; c < 9; c++)
                                            {
                                                if (c != first_value && c != second_value) m_allowedCells[a][b][c] = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public bool IsNotCorrect()
    {
        for (int row = 0; row < 9; row++)
        {
            for (int first_column = 0; first_column < 8; first_column++)
            {
                for (int second_column = first_column + 1; second_column < 9; second_column++)
                {
                    if (m_matrix[row][first_column] == m_matrix[row][second_column] &&
                        m_matrix[row][first_column] != 0)
                    {
                        return true;
                    }
                    if (m_matrix[first_column][row] == m_matrix[second_column][row] &&
                        m_matrix[first_column][row] != 0) 
                    { 
                        return true; 
                    }
                }
            }
        }
        for (int sub_square = 0; sub_square < 9; sub_square++)
        {
            for (int first_row = sub_square / 3 * 3; first_row < sub_square / 3 * 3 + 2; first_row++)
            {
                for (int first_column = sub_square % 3 * 3; first_column < sub_square % 3 * 3 + 2; first_column++)
                {
                    for (int second_row = first_row; second_row < sub_square / 3 * 3 + 3; second_row++)
                    {
                        for (int second_column = first_column; second_column < sub_square % 3 * 3 + 3; second_column++)
                        {
                            if (!(first_row == second_row && first_column == second_column) &&
                                m_matrix[first_row][first_column] == m_matrix[second_row][second_column] &&
                                m_matrix[first_row][first_column] != 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    public void Savepoint()
    {
        int x, y;
        if (Saved && IsNotCorrect())
        {
            Dictionary<string, object> save_point = m_savePoints[--m_points];
            bool[][][] saved_allowed_cells = (bool[][][])save_point["saved_allowed_cells"];
            bool[][] saved_allowed_columns = (bool[][])save_point["saved_allowed_columns"];
            bool[][] saved_allowed_in_sub_square = (bool[][])save_point["saved_allowed_in_sub_square"];
            bool[][] saved_allowed_rows = (bool[][])save_point["saved_allowed_rows"];
            int[][] saved_matrix = (int[][])save_point["saved_matrix"];
            int[][] saved_pen_digits = (int[][])save_point["saved_pen_digits"];
            int[] saved_digits_left = (int[])save_point["saved_digits_left"];
            int saved_digits = (int)save_point["saved_digits"];
            try
            {
                x = (int)save_point["x"];
                y = (int)save_point["y"];
                for (int a = 0; a < 9; a++)
                {
                    for (int b = 0; b < 9; b++)
                    {
                        Array.Copy(saved_allowed_cells[a][b], m_allowedCells[a][b], 9);
                    }
                    Array.Copy(saved_allowed_columns[a], m_allowedColumns[a], 9);
                    Array.Copy(saved_allowed_in_sub_square[a], m_allowedInSubSquare[a], 9);
                    Array.Copy(saved_allowed_rows[a], m_allowedRows[a], 9);
                    Array.Copy(saved_matrix[a], m_matrix[a], 9);
                    Array.Copy(saved_pen_digits[a], m_penDigits[a], 9);
                }
                Array.Copy(saved_digits_left, m_digitsLeft, 9);
                m_allDigits = saved_digits;
                m_saved = m_points > 0;
                if (x < 9 && y < 9)
                {
                    for (int value = 0; value < 9; value++)
                    {
                        if (m_allowedCells[x][y][value])
                        {
                            m_allowedCells[x][y][value] = false;
                            break;
                        }
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("The square is unsolvable");
                Environment.Exit(0);
            }
            m_savePoints.Remove(m_points);
        }
        else
        {
            Dictionary<string, object> save_point = new Dictionary<string, object>()
            {
                { "saved_allowed_cells", new bool[9][][] },
                { "saved_allowed_columns", new bool[9][] },
                { "saved_allowed_in_sub_square", new bool[9][] },
                { "saved_allowed_rows", new bool[9][] },
                { "saved_matrix", new int[9][] },
                { "saved_pen_digits", new int[9][] },
                { "saved_digits_left", new int[9] },
                { "saved_digits", m_allDigits }
            };
            for (int a = 0; a < 9; a++)
            {
                ((bool[][][])save_point["saved_allowed_cells"])[a] = new bool[9][];
                ((bool[][])save_point["saved_allowed_columns"])[a] = new bool[9];
                ((bool[][])save_point["saved_allowed_in_sub_square"])[a] = new bool[9];
                ((bool[][])save_point["saved_allowed_rows"])[a] = new bool[9];
                ((int[][])save_point["saved_matrix"])[a] = new int[9];
                ((int[][])save_point["saved_pen_digits"])[a] = new int[9];
                for (int b = 0; b < 9; b++)
                {
                    ((bool[][][])save_point["saved_allowed_cells"])[a][b] = new bool[9];
                    for (int c = 0; c < 9; c++)
                    {
                        ((bool[][][])save_point["saved_allowed_cells"])[a][b][c] = m_allowedCells[a][b][c];
                    }
                    ((bool[][])save_point["saved_allowed_columns"])[a][b] = m_allowedColumns[a][b];
                    ((bool[][])save_point["saved_allowed_in_sub_square"])[a][b] = m_allowedInSubSquare[a][b];
                    ((bool[][])save_point["saved_allowed_rows"])[a][b] = m_allowedRows[a][b];
                    ((int[][])save_point["saved_matrix"])[a][b] = m_matrix[a][b];
                    ((int[][])save_point["saved_pen_digits"])[a][b] = m_penDigits[a][b];
                }
                ((int[])save_point["saved_digits_left"])[a] = m_digitsLeft[a];
            }
            bool not_found = true;
            for (x = 0; x < 9 && not_found; x++)
            {
                for (y = 0; y < 9 && not_found; y++)
                {
                    for (int value = 0; value < 9 && not_found; value++)
                    {
                        if (m_allowedCells[x][y][value])
                        {
                            save_point.Add("x", x);
                            save_point.Add("y", y);
                            m_matrix[x][y] = value + 1;
                            for (int v = 0; v < 9; v++) m_allowedCells[x][y][v] = false;
                            m_allowedRows[x][value] = false;
                            m_allowedColumns[y][value] = false;
                            m_allowedInSubSquare[x / 3 * 3 + y / 3][value] = false;
                            m_penDigits[x / 3 * 3 + y / 3][value] = 0;
                            m_digitsLeft[value]--;
                            m_allDigits--;
                            not_found = false;
                            m_saved = true;
                            m_savePoints.Add(m_points++, save_point);
                        }
                    }
                }
            }
        }
    }

    private static void Main()
    {
        SudokuSolver solver = new SudokuSolver();
        solver.Input();
        bool is_not_correct = false;
        int tmp_digits, attempt = 0;
        if (solver.AllDigits > 64)
        {
            Console.WriteLine("The square is unsolvable");
            Environment.Exit(0);
        }
        if (solver.IsNotCorrect())
        {
            Console.WriteLine("The square is unsolvable");
            Environment.Exit(0);
        }
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        while ((solver.AllDigits > 0 || is_not_correct) && stopwatch.ElapsedMilliseconds < 100)
        {
            tmp_digits = solver.AllDigits;
            solver.SetPens();
            solver.ProhibitNullNumbers();
            solver.ProhibitCells();
            solver.ProhibitOneChildRowAndColumn();
            solver.ExcludeValuesInRowsAndColumns();
            solver.RemainingInSubSquare();
            solver.RemainingInRow();
            solver.RemainingInColumn();
            solver.RemainingInCell();
            solver.LastInSubSquare();
            solver.LeaveTwoPensInTheSubSquare();
            is_not_correct = solver.IsNotCorrect();
            if (solver.AllDigits == tmp_digits || is_not_correct)
            {
                attempt++;
                if (attempt == 3 || is_not_correct)
                {
                    attempt = 0;
                    solver.Savepoint();
                    is_not_correct = solver.IsNotCorrect();
                }
            }
            else attempt = 0;
        }
        stopwatch.Stop();
        if (stopwatch.ElapsedMilliseconds >= 100)
        {
            Console.WriteLine("The square is unsolvable");
            Environment.Exit(0);
        }
        Console.Clear();
        Console.WriteLine("Solved sudoku:");
        solver.PrintMatrix();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        Environment.Exit(0);
    }
}