
namespace SomerenUI
{
    partial class Rooster_Modify
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
            this.lblSwapActivitiesHeader = new System.Windows.Forms.Label();
            this.lblActivity1 = new System.Windows.Forms.Label();
            this.lblActivity2 = new System.Windows.Forms.Label();
            this.cmbActivity1 = new System.Windows.Forms.ComboBox();
            this.cmbActivity2 = new System.Windows.Forms.ComboBox();
            this.btnSwapActivities = new System.Windows.Forms.Button();
            this.btnCloseSwap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSwapActivitiesHeader
            // 
            this.lblSwapActivitiesHeader.AutoSize = true;
            this.lblSwapActivitiesHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwapActivitiesHeader.Location = new System.Drawing.Point(28, 35);
            this.lblSwapActivitiesHeader.Name = "lblSwapActivitiesHeader";
            this.lblSwapActivitiesHeader.Size = new System.Drawing.Size(120, 18);
            this.lblSwapActivitiesHeader.TabIndex = 14;
            this.lblSwapActivitiesHeader.Text = "Swap activities";
            // 
            // lblActivity1
            // 
            this.lblActivity1.AutoSize = true;
            this.lblActivity1.Location = new System.Drawing.Point(31, 84);
            this.lblActivity1.Name = "lblActivity1";
            this.lblActivity1.Size = new System.Drawing.Size(50, 13);
            this.lblActivity1.TabIndex = 15;
            this.lblActivity1.Text = "Activity 1";
            // 
            // lblActivity2
            // 
            this.lblActivity2.AutoSize = true;
            this.lblActivity2.Location = new System.Drawing.Point(206, 84);
            this.lblActivity2.Name = "lblActivity2";
            this.lblActivity2.Size = new System.Drawing.Size(50, 13);
            this.lblActivity2.TabIndex = 16;
            this.lblActivity2.Text = "Activity 2";
            // 
            // cmbActivity1
            // 
            this.cmbActivity1.FormattingEnabled = true;
            this.cmbActivity1.Location = new System.Drawing.Point(34, 114);
            this.cmbActivity1.Name = "cmbActivity1";
            this.cmbActivity1.Size = new System.Drawing.Size(121, 21);
            this.cmbActivity1.TabIndex = 17;
            // 
            // cmbActivity2
            // 
            this.cmbActivity2.FormattingEnabled = true;
            this.cmbActivity2.Location = new System.Drawing.Point(209, 114);
            this.cmbActivity2.Name = "cmbActivity2";
            this.cmbActivity2.Size = new System.Drawing.Size(121, 21);
            this.cmbActivity2.TabIndex = 18;
            // 
            // btnSwapActivities
            // 
            this.btnSwapActivities.Location = new System.Drawing.Point(34, 177);
            this.btnSwapActivities.Name = "btnSwapActivities";
            this.btnSwapActivities.Size = new System.Drawing.Size(296, 39);
            this.btnSwapActivities.TabIndex = 19;
            this.btnSwapActivities.Text = "Swap activities";
            this.btnSwapActivities.UseVisualStyleBackColor = true;
            this.btnSwapActivities.Click += new System.EventHandler(this.btnSwapActivities_Click);
            // 
            // btnCloseSwap
            // 
            this.btnCloseSwap.Location = new System.Drawing.Point(238, 253);
            this.btnCloseSwap.Name = "btnCloseSwap";
            this.btnCloseSwap.Size = new System.Drawing.Size(92, 31);
            this.btnCloseSwap.TabIndex = 20;
            this.btnCloseSwap.Text = "Close";
            this.btnCloseSwap.UseVisualStyleBackColor = true;
            this.btnCloseSwap.Click += new System.EventHandler(this.btnCloseSwap_Click);
            // 
            // Rooster_Modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 319);
            this.Controls.Add(this.btnCloseSwap);
            this.Controls.Add(this.btnSwapActivities);
            this.Controls.Add(this.cmbActivity2);
            this.Controls.Add(this.cmbActivity1);
            this.Controls.Add(this.lblActivity2);
            this.Controls.Add(this.lblActivity1);
            this.Controls.Add(this.lblSwapActivitiesHeader);
            this.Name = "Rooster_Modify";
            this.Text = "Rooster_Modify";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSwapActivitiesHeader;
        private System.Windows.Forms.Label lblActivity1;
        private System.Windows.Forms.Label lblActivity2;
        private System.Windows.Forms.ComboBox cmbActivity1;
        private System.Windows.Forms.ComboBox cmbActivity2;
        private System.Windows.Forms.Button btnSwapActivities;
        private System.Windows.Forms.Button btnCloseSwap;
    }
}