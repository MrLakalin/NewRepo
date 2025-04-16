namespace Dom
{
    partial class Vid_oplat
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
            this.vidoplatDB = new Dom.VidoplatDB();
            this.видыОплатыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.виды_оплатыTableAdapter = new Dom.VidoplatDBTableAdapters.Виды_оплатыTableAdapter();
            this.iDвидаоплатыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наименованиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ценазаплощадьDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ценазажильцаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vidoplatDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.видыОплатыBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDвидаоплатыDataGridViewTextBoxColumn,
            this.наименованиеDataGridViewTextBoxColumn,
            this.ценазаплощадьDataGridViewTextBoxColumn,
            this.ценазажильцаDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.видыОплатыBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(813, 454);
            this.dataGridView1.TabIndex = 0;
            // 
            // vidoplatDB
            // 
            this.vidoplatDB.DataSetName = "VidoplatDB";
            this.vidoplatDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // видыОплатыBindingSource
            // 
            this.видыОплатыBindingSource.DataMember = "Виды оплаты";
            this.видыОплатыBindingSource.DataSource = this.vidoplatDB;
            // 
            // виды_оплатыTableAdapter
            // 
            this.виды_оплатыTableAdapter.ClearBeforeFill = true;
            // 
            // iDвидаоплатыDataGridViewTextBoxColumn
            // 
            this.iDвидаоплатыDataGridViewTextBoxColumn.DataPropertyName = "ID_вида_оплаты";
            this.iDвидаоплатыDataGridViewTextBoxColumn.HeaderText = "ID_вида_оплаты";
            this.iDвидаоплатыDataGridViewTextBoxColumn.Name = "iDвидаоплатыDataGridViewTextBoxColumn";
            // 
            // наименованиеDataGridViewTextBoxColumn
            // 
            this.наименованиеDataGridViewTextBoxColumn.DataPropertyName = "Наименование";
            this.наименованиеDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.наименованиеDataGridViewTextBoxColumn.Name = "наименованиеDataGridViewTextBoxColumn";
            // 
            // ценазаплощадьDataGridViewTextBoxColumn
            // 
            this.ценазаплощадьDataGridViewTextBoxColumn.DataPropertyName = "Цена_за_площадь";
            this.ценазаплощадьDataGridViewTextBoxColumn.HeaderText = "Цена_за_площадь";
            this.ценазаплощадьDataGridViewTextBoxColumn.Name = "ценазаплощадьDataGridViewTextBoxColumn";
            // 
            // ценазажильцаDataGridViewTextBoxColumn
            // 
            this.ценазажильцаDataGridViewTextBoxColumn.DataPropertyName = "Цена_за_жильца";
            this.ценазажильцаDataGridViewTextBoxColumn.HeaderText = "Цена_за_жильца";
            this.ценазажильцаDataGridViewTextBoxColumn.Name = "ценазажильцаDataGridViewTextBoxColumn";
            // 
            // Vid_oplat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Vid_oplat";
            this.Text = "Vid_oplat";
            this.Load += new System.EventHandler(this.Vid_oplat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vidoplatDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.видыОплатыBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private VidoplatDB vidoplatDB;
        private System.Windows.Forms.BindingSource видыОплатыBindingSource;
        private VidoplatDBTableAdapters.Виды_оплатыTableAdapter виды_оплатыTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDвидаоплатыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименованиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ценазаплощадьDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ценазажильцаDataGridViewTextBoxColumn;
    }
}