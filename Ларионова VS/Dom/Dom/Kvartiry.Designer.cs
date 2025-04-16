namespace Dom
{
    partial class Kvartiry
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kvartiryDB = new Dom.KvartiryDB();
            this.квартирыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.квартирыTableAdapter = new Dom.KvartiryDBTableAdapters.КвартирыTableAdapter();
            this.iDкваритирыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерквартирыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номердомаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.числожильцовDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.площадьDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kvartiryDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.квартирыBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDкваритирыDataGridViewTextBoxColumn,
            this.номерквартирыDataGridViewTextBoxColumn,
            this.номердомаDataGridViewTextBoxColumn,
            this.числожильцовDataGridViewTextBoxColumn,
            this.площадьDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.квартирыBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(808, 463);
            this.dataGridView1.TabIndex = 0;
            // 
            // kvartiryDB
            // 
            this.kvartiryDB.DataSetName = "KvartiryDB";
            this.kvartiryDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // квартирыBindingSource
            // 
            this.квартирыBindingSource.DataMember = "Квартиры";
            this.квартирыBindingSource.DataSource = this.kvartiryDB;
            // 
            // квартирыTableAdapter
            // 
            this.квартирыTableAdapter.ClearBeforeFill = true;
            // 
            // iDкваритирыDataGridViewTextBoxColumn
            // 
            this.iDкваритирыDataGridViewTextBoxColumn.DataPropertyName = "ID_кваритиры";
            this.iDкваритирыDataGridViewTextBoxColumn.HeaderText = "ID_кваритиры";
            this.iDкваритирыDataGridViewTextBoxColumn.Name = "iDкваритирыDataGridViewTextBoxColumn";
            // 
            // номерквартирыDataGridViewTextBoxColumn
            // 
            this.номерквартирыDataGridViewTextBoxColumn.DataPropertyName = "Номер_квартиры";
            this.номерквартирыDataGridViewTextBoxColumn.HeaderText = "Номер_квартиры";
            this.номерквартирыDataGridViewTextBoxColumn.Name = "номерквартирыDataGridViewTextBoxColumn";
            // 
            // номердомаDataGridViewTextBoxColumn
            // 
            this.номердомаDataGridViewTextBoxColumn.DataPropertyName = "Номер_дома";
            this.номердомаDataGridViewTextBoxColumn.HeaderText = "Номер_дома";
            this.номердомаDataGridViewTextBoxColumn.Name = "номердомаDataGridViewTextBoxColumn";
            // 
            // числожильцовDataGridViewTextBoxColumn
            // 
            this.числожильцовDataGridViewTextBoxColumn.DataPropertyName = "Число_жильцов";
            this.числожильцовDataGridViewTextBoxColumn.HeaderText = "Число_жильцов";
            this.числожильцовDataGridViewTextBoxColumn.Name = "числожильцовDataGridViewTextBoxColumn";
            // 
            // площадьDataGridViewTextBoxColumn
            // 
            this.площадьDataGridViewTextBoxColumn.DataPropertyName = "Площадь";
            this.площадьDataGridViewTextBoxColumn.HeaderText = "Площадь";
            this.площадьDataGridViewTextBoxColumn.Name = "площадьDataGridViewTextBoxColumn";
            // 
            // Kvartiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Kvartiry";
            this.Text = "Kvartiry";
            this.Load += new System.EventHandler(this.Kvartiry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kvartiryDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.квартирыBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private KvartiryDB kvartiryDB;
        private System.Windows.Forms.BindingSource квартирыBindingSource;
        private KvartiryDBTableAdapters.КвартирыTableAdapter квартирыTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDкваритирыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерквартирыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номердомаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn числожильцовDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn площадьDataGridViewTextBoxColumn;
    }
}