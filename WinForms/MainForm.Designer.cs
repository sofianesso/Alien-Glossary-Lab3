namespace WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxLists = new ComboBox();
            listBoxWords = new ListBox();
            btnNew = new Button();
            btnCount = new Button();
            btnAdd = new Button();
            btnPractice = new Button();
            btnRemove = new Button();
            lblShowLists = new Label();
            lblBrand = new Label();
            lblLogo = new Label();
            lblWords = new Label();
            btnRemoveList = new Button();
            labelLogoSecond = new Label();
            lblHeader = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // comboBoxLists
            // 
            comboBoxLists.BackColor = Color.Black;
            comboBoxLists.Font = new Font("Normalidad UltraExtended Var", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxLists.ForeColor = Color.Lime;
            comboBoxLists.FormattingEnabled = true;
            comboBoxLists.Location = new Point(451, 163);
            comboBoxLists.Margin = new Padding(3, 2, 3, 2);
            comboBoxLists.Name = "comboBoxLists";
            comboBoxLists.Size = new Size(370, 32);
            comboBoxLists.Sorted = true;
            comboBoxLists.TabIndex = 0;
            comboBoxLists.SelectedIndexChanged += comboBoxLists_SelectedIndexChanged;
            // 
            // listBoxWords
            // 
            listBoxWords.BackColor = Color.Black;
            listBoxWords.Font = new Font("Normalidad Extended Var", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxWords.ForeColor = Color.Lime;
            listBoxWords.FormattingEnabled = true;
            listBoxWords.Location = new Point(451, 327);
            listBoxWords.Margin = new Padding(3, 2, 3, 2);
            listBoxWords.Name = "listBoxWords";
            listBoxWords.ScrollAlwaysVisible = true;
            listBoxWords.Size = new Size(370, 196);
            listBoxWords.TabIndex = 1;
            listBoxWords.SelectedIndexChanged += listBoxWords_SelectedIndexChanged;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.Black;
            btnNew.Font = new Font("Normalidad UltraExtended Var", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNew.ForeColor = Color.Lime;
            btnNew.Location = new Point(681, 209);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(140, 34);
            btnNew.TabIndex = 2;
            btnNew.Text = "New List";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // btnCount
            // 
            btnCount.BackColor = Color.Black;
            btnCount.Font = new Font("Normalidad UltraExtended Var", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCount.ForeColor = Color.Lime;
            btnCount.Location = new Point(126, 421);
            btnCount.Margin = new Padding(3, 2, 3, 2);
            btnCount.Name = "btnCount";
            btnCount.Size = new Size(224, 42);
            btnCount.TabIndex = 3;
            btnCount.Text = "Count";
            btnCount.UseVisualStyleBackColor = false;
            btnCount.Click += btnCount_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Black;
            btnAdd.Font = new Font("Normalidad UltraExtended Var", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.Lime;
            btnAdd.Location = new Point(126, 327);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(224, 43);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add Word";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnPractice
            // 
            btnPractice.BackColor = Color.Black;
            btnPractice.Font = new Font("Normalidad UltraExtended Var", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPractice.ForeColor = Color.Lime;
            btnPractice.Location = new Point(126, 467);
            btnPractice.Margin = new Padding(3, 2, 3, 2);
            btnPractice.Name = "btnPractice";
            btnPractice.Size = new Size(224, 40);
            btnPractice.TabIndex = 5;
            btnPractice.Text = "Practice";
            btnPractice.UseVisualStyleBackColor = false;
            btnPractice.Click += btnPractice_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Black;
            btnRemove.Font = new Font("Normalidad UltraExtended Var", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemove.ForeColor = Color.Lime;
            btnRemove.Location = new Point(126, 374);
            btnRemove.Margin = new Padding(3, 2, 3, 2);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(224, 43);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "Remove Word";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // lblShowLists
            // 
            lblShowLists.AutoSize = true;
            lblShowLists.BackColor = Color.Black;
            lblShowLists.BorderStyle = BorderStyle.Fixed3D;
            lblShowLists.Font = new Font("Normalidad UltraExtended Var", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShowLists.ForeColor = Color.LimeGreen;
            lblShowLists.Location = new Point(451, 127);
            lblShowLists.Name = "lblShowLists";
            lblShowLists.Size = new Size(203, 34);
            lblShowLists.TabIndex = 7;
            lblShowLists.Text = "Choose list:";
            lblShowLists.Click += lblShowLists_Click;
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Tempus Sans ITC", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBrand.ForeColor = Color.LimeGreen;
            lblBrand.Location = new Point(12, 9);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(451, 26);
            lblBrand.TabIndex = 8;
            lblBrand.Text = "𓍊𓋼𓍊𓋼𓍊𓍊𓋼𓍊𓋼𓍊 \U0001f6f8  ALIEN GLOSSARY APP \U0001f6f8  𓍊𓋼𓍊𓋼𓍊𓍊𓋼𓍊𓋼𓍊";
            lblBrand.Click += lblFooter2_Click;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Tempus Sans ITC", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.LimeGreen;
            lblLogo.Location = new Point(158, 149);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(128, 94);
            lblLogo.TabIndex = 9;
            lblLogo.Text = "👽";
            lblLogo.Click += lblLogo_Click;
            // 
            // lblWords
            // 
            lblWords.AutoSize = true;
            lblWords.BorderStyle = BorderStyle.Fixed3D;
            lblWords.Font = new Font("Normalidad UltraExtended Var", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWords.ForeColor = Color.Lime;
            lblWords.Location = new Point(451, 291);
            lblWords.Name = "lblWords";
            lblWords.Size = new Size(119, 34);
            lblWords.TabIndex = 10;
            lblWords.Text = "Words";
            lblWords.Click += lblWordsHeader_Click;
            // 
            // btnRemoveList
            // 
            btnRemoveList.BackColor = Color.Black;
            btnRemoveList.Font = new Font("Normalidad UltraExtended Var", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemoveList.ForeColor = Color.Lime;
            btnRemoveList.Location = new Point(451, 209);
            btnRemoveList.Name = "btnRemoveList";
            btnRemoveList.Size = new Size(112, 34);
            btnRemoveList.TabIndex = 11;
            btnRemoveList.Text = "Delete";
            btnRemoveList.UseVisualStyleBackColor = false;
            btnRemoveList.Click += btnRemoveList_Click;
            // 
            // labelLogoSecond
            // 
            labelLogoSecond.AutoSize = true;
            labelLogoSecond.BackColor = Color.Transparent;
            labelLogoSecond.Font = new Font("Tempus Sans ITC", 28F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLogoSecond.ForeColor = Color.Lime;
            labelLogoSecond.Location = new Point(-1, 35);
            labelLogoSecond.Name = "labelLogoSecond";
            labelLogoSecond.Size = new Size(102, 73);
            labelLogoSecond.TabIndex = 12;
            labelLogoSecond.Text = "\U0001f6f8";
            labelLogoSecond.Click += labelLogoSecond_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Normalidad UltraExtended Var", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(12, 94);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(114, 32);
            lblHeader.TabIndex = 13;
            lblHeader.Text = "ALIEN";
            lblHeader.Click += lblHeader_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tempus Sans ITC", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LimeGreen;
            label1.Location = new Point(381, 9);
            label1.Name = "label1";
            label1.Size = new Size(451, 26);
            label1.TabIndex = 14;
            label1.Text = "𓍊𓋼𓍊𓋼𓍊𓍊𓋼𓍊𓋼𓍊 \U0001f6f8  ALIEN GLOSSARY APP \U0001f6f8  𓍊𓋼𓍊𓋼𓍊𓍊𓋼𓍊𓋼𓍊";
            label1.Click += lblFooter1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(844, 562);
            Controls.Add(label1);
            Controls.Add(lblHeader);
            Controls.Add(labelLogoSecond);
            Controls.Add(btnRemoveList);
            Controls.Add(lblWords);
            Controls.Add(lblLogo);
            Controls.Add(lblBrand);
            Controls.Add(lblShowLists);
            Controls.Add(btnRemove);
            Controls.Add(btnPractice);
            Controls.Add(btnAdd);
            Controls.Add(btnCount);
            Controls.Add(btnNew);
            Controls.Add(listBoxWords);
            Controls.Add(comboBoxLists);
            Font = new Font("Tempus Sans ITC", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Lime;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alien Glossary App";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxLists;
        private ListBox listBoxWords;
        private Button btnNew;
        private Button btnCount;
        private Button btnAdd;
        private Button btnPractice;
        private Button btnRemove;
        private Label lblShowLists;
        private Label lblBrand;
        private Label lblLogo;
        private Label lblWords;
        private Button btnRemoveList;
        private Label labelLogoSecond;
        private Label lblHeader;
        private Label label1;
    }
}