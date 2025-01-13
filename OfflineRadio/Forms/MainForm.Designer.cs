namespace OfflineRadio.Forms
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
            dgvPrograms = new DataGridView();
            btnAddProgram = new Button();
            btnRemoveProgram = new Button();
            btnDownload = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPrograms).BeginInit();
            SuspendLayout();
            // 
            // dgvPrograms
            // 
            dgvPrograms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrograms.Location = new Point(1, -2);
            dgvPrograms.Name = "dgvPrograms";
            dgvPrograms.RowHeadersWidth = 123;
            dgvPrograms.Size = new Size(931, 541);
            dgvPrograms.TabIndex = 0;
            dgvPrograms.CellDoubleClick += dgvPrograms_CellDoubleClick_1;
            // 
            // btnAddProgram
            // 
            btnAddProgram.Location = new Point(32, 394);
            btnAddProgram.Name = "btnAddProgram";
            btnAddProgram.Size = new Size(251, 69);
            btnAddProgram.TabIndex = 2;
            btnAddProgram.Text = "Add Program";
            btnAddProgram.UseVisualStyleBackColor = true;
            btnAddProgram.Click += btnAddProgram_Click;
            // 
            // btnRemoveProgram
            // 
            btnRemoveProgram.Location = new Point(311, 394);
            btnRemoveProgram.Name = "btnRemoveProgram";
            btnRemoveProgram.Size = new Size(308, 69);
            btnRemoveProgram.TabIndex = 3;
            btnRemoveProgram.Text = "Remove Program";
            btnRemoveProgram.UseVisualStyleBackColor = true;
            btnRemoveProgram.Click += btnRemoveProgram_Click;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(640, 394);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(258, 69);
            btnDownload.TabIndex = 4;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 540);
            Controls.Add(btnDownload);
            Controls.Add(btnRemoveProgram);
            Controls.Add(btnAddProgram);
            Controls.Add(dgvPrograms);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dgvPrograms).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPrograms;
        private Button btnAddProgram;
        private Button btnRemoveProgram;
        private Button btnDownload;
    }
}