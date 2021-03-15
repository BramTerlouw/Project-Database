
namespace SomerenUI
{
    partial class Drinks_Modify
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
            this.lblChangeStock1 = new System.Windows.Forms.Label();
            this.lblChangeStock2 = new System.Windows.Forms.Label();
            this.txtChangeStockDrink = new System.Windows.Forms.TextBox();
            this.txtChangeStockStock = new System.Windows.Forms.TextBox();
            this.btnChangeStock = new System.Windows.Forms.Button();
            this.lblChangeName1 = new System.Windows.Forms.Label();
            this.lblChangeName2 = new System.Windows.Forms.Label();
            this.txtChangeNameOld = new System.Windows.Forms.TextBox();
            this.txtChangeNameNew = new System.Windows.Forms.TextBox();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChangeStock1
            // 
            this.lblChangeStock1.AutoSize = true;
            this.lblChangeStock1.Location = new System.Drawing.Point(29, 22);
            this.lblChangeStock1.Name = "lblChangeStock1";
            this.lblChangeStock1.Size = new System.Drawing.Size(72, 13);
            this.lblChangeStock1.TabIndex = 0;
            this.lblChangeStock1.Text = "Enter drink id:";
            // 
            // lblChangeStock2
            // 
            this.lblChangeStock2.AutoSize = true;
            this.lblChangeStock2.Location = new System.Drawing.Point(29, 54);
            this.lblChangeStock2.Name = "lblChangeStock2";
            this.lblChangeStock2.Size = new System.Drawing.Size(61, 13);
            this.lblChangeStock2.TabIndex = 1;
            this.lblChangeStock2.Text = "New stock:";
            // 
            // txtChangeStockDrink
            // 
            this.txtChangeStockDrink.Location = new System.Drawing.Point(129, 19);
            this.txtChangeStockDrink.Name = "txtChangeStockDrink";
            this.txtChangeStockDrink.Size = new System.Drawing.Size(100, 20);
            this.txtChangeStockDrink.TabIndex = 2;
            // 
            // txtChangeStockStock
            // 
            this.txtChangeStockStock.Location = new System.Drawing.Point(129, 51);
            this.txtChangeStockStock.Name = "txtChangeStockStock";
            this.txtChangeStockStock.Size = new System.Drawing.Size(100, 20);
            this.txtChangeStockStock.TabIndex = 3;
            // 
            // btnChangeStock
            // 
            this.btnChangeStock.Location = new System.Drawing.Point(32, 96);
            this.btnChangeStock.Name = "btnChangeStock";
            this.btnChangeStock.Size = new System.Drawing.Size(197, 23);
            this.btnChangeStock.TabIndex = 4;
            this.btnChangeStock.Text = "Change stock";
            this.btnChangeStock.UseVisualStyleBackColor = true;
            this.btnChangeStock.Click += new System.EventHandler(this.btnChangeStock_Click);
            // 
            // lblChangeName1
            // 
            this.lblChangeName1.AutoSize = true;
            this.lblChangeName1.Location = new System.Drawing.Point(385, 22);
            this.lblChangeName1.Name = "lblChangeName1";
            this.lblChangeName1.Size = new System.Drawing.Size(64, 13);
            this.lblChangeName1.TabIndex = 5;
            this.lblChangeName1.Text = "Name drink:";
            // 
            // lblChangeName2
            // 
            this.lblChangeName2.AutoSize = true;
            this.lblChangeName2.Location = new System.Drawing.Point(385, 58);
            this.lblChangeName2.Name = "lblChangeName2";
            this.lblChangeName2.Size = new System.Drawing.Size(87, 13);
            this.lblChangeName2.TabIndex = 6;
            this.lblChangeName2.Text = "Enter new name:";
            // 
            // txtChangeNameOld
            // 
            this.txtChangeNameOld.Location = new System.Drawing.Point(478, 19);
            this.txtChangeNameOld.Name = "txtChangeNameOld";
            this.txtChangeNameOld.Size = new System.Drawing.Size(100, 20);
            this.txtChangeNameOld.TabIndex = 7;
            // 
            // txtChangeNameNew
            // 
            this.txtChangeNameNew.Location = new System.Drawing.Point(478, 54);
            this.txtChangeNameNew.Name = "txtChangeNameNew";
            this.txtChangeNameNew.Size = new System.Drawing.Size(100, 20);
            this.txtChangeNameNew.TabIndex = 8;
            // 
            // btnChangeName
            // 
            this.btnChangeName.Location = new System.Drawing.Point(388, 96);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(190, 23);
            this.btnChangeName.TabIndex = 9;
            this.btnChangeName.Text = "Change name";
            this.btnChangeName.UseVisualStyleBackColor = true;
            this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
            // 
            // Drinks_Modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChangeName);
            this.Controls.Add(this.txtChangeNameNew);
            this.Controls.Add(this.txtChangeNameOld);
            this.Controls.Add(this.lblChangeName2);
            this.Controls.Add(this.lblChangeName1);
            this.Controls.Add(this.btnChangeStock);
            this.Controls.Add(this.txtChangeStockStock);
            this.Controls.Add(this.txtChangeStockDrink);
            this.Controls.Add(this.lblChangeStock2);
            this.Controls.Add(this.lblChangeStock1);
            this.Name = "Drinks_Modify";
            this.Text = "Drinks_Modify";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChangeStock1;
        private System.Windows.Forms.Label lblChangeStock2;
        private System.Windows.Forms.TextBox txtChangeStockDrink;
        private System.Windows.Forms.TextBox txtChangeStockStock;
        private System.Windows.Forms.Button btnChangeStock;
        private System.Windows.Forms.Label lblChangeName1;
        private System.Windows.Forms.Label lblChangeName2;
        private System.Windows.Forms.TextBox txtChangeNameOld;
        private System.Windows.Forms.TextBox txtChangeNameNew;
        private System.Windows.Forms.Button btnChangeName;
    }
}