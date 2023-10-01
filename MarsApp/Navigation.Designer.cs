namespace MarsApp
{
    partial class Navigation
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddApplicant = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectApplicants = new System.Windows.Forms.Button();
            this.Notice = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ResTests = new System.Windows.Forms.Button();
            this.Conclusion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddApplicant
            // 
            this.AddApplicant.Location = new System.Drawing.Point(199, 106);
            this.AddApplicant.Margin = new System.Windows.Forms.Padding(5);
            this.AddApplicant.Name = "AddApplicant";
            this.AddApplicant.Size = new System.Drawing.Size(270, 30);
            this.AddApplicant.TabIndex = 0;
            this.AddApplicant.Text = "Добавить претендента";
            this.AddApplicant.UseVisualStyleBackColor = true;
            this.AddApplicant.Click += new System.EventHandler(this.AddApplicant_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(103, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(482, 72);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вы находитесь в сегменте \"Набор колонистов\"\r\nпроекта колонизации Марса.\r\nПожалуйс" +
    "та, выберите действие.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectApplicants
            // 
            this.SelectApplicants.Location = new System.Drawing.Point(199, 144);
            this.SelectApplicants.Name = "SelectApplicants";
            this.SelectApplicants.Size = new System.Drawing.Size(270, 30);
            this.SelectApplicants.TabIndex = 2;
            this.SelectApplicants.Text = "Найти претендента";
            this.SelectApplicants.UseVisualStyleBackColor = true;
            this.SelectApplicants.Click += new System.EventHandler(this.SelectApplicants_Click);
            // 
            // Notice
            // 
            this.Notice.Location = new System.Drawing.Point(199, 180);
            this.Notice.Name = "Notice";
            this.Notice.Size = new System.Drawing.Size(270, 30);
            this.Notice.TabIndex = 3;
            this.Notice.Text = "Показать уведомления";
            this.Notice.UseVisualStyleBackColor = true;
            this.Notice.Click += new System.EventHandler(this.Notice_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 312);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(665, 306);
            this.dataGridView1.TabIndex = 4;
            // 
            // ResTests
            // 
            this.ResTests.Location = new System.Drawing.Point(199, 252);
            this.ResTests.Name = "ResTests";
            this.ResTests.Size = new System.Drawing.Size(270, 48);
            this.ResTests.TabIndex = 5;
            this.ResTests.Text = "Показать результаты испытаний";
            this.ResTests.UseVisualStyleBackColor = true;
            this.ResTests.Click += new System.EventHandler(this.ResTests_Click);
            // 
            // Conclusion
            // 
            this.Conclusion.Location = new System.Drawing.Point(199, 216);
            this.Conclusion.Name = "Conclusion";
            this.Conclusion.Size = new System.Drawing.Size(270, 30);
            this.Conclusion.TabIndex = 6;
            this.Conclusion.Text = "Утвердить заключение";
            this.Conclusion.UseVisualStyleBackColor = true;
            this.Conclusion.Click += new System.EventHandler(this.Conclusion_Click);
            // 
            // Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 630);
            this.Controls.Add(this.Conclusion);
            this.Controls.Add(this.ResTests);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Notice);
            this.Controls.Add(this.SelectApplicants);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddApplicant);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Navigation";
            this.Text = "Навигация";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddApplicant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectApplicants;
        private System.Windows.Forms.Button Notice;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ResTests;
        private System.Windows.Forms.Button Conclusion;
    }
}

