using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
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

        private List<GroupShape> groupShapes = new List<GroupShape>();
        public List<GroupShape> GroupShapes
        {
            get { return groupShapes; }
            set { groupShapes = value; }
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
            //just a random number that have so small probabillity to be same twice in our program
            rect.ShapeName = "rectangle#" + new Random().Next();

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
            //just a random number that have so small probabillity to be same twice in our program
            triangle.ShapeName = "triangle#" + new Random().Next();

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
            //just a random number that have so small probabillity to be same twice in our program
            circle.ShapeName = "circle#" + new Random().Next();

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
            //just a random number that have so small probabillity to be same twice in our program
            square.ShapeName = "square#" + new Random().Next();

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
            //just a random number that have so small probabillity to be same twice in our program
            hexagon.ShapeName = "hexagon#" + new Random().Next();

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
            if (selection.Any())
            {
                foreach (Shape item in Selection)
                {
                    item.Location = new PointF(
                    item.Location.X + p.X - lastLocation.X,
                    item.Location.Y + p.Y - lastLocation.Y
                    );
                }
            }
            lastLocation = p;
        }

        public void SetStrokeColor(Color color)
        {
            if (selection.Any())
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

        public void RotatePrimitive(float angle)
        {
            if (selection.Any())
            {
                foreach (var item in Selection)
                {
                    item.RotateAngle += angle;

                }
            }
        }

        public void ScalePrimitive(float scale)
        {
            if (selection.Count > 0)
            {
                foreach (var shape in Selection)
                {
                    shape.Scale *= scale;
                }
            }



        }

        public override void Draw(Graphics grfx)
        {
            base.Draw(grfx);

            if (selection != null)
            {

               // GraphicsState g;
                foreach (Shape shape in Selection)
                {
                  //  g = grfx.Save();
                   // shape.TransformationMatrix.Multiply(grfx.Transform);
                    float[] dashValues = { 4, 2 };
                    Pen dashPen = new Pen(Color.Black, 3);
                    //grfx.Transform = shape.TransformationMatrix;
                    dashPen.DashPattern = dashValues;
                    grfx.DrawRectangle(
                        dashPen,
                        shape.Location.X -10 ,
                        shape.Location.Y - 10,
                        shape.Width + 20,
                        shape.Height + 20
                        );

                  //  grfx.Restore(g);
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
            if (Selection.Count < 2) return;

            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            foreach (Shape item in Selection)
            {
                if (minX > item.Location.X) minX = item.Location.X;
                if (minY > item.Location.Y) minY = item.Location.Y;
                if (maxX < item.Location.X + item.Width) maxX = item.Location.X + item.Width;
                if (maxY < item.Location.Y + item.Height) maxY = item.Location.Y + item.Height;

            }

            GroupShape group = new GroupShape(new RectangleF(minX, minY, maxX - minX, maxY - minY));
            groupShapes.Add(group);
            group.SubShapes = Selection;
            Selection = new List<Shape> { group};

            foreach (Shape item in group.SubShapes)
            {
                ShapeList.Remove(item);
            }

            group.ShapeName = "group#" + new Random().Next();
            ShapeList.Add(group);

        }


        public void UngroupShapes()
        {
            // Check if there is only one selected shape, and it is a group
            if (Selection.Count == 1 && Selection[0] is GroupShape group)
            {
                // Get the subshapes from the group
                List<Shape> subShapes = group.SubShapes;

                // Remove the group from the groupShapes list and the ShapeList
                groupShapes.Remove(group);
                ShapeList.Remove(group);

                // Add the subshapes back to the ShapeList
                ShapeList.AddRange(subShapes);

                // Clear the selection and add the subshapes to the selection
                Selection.Clear();
                Selection.AddRange(subShapes);
            }
        }


        public object DeSerializeFile(string path = null)
        {
            object currentObject;
            Stream stream;
            IFormatter formatter = new BinaryFormatter();
            if (path == null)
            {
                stream = new FileStream("DrawFile.gvg", FileMode.Open);
            }
            else
            {
                stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
            }
            currentObject = formatter.Deserialize(stream);
            stream.Close();
            return currentObject;
        }

        public void SerializeFile(object currentObject, string path = null)
        {
            Stream stream;
            IFormatter binaryFormatter = new BinaryFormatter();
            if (path == null)
            {
                stream = new FileStream("WinFormFile.gvg", FileMode.Create, FileAccess.Write, FileShare.None);
            }
            else
            {
                string preparePath = path + ".gvg";
                stream = new FileStream(preparePath, FileMode.Create);
            }
            binaryFormatter.Serialize(stream, currentObject);
            stream.Close();
        }
    }
}
