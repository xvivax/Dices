using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Dices
{
    public class GameController
    {
        private int SCREEN_WIDTH = 80;
        private int SCREEN_HEIGHT = 30;
        private int RIGHT_OFFSET = 15;
        private int TOP_OFFSET = 4;
        private TextLine players;
        private TextLine dices;
        private TextLine sum;
        private TextBlock gameInfo;
        private int highestValue = 0;
        private List<int> playerSum = new List<int>();
        private int manyHighValue = 0;
        private int rndValueRange = 6;

        public GameController()
        {
            
        }

        public void StartGame(int plCount, int diceCount)
        {
            GameScreen myGame = new GameScreen(SCREEN_WIDTH, SCREEN_HEIGHT);

            Random rnd = new Random();


                Console.Clear();
                myGame.Render();
                DisplayGameInfo(plCount, diceCount);
                DisplayPlayersInfo(plCount, diceCount, rnd);
                HighestScore();

                DetermineState();


                Console.SetCursorPosition(0,0);
                //System.Threading.Thread.Sleep(400);
            Console.ReadKey();
        }

        public void DisplayGameInfo(int plCount, int diceCount)
        {
            gameInfo = new TextBlock(2,2, 15, new List<string>() {"Players playing: " + plCount, "Each player will have: " + diceCount + " dices", "\n"});
            gameInfo.Render();
        }

        public void DisplayPlayersInfo(int plCount, int diceCount, Random rnd)
        {
            playerSum.Clear();
            highestValue = 0;
            manyHighValue = 0;
            for (int i = 1; i <= plCount; i++)
            {
                //Console.WriteLine("Player[" + i + "]");
                players = new TextLine(RIGHT_OFFSET, i + TOP_OFFSET + ((diceCount + 1) * (i - 1)), 15, "Player[" + i + "]");
                players.Render();

                int total = 0;
                for (int j = 1; j <= diceCount; j++)
                {
                    int sk = rnd.Next(1, rndValueRange);
                    //Console.WriteLine("Dice[" + j + "] value is: " + sk);
                    dices = new TextLine(RIGHT_OFFSET, i + TOP_OFFSET + j + ((diceCount + 1) * (i - 1)), 15, "Dice[" + j + "] value is: " + sk);
                    dices.Render();
                    total += sk;
                }
                //Console.WriteLine("Sum of all dices: " + total);
                sum = new TextLine(RIGHT_OFFSET, i + TOP_OFFSET + diceCount + 1 + ((diceCount + 1) * (i - 1)), 15, "Sum of all dices: " + total);
                SumHolder(total);
                sum.Render();
            }
        }

        public void SumHolder(int value)
        {
            playerSum.Add(value);
        }

        public void HighestScore()
        {
            foreach (int item in playerSum)
            {
                if (highestValue < item)
                {
                    highestValue = item;
                    manyHighValue = 0;
                }
                else if (highestValue == item)
                {
                    manyHighValue++;
                }
            }
        }

        public int DetermineState()
        {
            if (manyHighValue > 0)
            {
                //TODO
                // Need to to add players into the new list and run extra round with them
                return 4;
            }
            else
            {
                // Need to display winner
                return 5;
            }
        }

        public int GetWinnerID()
        {
            return playerSum.IndexOf(highestValue) + 1;
        }

        public int GetWinnerValue()
        {
            return highestValue;
        }

        public void ExtraRound()
        {
            this.StartGame(manyHighValue, dices);
        }
    }
}