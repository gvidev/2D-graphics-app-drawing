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
            nameTB.Text = "shape#" + new Random().Next();
            widthTB.Text = "200";
            heightTB.Text = "200";
            strokeWidthTB.Text = "1";
            typeComboBox.SelectedIndex = 0;
        }

        Color shapeColor = Color.White;
        Color strokeColor = Color.Black;


        private void addButton_Click(object sender, EventArgs e)
        {

            if (!IsEmpty())
            {
                var dialogProcessor = DialogProcessor.GetInstance();
                string name = nameTB.Text.Trim();

                int locationX = parseInt(xTB.Text.Trim());
                int locationY = parseInt(yTB.Text.Trim());
                int width = parseInt(widthTB.Text.Trim());
                int height = parseInt(heightTB.Text.Trim());
                int strokeWidth = parseInt(strokeWidthTB.Text.Trim());
                int selectedIndex = typeComboBox.SelectedIndex;
                int opacity = (int)opacityUpDown.Value;

                if (locationX < 0 || locationY < 0 || width < 0 || height < 0 || strokeWidth < 0 || selectedIndex < 0)
                {
                    errorLabel.Text = "Моля въведете правилни стойности във всички полета!";
                }
                else
                {
                    switch (selectedIndex)
                    {

                        case 0:
                            RectangleShape square =
                            new RectangleShape(new Rectangle(locationX, locationY, width, height));
                            square.FillColor = shapeColor;
                            square.StrokeColor = strokeColor;
                            square.ShapeName = name;
                            square.StrokeWidth = strokeWidth;
                            square.Opacity = opacity;
                            dialogProcessor.ShapeList.Add(square);
                            break;
                        case 1:
                            RectangleShape rectangle =
                            new RectangleShape(new Rectangle(locationX, locationY, width, height * 2));
                            rectangle.FillColor = shapeColor;
                            rectangle.StrokeColor = strokeColor;
                            rectangle.ShapeName = name;
                            rectangle.StrokeWidth = strokeWidth;
                            rectangle.Opacity = opacity;
                            dialogProcessor.ShapeList.Add(rectangle);
                            break;
                        case 2:
                            TriangleShape triangle =
                            new TriangleShape(new Rectangle(locationX, locationY, width, height));
                            triangle.FillColor = shapeColor;
                            triangle.StrokeColor = strokeColor;
                            triangle.ShapeName = name;
                            triangle.StrokeWidth = strokeWidth;
                            triangle.Opacity = opacity;
                            dialogProcessor.ShapeList.Add(triangle);
                            break;
                        case 3:
                            CircleShape circle =
                            new CircleShape(new Rectangle(locationX, locationY, width, height));
                            circle.FillColor = shapeColor;
                            circle.StrokeColor = strokeColor;
                            circle.ShapeName = name;
                            circle.StrokeWidth = strokeWidth;
                            circle.Opacity = opacity;
                            dialogProcessor.ShapeList.Add(circle);
                            break;
                        case 4:
                            HexagonShape hexagon =
                                new HexagonShape(new Rectangle(locationX, locationY, width, height));
                            hexagon.FillColor = shapeColor;
                            hexagon.StrokeColor = strokeColor;
                            hexagon.ShapeName = name;
                            hexagon.StrokeWidth = strokeWidth;
                            hexagon.Opacity = opacity;
                            dialogProcessor.ShapeList.Add(hexagon);
                            break;
                        default:
                            break;
                    }

                    this.Close();
                }

            }
            else
            {
                errorLabel.Text = "Моля въведете всички полета!";
            }
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

        int parseInt(string text)
        {
            try
            {
                return int.Parse(text);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        // validate if all groupbox have input
        private bool IsEmpty()
        {
            bool flag = false;

            foreach (System.Windows.Forms.TextBox tb in Controls.OfType<System.Windows.Forms.TextBox>())
            {
                if (tb.Text.Trim().Length == 0)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }


    }
}

