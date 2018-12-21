using System;
using System.Runtime.CompilerServices;

namespace Dices
{
    public class GUIController
    {
        private MenuWindow menuWindow;
        private GameController gameController;
        private DiceSelectionWindow diceSelectionWindow;
        private PlayerSelectionWindow playerSelectionWindow;

        private bool needToRender = true;
        private int playersInGame = 0;
        private int diceValue = 0;


        public int State { get; set; } = 0;


        public GUIController()
        {
            menuWindow = new MenuWindow();
            gameController = new GameController();
            diceSelectionWindow = new DiceSelectionWindow();
            playerSelectionWindow = new PlayerSelectionWindow();
        }

        public void StartWindows()
        {
            do
            {
                switch (State)
                {
                    case -1:
                        needToRender = false;
                        break;
                    case 0:
                        State = menuWindow.ShowMenu(State);
                        break;
                    case 1:
                        State = playerSelectionWindow.ShowPlayerSelection(State);
                        playersInGame = playerSelectionWindow.GetPlayersNumber();
                        break;
                    case 2:
                        State = diceSelectionWindow.ShowDiceWindow(State);
                        diceValue = diceSelectionWindow.GetDiceNumber();
                        break;
                    case 3:
                        gameController.StartGame(playersInGame, diceValue);
                        break;
                }

            } while (needToRender);
        }
    }
}