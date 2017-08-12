using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WTCalc
{
	public partial class DateWin : Form
	{
		private RichTextMan RTMDateX2;
		private RichTextMan RTMDateX1;

		public DateWin()
		{
			InitializeComponent();

			this.RTMDateX2 = new RichTextMan(this.OutputDateX2);
			this.RTMDateX1 = new RichTextMan(this.OutputDateX1);

			DateTime now = DateTime.Now;

			this.BgnYText.Text = "" + now.Year;
			this.BgnMText.Text = "" + now.Month;
			this.BgnDText.Text = "" + now.Day;

			this.EndYText.Text = "" + now.Year;
			this.EndMText.Text = "" + now.Month;
			this.EndDText.Text = "" + now.Day;

			this.YText.Text = "" + now.Year;
			this.MText.Text = "" + now.Month;
			this.DText.Text = "" + now.Day;
		}

		private void DateWin_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void DateWin_Shown(object sender, EventArgs e)
		{
			this.RTMDateX2.Clear();
			this.RTMDateX1.Clear();

			this.BgnYText.Focus();

			this.MT_Enabled = true;
		}

		private void BtnCalcDateX2_Click(object sender, EventArgs e)
		{
			this.MT_Enabled = false;

			RichTextMan man = this.RTMDateX2;

			try
			{
				man.Clear();

				string bgnY = GetYMD(this.BgnYText, "開始_年");
				string bgnM = GetYMD(this.BgnMText, "開始_月");
				string bgnD = GetYMD(this.BgnDText, "開始_日");
				string endY = GetYMD(this.EndYText, "終了_年");
				string endM = GetYMD(this.EndMText, "終了_月");
				string endD = GetYMD(this.EndDText, "終了_日");

				BusyDlg.Section(this, delegate
				{
					Calc calc = new Calc();
					DateData bgn = new DateData(
						calc,
						calc.FromString(bgnY),
						calc.FromString(bgnM),
						calc.FromString(bgnD)
						);
					DateData end = new DateData(
						calc,
						calc.FromString(endY),
						calc.FromString(endM),
						calc.FromString(endD)
						);

					this.ChkConvYMD(bgn, bgnY, bgnM, bgnD, man, "開始日");
					this.ChkConvYMD(end, endY, endM, endD, man, "終了日");

#if false
					if (calc.LT(end.GetDay(), bgn.GetDay()))
					{
						DateData swap = bgn;
						bgn = end;
						end = swap;

						man.AddText("開始日より終了日が前なので、入れ替えて計算します。\n");
					}
#endif
					man.AddDate(bgn);
					man.AddBlank();
					man.AddText("と");
					man.AddBlank();

					man.AddDate(end);
					man.AddBlank();
					man.AddText("の...\n");

					if (calc.LT(end.GetDay(), bgn.GetDay()))
					{
						DateData swap = bgn;
						bgn = end;
						end = swap;
					}

					{
						CalcOperand[] diff = DateData.GetDiff(calc, bgn, end);

						man.AddText("差は");
						man.AddBlank();

						bool jointFlg = false;

						if (diff[0].IsZero() == false)
						{
							jointFlg = true;

							man.AddYMD(diff[0].ToString());
							man.AddBlank();
							man.AddYMDSuffix("年");
							man.AddBlank();
						}
						if (diff[1].IsZero() == false)
						{
							if (jointFlg)
							{
								man.AddText("と");
								man.AddBlank();
							}
							jointFlg = true;

							man.AddYMD(diff[1].ToString());
							man.AddBlank();
							man.AddYMDSuffix("ヶ月");
							man.AddBlank();
						}
						if (diff[2].IsZero() == false)
						{
							if (jointFlg)
							{
								man.AddText("と");
								man.AddBlank();
							}
							jointFlg = true;

							man.AddYMD(diff[2].ToString());
							man.AddBlank();
							man.AddYMDSuffix("週");
							man.AddBlank();
						}
						if (diff[3].IsZero() == false || jointFlg == false)
						{
							if (jointFlg)
							{
								man.AddText("と");
								man.AddBlank();
							}
							jointFlg = true;

							man.AddYMD(diff[3].ToString());
							man.AddBlank();
							man.AddYMDSuffix("日");
							man.AddBlank();
						}
						man.AddText("です。\n");
					}

					man.AddText("日数の差は");
					man.AddBlank();
					man.AddYMD(calc.Sub(end.GetDay(), bgn.GetDay()).ToString());
					man.AddBlank();
					man.AddYMDSuffix("日");
					man.AddBlank();
					man.AddText("です。\n");

					if (calc.LE(calc.FromInt(2), calc.Sub(end.GetDay(), bgn.GetDay())))
					{
						CalcOperand sum = calc.Add(bgn.GetDay(), end.GetDay());
						bool twoMid = calc.IsSame(calc.Mod(sum, calc.FromInt(2)), calc.FromInt(1));
						CalcOperand mid = calc.Div(sum, calc.FromInt(2), 0);

						if (twoMid)
						{
							man.AddText("中間の日は２つあります。\n");

							man.AddText("１つ目は");
							man.AddBlank();
							man.AddDate(new DateData(calc, mid));
							man.AddBlank();
							man.AddText("です。\n");

							mid = calc.Add(mid, calc.FromInt(1));

							man.AddText("２つ目は");
							man.AddBlank();
							man.AddDate(new DateData(calc, mid));
							man.AddBlank();
							man.AddText("です。\n");
						}
						else
						{
							man.AddText("中間の日は");
							man.AddBlank();
							man.AddDate(new DateData(calc, mid));
							man.AddBlank();
							man.AddText("です。\n");
						}
					}
					else
						man.AddText("中間の日はありません。\n");

					man.AddText("(グレゴリオ暦で計算しています)");
				});

				man.Commit();
			}
			catch (Exception ex)
			{
				SystemTools.WriteLog(ex);

				man.AllClear();

				MessageBox.Show(
					ex.Message,
					"計算に失敗しました",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
					);
			}
			finally
			{
				this.MT_Enabled = true;
				this.MT_TM = 2;
			}
		}

		private static string GetYMD(TextBox tb, string nameForUi)
		{
			tb.Text = StringTools.TrimNumber(tb.Text);

			string value = tb.Text;

			if (StringTools.IsNaturalNumber(value) == false)
			{
				throw new Exception(
					nameForUi + " に問題があります。\n" +
					"0123456789 以外の文字は使用できません。\n" +
					"１以上の整数を指定して下さい。"
					);
			}
			return value;
		}

		private void ChkConvYMD(DateData dd, string y, string m, string d, RichTextMan man, string nameForUi)
		{
			CalcOperand[] ymd = dd.GetDate();

			if (
				y != ymd[0].ToString() ||
				m != ymd[1].ToString() ||
				d != ymd[2].ToString()
				)
			{
				man.AddText(nameForUi);
				man.AddBlank();
				man.AddDate(y, m, d);
				man.AddBlank();
				man.AddText("は");
				man.AddBlank();
				man.AddDate(dd);
				man.AddBlank();
				man.AddText("と見なします。\n");
			}
		}

		private void BtnCalcDateX1_Click(object sender, EventArgs e)
		{
			this.MT_Enabled = false;

			RichTextMan man = this.RTMDateX1;

			try
			{
				man.Clear();

				string bgnY = GetYMD(this.YText, "日付_年");
				string bgnM = GetYMD(this.MText, "日付_月");
				string bgnD = GetYMD(this.DText, "日付_日");
				string addY = GetDay(this.AddYText, "加算_年");
				string addM = GetDay(this.AddMText, "加算_月");
				string addD = GetDay(this.AddDText, "加算_日");

				BusyDlg.Section(this, delegate
				{
					Calc calc = new Calc();
					DateData bgn = new DateData(
						calc,
						calc.FromString(bgnY),
						calc.FromString(bgnM),
						calc.FromString(bgnD)
						);

					this.ChkConvYMD(bgn, bgnY, bgnM, bgnD, man, "日付");

					man.AddDate(bgn);
					man.AddBlank();
					man.AddText("の");
					man.AddBlank();

					CalcOperand coAddY = calc.FromString(addY);
					CalcOperand coAddM = calc.FromString(addM);
					CalcOperand coAddD = calc.FromString(addD);

					bool jointFlg = false;

					if (coAddY.IsZero() == false)
					{
						jointFlg = true;

						man.AddYMD(coAddY.ToString());
						man.AddBlank();
						man.AddYMDSuffix("年");
						man.AddBlank();
					}
					if (coAddM.IsZero() == false)
					{
						jointFlg = true;

						man.AddYMD(coAddM.ToString());
						man.AddBlank();
						man.AddYMDSuffix("ヶ月");
						man.AddBlank();
					}
					if (coAddD.IsZero() == false || jointFlg == false)
					{
						jointFlg = true;

						man.AddYMD(coAddD.ToString());
						man.AddBlank();
						man.AddYMDSuffix("日");
						man.AddBlank();
					}

					if (this.RadioAdd.Checked)
					{
						man.AddText("後は...\n");

						DateData added = bgn.Add(coAddY, coAddM, coAddD);

						man.AddDate(added);
						man.AddBlank();
						man.AddText("です。\n");
					}
					else
					{
						man.AddText("前は...\n");

						DateData subed = bgn.Sub(coAddY, coAddM, coAddD);

						if (subed != null)
						{
							man.AddDate(subed);
							man.AddBlank();
							man.AddText("です。\n");
						}
						else
							man.AddText("西暦１年１月１日より前の日付です。\n");
					}

					man.AddText("(グレゴリオ暦で計算しています)");
				});

				man.Commit();
			}
			catch (Exception ex)
			{
				SystemTools.WriteLog(ex);

				man.AllClear();

				MessageBox.Show(
					ex.Message,
					"計算に失敗しました",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
					);
			}
			finally
			{
				this.MT_Enabled = true;
				this.MT_TM = 2;
			}
		}

		private static string GetDay(TextBox tb, string nameForUi)
		{
			tb.Text = StringTools.TrimNumber(tb.Text);

			string value = tb.Text;

			if (StringTools.IsNaturalNumberOrZero(value) == false)
			{
				throw new Exception(
					nameForUi + " に問題があります。\n" +
					"0123456789 以外の文字は使用できません。\n" +
					"ゼロ以上の整数を指定して下さい。"
					);
			}
			return value;
		}

		private void CommonKeyPress(object sender, KeyPressEventArgs e)
		{
			Control[] senderFocusArr = new Control[]
			{
				this.BgnYText,
				this.BgnMText,
				this.BgnDText,
				this.EndYText,
				this.EndMText,
				this.EndDText,
				this.BtnCalcDateX2,

				this.YText,
				this.MText,
				this.DText,
				this.AddYText,
				this.AddMText,
				this.AddDText,
				this.BtnCalcDateX1,
			};

			if (e.KeyChar == (char)Keys.Enter)
			{
				for (int index = 0; index < senderFocusArr.Length - 1; index++)
				{
					if (senderFocusArr[index] == sender)
					{
						senderFocusArr[index + 1].Focus();
						break;
					}
				}
				e.Handled = true;
			}
		}

		private void BgnYText_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.CommonKeyPress(sender, e);
		}

		private void BgnMText_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.CommonKeyPress(sender, e);
		}

		private void BgnDText_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.CommonKeyPress(sender, e);
		}

		private void EndYText_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.CommonKeyPress(sender, e);
		}

		private void EndMText_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.CommonKeyPress(sender, e);
		}

		private void EndDText_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.CommonKeyPress(sender, e);
		}

		private void YText_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.CommonKeyPress(sender, e);
		}

		private void MText_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.CommonKeyPress(sender, e);
		}

		private void DText_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.CommonKeyPress(sender, e);
		}

		private void AddYText_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.CommonKeyPress(sender, e);
		}

		private void AddMText_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.CommonKeyPress(sender, e);
		}

		private void AddDText_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.CommonKeyPress(sender, e);
		}

		private bool MT_Enabled;
		private bool MT_Busy;
		private long MT_Count;

		private int MT_TM;

		private void MainTimer_Tick(object sender, EventArgs e)
		{
			if (this.MT_Enabled == false || this.MT_Busy)
				return;

			this.MT_Busy = true;

			try
			{
				SystemTools.CommonTimer();

				if (0 < this.MT_TM)
				{
					this.TopMost = this.MT_TM % 2 == 0;
					this.MT_TM--;
				}
			}
			catch
			{
				// ignore
			}
			finally
			{
				this.MT_Busy = false;
				this.MT_Count++;
			}
		}

		private void DateWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.MT_Enabled = false;
		}
	}
}
