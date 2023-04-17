using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Forms;
using Draw.src.Model;

namespace Draw
{
    public partial class AddShape : Form
    {
        public AddShape()
        {
            InitializeComponent();
        }

        Color shapeColor = Color.White;
        Color strokeColor = Color.Black;
        
        private void addButton_Click(object sender, EventArgs e)
        {
            //DisplayProcessor displayProcessor= new DisplayProcessor();
            var dialogProcessor = DialogProcessor.GetInstance();
            string name = nameTB.Text.Trim();
            int locationX = int.Parse(xTB.Text.Trim());
            int locationY = int.Parse(yTB.Text.Trim());
            int width = int.Parse(widthTB.Text.Trim());
            int height = int.Parse(heightTB.Text.Trim());
            int strokeWidth = int.Parse(strokeWidthTB.Text.Trim());

            int selectedIndex = typeComboBox.SelectedIndex;
           
            switch (selectedIndex)
            {

                case 0:
                    RectangleShape square = 
                    new RectangleShape(new Rectangle(locationX, locationY, width, height));
                    square.FillColor = shapeColor;
                    square.StrokeColor = strokeColor;
                    square.ShapeName = name;
                    square.StrokeWidth= strokeWidth;
                    dialogProcessor.ShapeList.Add(square);
                    break;
                case 1:
                    RectangleShape rectangle =
                    new RectangleShape(new Rectangle(locationX, locationY, width, height*2));
                    rectangle.FillColor = shapeColor;
                    rectangle.StrokeColor = strokeColor;
                    rectangle.ShapeName = name;
                    rectangle.StrokeWidth = strokeWidth;
                    dialogProcessor.ShapeList.Add(rectangle);
                    break;
                case 2:
                    TriangleShape triangle =
                    new TriangleShape(new Rectangle(locationX, locationY, width, height));
                    triangle.FillColor = shapeColor;
                    triangle.StrokeColor = strokeColor;
                    triangle.ShapeName = name;
                    triangle.StrokeWidth = strokeWidth;
                    dialogProcessor.ShapeList.Add(triangle);
                    break;
                case 3:
                    CircleShape circle =
                    new CircleShape(new Rectangle(locationX, locationY, width, height));
                    circle.FillColor = shapeColor;
                    circle.StrokeColor = strokeColor;
                    circle.ShapeName = name;
                    circle.StrokeWidth = strokeWidth;
                    dialogProcessor.ShapeList.Add(circle);
                    break;
                case 4:
                    HexagonShape hexagon =
                        new HexagonShape(new Rectangle(locationX, locationY, width, height));
                    hexagon.FillColor = shapeColor;
                    hexagon.StrokeColor = strokeColor;
                    hexagon.ShapeName = name;
                    hexagon.StrokeWidth = strokeWidth;
                    dialogProcessor.ShapeList.Add(hexagon);
                    break;
                default:
                    break;
            }

            this.Close();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                shapeColor = colorDialog1.Color;
            }
        }

        private void strokeColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                strokeColor = colorDialog2.Color;
            }
        }
    }
}
