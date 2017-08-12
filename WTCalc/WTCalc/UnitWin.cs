using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTCalc
{
	public partial class UnitWin : Form
	{
		private const int SEIDO_10_KETA = 0;
		private const int SEIDO_100_KETA = 1;
		private const int SEIDO_1000_KETA = 2;

		private const int SEIDO_DEFAULT = SEIDO_100_KETA;

		public UnitWin()
		{
			InitializeComponent();

			Gnd.I.UnitWin_Anything_01 = WordWrapOffTools.WordWrapOff(this.TBInput);
			Gnd.I.UnitWin_Anything_02 = WordWrapOffTools.WordWrapOff(this.TBOutput);
		}

		private void UnitWin_Load(object sender, EventArgs e)
		{
			this.MinimumSize = this.Size;
		}

		private void UnitWin_Shown(object sender, EventArgs e)
		{
			this.CBSeido.SelectedIndex = SEIDO_DEFAULT;
			this.TBInput.Text = "1";
			this.TBOutput.Text = "";

			{
				Unit.GroupList ugl = Gnd.I.UnitGroupList;

				this.CBUnit.Items.Clear();

				foreach (Unit.Group group in ugl.Groups)
				{
					this.CBUnit.Items.Add(group.Name);
				}
				this.CBUnit.SelectedIndex = 0;
				this.RefreshUi_Unit();
			}

			this.Initサイズ調整();

			this.Top -= 50;
			this.Height += 100;

			this.MT_Enabled = true;
		}

		private void RefreshUi_Unit()
		{
			try
			{
				Unit.Group group = Gnd.I.UnitGroupList.Groups[this.CBUnit.SelectedIndex];

				this.CBInput.Items.Clear();
				this.CBOutput.Items.Clear();

				foreach (Unit unit in group.Units)
				{
					this.CBInput.Items.Add(unit.Name);
					this.CBOutput.Items.Add(unit.Name);
				}
				//int maxddi = group.Units.Count;

				//this.CBInput.MaxDropDownItems = maxddi;
				//this.CBOutput.MaxDropDownItems = maxddi;

				int defIdx_1 = group.GetDefaultIndex(1);
				int defIdx_2 = group.GetDefaultIndex(2);

				this.CBInput.SelectedIndex = defIdx_1;
				this.CBOutput.SelectedIndex = defIdx_2;

				this.RefreshUi();
			}
			catch
			{ }
		}

		private int WrongInputCount;

		private void RefreshUi()
		{
			try
			{
				this.WrongInputCount = 0;

				string str = this.TBInput.Text;

				Unit.Group group = Gnd.I.UnitGroupList.Groups[this.CBUnit.SelectedIndex];
				Unit inputUnit = group.Units[this.CBInput.SelectedIndex];
				Unit outputUnit = group.Units[this.CBOutput.SelectedIndex];

				UnitTh.KeisanInfo ki = new UnitTh.KeisanInfo()
				{
					Input = str,
					Basement = this.GetBasement(),
					InputRateNumer = inputUnit.RateNumer,
					InputRateDenom = inputUnit.RateDenom,
					InputOrigin = inputUnit.Origin,
					OutputRateNumer = outputUnit.RateNumer,
					OutputRateDenom = outputUnit.RateDenom,
					OutputOrigin = outputUnit.Origin,
				};

				UnitTh.I.SetKeisanInfo(ki);

				//this.TBOutput.Text = ki.Input + " 計算中..."; // moved
				//this.TBOutput.ForeColor = Color.Gray; // 変わらん...
			}
			catch //(Exception e)
			{
				//SystemTools.WriteLog(e); // FIXME 通常でも出る。
			}
		}

		private int GetBasement()
		{
			switch (this.CBSeido.SelectedIndex)
			{
				case SEIDO_10_KETA: return 10;
				case SEIDO_100_KETA: return 100;
				case SEIDO_1000_KETA: return 1000;
			}
			throw new Exception("精度が取得できません。");
		}

		private void TBInput_KeyPress(object sender, KeyPressEventArgs e)
		{
			const int CTRL_A = 1;

			if (e.KeyChar == (char)CTRL_A)
			{
				this.TBInput.SelectAll();
				e.Handled = true;
			}
		}

		private void TBOutput_KeyPress(object sender, KeyPressEventArgs e)
		{
			const int CTRL_A = 1;

			if (e.KeyChar == (char)CTRL_A)
			{
				this.TBOutput.SelectAll();
				e.Handled = true;
			}
		}

		private void CBSeido_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.RefreshUi();
		}

		private void CBUnit_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.RefreshUi_Unit();
		}

		private void TBInput_TextChanged(object sender, EventArgs e)
		{
			this.RefreshUi();
		}

		private void CBInput_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.RefreshUi();
		}

		private void CBOutput_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.RefreshUi();
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
				SystemTools.CommonTimer();

				{
					string str = this.TBInput.Text;
					Calc calc = new Calc();
					CalcOperand co_tmp = calc.FromString(str);
					string tmp = co_tmp.ToString();

					if (this.TBInput.MaxLength < tmp.Length)
						tmp = tmp.Substring(0, this.TBInput.MaxLength); // 長すぎる。-> 後ろを切る。

					if (str != tmp)
					{
						this.WrongInputCount++;

						if (20 < this.WrongInputCount)
						{
							this.WrongInputCount = 0;

							this.TBInput.Text = tmp;
							this.TBInput.SelectionStart = tmp.Length;
						}
					}
				}

				string ret = UnitTh.I.GetOutput();

				if (ret != null)
				{
					this.TBOutput.Text = ret;
					//this.TBOutput.ForeColor = Color.Black; // 変わらん...
				}
			}
			catch (Exception ex)
			{
				//SystemTools.WriteLog(ex);
				this.TBOutput.Text = ex.Message;
			}
			finally
			{
				this.MT_Busy = false;
				this.MT_Count++;
			}
		}

		#region サイズ調整

		private int O_H; // 0 as not inited
		//private int O_TBInput_T;
		private int O_TBInput_H;
		private int O_CBInput_T;
		private int O_LOutput_T;
		private int O_TBOutput_T;
		private int O_TBOutput_H;
		private int O_CBOutput_T;

		private void Initサイズ調整()
		{
			this.O_H = this.Height;
			//this.O_TBInput_T = this.TBInput.Top;
			this.O_TBInput_H = this.TBInput.Height;
			this.O_CBInput_T = this.CBInput.Top;
			this.O_LOutput_T = this.LOutput.Top;
			this.O_TBOutput_T = this.TBOutput.Top;
			this.O_TBOutput_H = this.TBOutput.Height;
			this.O_CBOutput_T = this.CBOutput.Top;
		}

		private void Doサイズ調整()
		{
			if (this.O_H == 0) // ? not inited
				return;

			int d = this.Height - this.O_H;

			if (d < 0)
				return;

			d /= 2;
			this.TBInput.Height = this.O_TBInput_H + d;
			this.CBInput.Top = this.O_CBInput_T + d;
			this.LOutput.Top = this.O_LOutput_T + d;
			this.TBOutput.Top = this.O_TBOutput_T + d;
			this.TBOutput.Height = this.O_TBOutput_H + d;
			d *= 2;
			this.CBOutput.Top = this.O_CBOutput_T + d;
		}

		#endregion

		private void UnitWin_Resize(object sender, EventArgs e)
		{
			this.Doサイズ調整();
		}

		private void UnitWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.MT_Enabled = false;
		}
	}
}
