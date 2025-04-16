namespace Dom
{
    partial class Oplata
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
            this.iDоплатыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDквартирыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDвидаоплатыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.суммаоплатыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.месяцDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.годDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаоплатыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.оплатыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.opalataDB = new Dom.OpalataDB();
            this.оплатыTableAdapter = new Dom.OpalataDBTableAdapters.ОплатыTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.оплатыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opalataDB)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDоплатыDataGridViewTextBoxColumn,
            this.iDквартирыDataGridViewTextBoxColumn,
            this.iDвидаоплатыDataGridViewTextBoxColumn,
            this.суммаоплатыDataGridViewTextBoxColumn,
            this.месяцDataGridViewTextBoxColumn,
            this.годDataGridViewTextBoxColumn,
            this.датаоплатыDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.оплатыBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(807, 463);
            this.dataGridView1.TabIndex = 0;
            // 
            // iDоплатыDataGridViewTextBoxColumn
            // 
            this.iDоплатыDataGridViewTextBoxColumn.DataPropertyName = "ID_оплаты";
            this.iDоплатыDataGridViewTextBoxColumn.HeaderText = "ID_оплаты";
            this.iDоплатыDataGridViewTextBoxColumn.Name = "iDоплатыDataGridViewTextBoxColumn";
            // 
            // iDквартирыDataGridViewTextBoxColumn
            // 
            this.iDквартирыDataGridViewTextBoxColumn.DataPropertyName = "ID_квартиры";
            this.iDквартирыDataGridViewTextBoxColumn.HeaderText = "ID_квартиры";
            this.iDквартирыDataGridViewTextBoxColumn.Name = "iDквартирыDataGridViewTextBoxColumn";
            // 
            // iDвидаоплатыDataGridViewTextBoxColumn
            // 
            this.iDвидаоплатыDataGridViewTextBoxColumn.DataPropertyName = "ID_вида_оплаты";
            this.iDвидаоплатыDataGridViewTextBoxColumn.HeaderText = "ID_вида_оплаты";
            this.iDвидаоплатыDataGridViewTextBoxColumn.Name = "iDвидаоплатыDataGridViewTextBoxColumn";
            // 
            // суммаоплатыDataGridViewTextBoxColumn
            // 
            this.суммаоплатыDataGridViewTextBoxColumn.DataPropertyName = "Сумма_оплаты";
            this.суммаоплатыDataGridViewTextBoxColumn.HeaderText = "Сумма_оплаты";
            this.суммаоплатыDataGridViewTextBoxColumn.Name = "суммаоплатыDataGridViewTextBoxColumn";
            // 
            // месяцDataGridViewTextBoxColumn
            // 
            this.месяцDataGridViewTextBoxColumn.DataPropertyName = "Месяц";
            this.месяцDataGridViewTextBoxColumn.HeaderText = "Месяц";
            this.месяцDataGridViewTextBoxColumn.Name = "месяцDataGridViewTextBoxColumn";
            // 
            // годDataGridViewTextBoxColumn
            // 
            this.годDataGridViewTextBoxColumn.DataPropertyName = "Год";
            this.годDataGridViewTextBoxColumn.HeaderText = "Год";
            this.годDataGridViewTextBoxColumn.Name = "годDataGridViewTextBoxColumn";
            // 
            // датаоплатыDataGridViewTextBoxColumn
            // 
            this.датаоплатыDataGridViewTextBoxColumn.DataPropertyName = "Дата_оплаты";
            this.датаоплатыDataGridViewTextBoxColumn.HeaderText = "Дата_оплаты";
            this.датаоплатыDataGridViewTextBoxColumn.Name = "датаоплатыDataGridViewTextBoxColumn";
            // 
            // оплатыBindingSource
            // 
            this.оплатыBindingSource.DataMember = "Оплаты";
            this.оплатыBindingSource.DataSource = this.opalataDB;
            // 
            // opalataDB
            // 
            this.opalataDB.DataSetName = "OpalataDB";
            this.opalataDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // оплатыTableAdapter
            // 
            this.оплатыTableAdapter.ClearBeforeFill = true;
            // 
            // Oplata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Oplata";
            this.Text = "Oplata";
            this.Load += new System.EventHandler(this.Oplata_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.оплатыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opalataDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private OpalataDB opalataDB;
        private System.Windows.Forms.BindingSource оплатыBindingSource;
        private OpalataDBTableAdapters.ОплатыTableAdapter оплатыTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDоплатыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDквартирыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDвидаоплатыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn суммаоплатыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn месяцDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn годDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаоплатыDataGridViewTextBoxColumn;
    }
}