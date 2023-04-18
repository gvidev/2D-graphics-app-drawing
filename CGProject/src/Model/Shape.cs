using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    /// <summary>
    /// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
    /// </summary>
	 [Serializable]
    public abstract class Shape
    {
		#region Constructors
		
		public Shape()
		{
		}
		
		public Shape(RectangleF rect)
		{
			rectangle = rect;
		}
		
		public Shape(Shape shape)
		{
			this.Height = shape.Height;
			this.Width = shape.Width;
			this.Location = shape.Location;
			this.rectangle = shape.rectangle;
			
			this.FillColor =  shape.FillColor;
		}
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Обхващащ правоъгълник на елемента.
		/// </summary>
		private RectangleF rectangle;		
		public virtual RectangleF Rectangle {
			get { return rectangle; }
			set { rectangle = value; }
		}
		
		/// <summary>
		/// Широчина на елемента.
		/// </summary>
		public virtual float Width {
			get { return Rectangle.Width; }
			set { rectangle.Width = value; }
		}
		
		/// <summary>
		/// Височина на елемента.
		/// </summary>
		public virtual float Height {
			get { return Rectangle.Height; }
			set { rectangle.Height = value; }
		}
		
		/// <summary>
		/// Горен ляв ъгъл на елемента.
		/// </summary>
		public virtual PointF Location {
			get { return Rectangle.Location; }
			set { rectangle.Location = value; }
		}
		
		/// <summary>
		/// Цвят на елемента.
		/// </summary>
		private Color fillColor;		
		public virtual Color FillColor {
			get { return fillColor; }
			set { fillColor = value; }
		}

        private Color strokeColor;
        public virtual Color StrokeColor
        {
            get { return strokeColor; }
            set { strokeColor = value; }
        }

        private string shapeName;
        public virtual string ShapeName
        {
            get { return shapeName; }
            set { shapeName = value; }
        }

        private int strokeWidth = 1;
        public virtual int StrokeWidth
        {
            get { return strokeWidth; }
            set { strokeWidth = value; }
        }

		//set a default value for the first initialize
		private int opacity = 100;
        public virtual int Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }

		//private Matrix transformationMatrix =new Matrix();
  //      public virtual Matrix TransformationMatrix
  //      {
  //          get { return transformationMatrix; }
  //          set { transformationMatrix = value; }
  //      }

        private float rotateAngle = 0;

        public virtual float RotateAngle
        {
            get { return rotateAngle; }
			set { rotateAngle = value; }

        }


        private float scale = 1;

        public virtual float Scale
        {
            get { return scale; }
            set { scale = value; }

        }

        #endregion


        /// <summary>
        /// Проверка дали точка point принадлежи на елемента.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Връща true, ако точката принадлежи на елемента и
        /// false, ако не пренадлежи</returns>
        public virtual bool Contains(PointF point)
		{
			return Rectangle.Contains(point.X, point.Y);
		}

        public virtual void Rotate(Graphics grfx)
        {
            grfx.TranslateTransform(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);

            grfx.RotateTransform(RotateAngle);

            grfx.TranslateTransform(-(Rectangle.X + Rectangle.Width / 2), -(Rectangle.Y + Rectangle.Height / 2));
        }

        //public virtual void Rotate(Graphics grfx)
        //{
        //    grfx.TranslateTransform(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);
        //    grfx.RotateTransform(RotateAngle);
        //    grfx.TranslateTransform(-(Rectangle.X + Rectangle.Width / 2), -(Rectangle.Y + Rectangle.Height / 2));

        //    // Update the shape's bounding box to match its new visual appearance
        //    Matrix rotationMatrix = new Matrix();
        //    rotationMatrix.RotateAt(RotateAngle, new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2));
        //    PointF[] corners = { new PointF(Rectangle.X, Rectangle.Y), new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y), new PointF(Rectangle.X, Rectangle.Y + Rectangle.Height), new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height) };
        //    rotationMatrix.TransformPoints(corners);
        //    float left = Math.Min(corners[0].X, Math.Min(corners[1].X, Math.Min(corners[2].X, corners[3].X)));
        //    float top = Math.Min(corners[0].Y, Math.Min(corners[1].Y, Math.Min(corners[2].Y, corners[3].Y)));
        //    float right = Math.Max(corners[0].X, Math.Max(corners[1].X, Math.Max(corners[2].X, corners[3].X)));
        //    float bottom = Math.Max(corners[0].Y, Math.Max(corners[1].Y, Math.Max(corners[2].Y, corners[3].Y)));
        //    Rectangle = new RectangleF(left, top, right - left, bottom - top);
        //}

        //public virtual void Scaling(Graphics grfx)
        //{
        //    grfx.TranslateTransform(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);
        //    grfx.ScaleTransform(scale, scale);
        //    grfx.TranslateTransform(-(Rectangle.X + Rectangle.Width / 2), -(Rectangle.Y + Rectangle.Height / 2));

        //    // Update the shape's size to match its new visual appearance
        //    SizeF newSize = new SizeF(Rectangle.Width * scale, Rectangle.Height * scale);
        //    PointF newLocation = new PointF(Rectangle.X + (Rectangle.Width - newSize.Width) / 2, Rectangle.Y + (Rectangle.Height - newSize.Height) / 2);
        //    Rectangle = new RectangleF(newLocation, newSize);
        //}



        public virtual void Scaling(Graphics grfx)
        {
            grfx.TranslateTransform(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);

            grfx.ScaleTransform(scale, scale);

            grfx.TranslateTransform(-(Rectangle.X + Rectangle.Width / 2), -(Rectangle.Y + Rectangle.Height / 2));
        }

        /// <summary>
        /// Визуализира елемента.
        /// </summary>
        /// <param name="grfx">Къде да бъде визуализиран елемента.</param>
        public virtual void DrawSelf(Graphics grfx)
		{
			// shape.Rectangle.Inflate(shape.BorderWidth, shape.BorderWidth);
		}


		
	}
}
