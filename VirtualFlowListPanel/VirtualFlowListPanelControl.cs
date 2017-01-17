using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VirtualFlowListPanel
{
	public partial class VirtualFlowListPanelControl : UserControl
	{
		private readonly List<Control> _items;

		public VirtualFlowListPanelControl()
		{
			InitializeComponent();

            ScrollBar.Minimum = 0;

            AutoScroll = false;
			VerticalScroll.Enabled = false;
			VerticalScroll.Visible = false;
			HorizontalScroll.Enabled = false;
			HorizontalScroll.Visible = false;
            _items = new List<Control>();

			Panel.FlowDirection = FlowDirection.TopDown;
			Panel.WrapContents = false;

			Panel.MouseWheel += PanelOnMouseWheel;
			ScrollBar.ValueChanged += ScrollBarOnValueChanged;
		}

		public void Add(Control control)
		{
            _items.Add(control);
			UpdateView();
		}

		public void AddRange(Control[] controls)
		{
            _items.AddRange(controls);
			UpdateView();
		}

	    public void Clear()
	    {
	        _items.Clear();
            UpdateView();
	    }

		public void UpdateView()
		{
			try
			{
				Panel.SuspendLayout();
				Panel.SuspendDrawing();
				Panel.Controls.Clear();

			    if (_items.Count > 0)
			    {
			        ScrollBar.Maximum = _items.Count - 1;

			        var elementCount = ScrollBar.Maximum - ScrollBar.Value < 10 ? ScrollBar.Maximum - ScrollBar.Value + 1 : 10;
			        Panel.Controls.AddRange(_items.GetRange(ScrollBar.Value, elementCount).ToArray());
			    }
			    else
			    {
			        ScrollBar.Maximum = 0;
			    }
			}
			finally
			{
				Panel.ResumeLayout();
				Panel.ResumeDrawing();
                Panel.Refresh();
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
