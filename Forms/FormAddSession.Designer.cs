namespace InCinema.Forms
{
    partial class FormAddSession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddSession));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCountBilet = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbTitleFilm = new System.Windows.Forms.ComboBox();
            this.filmTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cinemaDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cinemaDBDataSet = new InCinema.CinemaDBDataSet();
            this.filmTableTableAdapter = new InCinema.CinemaDBDataSetTableAdapters.FilmTableTableAdapter();
            this.txtPrice = new System.Windows.Forms.MaskedTextBox();
            this.filmTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filmTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmTableBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 123);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(142)))), ((int)(((byte)(218)))));
            this.label1.Location = new System.Drawing.Point(99, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 70);
            this.label1.TabIndex = 1;
            this.label1.Text = "Информация\r\nо сеансе";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(21, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Название фильма";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(21, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(21, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Время";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(21, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Стоимость билета";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(21, 419);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Количество билетов";
            // 
            // txtCountBilet
            // 
            this.txtCountBilet.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCountBilet.Location = new System.Drawing.Point(244, 419);
            this.txtCountBilet.Name = "txtCountBilet";
            this.txtCountBilet.ReadOnly = true;
            this.txtCountBilet.Size = new System.Drawing.Size(178, 27);
            this.txtCountBilet.TabIndex = 5;
            this.txtCountBilet.Text = "60";
            this.txtCountBilet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCountBilet_KeyPress);
            // 
            // datePicker
            // 
            this.datePicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.datePicker.Location = new System.Drawing.Point(222, 240);
            this.datePicker.MaxDate = new System.DateTime(2024, 9, 14, 0, 0, 0, 0);
            this.datePicker.MinDate = new System.DateTime(2023, 4, 27, 0, 0, 0, 0);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 27);
            this.datePicker.TabIndex = 2;
            this.datePicker.Value = new System.DateTime(2023, 5, 15, 0, 0, 0, 0);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(142)))), ((int)(((byte)(218)))));
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(153, 483);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(248)))), ((int)(((byte)(239)))));
            this.btnClose.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.Location = new System.Drawing.Point(295, 483);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Отмена";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbTitleFilm
            // 
            this.cmbTitleFilm.DataSource = this.filmTableBindingSource;
            this.cmbTitleFilm.DisplayMember = "Title";
            this.cmbTitleFilm.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbTitleFilm.FormattingEnabled = true;
            this.cmbTitleFilm.Location = new System.Drawing.Point(211, 163);
            this.cmbTitleFilm.Name = "cmbTitleFilm";
            this.cmbTitleFilm.Size = new System.Drawing.Size(211, 26);
            this.cmbTitleFilm.TabIndex = 1;
            this.cmbTitleFilm.ValueMember = "Id";
            // 
            // filmTableBindingSource
            // 
            this.filmTableBindingSource.DataMember = "FilmTable";
            this.filmTableBindingSource.DataSource = this.cinemaDBDataSetBindingSource;
            // 
            // cinemaDBDataSetBindingSource
            // 
            this.cinemaDBDataSetBindingSource.DataSource = this.cinemaDBDataSet;
            this.cinemaDBDataSetBindingSource.Position = 0;
            // 
            // cinemaDBDataSet
            // 
            this.cinemaDBDataSet.DataSetName = "CinemaDBDataSet";
            this.cinemaDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // filmTableTableAdapter
            // 
            this.filmTableTableAdapter.ClearBeforeFill = true;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPrice.Location = new System.Drawing.Point(243, 360);
            this.txtPrice.Mask = "###.##";
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(178, 27);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.ValidatingType = typeof(System.DateTime);
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // filmTableBindingSource1
            // 
            this.filmTableBindingSource1.DataMember = "FilmTable";
            this.filmTableBindingSource1.DataSource = this.cinemaDBDataSet;
            // 
            // cmbTime
            // 
            this.cmbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Items.AddRange(new object[] {
            "11:00",
            "14:00",
            "17:00",
            "20:00",
            "23:00"});
            this.cmbTime.Location = new System.Drawing.Point(244, 302);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(177, 26);
            this.cmbTime.TabIndex = 3;
            this.cmbTime.SelectedIndexChanged += new System.EventHandler(this.cmbTime_SelectedIndexChanged);
            // 
            // FormAddSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 543);
            this.Controls.Add(this.cmbTime);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.cmbTitleFilm);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.txtCountBilet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddSession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление сеанса";
            this.Load += new System.EventHandler(this.FormAddSession_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filmTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filmTableBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCountBilet;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbTitleFilm;
        private System.Windows.Forms.BindingSource cinemaDBDataSetBindingSource;
        private CinemaDBDataSet cinemaDBDataSet;
        private System.Windows.Forms.BindingSource filmTableBindingSource;
        private CinemaDBDataSetTableAdapters.FilmTableTableAdapter filmTableTableAdapter;
        private System.Windows.Forms.MaskedTextBox txtPrice;
        private System.Windows.Forms.BindingSource filmTableBindingSource1;
        private System.Windows.Forms.ComboBox cmbTime;
    }
}