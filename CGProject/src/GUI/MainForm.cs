
using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;

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
        /// 

        //get the current dialogProcessor in use in mainForm
        private DialogProcessor dialogProcessor = DialogProcessor.GetInstance();


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

            int portHeigth = viewPort.Height - 100;
            int portWidth = viewPort.Width - 100;

            dialogProcessor.AddRandomRectangle(portHeigth, portWidth);

            statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник на произволно място на платното";

            viewPort.Invalidate();
        }

        private void DrawTriangleSpeedButtonClick(object sender, EventArgs e)
        {
            int portHeigth = viewPort.Height - 100;
            int portWidth = viewPort.Width - 100;

            dialogProcessor.AddRandomTriangle(portHeigth, portWidth);

            statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник на произволно място на платното";

            viewPort.Invalidate();
        }

        private void DrawCircleSpeedButtonClick(object sender, EventArgs e)
        {
            int portHeigth = viewPort.Height - 100;
            int portWidth = viewPort.Width - 100;

            dialogProcessor.AddRandomCircle(portHeigth, portWidth);

            statusBar.Items[0].Text = "Последно действие: Рисуване на кръг на произволно място на платното";

            viewPort.Invalidate();
        }

        private void DrawSquareSpeedButtonClick(object sender, EventArgs e)
        {
            int portHeigth = viewPort.Height - 100;
            int portWidth = viewPort.Width - 100;

            dialogProcessor.AddRandomSquare(portHeigth, portWidth);

            statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат на произволно място на платното";

            viewPort.Invalidate();

        }

        private void DrawHexagonSpeedButtonClick(object sender, EventArgs e)
        {

            int portHeigth = viewPort.Height - 100;
            int portWidth = viewPort.Width - 100;

            dialogProcessor.AddRandomHexagon(portHeigth, portWidth);

            statusBar.Items[0].Text = "Последно действие: Рисуване на шестоъгълник на произволно място на платното";

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
                    else
                    {
                        dialogProcessor.Selection.Add(temp);
                    }

                    if (dialogProcessor.Selection.Count == 1)
                    {
                        statusBar.Items[0].Text = "Последно действие: Селекция на примитив с име " + dialogProcessor.Selection.First().ShapeName;
                        strokeWidthUpDown.Value = dialogProcessor.Selection.First().StrokeWidth;
                        opacityChanger.Value = dialogProcessor.Selection.First().Opacity;
                    }

                    if (dialogProcessor.Selection.Count > 1)
                    {
                        statusBar.Items[0].Text = "Последно действие: Селекция на примитиви";
                    }

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
                statusBar.Items[0].Text = "Последно действие: Смяна на цвят на контура";
                viewPort.Invalidate();
            }


        }

        private void SetFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SetFillColor(colorDialog2.Color);
                statusBar.Items[0].Text = "Последно действие: Смяна на цвят на фигурата";
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


            dialogProcessor.SetStrokeWidth((int)strokeWidthUpDown.Value);

            statusBar.Items[0].Text = "Последно действие: Промяна на големината на контура на фигурата";

            viewPort.Invalidate();

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

        //should be used for copy and paste element
        //List<Shape> newestShapes = null;
        bool copy = false;
        List<Shape> copiedSelection = null;

        //already reworked! Now it works also with Groups and so on...
        //So many things are not necessary
        private void copyButton_Click(object sender, EventArgs e)
        {
            copiedSelection = dialogProcessor.Selection;
            copy = true;
            statusBar.Items[0].Text = "Последно действие: Копиране на селекцията";
            //var selectedShape = dialogProcessor.Selection;

            //if (dialogProcessor.Selection.Count > 0)
            //{
            //    newestShapes = new List<Shape>();
            //    foreach (Shape shape in dialogProcessor.Selection)
            //    {
            //        var temp = GetObjectType(shape);
            //        newestShapes.Add(temp);
            //        copy = true;
            //        statusBar.Items[0].Text = "Последно действие: Копиране на селекцията";
            //    }
            //}
        }

        
        //already reworked! Now it works also with Groups and so on...
        private void pasteButton_Click(object sender, EventArgs e)
        {
            if (copy)
            {
                if (copiedSelection != null)
                {
                    for (int i = 0; i < copiedSelection.Count; i++)
                    {
                        //gets the first element in the selection
                        //whatever group or shape is 
                        var item = copiedSelection[i];

                        //check if it is a group
                        if (item.GetType().Name.Equals("GroupShape"))
                        {
                            //then create a new groupShape to go through it
                            //we copy the info from the selection[item]
                            GroupShape group = (GroupShape)copiedSelection[i];

                            //then I simply create a new rectangle for the border but with extended bord
                            //from the first one
                            Rectangle rectangle =
                                new Rectangle((int)group.Rectangle.Location.X, (int)group.Rectangle.Location.Y,
                                (int)group.Width + 50, (int)group.Height + 50);

                            //then i create a new group which is empty from the start but with the correct border
                            GroupShape groupToAdd = new GroupShape(rectangle);

                            //i gone through all subShapes in the group 
                            //get the type of the shape with the custom method that I`ve create
                            //then add them with the new metrics in the newestGroup subshapes 
                            foreach (var x in group.SubShapes)
                            {
                                var temp2 = GetObjectType(x);
                                groupToAdd.SubShapes.Add(temp2);
                                //group.SubShapes.Add(temp2);
                                //GroupShape groupToCreate = group;
                                //dialogProcessor.ShapeList.Add(gro);
                                //GroupShape newestGroup = new GroupShape(group.Rectangle);
                                //newestGroup.SubShapes.Add(temp2);
                                //dialogProcessor.GroupShapes.Add(newestGroup);
                                // dialogProcessor.GroupShapes..Add(temp2);
                            }
                            //I just adding the group to Shape List and when Invalidate the view to go through all and get them see
                            dialogProcessor.ShapeList.Add(groupToAdd);


                        }
                        else
                        {
                            var temp = GetObjectType(item);
                            dialogProcessor.ShapeList.Add(temp);
                        }

                    }
                    statusBar.Items[0].Text = "Последно действие: Поставяне на селекцията";
                    viewPort.Invalidate();
                }
            }

            //if (copy)
            //{
            //    if (newestShapes.Any() && newestShapes != null)
            //    {

            //        foreach (Shape item in newestShapes)
            //        {
            //            var temp = GetObjectType(item);
            //            dialogProcessor.ShapeList.Add(temp);
            //        }
            //        statusBar.Items[0].Text = "Последно действие: Поставяне на селекцията";
            //        viewPort.Invalidate();
            //        copy = false;


            //    }
            //}
        }


        private Shape GetObjectType(Shape selectedShape)
        {
            var type = selectedShape.GetType();
            string typeName = type.Name;

            Shape newestShape;

            Rectangle canvas
                = new Rectangle((int)selectedShape.Location.X + 30, (int)selectedShape.Location.Y + 30, (int)selectedShape.Width, (int)selectedShape.Height);


            switch (typeName)
            {
                case "RectangleShape":
                    if (selectedShape.Height == selectedShape.Width)
                    {
                        newestShape =
                            new RectangleShape(canvas);
                        newestShape.FillColor = selectedShape.FillColor;
                        newestShape.StrokeColor = selectedShape.StrokeColor;
                        newestShape.StrokeWidth = selectedShape.StrokeWidth;
                        newestShape.Opacity = selectedShape.Opacity;
                        newestShape.ShapeName = "square#" + new Random().Next();
                        return newestShape;
                    }
                    else
                    {
                        newestShape =
                            new RectangleShape(canvas);
                        newestShape.FillColor = selectedShape.FillColor;
                        newestShape.StrokeColor = selectedShape.StrokeColor;
                        newestShape.StrokeWidth = selectedShape.StrokeWidth;
                        newestShape.Opacity = selectedShape.Opacity;
                        newestShape.ShapeName = "rectangle#" + new Random().Next();
                        return newestShape;
                    }

                case "CircleShape":
                    newestShape =
                            new CircleShape(canvas);
                    newestShape.FillColor = selectedShape.FillColor;
                    newestShape.StrokeColor = selectedShape.StrokeColor;
                    newestShape.StrokeWidth = selectedShape.StrokeWidth;
                    newestShape.Opacity = selectedShape.Opacity;
                    newestShape.ShapeName = "circle#" + new Random().Next();
                    return newestShape;

                case "TriangleShape":
                    newestShape =
                            new TriangleShape(canvas);
                    newestShape.FillColor = selectedShape.FillColor;
                    newestShape.StrokeColor = selectedShape.StrokeColor;
                    newestShape.StrokeWidth = selectedShape.StrokeWidth;
                    newestShape.Opacity = selectedShape.Opacity;
                    newestShape.ShapeName = "triangle#" + new Random().Next();
                    return newestShape;

                case "HexagonShape":
                    newestShape =
                            new HexagonShape(canvas);
                    newestShape.FillColor = selectedShape.FillColor;
                    newestShape.StrokeColor = selectedShape.StrokeColor;
                    newestShape.StrokeWidth = selectedShape.StrokeWidth;
                    newestShape.Opacity = selectedShape.Opacity;
                    newestShape.ShapeName = "hexagon#" + new Random().Next();
                    return newestShape;
            }
            return null;
        }






        //key shortcuts
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

            int portHeigth = viewPort.Height;
            int portWidth = viewPort.Width;

            //CONTROL + X - DELETE SELECTED
            if (e.Control && e.KeyCode == Keys.X)
            {
                removeButton_Click(sender, e);
            }

            //CONTROL + C - COPY SELECTED
            if (e.Control && e.KeyCode == Keys.C)
            {
                copyButton_Click(sender, e);
            }

            //CONTROL + V - PASTE SELECTED
            if (e.Control && e.KeyCode == Keys.V)
            {
                pasteButton_Click(sender, e);

            }

            //CONTROL + N - NEW SHAPE   
            if (e.Control && e.KeyCode == Keys.N)
            {
                AddShapeButton_Click(sender, e);
            }

            //CONTROL + G - Group
            if (e.Control && e.KeyCode == Keys.G)
            {
                dialogProcessor.GroupPrimitives();
                statusBar.Items[0].Text = "Последно действие: Групиране на фигури";
                viewPort.Invalidate();
            }

            //CONTROL + A - SELECTE All
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (dialogProcessor.ShapeList.Any())
                {

                    foreach (var item in dialogProcessor.ShapeList)
                    {
                        dialogProcessor.Selection.Add(item);
                    }

                    statusBar.Items[0].Text = "Последно действие: Селектиране на всички фигури";
                    viewPort.Invalidate();
                }
            }


            //adding shortcuts to my application for better UX
            //CONTROL + 1
            if (e.Control && e.KeyValue == 49)
            {
                dialogProcessor.AddRandomSquare(portHeigth, portWidth);
                statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат на произволно място на платното";
                viewPort.Invalidate();
            }

            //CONTROL + 2
            if (e.Control && e.KeyValue == 50)
            {
                dialogProcessor.AddRandomRectangle(portHeigth, portWidth);
                statusBar.Items[0].Text =
                    "Последно действие: Рисуване на правоъгълник на произволно място на платното";
                viewPort.Invalidate();
            }

            //CONTROL + 3
            if (e.Control && e.KeyValue == 51)
            {
                dialogProcessor.AddRandomTriangle(portHeigth, portWidth);
                statusBar.Items[0].Text =
                    "Последно действие:  Рисуване на триъгълник на произволно място на платното";
                viewPort.Invalidate();
            }

            //CONTROL + 4
            if (e.Control && e.KeyValue == 52)
            {
                dialogProcessor.AddRandomCircle(portHeigth, portWidth);
                statusBar.Items[0].Text = "Последно действие: Рисуване на кръг на произволно място на платното";
                viewPort.Invalidate();
            }

            //CONTROL + 5
            if (e.Control && e.KeyValue == 53)
            {
                dialogProcessor.AddRandomHexagon(portHeigth, portWidth);
                statusBar.Items[0].Text =
                    "Последно действие: Рисуване на шестоъгълник на произволно място на платното";
                viewPort.Invalidate();
            }

        }



        //need to be implemented
        private void AddShapeButton_Click(object sender, EventArgs e)
        {
            AddShape addForm = new AddShape();
            addForm.ShowDialog();
            statusBar.Items[0].Text = "Последно действие: Добавяне на фигура по избор";
            viewPort.Invalidate();



        }

        private void RotateButton_Click(object sender, EventArgs e)
        {

            dialogProcessor.RotatePrimitive(45);
            statusBar.Items[0].Text = "Последно действие: Ротация на селектираните елементи на 45 градуса";
            viewPort.Invalidate();


        }

        private void ScaleButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.ScalePrimitive(1.1f);
            statusBar.Items[0].Text = "Последно действие: Промяна на размера на фигурата";
            viewPort.Invalidate();
        }

        private void GroupSelectionBtn_Click(object sender, EventArgs e)
        {
            dialogProcessor.GroupPrimitives();
            statusBar.Items[0].Text = "Последно действие: Групиране на селектирани фигури";
            viewPort.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "GVG File|*.gvg";
            saveFileDialog.Title = "Save a File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SerializeFile(dialogProcessor.ShapeList, saveFileDialog.FileName);
            }
            statusBar.Items[0].Text = "Последно действие: Записване на файл.";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "GVG FILE|*.gvg";
            openFileDialog.Title = "Open a File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.ShapeList = (List<Shape>)dialogProcessor.DeSerializeFile(openFileDialog.FileName);
            }
            statusBar.Items[0].Text = "Последно действие: Отваряне на файл";
            viewPort.Invalidate();
        }

        private void removeGroupButton_Click(object sender, EventArgs e)
        {

            dialogProcessor.UngroupShapes();
            statusBar.Items[0].Text = "Последно действие: Разгрупиране на селектирана група или групи";
            viewPort.Invalidate();
        }

        private void exportToPngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Create a new SaveFileDialog object
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png";
            saveFileDialog.Title = "Save an Image File";

            // If the user clicked the OK button
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Create a new bitmap with the size of the control
                Bitmap bitmap = new Bitmap(viewPort.Width, viewPort.Height);

                // Draw the contents of the control to the bitmap
                viewPort.DrawToBitmap(bitmap, new Rectangle(Point.Empty, viewPort.Size));


                bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                statusBar.Items[0].Text = "Последно действие: Записване на изображение от платното в PNG формат";
            }
        }

        private void exportToJPEGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new SaveFileDialog object
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = " JPEG Image| *.jpeg";
            saveFileDialog.Title = "Save an Image File";

            // If the user clicked the OK button
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Create a new bitmap with the size of the control
                Bitmap bitmap = new Bitmap(viewPort.Width, viewPort.Height);

                // Draw the contents of the control to the bitmap
                viewPort.DrawToBitmap(bitmap, new Rectangle(Point.Empty, viewPort.Size));


                bitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                statusBar.Items[0].Text = "Последно действие: Записване на изображение от платното в JPEG формат";
            }
        }


        private void searchSelectionTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string inputText = searchSelectionTB.Text;
                string text = inputText.Trim();
                if (!String.IsNullOrEmpty(text))
                {
                    var shapes = dialogProcessor.ShapeList;
                    var selection = dialogProcessor.Selection;
                    if (shapes.Any())
                    {
                        foreach (var item in shapes)
                        {
                            if (item.ShapeName == inputText)
                            {
                                selection.Clear();
                                selection.Add(item);
                                statusBar.Items[0].Text = "Последно действие: Търсене по име";
                                viewPort.Invalidate();
                            }
                            else
                            {
                                statusBar.Items[0].Text = "Няма намерени резултати от търсенето!";
                            }
                        }
                    }
                    else
                    {
                        statusBar.Items[0].Text = "Все още няма добавени елементи!";
                    }
                }
                else
                {
                    statusBar.Items[0].Text = "Моля въведете текст!";
                }
            }
        }


    }
}



