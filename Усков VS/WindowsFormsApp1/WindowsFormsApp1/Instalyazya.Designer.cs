namespace WindowsFormsApp1
{
    partial class Instalyazya
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
            this.instalyazyaDB = new WindowsFormsApp1.InstalyazyaDB();
            this.инсталляцияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.инсталляцияTableAdapter = new WindowsFormsApp1.InstalyazyaDBTableAdapters.ИнсталляцияTableAdapter();
            this.idinstDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idprodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.стоимостьИнсталляцииDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаИнсталляцииDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаДеинсталляцииDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествоЛицензийDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instalyazyaDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.инсталляцияBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idinstDataGridViewTextBoxColumn,
            this.idpolDataGridViewTextBoxColumn,
            this.idprodDataGridViewTextBoxColumn,
            this.стоимостьИнсталляцииDataGridViewTextBoxColumn,
            this.датаИнсталляцииDataGridViewTextBoxColumn,
            this.датаДеинсталляцииDataGridViewTextBoxColumn,
            this.количествоЛицензийDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.инсталляцияBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(807, 463);
            this.dataGridView1.TabIndex = 0;
            // 
            // instalyazyaDB
            // 
            this.instalyazyaDB.DataSetName = "InstalyazyaDB";
            this.instalyazyaDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // инсталляцияBindingSource
            // 
            this.инсталляцияBindingSource.DataMember = "Инсталляция";
            this.инсталляцияBindingSource.DataSource = this.instalyazyaDB;
            // 
            // инсталляцияTableAdapter
            // 
            this.инсталляцияTableAdapter.ClearBeforeFill = true;
            // 
            // idinstDataGridViewTextBoxColumn
            // 
            this.idinstDataGridViewTextBoxColumn.DataPropertyName = "id_inst";
            this.idinstDataGridViewTextBoxColumn.HeaderText = "id_inst";
            this.idinstDataGridViewTextBoxColumn.Name = "idinstDataGridViewTextBoxColumn";
            // 
            // idpolDataGridViewTextBoxColumn
            // 
            this.idpolDataGridViewTextBoxColumn.DataPropertyName = "id_pol";
            this.idpolDataGridViewTextBoxColumn.HeaderText = "id_pol";
            this.idpolDataGridViewTextBoxColumn.Name = "idpolDataGridViewTextBoxColumn";
            // 
            // idprodDataGridViewTextBoxColumn
            // 
            this.idprodDataGridViewTextBoxColumn.DataPropertyName = "id_prod";
            this.idprodDataGridViewTextBoxColumn.HeaderText = "id_prod";
            this.idprodDataGridViewTextBoxColumn.Name = "idprodDataGridViewTextBoxColumn";
            // 
            // стоимостьИнсталляцииDataGridViewTextBoxColumn
            // 
            this.стоимостьИнсталляцииDataGridViewTextBoxColumn.DataPropertyName = "Стоимость инсталляции";
            this.стоимостьИнсталляцииDataGridViewTextBoxColumn.HeaderText = "Стоимость инсталляции";
            this.стоимостьИнсталляцииDataGridViewTextBoxColumn.Name = "стоимостьИнсталляцииDataGridViewTextBoxColumn";
            // 
            // датаИнсталляцииDataGridViewTextBoxColumn
            // 
            this.датаИнсталляцииDataGridViewTextBoxColumn.DataPropertyName = "Дата инсталляции";
            this.датаИнсталляцииDataGridViewTextBoxColumn.HeaderText = "Дата инсталляции";
            this.датаИнсталляцииDataGridViewTextBoxColumn.Name = "датаИнсталляцииDataGridViewTextBoxColumn";
            // 
            // датаДеинсталляцииDataGridViewTextBoxColumn
            // 
            this.датаДеинсталляцииDataGridViewTextBoxColumn.DataPropertyName = "Дата деинсталляции";
            this.датаДеинсталляцииDataGridViewTextBoxColumn.HeaderText = "Дата деинсталляции";
            this.датаДеинсталляцииDataGridViewTextBoxColumn.Name = "датаДеинсталляцииDataGridViewTextBoxColumn";
            // 
            // количествоЛицензийDataGridViewTextBoxColumn
            // 
            this.количествоЛицензийDataGridViewTextBoxColumn.DataPropertyName = "Количество лицензий";
            this.количествоЛицензийDataGridViewTextBoxColumn.HeaderText = "Количество лицензий";
            this.количествоЛицензийDataGridViewTextBoxColumn.Name = "количествоЛицензийDataGridViewTextBoxColumn";
            // 
            // Instalyazya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Instalyazya";
            this.Text = "Instalyazya";
            this.Load += new System.EventHandler(this.Instalyazya_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instalyazyaDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.инсталляцияBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private InstalyazyaDB instalyazyaDB;
        private System.Windows.Forms.BindingSource инсталляцияBindingSource;
        private InstalyazyaDBTableAdapters.ИнсталляцияTableAdapter инсталляцияTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idinstDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn стоимостьИнсталляцииDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаИнсталляцииDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаДеинсталляцииDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествоЛицензийDataGridViewTextBoxColumn;
    }
}