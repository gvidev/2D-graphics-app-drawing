using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Draw;

namespace Draw.src.Model
{

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

            foreach (Shape item in SubShapes)
            {
                item.DrawSelf(grfx);
            }
        }
    }
}

