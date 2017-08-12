using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace WTCalc
{
	public partial class BusyDlg : Form
	{
		public delegate void Section_d();

		public static void Section(Form owner, Section_d d_section)
		{
			owner.Visible = false;

			using (Form f = new BusyDlg(d_section))
			{
				f.ShowDialog();
			}
			owner.Visible = true;

			if (LastException != null)
				throw LastException;
		}

		private Thread SectionTh;
		private static Exception LastException;

		public BusyDlg(Section_d d_section)
		{
			LastException = null;

			this.SectionTh = new Thread((ThreadStart)delegate
			{
				try
				{
					d_section();
				}
				catch (Exception e)
				{
					LastException = e;
				}
			});

			this.SectionTh.Start();

			InitializeComponent();
		}

		private void BusyDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void BusyDlg_Shown(object sender, EventArgs e)
		{
			this.MT_Enabled = true;
		}

		private bool ClosableFlag;

		private void BusyDlg_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = this.ClosableFlag == false;
		}

		private void DoClose()
		{
			this.MT_Enabled = false;
			this.ClosableFlag = true;
			this.Close();
		}

		private void BusyDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.MT_Enabled = false;
		}

		private bool MT_Enabled;
		private bool MT_Busy;
		private long MT_Count;

		private void MainTimer_Tick(object sender, EventArgs e)
		{
			if (this.MT_Enabled == false || this.MT_Busy)
				return;

			this.MT_Busy = true;

			try
			{
				if (this.MT_Count < 5)
					return;

				if (this.SectionTh.IsAlive == false)
				{
					this.DoClose();
					return;
				}
			}
			catch (Exception ex)
			{
				this.MT_Enabled = false;
				throw ex;
			}
			finally
			{
				this.MT_Count++;
				this.MT_Busy = false;
			}
		}
	}
}
