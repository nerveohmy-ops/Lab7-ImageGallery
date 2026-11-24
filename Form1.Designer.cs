namespace ImageGallery;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null!;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
            _originalImage?.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        toolTip1 = new ToolTip(components);

        panelTop = new Panel();
        label1 = new Label();
        panelLeft = new Panel();
        listBox1 = new ListBox();
        button1 = new Button();
        panelRight = new Panel();
        panelPreview = new Panel();
        pictureBox1 = new PictureBox();
        panelControls = new TableLayoutPanel();
        flowZoomRow = new FlowLayoutPanel();
        labelZoom = new Label();
        trackBarZoom = new TrackBar();
        labelMode = new Label();
        comboBoxSizeMode = new ComboBox();
        flowButtonsRow = new FlowLayoutPanel();
        buttonZoomIn = new Button();
        buttonZoomOut = new Button();
        buttonOriginalSize = new Button();
        buttonFitWindow = new Button();

        panelTop.SuspendLayout();
        panelLeft.SuspendLayout();
        panelRight.SuspendLayout();
        panelPreview.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        panelControls.SuspendLayout();
        flowZoomRow.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)trackBarZoom).BeginInit();
        flowButtonsRow.SuspendLayout();
        SuspendLayout();

        //
        // panelTop
        //
        panelTop.Controls.Add(label1);
        panelTop.Dock = DockStyle.Top;
        panelTop.Location = new Point(0, 0);
        panelTop.Name = "panelTop";
        panelTop.Padding = new Padding(10, 8, 10, 4);
        panelTop.Size = new Size(984, 34);
        panelTop.TabIndex = 0;

        //
        // label1
        //
        label1.AutoEllipsis = true;
        label1.Dock = DockStyle.Fill;
        label1.Location = new Point(10, 8);
        label1.Name = "label1";
        label1.Size = new Size(964, 22);
        label1.TabIndex = 0;
        label1.Text = "Директория не выбрана";
        label1.TextAlign = ContentAlignment.MiddleLeft;

        //
        // panelLeft
        //
        panelLeft.Controls.Add(listBox1);
        panelLeft.Controls.Add(button1);
        panelLeft.Dock = DockStyle.Left;
        panelLeft.Location = new Point(0, 34);
        panelLeft.Name = "panelLeft";
        panelLeft.Padding = new Padding(10, 4, 6, 10);
        panelLeft.Size = new Size(230, 577);
        panelLeft.TabIndex = 1;

        //
        // listBox1
        //
        listBox1.Dock = DockStyle.Fill;
        listBox1.FormattingEnabled = true;
        listBox1.IntegralHeight = false;
        listBox1.Location = new Point(10, 4);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(214, 525);
        listBox1.TabIndex = 0;
        listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;

        //
        // button1
        //
        button1.Dock = DockStyle.Bottom;
        button1.Location = new Point(10, 529);
        button1.Margin = new Padding(0, 8, 0, 0);
        button1.Name = "button1";
        button1.Size = new Size(214, 38);
        button1.TabIndex = 1;
        button1.Text = "Указать директорию";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;

        //
        // panelRight
        //
        panelRight.Controls.Add(panelPreview);
        panelRight.Controls.Add(panelControls);
        panelRight.Dock = DockStyle.Fill;
        panelRight.Location = new Point(230, 34);
        panelRight.Name = "panelRight";
        panelRight.Padding = new Padding(6, 4, 10, 10);
        panelRight.Size = new Size(754, 577);
        panelRight.TabIndex = 2;

        //
        // panelPreview
        //
        panelPreview.AutoScroll = true;
        panelPreview.BackColor = Color.FromArgb(242, 242, 242);
        panelPreview.BorderStyle = BorderStyle.FixedSingle;
        panelPreview.Controls.Add(pictureBox1);
        panelPreview.Dock = DockStyle.Fill;
        panelPreview.Location = new Point(6, 4);
        panelPreview.Name = "panelPreview";
        panelPreview.Size = new Size(738, 463);
        panelPreview.TabIndex = 0;
        panelPreview.Resize += panelPreview_Resize;

        //
        // pictureBox1
        //
        pictureBox1.Dock = DockStyle.Fill;
        pictureBox1.Location = new Point(0, 0);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(736, 461);
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;

        //
        // panelControls
        //
        panelControls.AutoSize = true;
        panelControls.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        panelControls.ColumnCount = 1;
        panelControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        panelControls.Controls.Add(flowZoomRow, 0, 0);
        panelControls.Controls.Add(flowButtonsRow, 0, 1);
        panelControls.Dock = DockStyle.Bottom;
        panelControls.Location = new Point(6, 467);
        panelControls.Name = "panelControls";
        panelControls.Padding = new Padding(0, 8, 0, 0);
        panelControls.RowCount = 2;
        panelControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        panelControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        panelControls.Size = new Size(738, 100);
        panelControls.TabIndex = 1;

        //
        // flowZoomRow
        //
        flowZoomRow.AutoSize = true;
        flowZoomRow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flowZoomRow.Controls.Add(labelZoom);
        flowZoomRow.Controls.Add(trackBarZoom);
        flowZoomRow.Controls.Add(labelMode);
        flowZoomRow.Controls.Add(comboBoxSizeMode);
        flowZoomRow.Dock = DockStyle.Fill;
        flowZoomRow.Location = new Point(0, 8);
        flowZoomRow.Margin = new Padding(0, 0, 0, 4);
        flowZoomRow.Name = "flowZoomRow";
        flowZoomRow.Size = new Size(738, 45);
        flowZoomRow.TabIndex = 0;

        //
        // labelZoom
        //
        labelZoom.AutoSize = false;
        labelZoom.Location = new Point(0, 0);
        labelZoom.Margin = new Padding(0, 6, 8, 0);
        labelZoom.Name = "labelZoom";
        labelZoom.Size = new Size(165, 28);
        labelZoom.TabIndex = 0;
        labelZoom.Text = "Масштаб: 100%";
        labelZoom.TextAlign = ContentAlignment.MiddleLeft;

        //
        // trackBarZoom
        //
        trackBarZoom.LargeChange = 10;
        trackBarZoom.Location = new Point(176, 3);
        trackBarZoom.Maximum = 200;
        trackBarZoom.Minimum = 50;
        trackBarZoom.Name = "trackBarZoom";
        trackBarZoom.Size = new Size(210, 45);
        trackBarZoom.SmallChange = 10;
        trackBarZoom.TabIndex = 1;
        trackBarZoom.TickFrequency = 10;
        trackBarZoom.Value = 100;
        trackBarZoom.Scroll += trackBarZoom_Scroll;

        //
        // labelMode
        //
        labelMode.AutoSize = true;
        labelMode.Location = new Point(398, 10);
        labelMode.Margin = new Padding(12, 10, 6, 0);
        labelMode.Name = "labelMode";
        labelMode.Size = new Size(46, 15);
        labelMode.TabIndex = 2;
        labelMode.Text = "Режим:";

        //
        // comboBoxSizeMode
        //
        comboBoxSizeMode.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxSizeMode.FormattingEnabled = true;
        comboBoxSizeMode.Location = new Point(453, 7);
        comboBoxSizeMode.Margin = new Padding(3, 7, 3, 3);
        comboBoxSizeMode.Name = "comboBoxSizeMode";
        comboBoxSizeMode.Size = new Size(260, 23);
        comboBoxSizeMode.TabIndex = 3;
        comboBoxSizeMode.SelectedIndexChanged += comboBoxSizeMode_SelectedIndexChanged;

        //
        // flowButtonsRow
        //
        flowButtonsRow.AutoSize = true;
        flowButtonsRow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flowButtonsRow.Controls.Add(buttonZoomIn);
        flowButtonsRow.Controls.Add(buttonZoomOut);
        flowButtonsRow.Controls.Add(buttonOriginalSize);
        flowButtonsRow.Controls.Add(buttonFitWindow);
        flowButtonsRow.Dock = DockStyle.Fill;
        flowButtonsRow.Location = new Point(0, 57);
        flowButtonsRow.Margin = new Padding(0);
        flowButtonsRow.Name = "flowButtonsRow";
        flowButtonsRow.Size = new Size(738, 43);
        flowButtonsRow.TabIndex = 1;

        //
        // buttonZoomIn
        //
        buttonZoomIn.AutoSize = true;
        buttonZoomIn.MinimumSize = new Size(125, 34);
        buttonZoomIn.Name = "buttonZoomIn";
        buttonZoomIn.Padding = new Padding(8, 0, 8, 0);
        buttonZoomIn.TabIndex = 0;
        buttonZoomIn.Text = "Увеличить (+10%)";
        buttonZoomIn.UseVisualStyleBackColor = true;
        toolTip1.SetToolTip(buttonZoomIn, "Увеличить масштаб на 10%");
        buttonZoomIn.Click += buttonZoomIn_Click;

        //
        // buttonZoomOut
        //
        buttonZoomOut.AutoSize = true;
        buttonZoomOut.MinimumSize = new Size(125, 34);
        buttonZoomOut.Name = "buttonZoomOut";
        buttonZoomOut.Padding = new Padding(8, 0, 8, 0);
        buttonZoomOut.TabIndex = 1;
        buttonZoomOut.Text = "Уменьшить (-10%)";
        buttonZoomOut.UseVisualStyleBackColor = true;
        toolTip1.SetToolTip(buttonZoomOut, "Уменьшить масштаб на 10%");
        buttonZoomOut.Click += buttonZoomOut_Click;

        //
        // buttonOriginalSize
        //
        buttonOriginalSize.AutoSize = true;
        buttonOriginalSize.MinimumSize = new Size(165, 34);
        buttonOriginalSize.Name = "buttonOriginalSize";
        buttonOriginalSize.Padding = new Padding(8, 0, 8, 0);
        buttonOriginalSize.TabIndex = 2;
        buttonOriginalSize.Text = "Оригинальный размер (100%)";
        buttonOriginalSize.UseVisualStyleBackColor = true;
        toolTip1.SetToolTip(buttonOriginalSize, "Показать изображение в масштабе 100%");
        buttonOriginalSize.Click += buttonOriginalSize_Click;

        //
        // buttonFitWindow
        //
        buttonFitWindow.AutoSize = true;
        buttonFitWindow.MinimumSize = new Size(155, 34);
        buttonFitWindow.Name = "buttonFitWindow";
        buttonFitWindow.Padding = new Padding(8, 0, 8, 0);
        buttonFitWindow.TabIndex = 3;
        buttonFitWindow.Text = "По размеру окна (Zoom)";
        buttonFitWindow.UseVisualStyleBackColor = true;
        toolTip1.SetToolTip(buttonFitWindow, "Вписать изображение в область просмотра с сохранением пропорций");
        buttonFitWindow.Click += buttonFitWindow_Click;

        //
        // Form1
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(984, 611);
        Controls.Add(panelRight);
        Controls.Add(panelLeft);
        Controls.Add(panelTop);
        MinimumSize = new Size(760, 480);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Галерея";

        panelTop.ResumeLayout(false);
        panelLeft.ResumeLayout(false);
        panelRight.ResumeLayout(false);
        panelRight.PerformLayout();
        panelPreview.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        panelControls.ResumeLayout(false);
        panelControls.PerformLayout();
        flowZoomRow.ResumeLayout(false);
        flowZoomRow.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)trackBarZoom).EndInit();
        flowButtonsRow.ResumeLayout(false);
        flowButtonsRow.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private ToolTip toolTip1 = null!;
    private Panel panelTop = null!;
    private Label label1 = null!;
    private Panel panelLeft = null!;
    private ListBox listBox1 = null!;
    private Button button1 = null!;
    private Panel panelRight = null!;
    private Panel panelPreview = null!;
    private PictureBox pictureBox1 = null!;
    private TableLayoutPanel panelControls = null!;
    private FlowLayoutPanel flowZoomRow = null!;
    private Label labelZoom = null!;
    private TrackBar trackBarZoom = null!;
    private Label labelMode = null!;
    private ComboBox comboBoxSizeMode = null!;
    private FlowLayoutPanel flowButtonsRow = null!;
    private Button buttonZoomIn = null!;
    private Button buttonZoomOut = null!;
    private Button buttonOriginalSize = null!;
    private Button buttonFitWindow = null!;
}
