using System;
using System.Collections.Generic;

namespace Dices
{
    public class DiceSelectionWindow : Window
    {
        private bool needToRender = true;
        private int diceNumber = 1;

        private TextLine diceNumberInfo;
        private TextBlock diceInfo;

        private GameController gameController;

        public DiceSelectionWindow() : base(0, 0, 120, 30, '#')
        {
            diceInfo = new TextBlock(10, 11, 100, new List<string>() { "\n", "Press +/- to add or reduce dice number", "Press Enter to continue" });
        }

        public int ShowDiceWindow(int state)
        {
            do
            {
                Console.Clear();
                Render();
                DisplayDiceInfo();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo consoleKey = Console.ReadKey(true);

                    switch (consoleKey.Key)
                    {
                        case ConsoleKey.Escape:
                            state = 1;
                            needToRender = false;
                            break;
                        case ConsoleKey.Subtract:
                        case ConsoleKey.OemMinus:
                            if (diceNumber >= 2)
                            {
                                diceNumber--;
                            }                           
                            break;
                        case ConsoleKey.Add:
                        case ConsoleKey.OemPlus:
                            diceNumber++;
                            break;
                        case ConsoleKey.Enter:
                            state = 3;
                            needToRender = false;
                            break;
                    }
                }

                Console.SetCursorPosition(0, 0);
                System.Threading.Thread.Sleep(400);
            } while (needToRender);

            return state;
        }

        public void DisplayDiceInfo()
        {
            diceNumberInfo = new TextLine(10, 10, 100,"Players will have " + diceNumber + " dice");
            diceNumberInfo.Render();
            diceInfo.Render();
        }

        public int GetDiceNumber()
        {
            return diceNumber;
        }
    }
}