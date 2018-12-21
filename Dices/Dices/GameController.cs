using System;
using System.Collections.Generic;

namespace Dices
{
    public class GameController
    {
        private int SCREEN_WIDTH = 40;
        private int SCREEN_HEIGHT = 20;
        private bool needToRender = true;
        private TextBlock textBlock;


        public GameController()
        {
            
        }

        public void StartGame(int plCount, int diceCount)
        {
            GameScreen myGame = new GameScreen(SCREEN_WIDTH, SCREEN_HEIGHT);
           
            do
            {
                Console.Clear();
                myGame.Render();
                DisplayGameInfo(plCount, diceCount);


                
                Console.SetCursorPosition(0,0);
                System.Threading.Thread.Sleep(400);
            } while (needToRender);
        }

        public void DisplayGameInfo(int plCount, int diceCount)
        {
            textBlock = new TextBlock(2,2, 15, new List<string>() {"Players playing: " + plCount, "Dice each player will have: " + diceCount});
            textBlock.Render();
        }
    }
}