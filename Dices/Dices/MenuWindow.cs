using System;
using System.Collections.Generic;

namespace Dices
{
    public class MenuWindow : Window
    {
        //private List<Button> buttons = new List<Button>();
        private TextBlock titleTextBlock;
        private TextBlock menuTextBlock;
        private TextBlock explanationTextBlock;
        //private int buttonIndex;

        public MenuWindow() : base(0, 0, 120, 30, '&')
        {
            titleTextBlock = new TextBlock(10, 5, 100, new List<string> { "Ola Ola that's the dice game", "Made in Kamchatka" });
            menuTextBlock = new TextBlock(10, 10, 100, new List<string>() {"Play", "\n", "Quit"});
            explanationTextBlock = new TextBlock(10, 15, 100, new List<string>() { "Press P to start the game", "Press Q to quit app" });
        }

        public void Render()
        {
            base.Render();

            titleTextBlock.Render();
            menuTextBlock.Render();
            explanationTextBlock.Render();

            Console.SetCursorPosition(0,0);
        }

        /*
        public void NextButton()
        {
            if (buttonIndex < 2)
            {
                buttons[buttonIndex].SetNotActive();
                buttonIndex++;
                buttons[buttonIndex].SetActive();
            }
        }

        public void PreviousButton()
        {
            if (buttonIndex > 0)
            {
                buttons[buttonIndex].SetNotActive();
                buttonIndex--;
                buttons[buttonIndex].SetActive();
            }
        }

        public int GetButtonIndex()
        {
            return buttonIndex;
        }
        */
    }
}