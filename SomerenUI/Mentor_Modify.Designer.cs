
namespace SomerenUI
{
    partial class Mentor_Modify
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
            this.lblAddMentorHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddMentorGroup = new System.Windows.Forms.TextBox();
            this.txtAddMentorTeacher = new System.Windows.Forms.TextBox();
            this.btnModifyMentor = new System.Windows.Forms.Button();
            this.lblDeleteMentorHeader = new System.Windows.Forms.Label();
            this.lblDeleteGroupId = new System.Windows.Forms.Label();
            this.lblDeleteMentorId = new System.Windows.Forms.Label();
            this.btnDeleteMonitor = new System.Windows.Forms.Button();
            this.txtDeleteMentorGroup = new System.Windows.Forms.TextBox();
            this.txtDeleteMentorTeacher = new System.Windows.Forms.TextBox();
            this.btnCloseModifyMentor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddMentorHeader
            // 
            this.lblAddMentorHeader.AutoSize = true;
            this.lblAddMentorHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddMentorHeader.Location = new System.Drawing.Point(28, 28);
            this.lblAddMentorHeader.Name = "lblAddMentorHeader";
            this.lblAddMentorHeader.Size = new System.Drawing.Size(91, 16);
            this.lblAddMentorHeader.TabIndex = 0;
            this.lblAddMentorHeader.Text = "Add mentor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Teacher id:";
            // 
            // txtAddMentorGroup
            // 
            this.txtAddMentorGroup.Location = new System.Drawing.Point(138, 68);
            this.txtAddMentorGroup.Name = "txtAddMentorGroup";
            this.txtAddMentorGroup.Size = new System.Drawing.Size(186, 20);
            this.txtAddMentorGroup.TabIndex = 3;
            // 
            // txtAddMentorTeacher
            // 
            this.txtAddMentorTeacher.Location = new System.Drawing.Point(138, 104);
            this.txtAddMentorTeacher.Name = "txtAddMentorTeacher";
            this.txtAddMentorTeacher.Size = new System.Drawing.Size(186, 20);
            this.txtAddMentorTeacher.TabIndex = 4;
            // 
            // btnModifyMentor
            // 
            this.btnModifyMentor.Location = new System.Drawing.Point(34, 154);
            this.btnModifyMentor.Name = "btnModifyMentor";
            this.btnModifyMentor.Size = new System.Drawing.Size(290, 23);
            this.btnModifyMentor.TabIndex = 5;
            this.btnModifyMentor.Text = "Add mentor";
            this.btnModifyMentor.UseVisualStyleBackColor = true;
            this.btnModifyMentor.Click += new System.EventHandler(this.btnAddMentor_Click);
            // 
            // lblDeleteMentorHeader
            // 
            this.lblDeleteMentorHeader.AutoSize = true;
            this.lblDeleteMentorHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeleteMentorHeader.Location = new System.Drawing.Point(404, 28);
            this.lblDeleteMentorHeader.Name = "lblDeleteMentorHeader";
            this.lblDeleteMentorHeader.Size = new System.Drawing.Size(109, 16);
            this.lblDeleteMentorHeader.TabIndex = 6;
            this.lblDeleteMentorHeader.Text = "Delete mentor:";
            // 
            // lblDeleteGroupId
            // 
            this.lblDeleteGroupId.AutoSize = true;
            this.lblDeleteGroupId.Location = new System.Drawing.Point(404, 68);
            this.lblDeleteGroupId.Name = "lblDeleteGroupId";
            this.lblDeleteGroupId.Size = new System.Drawing.Size(50, 13);
            this.lblDeleteGroupId.TabIndex = 7;
            this.lblDeleteGroupId.Text = "Group id:";
            // 
            // lblDeleteMentorId
            // 
            this.lblDeleteMentorId.AutoSize = true;
            this.lblDeleteMentorId.Location = new System.Drawing.Point(404, 107);
            this.lblDeleteMentorId.Name = "lblDeleteMentorId";
            this.lblDeleteMentorId.Size = new System.Drawing.Size(61, 13);
            this.lblDeleteMentorId.TabIndex = 8;
            this.lblDeleteMentorId.Text = "Teacher id:";
            // 
            // btnDeleteMonitor
            // 
            this.btnDeleteMonitor.Location = new System.Drawing.Point(407, 154);
            this.btnDeleteMonitor.Name = "btnDeleteMonitor";
            this.btnDeleteMonitor.Size = new System.Drawing.Size(290, 23);
            this.btnDeleteMonitor.TabIndex = 9;
            this.btnDeleteMonitor.Text = "Delete mentor";
            this.btnDeleteMonitor.UseVisualStyleBackColor = true;
            this.btnDeleteMonitor.Click += new System.EventHandler(this.btnDeleteMonitor_Click);
            // 
            // txtDeleteMentorGroup
            // 
            this.txtDeleteMentorGroup.Location = new System.Drawing.Point(511, 68);
            this.txtDeleteMentorGroup.Name = "txtDeleteMentorGroup";
            this.txtDeleteMentorGroup.Size = new System.Drawing.Size(186, 20);
            this.txtDeleteMentorGroup.TabIndex = 10;
            // 
            // txtDeleteMentorTeacher
            // 
            this.txtDeleteMentorTeacher.Location = new System.Drawing.Point(511, 104);
            this.txtDeleteMentorTeacher.Name = "txtDeleteMentorTeacher";
            this.txtDeleteMentorTeacher.Size = new System.Drawing.Size(186, 20);
            this.txtDeleteMentorTeacher.TabIndex = 11;
            // 
            // btnCloseModifyMentor
            // 
            this.btnCloseModifyMentor.Location = new System.Drawing.Point(595, 212);
            this.btnCloseModifyMentor.Name = "btnCloseModifyMentor";
            this.btnCloseModifyMentor.Size = new System.Drawing.Size(102, 23);
            this.btnCloseModifyMentor.TabIndex = 12;
            this.btnCloseModifyMentor.Text = "Close";
            this.btnCloseModifyMentor.UseVisualStyleBackColor = true;
            this.btnCloseModifyMentor.Click += new System.EventHandler(this.btnCloseModifyMentor_Click);
            // 
            // Mentor_Modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 515);
            this.Controls.Add(this.btnCloseModifyMentor);
            this.Controls.Add(this.txtDeleteMentorTeacher);
            this.Controls.Add(this.txtDeleteMentorGroup);
            this.Controls.Add(this.btnDeleteMonitor);
            this.Controls.Add(this.lblDeleteMentorId);
            this.Controls.Add(this.lblDeleteGroupId);
            this.Controls.Add(this.lblDeleteMentorHeader);
            this.Controls.Add(this.btnModifyMentor);
            this.Controls.Add(this.txtAddMentorTeacher);
            this.Controls.Add(this.txtAddMentorGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddMentorHeader);
            this.Name = "Mentor_Modify";
            this.Text = "Mentor_Modify";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddMentorHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddMentorGroup;
        private System.Windows.Forms.TextBox txtAddMentorTeacher;
        private System.Windows.Forms.Button btnModifyMentor;
        private System.Windows.Forms.Label lblDeleteMentorHeader;
        private System.Windows.Forms.Label lblDeleteGroupId;
        private System.Windows.Forms.Label lblDeleteMentorId;
        private System.Windows.Forms.Button btnDeleteMonitor;
        private System.Windows.Forms.TextBox txtDeleteMentorGroup;
        private System.Windows.Forms.TextBox txtDeleteMentorTeacher;
        private System.Windows.Forms.Button btnCloseModifyMentor;
    }
}