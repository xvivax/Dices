using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
//using Dices.Units;

namespace Dices
{
    public class GameScreen
    {
        private int width;
        private int height;

        private Window gameScreenWindow;


        public GameScreen(int width, int height)
        {
            this.width = width;
            this.height = height;

            gameScreenWindow = new Window(0, 0, width, height, '@');
        }

        public void Render()
        {
            gameScreenWindow.Render();
        }

    
    }
}