using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System;

namespace SudokuTests
{
    [TestClass]
    public class SetPens
    {
        [TestMethod]
        public void SetPensTest1()
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
                new int[9] { 2, 4, 2, 2, 0, 4, 0, 0, 6 },
                new int[9] { 0, 3, 0, 7, 1, 7, 3, 4, 4 },
                new int[9] { 5, 0, 2, 7, 0, 4, 3, 3, 4 },
                new int[9] { 0, 4, 0, 0, 3, 2, 2, 3, 6 },
                new int[9] { 2, 0, 1, 4, 0, 4, 0, 4, 4 },
                new int[9] { 4, 2, 0, 4, 2, 0, 3, 0, 4 },
                new int[9] { 5, 7, 3, 0, 4, 0, 3, 4, 2 },
                new int[9] { 4, 5, 3, 4, 0, 5, 3, 7, 0 },
                new int[9] { 6, 4, 0, 4, 3, 2, 0, 4, 0 }
            };
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            solver.SetPens();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.PenDigits[i][j], "Wrong pens");
                }
            }
        }

        [TestMethod]
        public void SetPensTest2()
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
                new int[9] { 8, 6, 5, 5, 8, 4, 5, 0, 3 },
                new int[9] { 7, 7, 0, 5, 4, 0, 3, 3, 3 },
                new int[9] { 3, 3, 5, 0, 6, 1, 0, 3, 0 },
                new int[9] { 7, 3, 7, 7, 4, 0, 7, 1, 0 },
                new int[9] { 7, 5, 4, 7, 0, 3, 5, 0, 2 },
                new int[9] { 6, 0, 8, 5, 5, 4, 5, 6, 3 },
                new int[9] { 4, 0, 7, 7, 7, 4, 4, 0, 2 },
                new int[9] { 5, 4, 5, 7, 5, 2, 0, 2, 0 },
                new int[9] { 0, 4, 7, 4, 7, 0, 2, 5, 3 }
            };
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            solver.SetPens();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.PenDigits[i][j], "Wrong pens");
                }
            }
        }

        [TestMethod]
        public void SetPensTest3()
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
                new int[9] { 7, 7, 0, 7, 3, 5, 2, 4, 0 },
                new int[9] { 5, 7, 4, 7, 0, 5, 0, 2, 1 },
                new int[9] { 7, 5, 6, 5, 4, 7, 2, 0, 0 },
                new int[9] { 7, 5, 4, 7, 5, 3, 0, 0, 3 },
                new int[9] { 4, 5, 7, 7, 5, 0, 3, 3, 0 },
                new int[9] { 8, 0, 8, 6, 8, 5, 3, 4, 4 },
                new int[9] { 4, 7, 5, 4, 0, 0, 4, 2, 4 },
                new int[9] { 0, 7, 7, 6, 2, 2, 3, 0, 5 },
                new int[9] { 5, 5, 7, 0, 5, 5, 0, 3, 4 }
            };
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            solver.SetPens();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.PenDigits[i][j], "Wrong pens");
                }
            }
        }
        [TestMethod]
        public void SetPensTest4()
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
                new int[9] { 3, 6, 6, 0, 1, 0, 6, 0, 6 },
                new int[9] { 8, 5, 8, 4, 3, 0, 5, 6, 5 },
                new int[9] { 8, 8, 5, 3, 0, 2, 6, 3, 8 },
                new int[9] { 0, 5, 5, 3, 4, 5, 6, 5, 8 },
                new int[9] { 5, 0, 3, 1, 0, 2, 0, 6, 4 },
                new int[9] { 4, 4, 0, 0, 2, 7, 2, 5, 7 },
                new int[9] { 6, 8, 8, 3, 0, 3, 6, 3, 5 },
                new int[9] { 6, 4, 6, 0, 2, 0, 2, 5, 0 },
                new int[9] { 7, 7, 4, 3, 3, 4, 0, 0, 5 }
            };
            SudokuSolver solver = new SudokuSolver();
            solver.Input(begginingMatrix);
            solver.SetPens();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.PenDigits[i][j], "Wrong pens");
                }
            }
        }

        [TestMethod]
        public void SetPensTest5()
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
            solver.SetPens();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.PenDigits[i][j], "Wrong pens");
                }
            }
        }

        [TestMethod]
        public void SetPensTest6()
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
            solver.SetPens();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.PenDigits[i][j], "Wrong pens");
                }
            }
        }

        [TestMethod]
        public void SetPensTest7()
        {
            int[][] begginingMatrix = new int[9][]
            {
                new int[9] { 3, 0, 0, 0, 7, 0, 5, 0, 0 },
                new int[9] { 1, 0, 9, 8, 0, 0, 0, 0, 0 },
                new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 6, 0, 0, 2, 0 },
                new int[9] { 0, 6, 4, 0, 0, 0, 0, 0, 0 },
                new int[9] { 0, 8, 0, 0, 0, 0, 0, 9, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 6, 0, 7 },
                new int[9] { 0, 0, 0, 9, 0, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 4, 0, 0 }
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
            solver.SetPens();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.PenDigits[i][j], "Wrong pens");
                }
            }
        }

        [TestMethod]
        public void SetPensTest8()
        {
            int[][] begginingMatrix = new int[9][]
            {
                new int[9] { 0, 9, 0, 3, 0, 4, 0, 0, 0 },
                new int[9] { 7, 0, 0, 0, 0, 0, 6, 0, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 8, 0, 0, 2, 0, 0 },
                new int[9] { 5, 0, 0, 0, 7, 0, 0, 0, 0 },
                new int[9] { 6, 0, 0, 0, 0, 0, 1, 0, 0 },
                new int[9] { 0, 8, 4, 0, 0, 0, 0, 0, 9 },
                new int[9] { 0, 0, 0, 0, 6, 0, 0, 5, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 0, 7, 0 }
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
            solver.SetPens();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.PenDigits[i][j], "Wrong pens");
                }
            }
        }

        [TestMethod]
        public void SetPensTest9()
        {
            int[][] begginingMatrix = new int[9][]
            {
                new int[9] { 7, 0, 0, 0, 2, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 9, 0, 6 },
                new int[9] { 0, 0, 0, 0, 0, 0, 8, 0, 0 },
                new int[9] { 0, 0, 0, 9, 0, 8, 0, 0, 0 },
                new int[9] { 8, 0, 0, 0, 0, 0, 0, 3, 0 },
                new int[9] { 0, 0, 0, 6, 0, 0, 5, 0, 0 },
                new int[9] { 0, 5, 9, 0, 3, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 0, 4, 0, 7, 0 },
                new int[9] { 0, 6, 0, 0, 0, 0, 0, 0, 0 }
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
            solver.SetPens();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.PenDigits[i][j], "Wrong pens");
                }
            }
        }

        [TestMethod]
        public void SetPensTest10()
        {
            int[][] begginingMatrix = new int[9][]
            {
                new int[9] { 0, 1, 0, 0, 0, 0, 0, 2, 8 },
                new int[9] { 6, 0, 0, 0, 7, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[9] { 0, 0, 9, 0, 0, 0, 3, 4, 0 },
                new int[9] { 7, 0, 0, 2, 0, 8, 0, 0, 0 },
                new int[9] { 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new int[9] { 4, 0, 0, 0, 6, 0, 5, 0, 0 },
                new int[9] { 0, 0, 0, 0, 0, 0, 9, 0, 0 },
                new int[9] { 0, 8, 0, 0, 0, 0, 0, 0, 0 }
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
            solver.SetPens();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.AreEqual(expected[i][j], solver.PenDigits[i][j], "Wrong pens");
                }
            }
        }
    }
}
