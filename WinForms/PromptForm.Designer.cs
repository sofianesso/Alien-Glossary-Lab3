namespace WinForms
{
    partial class PromptForm
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
            textBox1 = new TextBox();
            label1 = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.Font = new Font("Normalidad Extended Var", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.Lime;
            textBox1.Location = new Point(60, 138);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(366, 32);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Normalidad Extended Var", 11.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(60, 101);
            label1.Name = "label1";
            label1.Size = new Size(93, 34);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.Black;
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.Font = new Font("Normalidad Extended Var", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(263, 176);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(163, 43);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "OK";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Black;
            btnCancel.DialogResult = DialogResult.OK;
            btnCancel.Font = new Font("Normalidad Extended Var", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(60, 176);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(163, 43);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // PromptForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(813, 255);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(label1);
            Controls.Add(textBox1);
            ForeColor = Color.Lime;
            Name = "PromptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PromptForm";
            Load += PromptForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button btnConfirm;
        private Button btnCancel;
    }
}