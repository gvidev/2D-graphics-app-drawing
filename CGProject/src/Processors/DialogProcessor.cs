using Draw.src.Model;
using System;
using System.Drawing;

namespace Draw
{
    /// <summary>
    /// Класът, който ще бъде използван при управляване на диалога.
    /// </summary>
    public class DialogProcessor : DisplayProcessor
    {
        #region Constructor

        public DialogProcessor()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Избран елемент.
        /// </summary>
        private Shape selection;
        public Shape Selection
        {
            get { return selection; }
            set { selection = value; }
        }

        /// <summary>
        /// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
        /// </summary>
        private bool isDragging;
        public bool IsDragging
        {
            get { return isDragging; }
            set { isDragging = value; }
        }

        /// <summary>
        /// Последна позиция на мишката при "влачене".
        /// Използва се за определяне на вектора на транслация.
        /// </summary>
        private PointF lastLocation;
        public PointF LastLocation
        {
            get { return lastLocation; }
            set { lastLocation = value; }
        }

        #endregion

        /// <summary>
        /// Добавя примитив - правоъгълник на произволно място върху клиентската област.
        /// </summary>
        public void AddRandomRectangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            RectangleShape rect = new RectangleShape(new Rectangle(x, y, 100, 200));
            rect.FillColor = Color.White;
            rect.StrokeColor = Color.Black;

            ShapeList.Add(rect);
        }


        public void AddRandomTriangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 800);
            int y = rnd.Next(100, 400);

            TriangleShape triangle = new TriangleShape(new Rectangle(x, y, 150, 150));
            triangle.FillColor = Color.White;
            triangle.StrokeColor = Color.Black;

            ShapeList.Add(triangle);
        }

        public void AddRandomCircle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 800);
            int y = rnd.Next(100, 400);

            CircleShape circle = new CircleShape(new Rectangle(x, y, 150, 150));
            circle.FillColor = Color.White;
            circle.StrokeColor = Color.Black;

            ShapeList.Add(circle);
        }

        public void AddRandomSquare()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 800);
            int y = rnd.Next(100, 400);

            RectangleShape square = new RectangleShape(new Rectangle(x, y, 150, 150));
            square.FillColor = Color.White;
            square.StrokeColor = Color.Black;

            ShapeList.Add(square);
        }

        public void AddRandomHexagon()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            HexagonShape hexagon = new HexagonShape(new Rectangle(x, y, 200, 180));
            hexagon.FillColor = Color.White;
            hexagon.StrokeColor = Color.Black;

            ShapeList.Add(hexagon);
        }

        /// <summary>
        /// Проверява дали дадена точка е в елемента.
        /// Обхожда в ред обратен на визуализацията с цел намиране на
        /// "най-горния" елемент т.е. този който виждаме под мишката.
        /// </summary>
        /// <param name="point">Указана точка</param>
        /// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
        public Shape ContainsPoint(PointF point)
        {
            for (int i = ShapeList.Count - 1; i >= 0; i--)
            {
                if (ShapeList[i].Contains(point))
                {

                    return ShapeList[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
        /// </summary>
        /// <param name="p">Вектор на транслация.</param>
        public void TranslateTo(PointF p)
        {
            if (selection != null)
            {
                selection.Location = new PointF(
                    selection.Location.X + p.X - lastLocation.X,
                    selection.Location.Y + p.Y - lastLocation.Y
                    );
                lastLocation = p;
            }
        }

        public void SetStrokeColor(Color color)
        {
            if (selection != null)
            {
                selection.StrokeColor = color;
            }
        }

        public void SetFillColor(Color color)
        {
            if (selection != null)
            {
                selection.FillColor = color;
            }
        }

        public void SetStrokeWidth(int strokeWidth)
        {
            if (selection != null)
            {
                selection.StrokeWidth = strokeWidth;
            }
        }

        public void SetOpacity(int opacity)
        {
            if (selection != null)
            {
                selection.Opacity = opacity;
            }
        }

        public void RotatePrimitive(int angle)
        {
            if (selection != null)
            {
                Selection.TransformationMatrix.RotateAt(
                    angle,
                    new PointF(
                    Selection.Location.X + Selection.Width /2,
                    Selection.Location.Y + Selection.Height/2
                    )
                    );
            }
        }

        public void ScalePrimitive()
        {

            if (selection != null)
            {

                Selection.TransformationMatrix.Scale(
                Selection.Location.X ,
                Selection.Location.Y
                );
            }
            


        }

        public override void Draw(Graphics grfx)
        {
            base.Draw(grfx);

            if (selection != null)
            {
                float[] dashValues = {4, 2};
                Pen dashPen = new Pen(Color.Black, 3);
                dashPen.DashPattern = dashValues;
                grfx.DrawRectangle(
                    dashPen,
                    Selection.Location.X - 3, 
                    Selection.Location.Y - 3,
                    Selection.Width + 6 , 
                    Selection.Height + 6 
                    );
            }
        }

        public void Remove(Shape shape)
        {

            ShapeList.Remove(shape);
            shape = null;

        }

    }
}
