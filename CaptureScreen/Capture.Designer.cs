namespace CaptureScreen
{
    partial class Capture
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCapture = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.gbTarget = new System.Windows.Forms.GroupBox();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.rbClipboard = new System.Windows.Forms.RadioButton();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.gbComment = new System.Windows.Forms.GroupBox();
            this.gbTarget.SuspendLayout();
            this.gbComment.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(205, 12);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 52);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // txtLog
            // 
            this.txtLog.Enabled = false;
            this.txtLog.Location = new System.Drawing.Point(0, 421);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(280, 150);
            this.txtLog.TabIndex = 2;
            // 
            // gbTarget
            // 
            this.gbTarget.Controls.Add(this.rbClipboard);
            this.gbTarget.Controls.Add(this.rbFile);
            this.gbTarget.Location = new System.Drawing.Point(0, 12);
            this.gbTarget.Name = "gbTarget";
            this.gbTarget.Size = new System.Drawing.Size(199, 52);
            this.gbTarget.TabIndex = 3;
            this.gbTarget.TabStop = false;
            this.gbTarget.Text = "Target";
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(7, 20);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(41, 17);
            this.rbFile.TabIndex = 0;
            this.rbFile.TabStop = true;
            this.rbFile.Text = "File";
            this.rbFile.UseVisualStyleBackColor = true;
            // 
            // rbClipboard
            // 
            this.rbClipboard.AutoSize = true;
            this.rbClipboard.Location = new System.Drawing.Point(73, 18);
            this.rbClipboard.Name = "rbClipboard";
            this.rbClipboard.Size = new System.Drawing.Size(69, 17);
            this.rbClipboard.TabIndex = 1;
            this.rbClipboard.TabStop = true;
            this.rbClipboard.Text = "Clipboard";
            this.rbClipboard.UseVisualStyleBackColor = true;
            // 
            // txtParam
            // 
            this.txtParam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParam.Location = new System.Drawing.Point(0, 71);
            this.txtParam.MaxLength = 16;
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(281, 20);
            this.txtParam.TabIndex = 4;
            this.txtParam.Text = "EXPLORE";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(1, 19);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(280, 150);
            this.txtComment.TabIndex = 5;
            // 
            // gbComment
            // 
            this.gbComment.Controls.Add(this.txtComment);
            this.gbComment.Location = new System.Drawing.Point(0, 115);
            this.gbComment.Name = "gbComment";
            this.gbComment.Size = new System.Drawing.Size(281, 181);
            this.gbComment.TabIndex = 6;
            this.gbComment.TabStop = false;
            this.gbComment.Text = "Comment";
            // 
            // Capture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 583);
            this.Controls.Add(this.txtParam);
            this.Controls.Add(this.gbTarget);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.gbComment);
            this.Name = "Capture";
            this.Text = "Capture";
            this.gbTarget.ResumeLayout(false);
            this.gbTarget.PerformLayout();
            this.gbComment.ResumeLayout(false);
            this.gbComment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox gbTarget;
        private System.Windows.Forms.RadioButton rbClipboard;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.GroupBox gbComment;
    }
}

