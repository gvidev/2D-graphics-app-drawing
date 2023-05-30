using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    [Serializable]
    public class Shape0: Shape
    {

        #region Constructor
        public Shape0(RectangleF rect) : base(rect)
        {
        }

        public Shape0(Shape0 shape0) : base(shape0)
        {
        }

        public Shape0(float x1, float y1, float x2, float y2, float x3, float y3)
        {

        }


        #endregion

        public override bool Contains(PointF point)
        {
            //point B
            float x_up = Rectangle.X + Rectangle.Width / 2;
            float y_up = Rectangle.Y;

            //point A
            float x_Left = Rectangle.X;
            float y_Left = Rectangle.Y + Rectangle.Height;

            //point C
            float x_right = Rectangle.X + Rectangle.Width;
            float y_right = Rectangle.Y + Rectangle.Height;

            if (isInside(x_Left, y_Left, x_up, y_up, x_right, y_right, point.X, point.Y))
                return true;
            else
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            //point B
            float x_up = Rectangle.X + Rectangle.Width / 2;
            float y_up = Rectangle.Y;

            //point A
            float x_Left = Rectangle.X;
            float y_Left = Rectangle.Y + Rectangle.Height;

            //point C
            float x_right = Rectangle.X + Rectangle.Width;
            float y_right = Rectangle.Y + Rectangle.Height;

            // Point G
            float x_center = Rectangle.X + Rectangle.Width / 2;
            float y_center = Rectangle.Y + Rectangle.Height / 2;


            base.DrawSelf(grfx);
            base.Rotate(grfx);
            base.Scaling(grfx);
            PointF[] points = new PointF[3];

            PointF A = new PointF(x_Left, y_Left);
            PointF B = new PointF(x_up, y_up);
            PointF C = new PointF(x_right, y_right);
            PointF G = new PointF(x_center, y_center);


            points[0] = A;
            points[1] = B;
            points[2] = C;



            FillColor = Color.FromArgb
                (
                Opacity,
                FillColor.R,
                FillColor.G,
                FillColor.B
                );


            grfx.FillPolygon(new SolidBrush(FillColor), points);
            grfx.DrawLine(new Pen(StrokeColor, StrokeWidth), points[0], G);
            grfx.DrawLine(new Pen(StrokeColor, StrokeWidth), points[1], G);
            grfx.DrawLine(new Pen(StrokeColor, StrokeWidth), points[2], G);
            grfx.DrawPolygon(new Pen(StrokeColor, StrokeWidth), points);

            grfx.ResetTransform();
        }

        private double AreaOfTriangle(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            double result = Math.Abs((x1 * (y2 - y3)
                + x2 * (y3 - y1)
                + x3 * (y1 - y2)) / 2.0);

            return result;
        }

        private bool isInside(float x1, float y1, float x2, float y2, float x3, float y3, float x, float y)
        {
            //Lets our triangle be ABC and the outer or inner point be G

            /* Calculate Area of our shape */
            double A = AreaOfTriangle(x1, y1, x2, y2, x3, y3);

            /* Calculate area of triangle GBC */
            double A1 = AreaOfTriangle(x, y, x2, y2, x3, y3);

            /* Calculate area of triangle GAC */
            double A2 = AreaOfTriangle(x1, y1, x, y, x3, y3);

            /* Calculate area of triangle GAB */
            double A3 = AreaOfTriangle(x1, y1, x2, y2, x, y);



            return (A == A1 + A2 + A3);
        }
    }
}
