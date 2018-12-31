using System;
using System.Runtime.CompilerServices;

namespace Dices
{
    public class GUIController
    {

        enum WindowStates { Exit = -1, MainMenu, PlayerSelect, DiseSelect, Game, ExtraRound, Winnner};

        private MenuWindow menuWindow;
        private GameController gameController;
        private DiceSelectionWindow diceSelectionWindow;
        private PlayerSelectionWindow playerSelectionWindow;
        private WinWindow winWindow;

        private bool needToRender = true;
        private int playersInGame = 0;
        private int diceValue = 0;

        WindowStates currentState = WindowStates.MainMenu;


        public int State { get; set; } = 0;


        public GUIController()
        {
            menuWindow = new MenuWindow();
            gameController = new GameController();
            diceSelectionWindow = new DiceSelectionWindow();
            playerSelectionWindow = new PlayerSelectionWindow();
            winWindow = new WinWindow();
        }

        public void StartWindows()
        {
            do
            {
                switch (currentState)
                {
                    case WindowStates.Exit:
                        needToRender = false;
                        break;
                    case WindowStates.MainMenu:
                        State = menuWindow.ShowMenu(State);
                        break;
                    case WindowStates.PlayerSelect:
                        State = playerSelectionWindow.ShowPlayerSelection(State);
                        playersInGame = playerSelectionWindow.GetPlayersNumber();
                        break;
                    case WindowStates.DiseSelect:
                        State = diceSelectionWindow.ShowDiceWindow(State);
                        diceValue = diceSelectionWindow.GetDiceNumber();
                        break;
                    case WindowStates.Game:
                        gameController.StartGame(playersInGame, diceValue);
                        State = gameController.DetermineState();
                        break;
                    case WindowStates.ExtraRound:

                        break;
                    case WindowStates.Winnner:
                        State = winWindow.ShowWinner(gameController.GetWinnerID(), gameController.GetWinnerValue(), State);
                        break;
                }

                currentState = (WindowStates) State;
            } while (needToRender);
        }
    }
}