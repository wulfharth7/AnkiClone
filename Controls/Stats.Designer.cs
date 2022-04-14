
namespace clone
{
    partial class Stats
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnResetStats = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ankiDataSet = new clone.ankiDataSet();
            this.ankiDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ankiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ankiDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPDF
            // 
            this.btnPDF.Location = new System.Drawing.Point(587, 384);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(119, 34);
            this.btnPDF.TabIndex = 0;
            this.btnPDF.Text = "Download PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            // 
            // btnResetStats
            // 
            this.btnResetStats.Location = new System.Drawing.Point(462, 384);
            this.btnResetStats.Name = "btnResetStats";
            this.btnResetStats.Size = new System.Drawing.Size(119, 34);
            this.btnResetStats.TabIndex = 1;
            this.btnResetStats.Text = "Reset Stats";
            this.btnResetStats.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.ankiDataSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(74, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(209, 202);
            this.dataGridView1.TabIndex = 2;
            // 
            // ankiDataSet
            // 
            this.ankiDataSet.DataSetName = "ankiDataSet";
            this.ankiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ankiDataSetBindingSource
            // 
            this.ankiDataSetBindingSource.DataSource = this.ankiDataSet;
            this.ankiDataSetBindingSource.Position = 0;
            // 
            // Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnResetStats);
            this.Controls.Add(this.btnPDF);
            this.Name = "Stats";
            this.Size = new System.Drawing.Size(713, 427);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ankiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ankiDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnResetStats;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource ankiDataSetBindingSource;
        private ankiDataSet ankiDataSet;
    }
}
