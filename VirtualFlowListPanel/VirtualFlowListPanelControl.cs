using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VirtualFlowListPanel
{
	public partial class VirtualFlowListPanelControl : UserControl
	{
		private readonly List<Control> Items;

		public VirtualFlowListPanelControl()
		{
			InitializeComponent();

			AutoScroll = false;
			VerticalScroll.Enabled = false;
			VerticalScroll.Visible = false;
			HorizontalScroll.Enabled = false;
			HorizontalScroll.Visible = false;
			Items = new List<Control>();

			Panel.FlowDirection = FlowDirection.TopDown;
			Panel.WrapContents = false;

			Panel.MouseWheel += PanelOnMouseWheel;
			ScrollBar.ValueChanged += ScrollBarOnValueChanged;
		}

		public void Add(Control control)
		{
			Items.Add(control);
			UpdateView();
		}

		public void AddRange(Control[] controls)
		{
			Items.AddRange(controls);
			UpdateView();
		}

		public void UpdateView()
		{
			try
			{
				Panel.SuspendLayout();
				Panel.SuspendDrawing();
				Panel.Controls.Clear();

				ScrollBar.Maximum = Items.Count - 1;

				var elementCount = ScrollBar.Maximum - ScrollBar.Value < 10 ? ScrollBar.Maximum - ScrollBar.Value + 1 : 10;
				Panel.Controls.AddRange(Items.GetRange(ScrollBar.Value, elementCount).ToArray());
			}
			finally
			{
				Panel.ResumeLayout();
				Panel.ResumeDrawing();
			}
		}

		private void ScrollBarOnValueChanged(object sender, EventArgs eventArgs)
		{
			UpdateView();
		}

		private void PanelOnMouseWheel(object sender, MouseEventArgs mouseEventArgs)
		{
			if (mouseEventArgs.Delta < 0)
				ScrollBar.Value = ScrollBar.Value == ScrollBar.Maximum ? ScrollBar.Maximum : ++ScrollBar.Value;
			else
				ScrollBar.Value = ScrollBar.Value == ScrollBar.Minimum ? ScrollBar.Minimum : --ScrollBar.Value;
		}
	}
}
