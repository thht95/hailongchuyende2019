namespace QuanlyDontu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chàoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLoạiĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýPhòngBanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýSinhViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chàoToolStripMenuItem,
            this.quảnLýToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1341, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chàoToolStripMenuItem
            // 
            this.chàoToolStripMenuItem.Name = "chàoToolStripMenuItem";
            this.chàoToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.chàoToolStripMenuItem.Text = "Kiểm tra đơn từ";
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýLoạiĐơnToolStripMenuItem,
            this.quảnLýĐơnToolStripMenuItem,
            this.quảnLýPhòngBanToolStripMenuItem,
            this.quảnLýNhânViênToolStripMenuItem,
            this.quảnLýSinhViênToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // quảnLýLoạiĐơnToolStripMenuItem
            // 
            this.quảnLýLoạiĐơnToolStripMenuItem.Name = "quảnLýLoạiĐơnToolStripMenuItem";
            this.quảnLýLoạiĐơnToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quảnLýLoạiĐơnToolStripMenuItem.Text = "Quản lý loại đơn";
            // 
            // quảnLýĐơnToolStripMenuItem
            // 
            this.quảnLýĐơnToolStripMenuItem.Name = "quảnLýĐơnToolStripMenuItem";
            this.quảnLýĐơnToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quảnLýĐơnToolStripMenuItem.Text = "Quản lý đơn";
            // 
            // quảnLýPhòngBanToolStripMenuItem
            // 
            this.quảnLýPhòngBanToolStripMenuItem.Name = "quảnLýPhòngBanToolStripMenuItem";
            this.quảnLýPhòngBanToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quảnLýPhòngBanToolStripMenuItem.Text = "Quản lý phòng ban";
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quảnLýNhânViênToolStripMenuItem.Text = "Quản lý nhân viên";
            // 
            // quảnLýSinhViênToolStripMenuItem
            // 
            this.quảnLýSinhViênToolStripMenuItem.Name = "quảnLýSinhViênToolStripMenuItem";
            this.quảnLýSinhViênToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quảnLýSinhViênToolStripMenuItem.Text = "Quản lý sinh viên";
            this.quảnLýSinhViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýSinhViênToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 585);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chàoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýLoạiĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýPhòngBanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýSinhViênToolStripMenuItem;
    }
}