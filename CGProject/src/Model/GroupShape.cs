using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using Draw;

namespace Draw.src.Model
{
    [Serializable]
    public class GroupShape : Shape
    {

        private List<Shape> subShapes = new List<Shape>();
        public virtual List<Shape> SubShapes
        {
            get { return subShapes; }
            set { subShapes = value; }
        }

        #region Constructor

        public GroupShape(RectangleF rect) : base(rect)
        {
        }

        public GroupShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        public override PointF Location
        {
            get { return base.Location; }
            set
            {
                foreach (Shape item in SubShapes)
                {
                    item.Location = new PointF(item.Location.X - Location.X + value.X,
                        item.Location.Y - Location.Y + value.Y);
                }
                base.Location = new PointF(value.X, value.Y);
            }
        }

        public override Color FillColor
        {
            get => base.FillColor;
            set
            {
                foreach (var item in SubShapes)
                {
                    item.FillColor = value;
                }
            }
        }

        public override Color StrokeColor
        {
            get => base.StrokeColor;
            set
            {
                foreach (var item in SubShapes)
                {
                    item.StrokeColor = value;
                }
            }
        }

        public override int StrokeWidth
        {
            get => base.StrokeWidth;
            set
            {
                foreach (var item in SubShapes)
                {
                    item.StrokeWidth = value;
                }
            }
        }

        public override int Opacity
        {
            get => base.Opacity;
            set
            {
                foreach (var item in SubShapes)
                {
                    item.Opacity = value;
                }
            }
        }

        public override float RotateAngle
        {
            get => base.RotateAngle;
            set
            {
                foreach (var item in SubShapes)
                {
                    item.RotateAngle += value;
                }
            }
        }

        public override float Scale
        {
            get => base.Scale;
            set
            {
                foreach (var item in SubShapes)
                {
                    item.Scale = value;
                }
            }
        }

        //public override Matrix TransformationMatrix
        //{ get => base.TransformationMatrix; 
        //    set { 
        //        base.TransformationMatrix.Multiply(value); 
        //        foreach(Shape item in SubShapes)
        //        {
        //            item.TransformationMatrix.Multiply(value);
        //        }
        //    }
        //}



        public override bool Contains(PointF point)
        {
            foreach (Shape item in SubShapes)
            {
                if (item.Contains(point))
                {
                    return true;
                }

            }

            return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            
            base.DrawSelf(grfx);
          //  base.Rotate(grfx);
            foreach (Shape item in SubShapes)
            {
                item.DrawSelf(grfx);
               // grfx.ResetTransform();
            }
        }
    }
}

