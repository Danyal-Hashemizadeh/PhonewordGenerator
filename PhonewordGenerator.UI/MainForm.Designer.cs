namespace PhonewordGenerator.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblTitle = new Label();
            lblPhoneNumber = new Label();
            btnGenerate = new Button();
            btnCancel = new Button();
            progressBar = new ProgressBar();
            lblReverseSearch = new Label();
            txtWordInput = new TextBox();
            btnReverseSearch = new Button();
            lblCustomWords = new Label();
            txtCustomWords = new TextBox();
            lblGeneratedResults = new Label();
            lstGenerated = new ListBox();
            btnClearGenerated = new Button();
            lblSelectedResults = new Label();
            lstSelected = new ListBox();
            btnClearSelected = new Button();
            btnAdd = new Button();
            btnRemove = new Button();
            btnExport = new Button();
            btnClose = new Button();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            toolTip = new ToolTip(components);
            txtSearchGenerated = new TextBox();
            txtPhoneNumber = new TextBox();
            lblSearchGenerated = new Label();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(760, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Phoneword Generator";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.Location = new Point(20, 85);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(100, 25);
            lblPhoneNumber.TabIndex = 2;
            lblPhoneNumber.Text = "Phone Number:";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(347, 82);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(150, 25);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Generate Phonewords";
            toolTip.SetToolTip(btnGenerate, "Click to generate possible phonewords from the phone number.");
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(512, 82);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 25);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            toolTip.SetToolTip(btnCancel, "Cancel the phoneword generation process.");
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(20, 125);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(760, 20);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 6;
            progressBar.Visible = false;
            // 
            // lblReverseSearch
            // 
            lblReverseSearch.Location = new Point(20, 165);
            lblReverseSearch.Name = "lblReverseSearch";
            lblReverseSearch.Size = new Size(200, 25);
            lblReverseSearch.TabIndex = 7;
            lblReverseSearch.Text = "Enter Word for Reverse Search:";
            // 
            // txtWordInput
            // 
            txtWordInput.Location = new Point(232, 162);
            txtWordInput.Name = "txtWordInput";
            txtWordInput.Size = new Size(234, 25);
            txtWordInput.TabIndex = 3;
            toolTip.SetToolTip(txtWordInput, "Enter a word to find its numeric representation.");
            txtWordInput.TextChanged += txtWordInput_TextChanged;
            txtWordInput.KeyPress += txtWordInput_KeyPress;
            // 
            // btnReverseSearch
            // 
            btnReverseSearch.Location = new Point(472, 162);
            btnReverseSearch.Name = "btnReverseSearch";
            btnReverseSearch.Size = new Size(120, 25);
            btnReverseSearch.TabIndex = 4;
            btnReverseSearch.Text = "Reverse Search";
            toolTip.SetToolTip(btnReverseSearch, "Click to perform a reverse search for the entered word.");
            btnReverseSearch.UseVisualStyleBackColor = true;
            btnReverseSearch.Click += btnReverseSearch_Click;
            // 
            // lblCustomWords
            // 
            lblCustomWords.Location = new Point(20, 205);
            lblCustomWords.Name = "lblCustomWords";
            lblCustomWords.Size = new Size(400, 25);
            lblCustomWords.TabIndex = 10;
            lblCustomWords.Text = "Add Custom Words To The Phoneword Dictionary (One per line):";
            // 
            // txtCustomWords
            // 
            txtCustomWords.Location = new Point(20, 235);
            txtCustomWords.Multiline = true;
            txtCustomWords.Name = "txtCustomWords";
            txtCustomWords.ScrollBars = ScrollBars.Vertical;
            txtCustomWords.Size = new Size(360, 100);
            txtCustomWords.TabIndex = 5;
            toolTip.SetToolTip(txtCustomWords, "Enter custom words, one per line. Only uppercase letters A-Z are allowed.");
            txtCustomWords.TextChanged += txtCustomWords_TextChanged;
            txtCustomWords.KeyPress += txtCustomWords_KeyPress;
            // 
            // lblGeneratedResults
            // 
            lblGeneratedResults.Location = new Point(20, 355);
            lblGeneratedResults.Name = "lblGeneratedResults";
            lblGeneratedResults.Size = new Size(200, 25);
            lblGeneratedResults.TabIndex = 12;
            lblGeneratedResults.Text = "Generated Results";
            // 
            // lstGenerated
            // 
            lstGenerated.FormattingEnabled = true;
            lstGenerated.ItemHeight = 17;
            lstGenerated.Location = new Point(20, 385);
            lstGenerated.Name = "lstGenerated";
            lstGenerated.SelectionMode = SelectionMode.MultiExtended;
            lstGenerated.Size = new Size(360, 191);
            lstGenerated.TabIndex = 7;
            // 
            // btnClearGenerated
            // 
            btnClearGenerated.Location = new Point(20, 595);
            btnClearGenerated.Name = "btnClearGenerated";
            btnClearGenerated.Size = new Size(120, 30);
            btnClearGenerated.TabIndex = 8;
            btnClearGenerated.Text = "Clear Generated";
            toolTip.SetToolTip(btnClearGenerated, "Clear all generated phonewords.");
            btnClearGenerated.UseVisualStyleBackColor = true;
            btnClearGenerated.Click += btnClearGenerated_Click;
            // 
            // lblSelectedResults
            // 
            lblSelectedResults.Location = new Point(420, 355);
            lblSelectedResults.Name = "lblSelectedResults";
            lblSelectedResults.Size = new Size(200, 25);
            lblSelectedResults.TabIndex = 15;
            lblSelectedResults.Text = "Selected Results";
            // 
            // lstSelected
            // 
            lstSelected.FormattingEnabled = true;
            lstSelected.ItemHeight = 17;
            lstSelected.Location = new Point(420, 385);
            lstSelected.Name = "lstSelected";
            lstSelected.SelectionMode = SelectionMode.MultiExtended;
            lstSelected.Size = new Size(360, 191);
            lstSelected.TabIndex = 10;
            // 
            // btnClearSelected
            // 
            btnClearSelected.Location = new Point(660, 595);
            btnClearSelected.Name = "btnClearSelected";
            btnClearSelected.Size = new Size(120, 30);
            btnClearSelected.TabIndex = 12;
            btnClearSelected.Text = "Clear Selected";
            toolTip.SetToolTip(btnClearSelected, "Clear your selected phonewords.");
            btnClearSelected.UseVisualStyleBackColor = true;
            btnClearSelected.Click += btnClearSelected_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(260, 595);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 30);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add to Selected";
            toolTip.SetToolTip(btnAdd, "Add selected phonewords to your selection.");
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(420, 595);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(148, 30);
            btnRemove.TabIndex = 11;
            btnRemove.Text = "Remove from Selected";
            toolTip.SetToolTip(btnRemove, "Remove selected phonewords from your selection.");
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(579, 651);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(120, 30);
            btnExport.TabIndex = 13;
            btnExport.Text = "Export Selected";
            toolTip.SetToolTip(btnExport, "Export your selected phonewords to a file.");
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(705, 651);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 30);
            btnClose.TabIndex = 14;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 688);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(798, 22);
            statusStrip1.TabIndex = 22;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 17);
            statusLabel.Text = "Ready";
            // 
            // txtSearchGenerated
            // 
            txtSearchGenerated.Enabled = false;
            txtSearchGenerated.Location = new Point(226, 352);
            txtSearchGenerated.Name = "txtSearchGenerated";
            txtSearchGenerated.Size = new Size(154, 25);
            txtSearchGenerated.TabIndex = 6;
            toolTip.SetToolTip(txtSearchGenerated, "Type to search generated phonewords in real time.");
            txtSearchGenerated.TextChanged += txtSearchGenerated_TextChanged;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(126, 82);
            txtPhoneNumber.MaxLength = 11;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "Enter Numbers Only";
            txtPhoneNumber.Size = new Size(208, 25);
            txtPhoneNumber.TabIndex = 1;
            txtPhoneNumber.TextChanged += txtPhoneNumber_TextChanged;
            txtPhoneNumber.KeyPress += txtPhoneNumber_KeyPress;
            // 
            // lblSearchGenerated
            // 
            lblSearchGenerated.Location = new Point(170, 355);
            lblSearchGenerated.Name = "lblSearchGenerated";
            lblSearchGenerated.Size = new Size(50, 25);
            lblSearchGenerated.TabIndex = 24;
            lblSearchGenerated.Text = "Search:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(798, 710);
            Controls.Add(txtSearchGenerated);
            Controls.Add(lblSearchGenerated);
            Controls.Add(txtPhoneNumber);
            Controls.Add(statusStrip1);
            Controls.Add(btnClose);
            Controls.Add(btnExport);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(btnClearSelected);
            Controls.Add(lstSelected);
            Controls.Add(lblSelectedResults);
            Controls.Add(btnClearGenerated);
            Controls.Add(lstGenerated);
            Controls.Add(lblGeneratedResults);
            Controls.Add(txtCustomWords);
            Controls.Add(lblCustomWords);
            Controls.Add(btnReverseSearch);
            Controls.Add(txtWordInput);
            Controls.Add(lblReverseSearch);
            Controls.Add(progressBar);
            Controls.Add(btnCancel);
            Controls.Add(btnGenerate);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Phoneword Generator";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblPhoneNumber;
        private Button btnGenerate;
        private Button btnCancel;
        private ProgressBar progressBar;
        private Label lblReverseSearch;
        private TextBox txtWordInput;
        private Button btnReverseSearch;
        private Label lblCustomWords;
        private TextBox txtCustomWords;
        private Label lblGeneratedResults;
        private ListBox lstGenerated;
        private Button btnClearGenerated;
        private Label lblSelectedResults;
        private ListBox lstSelected;
        private Button btnClearSelected;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnExport;
        private Button btnClose;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private ToolTip toolTip;
        private TextBox txtPhoneNumber;
        private Label lblSearchGenerated;
        private TextBox txtSearchGenerated;
    }
}
