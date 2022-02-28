namespace PointerControl {
	partial class Form1 {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Panel panel1;
			System.Windows.Forms.NotifyIcon notifyIcon1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
			System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
			this.bUp = new System.Windows.Forms.Button();
			this.bDown = new System.Windows.Forms.Button();
			this.bLeft = new System.Windows.Forms.Button();
			this.bRight = new System.Windows.Forms.Button();
			this.cbEnabled = new System.Windows.Forms.CheckBox();
			this.bRefresh = new System.Windows.Forms.Button();
			this.bQuit = new System.Windows.Forms.Button();
			this.bMouse = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			panel1.SuspendLayout();
			contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(this.bMouse);
			panel1.Controls.Add(this.bUp);
			panel1.Controls.Add(this.bDown);
			panel1.Controls.Add(this.bLeft);
			panel1.Controls.Add(this.bRight);
			panel1.Location = new System.Drawing.Point(12, 37);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(309, 107);
			panel1.TabIndex = 5;
			// 
			// bUp
			// 
			this.bUp.Location = new System.Drawing.Point(77, 3);
			this.bUp.Name = "bUp";
			this.bUp.Size = new System.Drawing.Size(150, 23);
			this.bUp.TabIndex = 0;
			this.bUp.Text = "Ctrl+Alt+Shift+Up";
			this.bUp.UseVisualStyleBackColor = true;
			this.bUp.Click += new System.EventHandler(this.OnButtonClick);
			this.bUp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
			this.bUp.Leave += new System.EventHandler(this.OnLostFocus);
			// 
			// bDown
			// 
			this.bDown.Location = new System.Drawing.Point(77, 55);
			this.bDown.Name = "bDown";
			this.bDown.Size = new System.Drawing.Size(150, 23);
			this.bDown.TabIndex = 3;
			this.bDown.Text = "Ctrl+Alt+Shift+Down";
			this.bDown.UseVisualStyleBackColor = true;
			this.bDown.Click += new System.EventHandler(this.OnButtonClick);
			this.bDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
			// 
			// bLeft
			// 
			this.bLeft.Location = new System.Drawing.Point(3, 29);
			this.bLeft.Name = "bLeft";
			this.bLeft.Size = new System.Drawing.Size(150, 23);
			this.bLeft.TabIndex = 1;
			this.bLeft.Text = "Ctrl+Alt+Shift+Left";
			this.bLeft.UseVisualStyleBackColor = true;
			this.bLeft.Click += new System.EventHandler(this.OnButtonClick);
			this.bLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
			// 
			// bRight
			// 
			this.bRight.Location = new System.Drawing.Point(156, 29);
			this.bRight.Name = "bRight";
			this.bRight.Size = new System.Drawing.Size(150, 23);
			this.bRight.TabIndex = 2;
			this.bRight.Text = "Ctrl+Alt+Shift+Right";
			this.bRight.UseVisualStyleBackColor = true;
			this.bRight.Click += new System.EventHandler(this.OnButtonClick);
			this.bRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
			// 
			// notifyIcon1
			// 
			notifyIcon1.ContextMenuStrip = contextMenuStrip1;
			notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			notifyIcon1.Text = "Pointer Control";
			notifyIcon1.Visible = true;
			notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.IconDoubleClick);
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItem1});
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
			toolStripMenuItem1.Text = "Close";
			toolStripMenuItem1.Click += new System.EventHandler(this.MenuCloseClick);
			// 
			// cbEnabled
			// 
			this.cbEnabled.AutoSize = true;
			this.cbEnabled.Checked = true;
			this.cbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbEnabled.Location = new System.Drawing.Point(12, 12);
			this.cbEnabled.Name = "cbEnabled";
			this.cbEnabled.Size = new System.Drawing.Size(68, 19);
			this.cbEnabled.TabIndex = 0;
			this.cbEnabled.Text = "Enabled";
			this.cbEnabled.UseVisualStyleBackColor = true;
			this.cbEnabled.CheckedChanged += new System.EventHandler(this.OnEnabledChanged);
			// 
			// bRefresh
			// 
			this.bRefresh.Location = new System.Drawing.Point(165, 12);
			this.bRefresh.Name = "bRefresh";
			this.bRefresh.Size = new System.Drawing.Size(75, 23);
			this.bRefresh.TabIndex = 6;
			this.bRefresh.Text = "Refresh";
			this.bRefresh.UseVisualStyleBackColor = true;
			this.bRefresh.Click += new System.EventHandler(this.OnRefreshClick);
			// 
			// bQuit
			// 
			this.bQuit.Location = new System.Drawing.Point(246, 12);
			this.bQuit.Name = "bQuit";
			this.bQuit.Size = new System.Drawing.Size(75, 23);
			this.bQuit.TabIndex = 7;
			this.bQuit.Text = "Quit";
			this.bQuit.UseVisualStyleBackColor = true;
			this.bQuit.Click += new System.EventHandler(this.OnQuitClick);
			// 
			// bMouse
			// 
			this.bMouse.Location = new System.Drawing.Point(3, 81);
			this.bMouse.Name = "bMouse";
			this.bMouse.Size = new System.Drawing.Size(150, 23);
			this.bMouse.TabIndex = 4;
			this.bMouse.Text = "Ctrl+Alt+Shift+Enter";
			this.bMouse.UseVisualStyleBackColor = true;
			this.bMouse.Click += new System.EventHandler(this.OnButtonClick);
			this.bMouse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(333, 156);
			this.Controls.Add(this.bQuit);
			this.Controls.Add(this.bRefresh);
			this.Controls.Add(panel1);
			this.Controls.Add(this.cbEnabled);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Pointer Control";
			this.Leave += new System.EventHandler(this.OnLostFocus);
			panel1.ResumeLayout(false);
			contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CheckBox cbEnabled;
		private Button bUp;
		private Button bLeft;
		private Button bRight;
		private Button bDown;
		private Button bRefresh;
		private Button bQuit;
		private Button bMouse;
	}
}