namespace OfflineRadio.Forms
{
    partial class AddProgramForm
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
            txtURL = new TextBox();
            txtDuration = new TextBox();
            txtTitle = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // txtURL
            // 
            txtURL.Location = new Point(261, 181);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(300, 55);
            txtURL.TabIndex = 0;
            // 
            // txtDuration
            // 
            txtDuration.Location = new Point(261, 294);
            txtDuration.Name = "txtDuration";
            txtDuration.Size = new Size(300, 55);
            txtDuration.TabIndex = 1;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(261, 74);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(300, 55);
            txtTitle.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 98);
            label1.Name = "label1";
            label1.Size = new Size(96, 48);
            label1.TabIndex = 3;
            label1.Text = "Title:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 188);
            label2.Name = "label2";
            label2.Size = new Size(92, 48);
            label2.TabIndex = 4;
            label2.Text = "URL:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 294);
            label3.Name = "label3";
            label3.Size = new Size(166, 48);
            label3.TabIndex = 5;
            label3.Text = "Duration:";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(43, 391);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(225, 69);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // AddProgramForm
            // 
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(876, 523);
            Controls.Add(btnSubmit);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTitle);
            Controls.Add(txtDuration);
            Controls.Add(txtURL);
            Name = "AddProgramForm";
            Text = "AddProgramForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtURL;
        private TextBox txtDuration;
        private TextBox txtTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSubmit;
    }
}