using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TicTacToe
{
    internal class XOBoard
    {
        // The 2D array of characters
        char[,] board;

        // Methods
        public XOBoard(int size)
        {
            board = new char[size, size];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        public void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int GetPlayerNum(char c)
        {
            if (c == 'X')
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public char GetPlayerChar(int num)
        {
            if (num == 1)
            {
                return 'X';
            }
            else
            {
                return 'O';
            }
        }

        public bool IsEmpty(int i, int j)
        {
            if (board[i, j] == '-')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddChar(char c, int i, int j)
        {
            board[i, j] = c;
        }

        public int BoardStatus()
        {
            int cnt = 0;

            // Player #1 - X

            // rows
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 'X')
                    {
                        cnt++;
                    }
                    if (cnt == board.GetLength(0))
                    {
                        return 1;
                    }
                }
                cnt = 0;
            }
            // columns
            for (int j = 0; j < board.GetLength(1); j++)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (board[i, j] == 'X')
                    {
                        cnt++;
                    }
                    if (cnt == board.GetLength(0))
                    {
                        return 1;
                    }
                }
                cnt = 0;
            }
            // slants
            cnt = 0;
            for (int i = 0, j = 0; i < board.GetLength(0); i++, j++)
            {
                if (board[i, j] == 'X')
                {
                    cnt++;
                }
                if (cnt == board.GetLength(0))
                {
                    return 1;
                }
            }
            cnt = 0;
            for (int i = 0, j = board.GetLength(1) - 1; i < board.GetLength(0); i++, j--)
            {
                if (board[i, j] == 'X')
                {
                    cnt++;
                }
                if (cnt == board.GetLength(0))
                {
                    return 1;
                }
            }
            cnt = 0;

            // Player #2 - O

            // rows
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 'O')
                    {
                        cnt++;
                    }
                    if (cnt == board.GetLength(0))
                    {
                        return 2;
                    }
                }
                cnt = 0;
            }
            // columns
            for (int j = 0; j < board.GetLength(1); j++)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (board[i, j] == 'O')
                    {
                        cnt++;
                    }
                    if (cnt == board.GetLength(0))
                    {
                        return 2;
                    }
                }
                cnt = 0;
            }
            // slants
            for (int i = 0, j = 0; i < board.GetLength(0); i++, j++)
            {
                if (board[i, j] == 'O')
                {
                    cnt++;
                }
                if (cnt == board.GetLength(0))
                {
                    return 2;
                }
            }
            cnt = 0;
            for (int i = 0, j = board.GetLength(1) - 1; i < board.GetLength(0); i++, j--)
            {
                if (board[i, j] == 'O')
                {
                    cnt++;
                }
                if (cnt == board.GetLength(0))
                {
                    return 2;
                }
            }
            cnt = 0;

            // Full board
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 'X' || board[i, j] == 'O')
                    {
                        cnt++;
                    }
                    if (cnt == Math.Pow(board.GetLength(0), 2))
                    {
                        return 0;
                    }
                }
            }

            // No winner and no full
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return -1;
                    }
                }
            }
            return -1;
        }

        public int[] CompCell()
        {
            int cnt = 0;
            int[] cell = new int[2];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '-')
                    {
                        cell[0] = i;
                        cell[1] = j;
                        return cell;
                    }
                }
            }
            return cell;
        }
    }
}
