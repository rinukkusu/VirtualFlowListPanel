namespace VirtualFlowListPanel
{
	sealed partial class VirtualFlowListPanelControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Panel = new System.Windows.Forms.FlowLayoutPanel();
			this.ScrollBar = new System.Windows.Forms.VScrollBar();
			this.SuspendLayout();
			// 
			// Panel
			// 
			this.Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Panel.Location = new System.Drawing.Point(0, 0);
			this.Panel.Name = "Panel";
			this.Panel.Size = new System.Drawing.Size(130, 150);
			this.Panel.TabIndex = 0;
			// 
			// ScrollBar
			// 
			this.ScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
			this.ScrollBar.Location = new System.Drawing.Point(133, 0);
			this.ScrollBar.Name = "ScrollBar";
			this.ScrollBar.Size = new System.Drawing.Size(17, 150);
			this.ScrollBar.TabIndex = 0;
			// 
			// VirtualFlowListPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ScrollBar);
			this.Controls.Add(this.Panel);
			this.Name = "VirtualFlowListPanel";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel Panel;
		private System.Windows.Forms.VScrollBar ScrollBar;
	}
}
