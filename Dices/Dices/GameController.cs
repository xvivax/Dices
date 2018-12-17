using System;
using System.Collections.Generic;

namespace Dices
{
    public class GameController
    {
        private int SCREEN_WIDTH = 40;
        private int SCREEN_HEIGHT = 20;
        private bool needToRender = true;


        public GameController()
        {
            
        }

        public void StartGame()
        {
            GameScreen myGame = new GameScreen(SCREEN_WIDTH, SCREEN_HEIGHT);
           
            do
            {
                Console.Clear();

                


                myGame.Render();
                Console.SetCursorPosition(0,0);
                System.Threading.Thread.Sleep(400);
            } while (needToRender);
        }
    }
}