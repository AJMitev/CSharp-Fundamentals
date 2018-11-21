namespace SimpleSnake.GameObjects
{
    using System;

    public class Point
    {
        private int _leftX;
        private int _topY;

        public Point(int leftX, int topY)
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }

        public int LeftX
        {
            get
            {
                return _leftX;
            }
            set
            {
                //TODO: Think about directions
                if (value < -1 || value > Console.WindowWidth)
                {
                    throw new ArgumentException();
                }

                _leftX = value;
            }
        }

        public int TopY
        {
            get { return _topY; }
            set
            {
                if (value < -1 || value > Console.WindowHeight)
                {
                    throw new ArgumentException();
                }

                _topY = value;
            }
        }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.Write(symbol);
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX,topY);
            Console.Write(symbol);
        }
    }
}
