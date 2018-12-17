namespace Dices
{
    public class Button : GuiObject
    {
        private Frame activeFrame;
        private bool isActive = false;
        private Frame nonActiveFrame;
        private TextLine textLine;

        public Button(int x, int y, string text) : base(x, y, text.Length + 4, 5)
        {
            textLine = new TextLine(x + 1, y + 1 + ((height - 2) / 2), width - 2, text);
            activeFrame = new Frame(x, y, width, height, '#');
            nonActiveFrame = new Frame(x, y, width, height, '+');
        }

        public Button(int x, int y, int width, int height, string text) : base(x, y, width, height)
        {
            textLine = new TextLine(x + 1, y + 1 + ((height - 2) / 2), width - 2, text);

            activeFrame = new Frame(x, y, width, height, '#');
            nonActiveFrame = new Frame(x, y, width, height, '+');
        }

        public void SetActive()
        {
            isActive = true;
        }

        public void SetNotActive()
        {
            isActive = false;
        }

        public override void Render()
        {
            if (isActive)
            {
                activeFrame.Render();
            }
            else
            {
                nonActiveFrame.Render();
                
            }

            textLine.Render();
        }
    }
}