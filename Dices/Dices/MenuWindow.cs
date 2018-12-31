using System;
using System.Collections.Generic;

namespace Dices
{
    public class MenuWindow : Window
    {
        private TextBlock titleTextBlock;
        private TextBlock menuTextBlock;
        private TextBlock explanationTextBlock;

        public MenuWindow() : base(0, 0, 120, 30, '&')
        {
            titleTextBlock = new TextBlock(10, 5, 100, new List<string> { "Ola Ola that's the dice game", "Made in Kamchatka" });
            menuTextBlock = new TextBlock(10, 10, 100, new List<string>() {"Play", "\n", "Quit"});
            explanationTextBlock = new TextBlock(10, 15, 100, new List<string>() { "Press P to start the game", "Press Q to quit app" });
        }

        private void Render()
        {
            base.Render();

            titleTextBlock.Render();
            menuTextBlock.Render();
            explanationTextBlock.Render();

            Console.SetCursorPosition(0,0);
        }

        public int ShowMenu(int state)
        {
            Render();
            ConsoleKeyInfo consoleKey = Console.ReadKey(true);

            switch (consoleKey.Key)
            {
                case ConsoleKey.P:
                    state = 1;
                    break;
                case ConsoleKey.Q:
                    state = -1;
                    break;
            }

            return state;
        }
    }
}