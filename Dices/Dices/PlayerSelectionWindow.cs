using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace Dices
{
    public class PlayerSelectionWindow : Window
    {
        private bool needToRender = true;
        private const int TOTAL_ROWS = 3;
        private const int TOTAL_COLS = 2;
        private Button[][] playersButtons = new Button[TOTAL_ROWS][];
        private DiceSelectionWindow diceSelectionWindow;

        private int row = 0;
        private int col = 0;

        public PlayerSelectionWindow() : base(0, 0, 120, 30, '#')
        {
            for (int i = 0; i < TOTAL_ROWS; i++)
            {
                playersButtons[i] = new Button[TOTAL_COLS];
            }

            playersButtons[0][0] = new Button(2, 1, "P2");            
            playersButtons[0][1] = new Button(10, 1, "P3");
            playersButtons[1][0] = new Button(2, 6, "P4");
            playersButtons[1][1] = new Button(10, 6, "P5");
            playersButtons[2][0] = new Button(2, 11, "P6");
            playersButtons[2][1] = new Button(10, 11, "P7");

            playersButtons[0][0].SetActive();
        }

        public int ShowPlayerSelection(int state)
        {
            do
            {
                Console.Clear();
                Render();
                RenderTable();
                Console.SetCursorPosition(0, 0);

                ConsoleKeyInfo consoleKey = Console.ReadKey(true);

                switch (consoleKey.Key)
                {
                    case ConsoleKey.Escape:
                        state = 0;
                        needToRender = false;
                        break;
                    case ConsoleKey.RightArrow:
                        if (col < 1)
                        {
                            playersButtons[row][col].SetNotActive();
                            col++;
                            playersButtons[row][col].SetActive();
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (col > 0)
                        {
                            playersButtons[row][col].SetNotActive();
                            col--;
                            playersButtons[row][col].SetActive();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (row > 0)
                        {
                            playersButtons[row][col].SetNotActive();
                            row--;
                            playersButtons[row][col].SetActive();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (row < 2)
                        {
                            playersButtons[row][col].SetNotActive();
                            row++;
                            playersButtons[row][col].SetActive();
                        }
                        break;
                    case ConsoleKey.Enter:
                        state = 2;
                        needToRender = false;
                        break;
                    default:
                        Console.WriteLine("You pressed something different");
                        break;
                }
            } while (needToRender);

            return state;
        }

        public void RenderTable()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (playersButtons[i][j] != null)
                    {
                        playersButtons[i][j].Render();
                    }
                    
                }
            }
        }

        public int GetPlayersNumber()
        {
            return (row * TOTAL_COLS) + col + 2;
        }
    }
}