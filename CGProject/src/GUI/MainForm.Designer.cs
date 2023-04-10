using System.Windows.Forms.VisualStyles;

namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToJPEGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyboardShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.addShapeButton = new System.Windows.Forms.ToolStripButton();
            this.removeButton = new System.Windows.Forms.ToolStripButton();
            this.drawSquareSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawTriangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawCircleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawHexagonSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.setFillColor = new System.Windows.Forms.ToolStripButton();
            this.setStrokeColor = new System.Windows.Forms.ToolStripButton();
            this.rotateButton = new System.Windows.Forms.ToolStripButton();
            this.scaleButton = new System.Windows.Forms.ToolStripButton();
            this.GroupSelectionBtn = new System.Windows.Forms.ToolStripButton();
            this.RemoveGroupBtn = new System.Windows.Forms.ToolStripButton();
            this.copyButton = new System.Windows.Forms.ToolStripButton();
            this.pasteButton = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.opacityChanger = new System.Windows.Forms.NumericUpDown();
            this.opacityLabel = new System.Windows.Forms.Label();
            this.strokeWidthLabel = new System.Windows.Forms.Label();
            this.strokeWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.searchSelectionTB = new System.Windows.Forms.TextBox();
            this.doubleBufferedPanel1 = new Draw.DoubleBufferedPanel();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityChanger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strokeWidthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.mainMenu.Size = new System.Drawing.Size(1091, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save ";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToToolStripMenuItem,
            this.exportToJPEGToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // exportToToolStripMenuItem
            // 
            this.exportToToolStripMenuItem.Name = "exportToToolStripMenuItem";
            this.exportToToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exportToToolStripMenuItem.Text = "Export to .PNG";
            this.exportToToolStripMenuItem.Click += new System.EventHandler(this.exportToPngToolStripMenuItem_Click);
            // 
            // exportToJPEGToolStripMenuItem
            // 
            this.exportToJPEGToolStripMenuItem.Name = "exportToJPEGToolStripMenuItem";
            this.exportToJPEGToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exportToJPEGToolStripMenuItem.Text = "Export to .JPEG";
            this.exportToJPEGToolStripMenuItem.Click += new System.EventHandler(this.exportToJPEGToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.keyboardShortcutsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // keyboardShortcutsToolStripMenuItem
            // 
            this.keyboardShortcutsToolStripMenuItem.Name = "keyboardShortcutsToolStripMenuItem";
            this.keyboardShortcutsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.keyboardShortcutsToolStripMenuItem.Text = "Keyboard Shortcuts";
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 650);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1091, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // speedMenu
            // 
            this.speedMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickUpSpeedButton,
            this.addShapeButton,
            this.removeButton,
            this.drawSquareSpeedButton,
            this.drawRectangleSpeedButton,
            this.drawTriangleSpeedButton,
            this.drawCircleSpeedButton,
            this.drawHexagonSpeedButton,
            this.setFillColor,
            this.setStrokeColor,
            this.rotateButton,
            this.scaleButton,
            this.GroupSelectionBtn,
            this.RemoveGroupBtn,
            this.copyButton,
            this.pasteButton});
            this.speedMenu.Location = new System.Drawing.Point(0, 24);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.speedMenu.Size = new System.Drawing.Size(1091, 27);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.pickUpSpeedButton.Text = "Селектиране на фигура";
            // 
            // addShapeButton
            // 
            this.addShapeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addShapeButton.Image = ((System.Drawing.Image)(resources.GetObject("addShapeButton.Image")));
            this.addShapeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addShapeButton.Name = "addShapeButton";
            this.addShapeButton.Size = new System.Drawing.Size(24, 24);
            this.addShapeButton.Text = "Добавяне на фигура с зададени параметри";
            this.addShapeButton.ToolTipText = "Добавяне на фигура с зададени параметри";
            this.addShapeButton.Click += new System.EventHandler(this.AddShapeButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeButton.Image = ((System.Drawing.Image)(resources.GetObject("removeButton.Image")));
            this.removeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(24, 24);
            this.removeButton.Text = "Премахване на селектирания примитив";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // drawSquareSpeedButton
            // 
            this.drawSquareSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawSquareSpeedButton.ForeColor = System.Drawing.Color.Transparent;
            this.drawSquareSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawSquareSpeedButton.Image")));
            this.drawSquareSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawSquareSpeedButton.Name = "drawSquareSpeedButton";
            this.drawSquareSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawSquareSpeedButton.Text = "Чертане на квадрат";
            this.drawSquareSpeedButton.Click += new System.EventHandler(this.DrawSquareSpeedButtonClick);
            // 
            // drawRectangleSpeedButton
            // 
            this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
            this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            this.drawRectangleSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawRectangleSpeedButton.Text = "Чертане на правоъгълник";
            this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // drawTriangleSpeedButton
            // 
            this.drawTriangleSpeedButton.BackColor = System.Drawing.Color.Transparent;
            this.drawTriangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawTriangleSpeedButton.ForeColor = System.Drawing.Color.White;
            this.drawTriangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawTriangleSpeedButton.Image")));
            this.drawTriangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawTriangleSpeedButton.Name = "drawTriangleSpeedButton";
            this.drawTriangleSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawTriangleSpeedButton.Text = "Чертане на триъгълник";
            this.drawTriangleSpeedButton.Click += new System.EventHandler(this.DrawTriangleSpeedButtonClick);
            // 
            // drawCircleSpeedButton
            // 
            this.drawCircleSpeedButton.BackColor = System.Drawing.Color.Transparent;
            this.drawCircleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawCircleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawCircleSpeedButton.Image")));
            this.drawCircleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawCircleSpeedButton.Name = "drawCircleSpeedButton";
            this.drawCircleSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawCircleSpeedButton.Text = "Чертане на кръг";
            this.drawCircleSpeedButton.Click += new System.EventHandler(this.DrawCircleSpeedButtonClick);
            // 
            // drawHexagonSpeedButton
            // 
            this.drawHexagonSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawHexagonSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawHexagonSpeedButton.Image")));
            this.drawHexagonSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawHexagonSpeedButton.Name = "drawHexagonSpeedButton";
            this.drawHexagonSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawHexagonSpeedButton.Text = "Чертане на шестоъгълник";
            this.drawHexagonSpeedButton.Click += new System.EventHandler(this.DrawHexagonSpeedButtonClick);
            // 
            // setFillColor
            // 
            this.setFillColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setFillColor.Image = ((System.Drawing.Image)(resources.GetObject("setFillColor.Image")));
            this.setFillColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setFillColor.Name = "setFillColor";
            this.setFillColor.Size = new System.Drawing.Size(24, 24);
            this.setFillColor.Text = "Смяна на цвета на фигурата";
            this.setFillColor.ToolTipText = "Смяна на основния цвят на фигурата";
            this.setFillColor.Click += new System.EventHandler(this.SetFillColor_Click);
            // 
            // setStrokeColor
            // 
            this.setStrokeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setStrokeColor.Image = ((System.Drawing.Image)(resources.GetObject("setStrokeColor.Image")));
            this.setStrokeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setStrokeColor.Name = "setStrokeColor";
            this.setStrokeColor.Size = new System.Drawing.Size(24, 24);
            this.setStrokeColor.Text = "Смяна на цвета на контура на фигурата";
            this.setStrokeColor.Click += new System.EventHandler(this.SetStrokeColor_Click);
            // 
            // rotateButton
            // 
            this.rotateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateButton.Image")));
            this.rotateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(24, 24);
            this.rotateButton.Text = "toolStripButton1";
            this.rotateButton.ToolTipText = "Завъртане на избрания примитив";
            this.rotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // scaleButton
            // 
            this.scaleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.scaleButton.Image = ((System.Drawing.Image)(resources.GetObject("scaleButton.Image")));
            this.scaleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.scaleButton.Name = "scaleButton";
            this.scaleButton.Size = new System.Drawing.Size(24, 24);
            this.scaleButton.Text = "toolStripButton1";
            this.scaleButton.ToolTipText = "Уголемяване или смаляване на избрания примитив";
            this.scaleButton.Click += new System.EventHandler(this.ScaleButton_Click);
            // 
            // GroupSelectionBtn
            // 
            this.GroupSelectionBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GroupSelectionBtn.Image = ((System.Drawing.Image)(resources.GetObject("GroupSelectionBtn.Image")));
            this.GroupSelectionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GroupSelectionBtn.Name = "GroupSelectionBtn";
            this.GroupSelectionBtn.Size = new System.Drawing.Size(24, 24);
            this.GroupSelectionBtn.Text = "Групиране на примитивите";
            this.GroupSelectionBtn.ToolTipText = "Групиране на примитивите";
            this.GroupSelectionBtn.Click += new System.EventHandler(this.GroupSelectionBtn_Click);
            // 
            // RemoveGroupBtn
            // 
            this.RemoveGroupBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveGroupBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveGroupBtn.Image")));
            this.RemoveGroupBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveGroupBtn.Name = "RemoveGroupBtn";
            this.RemoveGroupBtn.Size = new System.Drawing.Size(24, 24);
            this.RemoveGroupBtn.Text = "Разрупиране на примитивите";
            this.RemoveGroupBtn.Click += new System.EventHandler(this.removeGroupButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyButton.Image = ((System.Drawing.Image)(resources.GetObject("copyButton.Image")));
            this.copyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(24, 24);
            this.copyButton.Text = "Копиране на селекция";
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // pasteButton
            // 
            this.pasteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteButton.Image")));
            this.pasteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(24, 24);
            this.pasteButton.Text = "Поставяне на копираното";
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // opacityChanger
            // 
            this.opacityChanger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.opacityChanger.Location = new System.Drawing.Point(756, 24);
            this.opacityChanger.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.opacityChanger.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.opacityChanger.Name = "opacityChanger";
            this.opacityChanger.Size = new System.Drawing.Size(45, 20);
            this.opacityChanger.TabIndex = 5;
            this.opacityChanger.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.opacityChanger.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // opacityLabel
            // 
            this.opacityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.opacityLabel.AutoSize = true;
            this.opacityLabel.BackColor = System.Drawing.Color.Transparent;
            this.opacityLabel.Location = new System.Drawing.Point(650, 27);
            this.opacityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.opacityLabel.Name = "opacityLabel";
            this.opacityLabel.Size = new System.Drawing.Size(84, 13);
            this.opacityLabel.TabIndex = 6;
            this.opacityLabel.Text = "Change opacity:";
            // 
            // strokeWidthLabel
            // 
            this.strokeWidthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.strokeWidthLabel.AutoSize = true;
            this.strokeWidthLabel.Location = new System.Drawing.Point(456, 27);
            this.strokeWidthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.strokeWidthLabel.Name = "strokeWidthLabel";
            this.strokeWidthLabel.Size = new System.Drawing.Size(107, 13);
            this.strokeWidthLabel.TabIndex = 7;
            this.strokeWidthLabel.Text = "Change stroke width:";
            // 
            // strokeWidthUpDown
            // 
            this.strokeWidthUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.strokeWidthUpDown.Location = new System.Drawing.Point(588, 24);
            this.strokeWidthUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.strokeWidthUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.strokeWidthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.strokeWidthUpDown.Name = "strokeWidthUpDown";
            this.strokeWidthUpDown.Size = new System.Drawing.Size(38, 20);
            this.strokeWidthUpDown.TabIndex = 8;
            this.strokeWidthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.strokeWidthUpDown.ValueChanged += new System.EventHandler(this.strokeWitdhUpDown_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // searchSelectionTB
            // 
            this.searchSelectionTB.Location = new System.Drawing.Point(861, 24);
            this.searchSelectionTB.Name = "searchSelectionTB";
            this.searchSelectionTB.Size = new System.Drawing.Size(165, 20);
            this.searchSelectionTB.TabIndex = 10;
            this.searchSelectionTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchSelectionTB_KeyDown);
            // 
            // doubleBufferedPanel1
            // 
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(729, 186);
            this.doubleBufferedPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(5, 5);
            this.doubleBufferedPanel1.TabIndex = 9;
            // 
            // viewPort
            // 
            this.viewPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewPort.Location = new System.Drawing.Point(0, 53);
            this.viewPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(1091, 580);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 672);
            this.Controls.Add(this.searchSelectionTB);
            this.Controls.Add(this.doubleBufferedPanel1);
            this.Controls.Add(this.strokeWidthUpDown);
            this.Controls.Add(this.strokeWidthLabel);
            this.Controls.Add(this.opacityLabel);
            this.Controls.Add(this.opacityChanger);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(1071, 664);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Draw";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityChanger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strokeWidthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton drawTriangleSpeedButton;
        private System.Windows.Forms.ToolStripButton drawCircleSpeedButton;
        private System.Windows.Forms.ToolStripButton drawSquareSpeedButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripButton setStrokeColor;
        private System.Windows.Forms.ToolStripButton setFillColor;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.NumericUpDown opacityChanger;
        private System.Windows.Forms.Label opacityLabel;
        private System.Windows.Forms.Label strokeWidthLabel;
        private System.Windows.Forms.NumericUpDown strokeWidthUpDown;
        private System.Windows.Forms.ToolStripButton removeButton;
        private System.Windows.Forms.ToolStripButton drawHexagonSpeedButton;
        private System.Windows.Forms.ToolStripButton addShapeButton;
        private System.Windows.Forms.ToolStripMenuItem keyboardShortcutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton rotateButton;
        private System.Windows.Forms.ToolStripButton scaleButton;
        private System.Windows.Forms.ToolStripButton GroupSelectionBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DoubleBufferedPanel doubleBufferedPanel1;
        private System.Windows.Forms.ToolStripButton RemoveGroupBtn;
        private System.Windows.Forms.ToolStripMenuItem exportToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToJPEGToolStripMenuItem;
        private System.Windows.Forms.TextBox searchSelectionTB;
        private System.Windows.Forms.ToolStripButton copyButton;
        private System.Windows.Forms.ToolStripButton pasteButton;
    }
}
