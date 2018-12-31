using System;
using System.Collections.Generic;

namespace Dices
{
    public class WinWindow : Window
    {
        private TextBlock winnerTextBlock;
        private TextBlock menuTextBlock;
        private TextBlock explanationTextBlock;

        public WinWindow() : base(0, 0, 120, 30, '&')
        {
            
            menuTextBlock = new TextBlock(10, 10, 100, new List<string>() {"Replay","\n", "Go to menu", "\n", "Quit"});
            explanationTextBlock = new TextBlock(10, 17, 100, new List<string>() { "Press R to replay the game", "Press M to go to menu", "Press Q to quit app" });
        }

        private void Render()
        {
            base.Render();

            menuTextBlock.Render();
            explanationTextBlock.Render();

            Console.SetCursorPosition(0,0);
        }

        public int ShowWinner(int id, int value, int state)
        {

            Render();
            winnerTextBlock = new TextBlock(10, 5, 100, new List<string> { "Player[" + id + "] won the game with score of: " + value });
            winnerTextBlock.Render();

            ConsoleKeyInfo consoleKey = Console.ReadKey(true);

            switch (consoleKey.Key)
            {
                case ConsoleKey.R:
                    state = 3;
                    break;
                case ConsoleKey.M:
                    state = 0;
                    break;
                case ConsoleKey.Q:
                    state = -1;
                    break;
            }

            return state;
        }
    }
}