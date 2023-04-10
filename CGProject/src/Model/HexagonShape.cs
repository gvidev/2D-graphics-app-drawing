using System;
using System.Collections.Generic;
using System.Drawing;
using Draw.src.Model;
using System.Linq;
using System.Text;
using static System.Windows.Forms.LinkLabel;

namespace Draw.src.Model
{
    [Serializable]
    public class HexagonShape : Shape
    {
        public HexagonShape(RectangleF rect) : base(rect)
        {
        }

        public HexagonShape(Shape shape) : base(shape)
        {
        }


        PointF[] hexagon = new PointF[6];

        public override bool Contains(PointF point)
        {
            if (IsPointInPolygon(hexagon, point)) 
                return true;

            return false;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            
            base.DrawSelf(grfx);

            base.Rotate(grfx);
            base.Scaling(grfx);
            //point A
            float x_left = Rectangle.X;
            float y_left = Rectangle.Y + Rectangle.Height / 2;

            //point B
            float x_upLeft = Rectangle.X +  Rectangle.Width/4;
            float y_upLeft = Rectangle.Y;

            //point C
            float x_upRight = Rectangle.X + (3 * Rectangle.Width) / 4;
            float y_upRight = Rectangle.Y;

            //point D
            float x_right = Rectangle.X + Rectangle.Width;
            float y_right = Rectangle.Y + Rectangle.Height / 2;

            //point E
            float x_downRight = Rectangle.X + (3* Rectangle.Width)/4;
            float y_downRight = Rectangle.Y + Rectangle.Height;

            //point F
            float x_downLeft = Rectangle.X + Rectangle.Width/4;
            float y_downLeft = Rectangle.Y + Rectangle.Height; ;

           
           
            //PointF A = new PointF(x1, y1);
            //PointF B = new PointF(x2, y2);
            //PointF C = new PointF(x3, y3);

            PointF A = new PointF(x_left, y_left);
            PointF B = new PointF(x_upLeft, y_upLeft);
            PointF C = new PointF(x_upRight, y_upRight);
            PointF D = new PointF(x_right, y_right);
            PointF F = new PointF(x_downRight, y_downRight);
            PointF E = new PointF(x_downLeft, y_downLeft);

            hexagon[0] = A;
            hexagon[1] = B;
            hexagon[2] = C;
            hexagon[3] = D;
            hexagon[4] = F;
            hexagon[5] = E;

            

            FillColor = Color.FromArgb
                (
                Opacity,
                FillColor.R,
                FillColor.G,
                FillColor.B
                );

           // grfx.Transform = TransformationMatrix;

            grfx.FillPolygon(new SolidBrush(FillColor), hexagon);
            grfx.DrawPolygon(new Pen(StrokeColor, StrokeWidth), hexagon);

            grfx.ResetTransform();
        }


        //that should work correct
        private bool IsPointInPolygon(PointF[] polygon, PointF point)

        {

            bool isInside = false;

            for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)

            {

                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)) &&

                (point.X < (polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))

                {

                    isInside = !isInside;

                }

            }

            return isInside;

        }



    }
}
