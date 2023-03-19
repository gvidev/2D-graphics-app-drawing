using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Controls;

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
        private List<Shape> selection = new List<Shape>();
        public List<Shape> Selection
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
        public void AddRandomRectangle(int heigth, int width)
        {
            Random rnd = new Random();
            int x = rnd.Next(50, width);
            int y = rnd.Next(50, heigth);

            RectangleShape rect = new RectangleShape(new Rectangle(x, y, 100, 200));
            rect.FillColor = Color.White;
            rect.StrokeColor = Color.Black;

            ShapeList.Add(rect);
        }


        public void AddRandomTriangle(int heigth, int width)
        {
            Random rnd = new Random();
            int x = rnd.Next(50, width);
            int y = rnd.Next(50, heigth);

            TriangleShape triangle = new TriangleShape(new Rectangle(x, y, 150, 150));
            triangle.FillColor = Color.White;
            triangle.StrokeColor = Color.Black;

            ShapeList.Add(triangle);
        }

        public void AddRandomCircle(int heigth, int width)
        {
            Random rnd = new Random();
            int x = rnd.Next(50, width);
            int y = rnd.Next(50, heigth);

            CircleShape circle = new CircleShape(new Rectangle(x, y, 150, 150));
            circle.FillColor = Color.White;
            circle.StrokeColor = Color.Black;

            ShapeList.Add(circle);
        }

        public void AddRandomSquare(int heigth, int width)
        {
            Random rnd = new Random();
            int x = rnd.Next(50, width);
            int y = rnd.Next(50, heigth);

            RectangleShape square = new RectangleShape(new Rectangle(x, y, 150, 150));
            square.FillColor = Color.White;
            square.StrokeColor = Color.Black;

            ShapeList.Add(square);
        }

        public void AddRandomHexagon(int heigth, int width)
        {
            Random rnd = new Random();
            int x = rnd.Next(50, width);
            int y = rnd.Next(50, heigth);

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
            if (selection.Count > 0)
            {
                foreach (Shape item in Selection)
                {
                    item.Location = new PointF(
                    item.Location.X + p.X - lastLocation.X,
                    item.Location.Y + p.Y - lastLocation.Y
                    );
                }
                
                lastLocation = p;
            }
        }

        public void SetStrokeColor(Color color)
        {
            if (selection.Count > 0)
            {

                foreach (Shape shape in Selection)
                {
                    shape.StrokeColor = color;
                }
                
            }
        }

        public void SetFillColor(Color color)
        {
            if (selection.Count > 0)
            {
                foreach (Shape shape in Selection)
                {
                    shape.FillColor = color;
                }
                
            }
        }

        public void SetStrokeWidth(int strokeWidth)
        {
            if (selection.Count > 0)
            {
                foreach (Shape shape in Selection)
                {
                     shape.StrokeWidth = strokeWidth;
                }
               
            }
        }

        public void SetOpacity(int opacity)
        {
            if (selection.Count > 0)
            {
                foreach (Shape shape in Selection)
                {
                    shape.Opacity = opacity;
                }
                
            }
        }

        public void RotatePrimitive(int angle)
        {
            if (selection.Count > 0)
            {
                foreach (Shape shape in Selection)
                {
                    shape.TransformationMatrix.RotateAt(
                    angle,
                    new PointF(
                    shape.Location.X + shape.Width /2,
                    shape.Location.Y + shape.Height/2
                    )
                    );

                }
                
            }
        }

        public void ScalePrimitive()
        {
            if (selection.Count > 0)
            {
                foreach (var shape in Selection)
                {
                    

                    PointF[] pointsOfShape = { shape.Location,
                                               new PointF(shape.Location.X + shape.Width, shape.Location.Y),
                                               new PointF(shape.Location.X, shape.Location.Y + shape.Height),
                                               new PointF(shape.Location.X + shape.Width, shape.Location.Y + shape.Height + shape.Width)
                    };

                    shape.TransformationMatrix.Scale(2, 2);
                    shape.TransformationMatrix.TransformPoints( pointsOfShape );

                    Shape shape1 = shape;

                    ShapeList.Add(shape1);

                    //somehow need to reDraw


                }


                //// Get the coordinates of the graphic figure
                //PointF[] points = { };

                //// Create a new matrix and set the scaling factors
                //Matrix scalingMatrix = new Matrix();
                //scalingMatrix.Scale(2.0f, 2.0f); // Double the size of the figure

                //// Transform the coordinates using the scaling matrix
                //scalingMatrix.TransformPoints(points);

                //// Redraw the graphic figure using the transformed coordinates
                //RedrawFigure(points);



            }



        }

        public override void Draw(Graphics grfx)
        {
            base.Draw(grfx);

            if (selection.Count > 0)
            {
                foreach (Shape shape in Selection)
                {
                    float[] dashValues = {4, 2};
                Pen dashPen = new Pen(Color.Black, 3);
                dashPen.DashPattern = dashValues;
                grfx.DrawRectangle(
                    dashPen,
                    shape.Location.X - 3, 
                    shape.Location.Y - 3,
                    shape.Width + 6 , 
                    shape.Height + 6 
                    );
                }
                
            }
        }

        public void RemoveFromList(Shape shape)
        {

            ShapeList.Remove(shape);
            shape = null;
            
        }
        public void RemoveFromSelection(Shape shape)
        {

            Selection.Remove(shape);

        }

        public void GroupPrimitives()
        {
            //TODO for the bounding box : 
            //define 4 variables - minX, maxX, minY,maxY
            //iterate the subShape
            //find the left most primitive and store the x coord
            //find the top most primitive and store the y coord
            //find the top most primitive and store its right most location
            //find the bot most primitive and store its botton most location
            GroupShape group = new GroupShape(new RectangleF(200,300,150,200));
          

           
            group.SubShapes = selection;
            selection.Clear();

        }
    }
}
