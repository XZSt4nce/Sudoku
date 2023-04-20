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
