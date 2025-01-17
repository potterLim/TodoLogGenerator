namespace TodoLogGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectDirectory = new System.Windows.Forms.Button();
            this.lblSelectedDirectory = new System.Windows.Forms.Label();
            this.btnGenerateLog = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectDirectory
            // 
            this.btnSelectDirectory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSelectDirectory.Location = new System.Drawing.Point(20, 20);
            this.btnSelectDirectory.Name = "btnSelectDirectory";
            this.btnSelectDirectory.Size = new System.Drawing.Size(120, 30);
            this.btnSelectDirectory.TabIndex = 0;
            this.btnSelectDirectory.Text = "Select Directory";
            this.btnSelectDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
            // 
            // lblSelectedDirectory
            // 
            this.lblSelectedDirectory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSelectedDirectory.Location = new System.Drawing.Point(20, 60);
            this.lblSelectedDirectory.Name = "lblSelectedDirectory";
            this.lblSelectedDirectory.Size = new System.Drawing.Size(500, 30);
            this.lblSelectedDirectory.TabIndex = 1;
            this.lblSelectedDirectory.Text = "Selected Directory: None";
            // 
            // btnGenerateLog
            // 
            this.btnGenerateLog.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGenerateLog.Location = new System.Drawing.Point(20, 100);
            this.btnGenerateLog.Name = "btnGenerateLog";
            this.btnGenerateLog.Size = new System.Drawing.Size(120, 30);
            this.btnGenerateLog.TabIndex = 2;
            this.btnGenerateLog.Text = "Generate Log";
            this.btnGenerateLog.UseVisualStyleBackColor = true;
            this.btnGenerateLog.Click += new System.EventHandler(this.btnGenerateLog_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStatus.Location = new System.Drawing.Point(20, 140);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(550, 200);
            this.txtStatus.TabIndex = 3;
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaveLog.Location = new System.Drawing.Point(450, 100);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(120, 30);
            this.btnSaveLog.TabIndex = 4;
            this.btnSaveLog.Text = "Save Log";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(150, 100);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 30);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSaveLog);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnGenerateLog);
            this.Controls.Add(this.lblSelectedDirectory);
            this.Controls.Add(this.btnSelectDirectory);
            this.Name = "MainForm";
            this.Text = "TODO Log Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectDirectory;
        private System.Windows.Forms.Label lblSelectedDirectory;
        private System.Windows.Forms.Button btnGenerateLog;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.Button btnStop;
    }
}

