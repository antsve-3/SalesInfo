namespace SalesInfo
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxSoldArticles = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDistrict = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxPersonalNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddSalseInfo = new System.Windows.Forms.Button();
            this.lblSalesResult = new System.Windows.Forms.Label();
            this.btnFilePrint = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.tbxSalesResults = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Namn";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(16, 36);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(100, 20);
            this.tbxName.TabIndex = 1;
            this.tbxName.TextChanged += new System.EventHandler(this.tbxName_TextChanged);
            // 
            // tbxSoldArticles
            // 
            this.tbxSoldArticles.Location = new System.Drawing.Point(382, 36);
            this.tbxSoldArticles.Name = "tbxSoldArticles";
            this.tbxSoldArticles.Size = new System.Drawing.Size(100, 20);
            this.tbxSoldArticles.TabIndex = 4;
            this.tbxSoldArticles.TextChanged += new System.EventHandler(this.tbxSoldArticles_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Antal sålda artiklar";
            // 
            // tbxDistrict
            // 
            this.tbxDistrict.Location = new System.Drawing.Point(260, 36);
            this.tbxDistrict.Name = "tbxDistrict";
            this.tbxDistrict.Size = new System.Drawing.Size(100, 20);
            this.tbxDistrict.TabIndex = 3;
            this.tbxDistrict.TextChanged += new System.EventHandler(this.tbxDistrict_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Distrikt";
            // 
            // tbxPersonalNumber
            // 
            this.tbxPersonalNumber.Location = new System.Drawing.Point(138, 36);
            this.tbxPersonalNumber.Name = "tbxPersonalNumber";
            this.tbxPersonalNumber.Size = new System.Drawing.Size(100, 20);
            this.tbxPersonalNumber.TabIndex = 2;
            this.tbxPersonalNumber.Text = "YYYYMMDDXXXX";
            this.tbxPersonalNumber.TextChanged += new System.EventHandler(this.tbxPersonalNumber_TextChanged);
            this.tbxPersonalNumber.Enter += new System.EventHandler(this.tbxPersonalNumber_OnFocus);
            this.tbxPersonalNumber.Leave += new System.EventHandler(this.tbxPersonalNumber_DeFocus);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Personnummer";
            // 
            // btnAddSalseInfo
            // 
            this.btnAddSalseInfo.Location = new System.Drawing.Point(382, 65);
            this.btnAddSalseInfo.Name = "btnAddSalseInfo";
            this.btnAddSalseInfo.Size = new System.Drawing.Size(100, 23);
            this.btnAddSalseInfo.TabIndex = 5;
            this.btnAddSalseInfo.Text = "Lägg till säljinfo";
            this.btnAddSalseInfo.UseVisualStyleBackColor = true;
            this.btnAddSalseInfo.Click += new System.EventHandler(this.btnAddSalesInfo_click);
            // 
            // lblSalesResult
            // 
            this.lblSalesResult.AutoSize = true;
            this.lblSalesResult.Location = new System.Drawing.Point(325, 181);
            this.lblSalesResult.Name = "lblSalesResult";
            this.lblSalesResult.Size = new System.Drawing.Size(35, 13);
            this.lblSalesResult.TabIndex = 9;
            this.lblSalesResult.Text = "label5";
            this.lblSalesResult.Visible = false;
            // 
            // btnFilePrint
            // 
            this.btnFilePrint.Location = new System.Drawing.Point(382, 104);
            this.btnFilePrint.Name = "btnFilePrint";
            this.btnFilePrint.Size = new System.Drawing.Size(100, 23);
            this.btnFilePrint.TabIndex = 6;
            this.btnFilePrint.Text = "Skriv till fil";
            this.btnFilePrint.UseVisualStyleBackColor = true;
            this.btnFilePrint.Visible = false;
            this.btnFilePrint.Click += new System.EventHandler(this.btnFilePrint_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(12, 87);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(35, 13);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "label5";
            this.lblError.Visible = false;
            // 
            // tbxSalesResults
            // 
            this.tbxSalesResults.Location = new System.Drawing.Point(12, 127);
            this.tbxSalesResults.Multiline = true;
            this.tbxSalesResults.Name = "tbxSalesResults";
            this.tbxSalesResults.ReadOnly = true;
            this.tbxSalesResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxSalesResults.Size = new System.Drawing.Size(303, 150);
            this.tbxSalesResults.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 289);
            this.Controls.Add(this.tbxSalesResults);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnFilePrint);
            this.Controls.Add(this.lblSalesResult);
            this.Controls.Add(this.btnAddSalseInfo);
            this.Controls.Add(this.tbxPersonalNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxDistrict);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxSoldArticles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Säljinfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxSoldArticles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDistrict;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxPersonalNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddSalseInfo;
        private System.Windows.Forms.Label lblSalesResult;
        private System.Windows.Forms.Button btnFilePrint;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox tbxSalesResults;
    }
}

