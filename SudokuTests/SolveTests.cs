using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System.Diagnostics;
using System;

namespace SudokuTests
{
    [TestClass]
    public class SudokuTest
    {
        [TestMethod]
        public void SolveTest1()
        {
            int[][] begginingMatrix = new int[9][] 
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
            int[][] expected = new int[9][]
            {
                new int[9] { 1, 4, 5, 3, 2, 7, 6, 9, 8 },
                new int[9] { 8, 3, 9, 6, 5, 4, 1, 2, 7 },
                new int[9] { 6, 7, 2, 9, 1, 8, 5, 4, 3 },
                new int[9] { 4, 9, 6, 1, 8, 5, 3, 7, 2 },
                new int[9] { 2, 1, 8, 4, 7, 3, 9, 5, 6 },
                new int[9] { 7, 5, 3, 2, 9, 6, 4, 8, 1 },
                new int[9] { 3, 6, 7, 5, 4, 2, 8, 1, 9 },
                new int[9] { 9, 8, 4, 7, 6, 1, 2, 3, 5 },
                new int[9] { 5, 2, 1, 8, 3, 9, 7, 6, 4 }
            };
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            bool is_not_correct = false;
            int tmp_digits, attempt = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((solver.AllDigits > 0 || is_not_correct) && stopwatch.ElapsedMilliseconds < 20)
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
            Assert.IsFalse(stopwatch.ElapsedMilliseconds >= 20, "Time's up");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.Matrix[i][j], "Wrong solve");
                }
            }
        }

        [TestMethod]
        public void SolveTest2()
        {
            int[][] begginingMatrix = new int[9][]
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
            int[][] expected = new int[9][]
            {
                new int[9] { 6, 5, 1, 9, 2, 3, 8, 7, 4 },
                new int[9] { 8, 9, 3, 6, 4, 7, 5, 1, 2 },
                new int[9] { 4, 7, 2, 1, 8, 5, 3, 9, 6 },
                new int[9] { 7, 6, 5, 8, 9, 1, 2, 4, 3 },
                new int[9] { 1, 2, 9, 4, 3, 6, 7, 5, 8 },
                new int[9] { 3, 4, 8, 7, 5, 2, 9, 6, 1 },
                new int[9] { 2, 8, 7, 5, 1, 4, 6, 3, 9 },
                new int[9] { 5, 3, 4, 2, 6, 9, 1, 8, 7 },
                new int[9] { 9, 1, 6, 3, 7, 8, 4, 2, 5 }
            };
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            bool is_not_correct = false;
            int tmp_digits, attempt = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((solver.AllDigits > 0 || is_not_correct) && stopwatch.ElapsedMilliseconds < 20)
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
            Assert.IsFalse(stopwatch.ElapsedMilliseconds >= 20, "Time's up");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.Matrix[i][j], "Wrong solve");
                }
            }
        }

        [TestMethod]
        public void SolveTest3()
        {
            int[][] begginingMatrix = new int[9][]
            {
                new int[9] { 0, 0, 3, 0, 0, 0, 8, 9, 0 },
                new int[9] { 9, 0, 0, 5, 0, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 0, 7, 0, 0, 0 },
                new int[9] { 8, 0, 0, 0, 9, 0, 2, 0, 0 },
                new int[9] { 0, 7, 0, 6, 0, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[9] { 0, 5, 6, 0, 0, 0, 0, 0, 7 },
                new int[9] { 0, 0, 0, 0, 8, 1, 4, 0, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
            int[][] expected = new int[9][]
            {
                new int[9] { 7, 2, 3, 1, 6, 4, 8, 9, 5 },
                new int[9] { 9, 1, 4, 5, 3, 8, 7, 6, 2 },
                new int[9] { 6, 8, 5, 9, 2, 7, 1, 3, 4 },
                new int[9] { 8, 6, 1, 4, 9, 5, 2, 7, 3 },
                new int[9] { 3, 7, 9, 6, 1, 2, 5, 4, 8 },
                new int[9] { 5, 4, 2, 8, 7, 3, 6, 1, 9 },
                new int[9] { 1, 5, 6, 2, 4, 9, 3, 8, 7 },
                new int[9] { 2, 9, 7, 3, 8, 1, 4, 5, 6 },
                new int[9] { 4, 3, 8, 7, 5, 6, 9, 2, 1 }
            };
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            bool is_not_correct = false;
            int tmp_digits, attempt = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((solver.AllDigits > 0 || is_not_correct) && stopwatch.ElapsedMilliseconds < 20)
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
            Assert.IsFalse(stopwatch.ElapsedMilliseconds >= 20, "Time's up");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.Matrix[i][j], "Wrong solve");
                }
            }
        }

        [TestMethod]
        public void SolveTest4()
        {
            int[][] begginingMatrix = new int[9][]
            {
                new int[9] { 4, 0, 8, 0, 6, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 5, 0, 0 },
                new int[9] { 6, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[9] { 0, 1, 0, 5, 0, 7, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 0, 4, 3 },
                new int[9] { 0, 0, 0, 2, 0, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 4, 9, 0, 8, 0 },
                new int[9] { 0, 5, 0, 0, 0, 0, 7, 0, 0 },
                new int[9] { 0, 0, 0, 6, 0, 0, 0, 0, 0 }
            };
            int[][] expected = new int[9][]
            {
                new int[9] { 4, 2, 8, 3, 6, 5, 9, 7, 1 },
                new int[9] { 7, 9, 1, 4, 2, 8, 5, 3, 6 },
                new int[9] { 6, 3, 5, 9, 7, 1, 4, 2, 8 },
                new int[9] { 3, 1, 4, 5, 8, 7, 6, 9, 2 },
                new int[9] { 5, 7, 2, 1, 9, 6, 8, 4, 3 },
                new int[9] { 9, 8, 6, 2, 3, 4, 1, 5, 7 },
                new int[9] { 1, 6, 3, 7, 4, 9, 2, 8, 5 },
                new int[9] { 2, 5, 9, 8, 1, 3, 7, 6, 4 },
                new int[9] { 8, 4, 7, 6, 5, 2, 3, 1, 9 }
            };
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            bool is_not_correct = false;
            int tmp_digits, attempt = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((solver.AllDigits > 0 || is_not_correct) && stopwatch.ElapsedMilliseconds < 20)
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
            Assert.IsFalse(stopwatch.ElapsedMilliseconds >= 20, "Time's up");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.Matrix[i][j], "Wrong solve");
                }
            }
        }

        [TestMethod]
        public void SolveTest5()
        {
            int[][] begginingMatrix = new int[9][]
            {
                new int[9] { 8, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[9] { 0, 0, 3, 6, 0, 0, 0, 0, 0 },
                new int[9] { 0, 7, 0, 0, 9, 0, 2, 0, 0 },
                new int[9] { 0, 5, 0, 0, 0, 7, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 4, 5, 7, 0, 0 },
                new int[9] { 0, 0, 0, 1, 0, 0, 0, 3, 0 },
                new int[9] { 0, 0, 1, 0, 0, 0, 0, 6, 8 },
                new int[9] { 0, 0, 8, 5, 0, 0, 0, 1, 0 },
                new int[9] { 0, 9, 0, 0, 0, 0, 4, 0, 0 }
            };
            int[][] expected = new int[9][]
            {
                new int[9] { 8, 1, 2, 7, 5, 3, 6, 4, 9 },
                new int[9] { 9, 4, 3, 6, 8, 2, 1, 7, 5 },
                new int[9] { 6, 7, 5, 4, 9, 1, 2, 8, 3 },
                new int[9] { 1, 5, 4, 2, 3, 7, 8, 9, 6 },
                new int[9] { 3, 6, 9, 8, 4, 5, 7, 2, 1 },
                new int[9] { 2, 8, 7, 1, 6, 9, 5, 3, 4 },
                new int[9] { 5, 2, 1, 9, 7, 4, 3, 6, 8 },
                new int[9] { 4, 3, 8, 5, 2, 6, 9, 1, 7 },
                new int[9] { 7, 9, 6, 3, 1, 8, 4, 5, 2 }
            };
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            bool is_not_correct = false;
            int tmp_digits, attempt = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((solver.AllDigits > 0 || is_not_correct) && stopwatch.ElapsedMilliseconds < 20)
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
            Assert.IsFalse(stopwatch.ElapsedMilliseconds >= 20, "Time's up");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.Matrix[i][j], "Wrong solve");
                }
            }
        }

        [TestMethod]
        public void SolveTest6()
        {
            int[][] begginingMatrix = new int[9][]
            {
                new int[9] { 0, 0, 0, 2, 4, 0, 0, 0, 0 },
                new int[9] { 0, 0, 7, 1, 8, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 0, 9, 7 },
                new int[9] { 6, 7, 0, 0, 0, 0, 0, 3, 1 },
                new int[9] { 3, 8, 0, 0, 0, 0, 0, 0, 0 },
                new int[9] { 0, 3, 0, 0, 0, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 3, 2, 4, 0, 0 },
                new int[9] { 0, 0, 0, 0, 1, 7, 0, 0, 0 }
            };
            int[][] expected = new int[9][]
            {
                new int[9] { 1, 5, 3, 2, 4, 6, 7, 8, 9 },
                new int[9] { 2, 4, 7, 1, 8, 9, 3, 5, 6 },
                new int[9] { 8, 9, 6, 3, 7, 5, 2, 1, 4 },
                new int[9] { 4, 1, 2, 6, 5, 3, 8, 9, 7 },
                new int[9] { 6, 7, 9, 4, 2, 8, 5, 3, 1 },
                new int[9] { 3, 8, 5, 7, 9, 1, 6, 4, 2 },
                new int[9] { 7, 3, 8, 9, 6, 4, 1, 2, 5 },
                new int[9] { 9, 6, 1, 5, 3, 2, 4, 7, 8 },
                new int[9] { 5, 2, 4, 8, 1, 7, 9, 6, 3 }
            };
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            bool is_not_correct = false;
            int tmp_digits, attempt = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((solver.AllDigits > 0 || is_not_correct) && stopwatch.ElapsedMilliseconds < 20)
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
            Assert.IsFalse(stopwatch.ElapsedMilliseconds >= 20, "Time's up");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.Matrix[i][j], "Wrong solve");
                }
            }
        }

        [TestMethod]
        public void SolveTest7()
        {
            int[][] begginingMatrix = new int[9][]
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
            int[][] expected = new int[9][]
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
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            bool is_not_correct = false;
            int tmp_digits, attempt = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((solver.AllDigits > 0 || is_not_correct) && stopwatch.ElapsedMilliseconds < 20)
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
            Assert.IsFalse(stopwatch.ElapsedMilliseconds >= 20, "Time's up");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.Matrix[i][j], "Wrong solve");
                }
            }
        }

        [TestMethod]
        public void SolveTest8()
        {
            int[][] begginingMatrix = new int[9][]
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
            int[][] expected = new int[9][]
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
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            bool is_not_correct = false;
            int tmp_digits, attempt = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((solver.AllDigits > 0 || is_not_correct) && stopwatch.ElapsedMilliseconds < 20)
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
            Assert.IsFalse(stopwatch.ElapsedMilliseconds >= 20, "Time's up");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.Matrix[i][j], "Wrong solve");
                }
            }
        }

        [TestMethod]
        public void SolveTest9()
        {
            int[][] begginingMatrix = new int[9][]
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
            int[][] expected = new int[9][]
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
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            bool is_not_correct = false;
            int tmp_digits, attempt = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((solver.AllDigits > 0 || is_not_correct) && stopwatch.ElapsedMilliseconds < 20)
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
            Assert.IsFalse(stopwatch.ElapsedMilliseconds >= 20, "Time's up");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.Matrix[i][j], "Wrong solve");
                }
            }
        }

        [TestMethod]
        public void SolveTest10()
        {
            int[][] begginingMatrix = new int[9][]
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
            int[][] expected = new int[9][]
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
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            bool is_not_correct = false;
            int tmp_digits, attempt = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while ((solver.AllDigits > 0 || is_not_correct) && stopwatch.ElapsedMilliseconds < 20)
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
            Assert.IsFalse(stopwatch.ElapsedMilliseconds >= 20, "Time's up");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.Matrix[i][j], "Wrong solve");
                }
            }
        }
    }
}
