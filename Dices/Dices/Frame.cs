using System;
using System.Runtime.InteropServices;

namespace Dices
{
    public class Frame : GuiObject
    {
        private char renderChar;

        public Frame(int x, int y, int width, int height, char renderChar) : base(x, y, width, height)
        {
            this.renderChar = renderChar;
        }

        public override void Render()
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                    {
                        Console.Write(renderChar);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
            Console.SetCursorPosition(0,0);
        }
    }
}