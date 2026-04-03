namespace KalkulatorIKombinuar;

partial class Form1
{
    private const int LargeButtonHeight = 64;
    private const int SmallButtonHeight = 52;

    private System.ComponentModel.IContainer components = null!;
    private SplitContainer splitContainer = null!;
    private TableLayoutPanel calculatorLayout = null!;
    private FlowLayoutPanel modeLayout = null!;
    private Label lblMode = null!;
    private ComboBox cmbMode = null!;
    private TableLayoutPanel displayLayout = null!;
    private Label lblMemoryFlag = null!;
    private Label lblAngleMode = null!;
    private Label lblExpression = null!;
    private Label lblDisplay = null!;
    private Panel scientificHost = null!;
    private TableLayoutPanel scientificLayout = null!;
    private TableLayoutPanel memoryLayout = null!;
    private TableLayoutPanel keypadLayout = null!;
    private TableLayoutPanel historyLayout = null!;
    private Label lblHistoryTitle = null!;
    private Label lblHistoryHint = null!;
    private Label lblCopyright = null!;
    private ListBox lstHistory = null!;
    private Button btnClearHistory = null!;
    private Button btnDecimal = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        splitContainer = new SplitContainer();
        calculatorLayout = new TableLayoutPanel();
        modeLayout = new FlowLayoutPanel();
        lblMode = new Label();
        cmbMode = new ComboBox();
        displayLayout = new TableLayoutPanel();
        lblMemoryFlag = new Label();
        lblAngleMode = new Label();
        lblExpression = new Label();
        lblDisplay = new Label();
        scientificHost = new Panel();
        scientificLayout = CreateUniformGrid(5, 2);
        memoryLayout = CreateUniformGrid(5, 1);
        keypadLayout = CreateUniformGrid(4, 5);
        historyLayout = new TableLayoutPanel();
        lblHistoryTitle = new Label();
        lblHistoryHint = new Label();
        lblCopyright = new Label();
        lstHistory = new ListBox();
        btnClearHistory = CreateButton("Pastro historikun", BtnClearHistory_Click, Color.FromArgb(52, 52, 52), 11F, SmallButtonHeight);

        var btnSquare = CreateButton("x^2", UnaryOperatorButton_Click, Color.FromArgb(44, 44, 44), 12F, SmallButtonHeight);
        var btnSqrt = CreateButton("sqrt", UnaryOperatorButton_Click, Color.FromArgb(44, 44, 44), 12F, SmallButtonHeight);
        var btnReciprocal = CreateButton("1/x", UnaryOperatorButton_Click, Color.FromArgb(44, 44, 44), 12F, SmallButtonHeight);
        var btnPercent = CreateButton("%", PercentButton_Click, Color.FromArgb(44, 44, 44), 12F, SmallButtonHeight);
        var btnPower = CreateButton("x^y", BinaryOperatorButton_Click, Color.FromArgb(44, 44, 44), 12F, SmallButtonHeight);
        var btnSin = CreateButton("sin", UnaryOperatorButton_Click, Color.FromArgb(44, 44, 44), 12F, SmallButtonHeight);
        var btnCos = CreateButton("cos", UnaryOperatorButton_Click, Color.FromArgb(44, 44, 44), 12F, SmallButtonHeight);
        var btnTan = CreateButton("tan", UnaryOperatorButton_Click, Color.FromArgb(44, 44, 44), 12F, SmallButtonHeight);
        var btnLog = CreateButton("log", UnaryOperatorButton_Click, Color.FromArgb(44, 44, 44), 12F, SmallButtonHeight);
        var btnLn = CreateButton("ln", UnaryOperatorButton_Click, Color.FromArgb(44, 44, 44), 12F, SmallButtonHeight);

        var btnMC = CreateButton("MC", MemoryButton_Click, Color.FromArgb(46, 46, 46), 11F, SmallButtonHeight);
        var btnMR = CreateButton("MR", MemoryButton_Click, Color.FromArgb(46, 46, 46), 11F, SmallButtonHeight);
        var btnMPlus = CreateButton("M+", MemoryButton_Click, Color.FromArgb(46, 46, 46), 11F, SmallButtonHeight);
        var btnMMinus = CreateButton("M-", MemoryButton_Click, Color.FromArgb(46, 46, 46), 11F, SmallButtonHeight);
        var btnMS = CreateButton("MS", MemoryButton_Click, Color.FromArgb(46, 46, 46), 11F, SmallButtonHeight);

        var btnCE = CreateButton("CE", ClearEntryButton_Click, Color.FromArgb(52, 52, 52), 12F, LargeButtonHeight);
        var btnClear = CreateButton("C", ClearAllButton_Click, Color.FromArgb(52, 52, 52), 12F, LargeButtonHeight);
        var btnBack = CreateButton("Back", BackspaceButton_Click, Color.FromArgb(52, 52, 52), 12F, LargeButtonHeight);
        var btnDivide = CreateButton("/", BinaryOperatorButton_Click, Color.FromArgb(52, 52, 52), 13F, LargeButtonHeight);
        var btn7 = CreateButton("7", DigitButton_Click, Color.FromArgb(61, 61, 61), 16F, LargeButtonHeight);
        var btn8 = CreateButton("8", DigitButton_Click, Color.FromArgb(61, 61, 61), 16F, LargeButtonHeight);
        var btn9 = CreateButton("9", DigitButton_Click, Color.FromArgb(61, 61, 61), 16F, LargeButtonHeight);
        var btnMultiply = CreateButton("*", BinaryOperatorButton_Click, Color.FromArgb(52, 52, 52), 13F, LargeButtonHeight);
        var btn4 = CreateButton("4", DigitButton_Click, Color.FromArgb(61, 61, 61), 16F, LargeButtonHeight);
        var btn5 = CreateButton("5", DigitButton_Click, Color.FromArgb(61, 61, 61), 16F, LargeButtonHeight);
        var btn6 = CreateButton("6", DigitButton_Click, Color.FromArgb(61, 61, 61), 16F, LargeButtonHeight);
        var btnSubtract = CreateButton("-", BinaryOperatorButton_Click, Color.FromArgb(52, 52, 52), 13F, LargeButtonHeight);
        var btn1 = CreateButton("1", DigitButton_Click, Color.FromArgb(61, 61, 61), 16F, LargeButtonHeight);
        var btn2 = CreateButton("2", DigitButton_Click, Color.FromArgb(61, 61, 61), 16F, LargeButtonHeight);
        var btn3 = CreateButton("3", DigitButton_Click, Color.FromArgb(61, 61, 61), 16F, LargeButtonHeight);
        var btnAdd = CreateButton("+", BinaryOperatorButton_Click, Color.FromArgb(52, 52, 52), 13F, LargeButtonHeight);
        var btnSign = CreateButton("+/-", SignButton_Click, Color.FromArgb(52, 52, 52), 12F, LargeButtonHeight);
        var btn0 = CreateButton("0", DigitButton_Click, Color.FromArgb(61, 61, 61), 16F, LargeButtonHeight);
        btnDecimal = CreateButton(".", DecimalButton_Click, Color.FromArgb(61, 61, 61), 16F, LargeButtonHeight);
        var btnEquals = CreateButton("=", EqualsButton_Click, Color.FromArgb(8, 104, 189), 16F, LargeButtonHeight);

        SuspendLayout();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        calculatorLayout.SuspendLayout();
        modeLayout.SuspendLayout();
        displayLayout.SuspendLayout();
        scientificHost.SuspendLayout();
        historyLayout.SuspendLayout();

        btnSquare.Tag = "square";
        btnSqrt.Tag = "sqrt";
        btnReciprocal.Tag = "reciprocal";
        btnPower.Tag = "power";
        btnSin.Tag = "sin";
        btnCos.Tag = "cos";
        btnTan.Tag = "tan";
        btnLog.Tag = "log";
        btnLn.Tag = "ln";

        btnMC.Tag = "mc";
        btnMR.Tag = "mr";
        btnMPlus.Tag = "mplus";
        btnMMinus.Tag = "mminus";
        btnMS.Tag = "ms";

        btnDivide.Tag = "divide";
        btnMultiply.Tag = "multiply";
        btnSubtract.Tag = "subtract";
        btnAdd.Tag = "add";

        splitContainer.Dock = DockStyle.Fill;
        splitContainer.FixedPanel = FixedPanel.Panel2;
        splitContainer.Location = new Point(0, 0);
        splitContainer.Name = "splitContainer";
        splitContainer.Panel1.BackColor = Color.FromArgb(24, 24, 24);
        splitContainer.Panel1.Controls.Add(calculatorLayout);
        splitContainer.Panel2.BackColor = Color.FromArgb(18, 18, 18);
        splitContainer.Panel2.Controls.Add(historyLayout);
        splitContainer.Panel2.Padding = new Padding(0, 18, 18, 18);
        splitContainer.Panel2MinSize = 270;
        splitContainer.Size = new Size(1260, 780);
        splitContainer.SplitterDistance = 940;
        splitContainer.SplitterWidth = 5;
        splitContainer.TabIndex = 0;

        calculatorLayout.BackColor = Color.FromArgb(24, 24, 24);
        calculatorLayout.ColumnCount = 1;
        calculatorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        calculatorLayout.Controls.Add(modeLayout, 0, 0);
        calculatorLayout.Controls.Add(displayLayout, 0, 1);
        calculatorLayout.Controls.Add(scientificHost, 0, 2);
        calculatorLayout.Controls.Add(memoryLayout, 0, 3);
        calculatorLayout.Controls.Add(keypadLayout, 0, 4);
        calculatorLayout.Dock = DockStyle.Fill;
        calculatorLayout.Location = new Point(0, 0);
        calculatorLayout.Name = "calculatorLayout";
        calculatorLayout.Padding = new Padding(18);
        calculatorLayout.RowCount = 5;
        calculatorLayout.RowStyles.Add(new RowStyle());
        calculatorLayout.RowStyles.Add(new RowStyle());
        calculatorLayout.RowStyles.Add(new RowStyle());
        calculatorLayout.RowStyles.Add(new RowStyle());
        calculatorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        calculatorLayout.Size = new Size(940, 780);
        calculatorLayout.TabIndex = 0;

        modeLayout.AutoSize = true;
        modeLayout.Controls.Add(lblMode);
        modeLayout.Controls.Add(cmbMode);
        modeLayout.Dock = DockStyle.Fill;
        modeLayout.FlowDirection = FlowDirection.LeftToRight;
        modeLayout.Location = new Point(18, 18);
        modeLayout.Margin = new Padding(0, 0, 0, 10);
        modeLayout.Name = "modeLayout";
        modeLayout.Size = new Size(904, 38);
        modeLayout.TabIndex = 0;
        modeLayout.WrapContents = false;

        lblMode.AutoSize = true;
        lblMode.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Regular, GraphicsUnit.Point);
        lblMode.ForeColor = Color.Gainsboro;
        lblMode.Location = new Point(3, 7);
        lblMode.Margin = new Padding(3, 7, 10, 0);
        lblMode.Name = "lblMode";
        lblMode.Size = new Size(66, 20);
        lblMode.TabIndex = 0;
        lblMode.Text = "Menyra:";

        cmbMode.BackColor = Color.FromArgb(40, 40, 40);
        cmbMode.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbMode.FlatStyle = FlatStyle.Flat;
        cmbMode.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
        cmbMode.ForeColor = Color.White;
        cmbMode.FormattingEnabled = true;
        cmbMode.Items.AddRange(new object[] { "Standard", "Scientific" });
        cmbMode.Location = new Point(82, 3);
        cmbMode.Margin = new Padding(0, 3, 3, 3);
        cmbMode.Name = "cmbMode";
        cmbMode.Size = new Size(180, 27);
        cmbMode.TabIndex = 1;
        cmbMode.SelectedIndexChanged += CmbMode_SelectedIndexChanged;

        displayLayout.BackColor = Color.FromArgb(31, 31, 31);
        displayLayout.ColumnCount = 2;
        displayLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        displayLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        displayLayout.Controls.Add(lblMemoryFlag, 0, 0);
        displayLayout.Controls.Add(lblAngleMode, 1, 0);
        displayLayout.Controls.Add(lblExpression, 0, 1);
        displayLayout.Controls.Add(lblDisplay, 0, 2);
        displayLayout.Dock = DockStyle.Fill;
        displayLayout.Location = new Point(18, 66);
        displayLayout.Margin = new Padding(0, 0, 0, 12);
        displayLayout.Name = "displayLayout";
        displayLayout.Padding = new Padding(12);
        displayLayout.RowCount = 3;
        displayLayout.RowStyles.Add(new RowStyle());
        displayLayout.RowStyles.Add(new RowStyle());
        displayLayout.RowStyles.Add(new RowStyle());
        displayLayout.Size = new Size(904, 126);
        displayLayout.TabIndex = 1;

        lblMemoryFlag.AutoSize = true;
        lblMemoryFlag.Dock = DockStyle.Fill;
        lblMemoryFlag.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblMemoryFlag.ForeColor = Color.Silver;
        lblMemoryFlag.Location = new Point(15, 12);
        lblMemoryFlag.Name = "lblMemoryFlag";
        lblMemoryFlag.Size = new Size(434, 19);
        lblMemoryFlag.TabIndex = 0;
        lblMemoryFlag.Text = "M";
        lblMemoryFlag.Visible = false;

        lblAngleMode.AutoSize = true;
        lblAngleMode.Dock = DockStyle.Fill;
        lblAngleMode.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblAngleMode.ForeColor = Color.Silver;
        lblAngleMode.Location = new Point(455, 12);
        lblAngleMode.Name = "lblAngleMode";
        lblAngleMode.Size = new Size(434, 19);
        lblAngleMode.TabIndex = 1;
        lblAngleMode.Text = "Trig: DEG";
        lblAngleMode.TextAlign = ContentAlignment.MiddleRight;

        lblExpression.AutoEllipsis = true;
        displayLayout.SetColumnSpan(lblExpression, 2);
        lblExpression.Dock = DockStyle.Fill;
        lblExpression.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        lblExpression.ForeColor = Color.Silver;
        lblExpression.Location = new Point(15, 31);
        lblExpression.Name = "lblExpression";
        lblExpression.Size = new Size(874, 31);
        lblExpression.TabIndex = 2;
        lblExpression.TextAlign = ContentAlignment.MiddleRight;

        lblDisplay.AutoEllipsis = true;
        displayLayout.SetColumnSpan(lblDisplay, 2);
        lblDisplay.Dock = DockStyle.Fill;
        lblDisplay.Font = new Font("Segoe UI Semibold", 28F, FontStyle.Regular, GraphicsUnit.Point);
        lblDisplay.ForeColor = Color.White;
        lblDisplay.Location = new Point(15, 62);
        lblDisplay.Name = "lblDisplay";
        lblDisplay.Size = new Size(874, 52);
        lblDisplay.TabIndex = 3;
        lblDisplay.Text = "0";
        lblDisplay.TextAlign = ContentAlignment.MiddleRight;

        scientificHost.Controls.Add(scientificLayout);
        scientificHost.Dock = DockStyle.Fill;
        scientificHost.Location = new Point(18, 204);
        scientificHost.Margin = new Padding(0, 0, 0, 10);
        scientificHost.Name = "scientificHost";
        scientificHost.Size = new Size(904, 120);
        scientificHost.TabIndex = 2;

        scientificLayout.Dock = DockStyle.Fill;
        scientificLayout.Location = new Point(0, 0);
        scientificLayout.Margin = new Padding(0);
        scientificLayout.Name = "scientificLayout";
        scientificLayout.Size = new Size(904, 120);
        scientificLayout.TabIndex = 0;
        scientificLayout.Controls.Add(btnSquare, 0, 0);
        scientificLayout.Controls.Add(btnSqrt, 1, 0);
        scientificLayout.Controls.Add(btnReciprocal, 2, 0);
        scientificLayout.Controls.Add(btnPercent, 3, 0);
        scientificLayout.Controls.Add(btnPower, 4, 0);
        scientificLayout.Controls.Add(btnSin, 0, 1);
        scientificLayout.Controls.Add(btnCos, 1, 1);
        scientificLayout.Controls.Add(btnTan, 2, 1);
        scientificLayout.Controls.Add(btnLog, 3, 1);
        scientificLayout.Controls.Add(btnLn, 4, 1);

        memoryLayout.Dock = DockStyle.Fill;
        memoryLayout.Location = new Point(18, 334);
        memoryLayout.Margin = new Padding(0, 0, 0, 10);
        memoryLayout.Name = "memoryLayout";
        memoryLayout.Size = new Size(904, 52);
        memoryLayout.TabIndex = 3;
        memoryLayout.Controls.Add(btnMC, 0, 0);
        memoryLayout.Controls.Add(btnMR, 1, 0);
        memoryLayout.Controls.Add(btnMPlus, 2, 0);
        memoryLayout.Controls.Add(btnMMinus, 3, 0);
        memoryLayout.Controls.Add(btnMS, 4, 0);

        keypadLayout.Dock = DockStyle.Fill;
        keypadLayout.Location = new Point(18, 396);
        keypadLayout.Margin = new Padding(0);
        keypadLayout.Name = "keypadLayout";
        keypadLayout.Size = new Size(904, 366);
        keypadLayout.TabIndex = 4;
        keypadLayout.Controls.Add(btnCE, 0, 0);
        keypadLayout.Controls.Add(btnClear, 1, 0);
        keypadLayout.Controls.Add(btnBack, 2, 0);
        keypadLayout.Controls.Add(btnDivide, 3, 0);
        keypadLayout.Controls.Add(btn7, 0, 1);
        keypadLayout.Controls.Add(btn8, 1, 1);
        keypadLayout.Controls.Add(btn9, 2, 1);
        keypadLayout.Controls.Add(btnMultiply, 3, 1);
        keypadLayout.Controls.Add(btn4, 0, 2);
        keypadLayout.Controls.Add(btn5, 1, 2);
        keypadLayout.Controls.Add(btn6, 2, 2);
        keypadLayout.Controls.Add(btnSubtract, 3, 2);
        keypadLayout.Controls.Add(btn1, 0, 3);
        keypadLayout.Controls.Add(btn2, 1, 3);
        keypadLayout.Controls.Add(btn3, 2, 3);
        keypadLayout.Controls.Add(btnAdd, 3, 3);
        keypadLayout.Controls.Add(btnSign, 0, 4);
        keypadLayout.Controls.Add(btn0, 1, 4);
        keypadLayout.Controls.Add(btnDecimal, 2, 4);
        keypadLayout.Controls.Add(btnEquals, 3, 4);

        historyLayout.BackColor = Color.FromArgb(18, 18, 18);
        historyLayout.ColumnCount = 1;
        historyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        historyLayout.Controls.Add(lblHistoryTitle, 0, 0);
        historyLayout.Controls.Add(lblHistoryHint, 0, 1);
        historyLayout.Controls.Add(lstHistory, 0, 2);
        historyLayout.Controls.Add(btnClearHistory, 0, 3);
        historyLayout.Controls.Add(lblCopyright, 0, 4);
        historyLayout.Dock = DockStyle.Fill;
        historyLayout.Location = new Point(0, 18);
        historyLayout.Margin = new Padding(0);
        historyLayout.Name = "historyLayout";
        historyLayout.RowCount = 5;
        historyLayout.RowStyles.Add(new RowStyle());
        historyLayout.RowStyles.Add(new RowStyle());
        historyLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        historyLayout.RowStyles.Add(new RowStyle());
        historyLayout.RowStyles.Add(new RowStyle());
        historyLayout.Size = new Size(297, 744);
        historyLayout.TabIndex = 0;

        lblHistoryTitle.AutoSize = true;
        lblHistoryTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Regular, GraphicsUnit.Point);
        lblHistoryTitle.ForeColor = Color.White;
        lblHistoryTitle.Location = new Point(3, 0);
        lblHistoryTitle.Margin = new Padding(3, 0, 3, 4);
        lblHistoryTitle.Name = "lblHistoryTitle";
        lblHistoryTitle.Size = new Size(85, 28);
        lblHistoryTitle.TabIndex = 0;
        lblHistoryTitle.Text = "Historiku";

        lblHistoryHint.AutoSize = true;
        lblHistoryHint.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        lblHistoryHint.ForeColor = Color.Silver;
        lblHistoryHint.Location = new Point(3, 32);
        lblHistoryHint.Margin = new Padding(3, 0, 3, 12);
        lblHistoryHint.Name = "lblHistoryHint";
        lblHistoryHint.Size = new Size(246, 17);
        lblHistoryHint.TabIndex = 1;
        lblHistoryHint.Text = "Dy klikime per ta rikthyer rezultatin e fundit";

        lstHistory.BackColor = Color.FromArgb(31, 31, 31);
        lstHistory.BorderStyle = BorderStyle.None;
        lstHistory.Dock = DockStyle.Fill;
        lstHistory.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        lstHistory.ForeColor = Color.White;
        lstHistory.FormattingEnabled = true;
        lstHistory.HorizontalScrollbar = true;
        lstHistory.ItemHeight = 20;
        lstHistory.Location = new Point(3, 61);
        lstHistory.Margin = new Padding(3, 0, 3, 12);
        lstHistory.Name = "lstHistory";
        lstHistory.Size = new Size(291, 607);
        lstHistory.TabIndex = 2;
        lstHistory.DoubleClick += LstHistory_DoubleClick;

        btnClearHistory.Dock = DockStyle.Fill;
        btnClearHistory.Enabled = false;
        btnClearHistory.Margin = new Padding(0);
        btnClearHistory.Name = "btnClearHistory";
        btnClearHistory.TabIndex = 3;

        lblCopyright.AutoSize = true;
        lblCopyright.Dock = DockStyle.Fill;
        lblCopyright.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
        lblCopyright.ForeColor = Color.DarkGray;
        lblCopyright.Location = new Point(3, 711);
        lblCopyright.Margin = new Padding(3, 10, 3, 0);
        lblCopyright.Name = "lblCopyright";
        lblCopyright.Size = new Size(291, 33);
        lblCopyright.TabIndex = 4;
        lblCopyright.Text = "Copyrights go to Diellart Zeka";
        lblCopyright.TextAlign = ContentAlignment.MiddleCenter;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(24, 24, 24);
        ClientSize = new Size(1260, 780);
        Controls.Add(splitContainer);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        ForeColor = Color.White;
        KeyPreview = true;
        MinimumSize = new Size(1100, 720);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Kalkulator i kombinuar";

        historyLayout.ResumeLayout(false);
        historyLayout.PerformLayout();
        scientificHost.ResumeLayout(false);
        displayLayout.ResumeLayout(false);
        displayLayout.PerformLayout();
        modeLayout.ResumeLayout(false);
        modeLayout.PerformLayout();
        calculatorLayout.ResumeLayout(false);
        calculatorLayout.PerformLayout();
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        splitContainer.ResumeLayout(false);
        ResumeLayout(false);
    }

    private static TableLayoutPanel CreateUniformGrid(int columnCount, int rowCount)
    {
        var layout = new TableLayoutPanel
        {
            ColumnCount = columnCount,
            RowCount = rowCount,
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            Padding = new Padding(0)
        };

        for (var column = 0; column < columnCount; column++)
        {
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columnCount));
        }

        for (var row = 0; row < rowCount; row++)
        {
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / rowCount));
        }

        return layout;
    }

    private static Button CreateButton(string text, EventHandler handler, Color backColor, float fontSize, int minimumHeight)
    {
        var button = new Button
        {
            BackColor = backColor,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Fill,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI Semibold", fontSize, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.White,
            Margin = new Padding(4),
            MinimumSize = new Size(0, minimumHeight),
            Text = text,
            UseVisualStyleBackColor = false
        };

        button.FlatAppearance.BorderColor = Color.FromArgb(76, 76, 76);
        button.FlatAppearance.BorderSize = 1;
        button.Click += handler;

        return button;
    }
}
