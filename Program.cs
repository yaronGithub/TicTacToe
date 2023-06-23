using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the board size: ");
            int boardSize = int.Parse(Console.ReadLine());

            Console.WriteLine("Computer vs player = 1, Player vs player = 2, Computer vs computer = 3.");
            int choose = int.Parse(Console.ReadLine());

            XOBoard board = new XOBoard(boardSize);
            Console.WriteLine();
            Random random = new Random();
            board.PrintBoard();

            int firstPlayer = random.Next(1, 3);
            int secondPlayer;
            if (firstPlayer == 1)
            {
                Console.WriteLine("Player X starts first.\n");
                secondPlayer = 2;
            }
            else
            {
                Console.WriteLine("Player O starts first.\n");
                secondPlayer = 1;
            }


            int i, j;

            // Game loop
            while (board.BoardStatus() == -1)
            {
                // First player
                if (choose != 3)
                {
                    Console.WriteLine("Player {0}, enter place (column, row): ", board.GetPlayerChar(firstPlayer));
                    Console.Write("column: ");
                    j = int.Parse(Console.ReadLine());
                    Console.Write("row: ");
                    i = int.Parse(Console.ReadLine());
                    if (board.IsEmpty(i, j))
                    {
                        board.AddChar(board.GetPlayerChar(firstPlayer), i, j);
                    }
                    else
                    {
                        while (board.IsEmpty(i, j) == false)
                        {
                            Console.WriteLine("The place is occupied. Please enter other column, row values: ");
                            Console.Write("column: ");
                            j = int.Parse(Console.ReadLine());
                            Console.Write("row: ");
                            i = int.Parse(Console.ReadLine());
                        }
                        board.AddChar(board.GetPlayerChar(firstPlayer), i, j);
                    }
                    if (board.BoardStatus() == firstPlayer)
                    {
                        Console.WriteLine();
                        board.PrintBoard();
                        Console.WriteLine("Player {0} has won!!!", board.GetPlayerChar(firstPlayer));
                        break;
                    }
                    Console.WriteLine();
                    board.PrintBoard();

                    if (board.BoardStatus() == 0)
                    {
                        Console.WriteLine("Draw");
                        break;
                    }
                }else
                {
                    int rndI = random.Next(0, boardSize), rndJ = random.Next(0, boardSize);
                    while (board.IsEmpty(rndI, rndJ) == false)
                    {
                        rndI = random.Next(0, boardSize); rndJ = random.Next(0, boardSize);
                    }
                    board.AddChar(board.GetPlayerChar(firstPlayer), rndI, rndJ);
                    Console.WriteLine("Computer plays j={0}, i={1}.", rndJ, rndI);

                    if (board.BoardStatus() == firstPlayer)
                    {
                        board.PrintBoard();
                        Console.WriteLine();
                        Console.WriteLine("Player {0} has won!!!", board.GetPlayerChar(firstPlayer));
                        break;
                    }
                    Console.WriteLine();
                    board.PrintBoard();

                    if (board.BoardStatus() == 0)
                    {
                        Console.WriteLine("Draw");
                        break;
                    }
                }

                // Second player
                if (choose == 2)
                {
                    Console.WriteLine("Player {0}, enter place (column, row): ", board.GetPlayerChar(secondPlayer));
                    Console.Write("column: ");
                    j = int.Parse(Console.ReadLine());
                    Console.Write("row: ");
                    i = int.Parse(Console.ReadLine());
                    if (board.IsEmpty(i, j))
                    {
                        board.AddChar(board.GetPlayerChar(secondPlayer), i, j);
                    }
                    else
                    {
                        while (board.IsEmpty(i, j) == false)
                        {
                            Console.WriteLine("The place is occupied. Please enter other column, row values: ");
                            Console.Write("column: ");
                            j = int.Parse(Console.ReadLine());
                            Console.Write("row: ");
                            i = int.Parse(Console.ReadLine());
                        }
                        board.AddChar(board.GetPlayerChar(secondPlayer), i, j);
                    }
                    if (board.BoardStatus() == secondPlayer)
                    {
                        board.PrintBoard();
                        Console.WriteLine();
                        Console.WriteLine("Player {0} has won!!!", board.GetPlayerChar(secondPlayer));
                        break;
                    }
                    Console.WriteLine();
                    board.PrintBoard();

                    if (board.BoardStatus() == 0)
                    {
                        Console.WriteLine("Draw");
                        break;
                    }
                }
                else
                {
                    int rndI = random.Next(0, boardSize), rndJ = random.Next(0, boardSize);
                    while (board.IsEmpty(rndI, rndJ) == false)
                    {
                        rndI = random.Next(0, boardSize); rndJ = random.Next(0, boardSize);
                    }
                    board.AddChar(board.GetPlayerChar(secondPlayer), rndI, rndJ);
                    Console.WriteLine("Computer plays j={0}, i={1}.", rndJ, rndI);

                    if (board.BoardStatus() == secondPlayer)
                    {
                        board.PrintBoard();
                        Console.WriteLine();
                        Console.WriteLine("Player {0} has won!!!", board.GetPlayerChar(secondPlayer));
                        break;
                    }
                    Console.WriteLine();
                    board.PrintBoard();

                    if (board.BoardStatus() == 0)
                    {
                        Console.WriteLine("Draw");
                        break;
                    }
                }
            }
        }
    }
}
