using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    [Serializable]
    public class CircleShape : Shape
    {
        
        public CircleShape(RectangleF rect) : base(rect)
        {
        }

        public CircleShape(Shape shape) : base(shape)
        {
        }

        public override bool Contains(PointF point)
        {
            //x1,y1 are used for point cordinates
            //x, y, R for our Circle center codinates - p.O(x,y)
            //R - radius
            float x = Rectangle.X + Rectangle.Width/2;
            float y = Rectangle.Y + Rectangle.Height/2;
            float x1 = point.X;
            float y1 = point.Y;
            float R = Rectangle.Height/ 2;
           
            if (!isInside(x1,y1,x,y,R))
            {
                return false;
            }
            return true;

        }
        //Matrix transformationMatrix = new Matrix();
        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
          
            base.DrawSelf(grfx);


            

            base.Scaling(grfx);
            base.Rotate(grfx);
            
            FillColor = Color.FromArgb
                (
                Opacity,
                FillColor.R,
                FillColor.G,
                FillColor.B
                );

           // var state = grfx.Save();

            
           // grfx.Transform = TransformationMatrix;

            grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(new Pen(StrokeColor, StrokeWidth), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);


          //  grfx.Restore(state);
            grfx.ResetTransform();
        }

        //x1,y1 are used for point cordinates
        //x, y, R for our Circle center codinates - p.O(x,y)
        //R - radius
        private bool isInside(float x1,float y1, float x, float y, float R)
        {
            double result = (Math.Pow(Math.Abs(x1 - x),2) + (Math.Pow(Math.Abs(y1 - y), 2)));
            if(result <= Math.Pow((R),2))
            {
                return true;
            }
            return false;
        }
    }
}
