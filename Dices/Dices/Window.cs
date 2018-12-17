namespace Dices
{
    public class Window : GuiObject
    {
        private Frame border;

        public Window(int x, int y, int width, int height, char windowChar) : base(x, y, width, height)
        {
            border = new Frame(x, y, width, height, windowChar);
        }

        public override void Render()
        {
            border.Render();
        }
    }
}