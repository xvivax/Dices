namespace Dices
{
    public abstract class GuiObject
    {
        protected int x;
        protected int y;
        protected int width;
        protected int height;

        protected GuiObject(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public abstract void Render();
    }
}