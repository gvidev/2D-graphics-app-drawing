using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Draw.src.Model
{
    [Serializable]
    public class TriangleShape : Shape
    {

        #region Constructor
        public TriangleShape(RectangleF rect) : base(rect)
        {
        }

        public TriangleShape(TriangleShape triangle) : base(triangle)
        {
        }

        public TriangleShape(float x1, float y1, float x2, float y2, float x3, float y3)
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

            if (isInside(x_Left, y_Left, x_up, y_up, x_right, y_right,point.X,point.Y))
                return true;
            else
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            //float x1 = 40, y1 = 160;
            //float x2 = 100, y2 = 40;
            //float x3 = 160, y3 = 160;

            //point B
            float x_up = Rectangle.X + Rectangle.Width / 2;
            float y_up = Rectangle.Y;

            //point A
            float x_Left = Rectangle.X;
            float y_Left = Rectangle.Y + Rectangle.Height;

            //point C
            float x_right = Rectangle.X + Rectangle.Width;
            float y_right = Rectangle.Y + Rectangle.Height;

           
            base.DrawSelf(grfx);
            base.Rotate(grfx);
            base.Scaling(grfx);
            PointF[] points = new PointF[3];
            //PointF A = new PointF(x1, y1);
            //PointF B = new PointF(x2, y2);
            //PointF C = new PointF(x3, y3);

            PointF A = new PointF(x_Left, y_Left);
            PointF B = new PointF(x_up, y_up);
            PointF C = new PointF(x_right, y_right);

            points[0]= A;
            points[1]= B;
            points[2]= C;

            FillColor = Color.FromArgb
                (
                Opacity,
                FillColor.R,
                FillColor.G,
                FillColor.B
                );

            //grfx.Transform = TransformationMatrix;

            grfx.FillPolygon(new SolidBrush(FillColor), points);
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
