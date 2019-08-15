namespace SafetyStockCalc
{
    partial class AddModification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddModification));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ProjektComb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SAPcomb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.modTxt = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.DelModBtn = new System.Windows.Forms.Button();
            this.AddModBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.49152F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.50847F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(428, 236);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.01896F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.98104F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ProjektComb, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.SAPcomb, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.modTxt, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(422, 158);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Projekt:";
            // 
            // ProjektComb
            // 
            this.ProjektComb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProjektComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProjektComb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjektComb.FormattingEnabled = true;
            this.ProjektComb.Location = new System.Drawing.Point(179, 12);
            this.ProjektComb.Name = "ProjektComb";
            this.ProjektComb.Size = new System.Drawing.Size(216, 29);
            this.ProjektComb.TabIndex = 1;
            this.ProjektComb.SelectedIndexChanged += new System.EventHandler(this.ProjektComb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "SAP";
            // 
            // SAPcomb
            // 
            this.SAPcomb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SAPcomb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SAPcomb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAPcomb.FormattingEnabled = true;
            this.SAPcomb.Location = new System.Drawing.Point(179, 65);
            this.SAPcomb.Name = "SAPcomb";
            this.SAPcomb.Size = new System.Drawing.Size(216, 29);
            this.SAPcomb.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Modyfikacja:";
            // 
            // modTxt
            // 
            this.modTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modTxt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modTxt.Location = new System.Drawing.Point(179, 119);
            this.modTxt.Name = "modTxt";
            this.modTxt.Size = new System.Drawing.Size(216, 27);
            this.modTxt.TabIndex = 6;
            this.modTxt.TextChanged += new System.EventHandler(this.modTxt_TextChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tableLayoutPanel3.Controls.Add(this.DelModBtn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.AddModBtn, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 167);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(422, 66);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // DelModBtn
            // 
            this.DelModBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DelModBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.DelModBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelModBtn.Location = new System.Drawing.Point(3, 16);
            this.DelModBtn.Name = "DelModBtn";
            this.DelModBtn.Size = new System.Drawing.Size(205, 33);
            this.DelModBtn.TabIndex = 0;
            this.DelModBtn.Text = "Usuń";
            this.DelModBtn.UseVisualStyleBackColor = false;
            // 
            // AddModBtn
            // 
            this.AddModBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddModBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.AddModBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddModBtn.Location = new System.Drawing.Point(214, 16);
            this.AddModBtn.Name = "AddModBtn";
            this.AddModBtn.Size = new System.Drawing.Size(205, 33);
            this.AddModBtn.TabIndex = 1;
            this.AddModBtn.Text = "Dodaj";
            this.AddModBtn.UseVisualStyleBackColor = false;
            this.AddModBtn.Click += new System.EventHandler(this.AddModBtn_Click);
            // 
            // AddModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 236);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddModification";
            this.Text = "AddModification";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ProjektComb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SAPcomb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox modTxt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button DelModBtn;
        private System.Windows.Forms.Button AddModBtn;
    }
}