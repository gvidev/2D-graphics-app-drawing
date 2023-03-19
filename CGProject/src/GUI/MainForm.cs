using Draw.src.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Draw
{
    /// <summary>
    /// Върху главната форма е поставен потребителски контрол,
    /// в който се осъществява визуализацията
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
        /// </summary>
        private DialogProcessor dialogProcessor = new DialogProcessor();


        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //

        }

        /// <summary>
        /// Изход от програмата. Затваря главната форма, а с това и програмата.
        /// </summary>
        void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
        /// </summary>
        void ViewPortPaint(object sender, PaintEventArgs e)
        {
            dialogProcessor.ReDraw(sender, e);
        }

        /// <summary>
        /// Бутон, който поставя на произволно място правоъгълник със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
        {

            int portHeigth = viewPort.Height -100;
            int portWidth = viewPort.Width - 100;

            dialogProcessor.AddRandomRectangle(portHeigth,portWidth);

            statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";

            viewPort.Invalidate();
        }

        private void DrawTriangleSpeedButtonClick(object sender, EventArgs e)
        {
            int portHeigth = viewPort.Height - 100;
            int portWidth = viewPort.Width - 100;

            dialogProcessor.AddRandomTriangle(portHeigth, portWidth);

            statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник";

            viewPort.Invalidate();
        }

        private void DrawCircleSpeedButtonClick(object sender, EventArgs e)
        {
            int portHeigth = viewPort.Height - 100  ;
            int portWidth = viewPort.Width - 100;

            dialogProcessor.AddRandomCircle(portHeigth, portWidth);

            statusBar.Items[0].Text = "Последно действие: Рисуване на кръг";

            viewPort.Invalidate();
        }

        private void DrawSquareSpeedButtonClick(object sender, EventArgs e)
        {
            int portHeigth = viewPort.Height - 100;
            int portWidth = viewPort.Width - 100;

            dialogProcessor.AddRandomSquare(portHeigth, portWidth);

            statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат";

            viewPort.Invalidate();

        }

        private void DrawHexagonSpeedButtonClick(object sender, EventArgs e)
        {

            int portHeigth = viewPort.Height - 100;
            int portWidth = viewPort.Width - 100;

            dialogProcessor.AddRandomHexagon(portHeigth, portWidth);

            statusBar.Items[0].Text = "Последно действие: Рисуване на шестоъгълник";

            viewPort.Invalidate();

        }


        /// <summary>
        /// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
        /// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
        /// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
        /// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
        /// </summary>
        void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (pickUpSpeedButton.Checked)
            {
                var temp = dialogProcessor.ContainsPoint(e.Location);


                if (temp != null)
                {
                    if (dialogProcessor.Selection.Contains(temp))
                    {
                            dialogProcessor.Selection.Remove(temp);  
                    }
                    
                    else{
                        dialogProcessor.Selection.Add(temp);
                    }
                    statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
                    dialogProcessor.IsDragging = true;
                    dialogProcessor.LastLocation = e.Location;
                    viewPort.Invalidate();
                }
            } 
        }

        /// <summary>
        /// Прихващане на преместването на мишката.
        /// Ако сме в режм на "влачене", то избрания елемент се транслира.
        /// </summary>
        void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (dialogProcessor.IsDragging)
            {
                if (dialogProcessor.Selection != null) 
                    statusBar.Items[0].Text = "Последно действие: Влачене";
                dialogProcessor.TranslateTo(e.Location);
                viewPort.Invalidate();
            }
        }

        /// <summary>
        /// Прихващане на отпускането на бутона на мишката.
        /// Излизаме от режим "влачене".
        /// </summary>
        void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dialogProcessor.IsDragging = false;
        }

        private void SetStrokeColor_Click(object sender, EventArgs e)
        {

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SetStrokeColor(colorDialog1.Color);
                viewPort.Invalidate();
            }


        }

        private void SetFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SetFillColor(colorDialog2.Color);
                viewPort.Invalidate();
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {

            dialogProcessor.SetOpacity((int)opacityChanger.Value);

            statusBar.Items[0].Text = "Последно действие: Промяна на непрозрачност на фигурата";

            viewPort.Invalidate();

        }

        private void strokeWitdhUpDown_ValueChanged(object sender, EventArgs e)
        {

            if (dialogProcessor.Selection != null)
            {

                dialogProcessor.SetStrokeWidth((int)strokeWidthUpDown.Value);

                statusBar.Items[0].Text = "Последно действие: Промяна на големината на контура на фигурата";

                viewPort.Invalidate();
            }
            else
            {
                MessageBox.Show("Please select item and try again!", "Not selected item",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            List<Shape> shapes = dialogProcessor.Selection;

            if (shapes.Count > 0)
            {
                foreach (Shape shape in shapes.ToList())
                {
                    dialogProcessor.RemoveFromList(shape);
                    dialogProcessor.RemoveFromSelection(shape);
                    statusBar.Items[0].Text = "Последно действие: Изтриване на примитив от платното";                 
                }
            }
            viewPort.Invalidate();

        }

        private Shape GetObjectType(Shape selectedShape)
        {
            var type = selectedShape.GetType();
            string typeName = type.Name;

            Shape newestShape;

            Rectangle rectangleCanvas
                = new Rectangle((int)selectedShape.Location.X + 5, (int)selectedShape.Location.Y + 5, 100, 200);

            Rectangle squareCanvas
                = new Rectangle((int)selectedShape.Location.X + 5, (int)selectedShape.Location.Y + 5, 150, 150);

            switch (typeName)
            {
                case "RectangleShape":
                    if (selectedShape.Height == selectedShape.Width)
                    {
                        newestShape =
                            new RectangleShape(squareCanvas);
                        newestShape.FillColor = selectedShape.FillColor;
                        newestShape.StrokeColor = selectedShape.StrokeColor;
                        newestShape.StrokeWidth = selectedShape.StrokeWidth;
                        newestShape.Opacity = selectedShape.Opacity;
                        return newestShape;
                    }
                    else
                    {
                        newestShape =
                            new RectangleShape(rectangleCanvas);
                        newestShape.FillColor = selectedShape.FillColor;
                        newestShape.StrokeColor = selectedShape.StrokeColor;
                        newestShape.StrokeWidth = selectedShape.StrokeWidth;
                        newestShape.Opacity = selectedShape.Opacity;
                        return newestShape;
                    }

                case "CircleShape":
                    newestShape =
                            new CircleShape(squareCanvas);
                    newestShape.FillColor = selectedShape.FillColor;
                    newestShape.StrokeColor = selectedShape.StrokeColor;
                    newestShape.StrokeWidth = selectedShape.StrokeWidth;
                    newestShape.Opacity = selectedShape.Opacity;
                    return newestShape;

                case "TriangleShape":
                    newestShape =
                            new TriangleShape(squareCanvas);
                    newestShape.FillColor = selectedShape.FillColor;
                    newestShape.StrokeColor = selectedShape.StrokeColor;
                    newestShape.StrokeWidth = selectedShape.StrokeWidth;
                    newestShape.Opacity = selectedShape.Opacity;
                    return newestShape;
            }
            return null;
        }



        //should be used for copy and paste element
        Shape newestShape;
        //Shape copiedShape;

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

            int portHeigth = viewPort.Height;
            int portWidth = viewPort.Width;


            if (e.Control && e.KeyCode == Keys.X)
            {
                //if (dialogProcessor.Selection != null)
                //{
                //    dialogProcessor.Remove(dialogProcessor.Selection);
                //    statusBar.Items[0].Text = "Последно действие: Изтриване на примитив от платното";
                //    viewPort.Invalidate();
                //}

                removeButton_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                var selectedShape = dialogProcessor.Selection;

                if (dialogProcessor.Selection.Count > 0)
                {
                    foreach (Shape shape in dialogProcessor.Selection)
                    {
                        newestShape = GetObjectType(shape);
                    }


                    //this line guarantee us that we can have choice to copy new shapes or save the latest
                    //copiedShapes[0] = newestShape;


                    //all above is not necesery
                    //no maybe not
                    // newestShape = selectedShape;
                }

            }

            if (e.Control && e.KeyCode == Keys.V)
            {
                if (newestShape != null)
                {
                    var temp = GetObjectType(newestShape);
                    //newestShape = copiedShapes[0];
                    dialogProcessor.ShapeList.Add(temp);
                    viewPort.Invalidate();

                    //there cannot be set to null because we want to have multiply copies of this shape
                    //copiedShapes[0]=null;
                }
            }

            //adding shortcuts to my application for better UI
            if (e.Control && e.KeyValue == 49)
            {


                dialogProcessor.AddRandomSquare(portHeigth,portWidth);
                viewPort.Invalidate();
            }
            if (e.Control && e.KeyValue == 50)
            {
                dialogProcessor.AddRandomRectangle(portHeigth, portWidth);
                viewPort.Invalidate();
            }
            if (e.Control && e.KeyValue == 51)
            {
                dialogProcessor.AddRandomTriangle(portHeigth, portWidth);
                viewPort.Invalidate();
            }
            if (e.Control && e.KeyValue == 52)
            {
                dialogProcessor.AddRandomCircle(portHeigth, portWidth);
                viewPort.Invalidate();
            }

        }


        //need to be implemented
        private void AddShapeButton_Click(object sender, EventArgs e)
        {

        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            int input;
            if (int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Please enter an integer value:", "User Input", ""), out input))
            {
                dialogProcessor.RotatePrimitive(input);
                viewPort.Invalidate();
            }
            else
            {
                MessageBox.Show("Please enter a valid integer value");
            }


        }

        private void ScaleButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.ScalePrimitive();
            

            viewPort.Invalidate();
        }

        private void RemoveGroupSelectionBtn_Click(object sender, EventArgs e)
        {
            dialogProcessor.GroupPrimitives();
            viewPort.Invalidate();
        }
        
    }
}
