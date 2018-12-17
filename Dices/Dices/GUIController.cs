using System;
using System.Runtime.CompilerServices;

namespace Dices
{
    public class GUIController
    {
        private MenuWindow menuWindow;
        public bool needToRender = true;
        private CreditWindow creditWindow;
        private GameController gameController;

        private PlayerSelectionWindow playerSelectionWindow;

        private bool displayCredits = false;

        public GUIController()
        {
            menuWindow = new MenuWindow();
            creditWindow = new CreditWindow();
            gameController = new GameController();
        }

        public void ShowMenu()
        {
            do
            {
                menuWindow.Render();

                ConsoleKeyInfo consoleKey = Console.ReadKey(true);

                switch (consoleKey.Key)
                {
                    case ConsoleKey.P:
                        //menuWindow.PreviousButton();
                        playerSelectionWindow = new PlayerSelectionWindow();
                        playerSelectionWindow.ShowPlayerSelectionWindow();
                        break;
                    case ConsoleKey.Q:
                        //menuWindow.NextButton();
                        needToRender = false;
                        break;
                }
            } while (needToRender);
        }

        public int PlayersSelected()
        {
            return playerSelectionWindow.GetPlayersNumber();
        }
    }
}