namespace graphic_editor
{
    partial class MainForm
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
            this.btnDrawRect = new System.Windows.Forms.Button();
            this.btnDrawCircle = new System.Windows.Forms.Button();
            this.workspace = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tslabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDrawRect
            // 
            this.btnDrawRect.Location = new System.Drawing.Point(12, 12);
            this.btnDrawRect.Name = "btnDrawRect";
            this.btnDrawRect.Size = new System.Drawing.Size(97, 23);
            this.btnDrawRect.TabIndex = 0;
            this.btnDrawRect.Text = "Draw Rectangle";
            this.btnDrawRect.UseVisualStyleBackColor = true;
            this.btnDrawRect.Click += new System.EventHandler(this.btnDrawRect_Click);
            // 
            // btnDrawCircle
            // 
            this.btnDrawCircle.Location = new System.Drawing.Point(115, 12);
            this.btnDrawCircle.Name = "btnDrawCircle";
            this.btnDrawCircle.Size = new System.Drawing.Size(97, 23);
            this.btnDrawCircle.TabIndex = 1;
            this.btnDrawCircle.Text = "Draw Circle";
            this.btnDrawCircle.UseVisualStyleBackColor = true;
            this.btnDrawCircle.Click += new System.EventHandler(this.btnDrawCircle_Click);
            // 
            // workspace
            // 
            this.workspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workspace.BackColor = System.Drawing.Color.White;
            this.workspace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workspace.Location = new System.Drawing.Point(12, 41);
            this.workspace.Name = "workspace";
            this.workspace.Size = new System.Drawing.Size(541, 338);
            this.workspace.TabIndex = 2;
            this.workspace.Paint += new System.Windows.Forms.PaintEventHandler(this.workspace_Paint);
            this.workspace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.workspace_MouseDown);
            this.workspace.MouseMove += new System.Windows.Forms.MouseEventHandler(this.workspace_MouseMove);
            this.workspace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.workspace_MouseUp);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(478, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Quit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 382);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(565, 22);
            this.statusStrip.TabIndex = 4;
            // 
            // tslabel
            // 
            this.tslabel.Name = "tslabel";
            this.tslabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 404);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.workspace);
            this.Controls.Add(this.btnDrawCircle);
            this.Controls.Add(this.btnDrawRect);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDrawRect;
        private System.Windows.Forms.Button btnDrawCircle;
        private System.Windows.Forms.Panel workspace;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tslabel;
    }
}

