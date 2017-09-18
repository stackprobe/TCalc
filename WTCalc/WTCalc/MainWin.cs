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
	public partial class MainWin : Form
	{
		public RichTextMan RTM;

		private static Color RTB_背景色_Default = Color.White;
		private static Color RTB_背景色_計算中 = Color.FromArgb(220, 220, 255);

		private List<HGridGuide> _hGridGuideList = new List<HGridGuide>();

		public MainWin()
		{
			InitializeComponent();

			Gnd.I.MW = this;
			Gnd.I.TCalcs = new TCalcBase[]
			{
				new Keisan2(), // K2
				new Keisan(),  // KP
				new TCalc(),   // CP
			};
			this.RTM = new RichTextMan(this.DisplayArea);
			this.RTM.Clear();

			{
				Control owner = this.DisplayArea;
				int between = 5;

				_hGridGuideList.Add(new HGridGuide(owner, between)
					.Add(this.FigA)
					.Add(this.BtnMC)
					.Add(this.BtnMR)
					.Add(this.BtnMS)
					.Add(this.BtnMPlus)
					.Add(this.BtnMMinus)
					);

				_hGridGuideList.Add(new HGridGuide(owner, between)
					.Add(this.FigB)
					.Add(this.BtnBS)
					.Add(this.BtnCE)
					.Add(this.BtnC)
					.Add(this.BtnSign)
					.Add(this.BtnRoot)
					);

				_hGridGuideList.Add(new HGridGuide(owner, between)
					.Add(this.FigC)
					.Add(this.Fig7)
					.Add(this.Fig8)
					.Add(this.Fig9)
					.Add(this.BtnDiv)
					.Add(this.BtnPower)
					);

				_hGridGuideList.Add(new HGridGuide(owner, between)
					.Add(this.FigD)
					.Add(this.Fig4)
					.Add(this.Fig5)
					.Add(this.Fig6)
					.Add(this.BtnMul)
					.Add(this.BtnInverse)
					);

				_hGridGuideList.Add(new HGridGuide(owner, between)
					.Add(this.FigE)
					.Add(this.Fig1)
					.Add(this.Fig2)
					.Add(this.Fig3)
					.Add(this.BtnSub)
					.Add(this.BtnEq)
					);

				_hGridGuideList.Add(new HGridGuide(owner, between)
					.Add(this.FigF)
					.Add(this.Fig0, 2)
					.Add(null)
					.Add(this.BtnPeriod)
					.Add(this.BtnAdd)
					.Add(null)
					);
			}

#if false // 起動テスト
			{
				{
					TCalc p = Gnd.I.CP;

					p.Start("1", "+", "1");
					while (p.IsRunning()) Thread.Sleep(100);
					if (p.GetAnswer() != "2") throw new Exception("CP_GetAnswer_NG");
				}

				{
					Keisan p = Gnd.I.KP;

					p.Start("1", "+", "1");
					while (p.IsRunning()) Thread.Sleep(100);
					if (p.GetAnswer() != "2") throw new Exception("CP_GetAnswer_NG");
				}
			}
#endif
		}

		private void MainWin_Load(object sender, EventArgs e)
		{
			this.MinimumSize = this.Size;
		}

		private void MainWin_Shown(object sender, EventArgs e)
		{
			if (Gnd.I.MainWin_W != 0) // saved
			{
				this.Left = Gnd.I.MainWin_L;
				this.Top = Gnd.I.MainWin_T;
				this.Width = Gnd.I.MainWin_W;
				this.Height = Gnd.I.MainWin_H;
			}

			this.MT_Enabled = true;
			this.RefreshUi();
		}

		private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal) // save
			{
				Gnd.I.MainWin_L = this.Left;
				Gnd.I.MainWin_T = this.Top;
				Gnd.I.MainWin_W = this.Width;
				Gnd.I.MainWin_H = this.Height;
			}
		}

		private void MainWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.MT_Enabled = false;
		}

		private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private Color DABC = RTB_背景色_Default;
		private int DABC_Count;
		private const int DABC_MAX = 5;

		private bool MT_Enabled;
		private bool MT_Busy;
		private long MT_Count;

		private const int TO_TOP_MAX = 4;
		private int ToTopCount;

		private void MainTimer_Tick(object sender, EventArgs e)
		{
			if (this.MT_Enabled == false || this.MT_Busy)
				return;

			this.MT_Busy = true;

			try
			{
				SystemTools.CommonTimer();

				if (this.MT_Count == 0)
					this.BtnEq.Focus();

				string answer = null;

				foreach (TCalcBase tc in Gnd.I.TCalcs)
				{
					answer = tc.GetAnswer();

					if (answer != null)
						break;
				}
				if (answer != null)
				{
					this.DABC = RTB_背景色_Default;

					if (answer == Gnd.I.INVALID_ANSWER)
					{
						this.クリア();
					}
					else if (Gnd.I.MemoryStoreMode)
					{
						Gnd.I.MemoryOperand.SetOperand(answer);
						Gnd.I.MemoryStoreMode = false;
					}
					else if (Gnd.I.ReservedEnzanshi == null)
					{
						Gnd.I.Answer.SetOperand(answer);
					}
					else
					{
						Gnd.I.LOperand.SetOperand(answer);
						Gnd.I.Enzanshi.SetValue(Gnd.I.ReservedEnzanshi);
						Gnd.I.ROperand.Clear();
						Gnd.I.Answer.Clear();

						Gnd.I.ReservedEnzanshi = null;
					}
					this.AutoNormalize();
					this.RefreshUi();
				}

				foreach (HGridGuide hgg in _hGridGuideList)
				{
					hgg.Refresh();
				}

				if (this.DABC == RTB_背景色_Default)
				{
					if (0 < this.DABC_Count)
					{
						this.DABC_Count--;

						if (this.DABC_Count == 0)
							this.DisplayArea.BackColor = RTB_背景色_Default;
					}
				}
				else if (this.DABC == this.DisplayArea.BackColor)
				{
					if (1 < this.DABC_Count)
						this.DABC_Count--;
				}
				else
				{
					if (this.DABC_Count < DABC_MAX)
					{
						this.DABC_Count++;

						if (this.DABC_Count == DABC_MAX)
							this.DisplayArea.BackColor = this.DABC;
					}
				}

				if (0 < this.ToTopCount)
				{
					this.ToTopCount--;
					this.TopMost = this.ToTopCount % 2 == 1; // 最後に false
				}
			}
			catch (Exception ex)
			{
				SystemTools.WriteLog(ex);
			}
			finally
			{
				this.MT_Count++;
				this.MT_Busy = false;
			}
		}

		private void CalcStart(string operand1, string enzanshi, string operand2)
		{
			if (enzanshi == "/" && StringTools.ContainsOnly(operand2, "-.0"))
				throw new Exception("ZERO_DIVIDE");

			this.DABC = RTB_背景色_計算中;

			foreach (TCalcBase tc in Gnd.I.TCalcs)
				if (tc.Start(operand1, enzanshi, operand2))
					break;
		}

		private string SouthMessage = null;

		private void RefreshUi()
		{
			this.RTM.RefreshUi();

			if (this.SouthMessage != null)
			{
				this.Status.Text = this.SouthMessage;
			}
			else
			{
				this.Status.Text = Gnd.I.Radix + "進, ";

				if (Gnd.I.Basement == 0)
					this.Status.Text += "整数";
				else
					this.Status.Text += "少数点以下" + Gnd.I.Basement + "桁まで";

				if (Gnd.I.MemoryOperand.IsEmpty() == false)
				{
					this.Status.Text += " [M]";
				}
				if (Gnd.I.TCalcs.Any(tc => tc.IsRunning()))
				{
					this.Status.Text += " [計算中]";
				}
				if (Gnd.I.ReservedEnzanshi != null)
				{
					this.Status.Text += " 予約(" + Gnd.I.ReservedEnzanshi + ")";
				}
			}
			this.RefreshUi基数Check();
			this.RefreshUi精度Check();

			{
				List<Button> figBtns = new List<Button>();

				figBtns.Add(this.Fig0);
				figBtns.Add(this.Fig1);
				figBtns.Add(this.Fig2);
				figBtns.Add(this.Fig3);
				figBtns.Add(this.Fig4);
				figBtns.Add(this.Fig5);
				figBtns.Add(this.Fig6);
				figBtns.Add(this.Fig7);
				figBtns.Add(this.Fig8);
				figBtns.Add(this.Fig9);
				figBtns.Add(this.FigA);
				figBtns.Add(this.FigB);
				figBtns.Add(this.FigC);
				figBtns.Add(this.FigD);
				figBtns.Add(this.FigE);
				figBtns.Add(this.FigF);

				int actRdx = this.GetActiveRadix();

				for (int n = 0; n < figBtns.Count; n++)
				{
					figBtns[n].Enabled = n < actRdx;
				}
			}
		}

		private void RefreshUi基数Check()
		{
			ToolStripMenuItem[] items = new ToolStripMenuItem[]
			{
				null,
				null,
				this.進02ToolStripMenuItem,
				this.進03ToolStripMenuItem,
				this.進04ToolStripMenuItem,
				this.進05ToolStripMenuItem,
				this.進06ToolStripMenuItem,
				this.進07ToolStripMenuItem,
				this.進08ToolStripMenuItem,
				this.進09ToolStripMenuItem,
				this.進10ToolStripMenuItem,
				this.進11ToolStripMenuItem,
				this.進12ToolStripMenuItem,
				this.進13ToolStripMenuItem,
				this.進14ToolStripMenuItem,
				this.進15ToolStripMenuItem,
				this.進16ToolStripMenuItem,
			};

			foreach (ToolStripMenuItem item in items)
			{
				if (item != null)
				{
					item.Checked = false;
				}
			}
			items[Gnd.I.Radix].Checked = true;
		}

		private void RefreshUi精度Check()
		{
			this.桁0ToolStripMenuItem.Checked = Gnd.I.Basement == 0;
			this.桁10ToolStripMenuItem.Checked = Gnd.I.Basement == 10;
			this.桁30ToolStripMenuItem.Checked = Gnd.I.Basement == 30;
			this.桁100ToolStripMenuItem.Checked = Gnd.I.Basement == 100;
			this.桁300ToolStripMenuItem.Checked = Gnd.I.Basement == 300;
			this.桁1000ToolStripMenuItem.Checked = Gnd.I.Basement == 1000;
		}

		private void クリア()
		{
			this.DABC = RTB_背景色_Default;

			Gnd.I.LOperand.Clear();
			Gnd.I.Enzanshi.Clear();
			Gnd.I.ROperand.Clear();
			Gnd.I.Answer.Clear();

			Gnd.I.ReservedEnzanshi = null;
		}

		private void 中止AToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (TCalcBase tc in Gnd.I.TCalcs)
				tc.ForceExit();

			this.クリア();
			this.RefreshUi();
		}

		// Button -->

		private bool CommonBeforeBtn() // ret: 中止
		{
			this.SouthMessage = null;

			if (this.MT_Busy) // 2bs
				return true;

			if (Gnd.I.TCalcs.Any(tc => tc.IsRunning()))
				return true;

			if (Gnd.I.TCalcs.Any(tc => tc.IsFinished(true)))
				return true;

			return false;
		}

		private void AutoNormalize()
		{
			if (Gnd.I.Answer.IsEmpty() == false)
			{
				Gnd.I.ROperand.Normalize();
			}
			else if (Gnd.I.Enzanshi.IsEmpty() == false)
			{
				Gnd.I.LOperand.Normalize();
			}
		}

		private void CommonAfterBtn()
		{
			this.AutoNormalize();
			this.RefreshUi();
		}

		private void ChangeRadix(int newRadix)
		{
			if (this.CommonBeforeBtn())
				return;

			string operand = null;

			if (Gnd.I.LOperand.IsEmpty() == false)
				operand = Gnd.I.LOperand.GetValue();

			if (Gnd.I.Answer.IsEmpty() == false)
				operand = Gnd.I.Answer.GetValue();

			if (operand == null)
			{
				Gnd.I.LOperand.Clear();
				Gnd.I.Enzanshi.Clear();
				Gnd.I.ROperand.Clear();
			}
			else
			{
				Gnd.I.LOperand.SetOperand(operand);
				Gnd.I.Enzanshi.SetValue("Radix " + Gnd.I.Radix + " converts to");
				Gnd.I.ROperand.SetInt(newRadix);
				Gnd.I.Answer.Clear();

				this.CalcStart(Gnd.I.LOperand.GetOperandForCalc(), "X", "" + newRadix);
			}
			Gnd.I.Radix = newRadix;
			this.CommonAfterBtn();
		}

		private void 進02ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(2);
		}

		private void 進03ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(3);
		}

		private void 進04ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(4);
		}

		private void 進05ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(5);
		}

		private void 進06ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(6);
		}

		private void 進07ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(7);
		}

		private void 進08ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(8);
		}

		private void 進09ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(9);
		}

		private void 進10ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(10);
		}

		private void 進11ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(11);
		}

		private void 進12ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(12);
		}

		private void 進13ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(13);
		}

		private void 進14ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(14);
		}

		private void 進15ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(15);
		}

		private void 進16ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeRadix(16);
		}

		private void ChangeBasement(int newBasement)
		{
			if (this.CommonBeforeBtn())
				return;

			Gnd.I.Basement = newBasement;
			this.CommonAfterBtn();
		}

		private void 桁0ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeBasement(0);
		}

		private void 桁10ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeBasement(10);
		}

		private void 桁30ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeBasement(30);
		}

		private void 桁100ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeBasement(100);
		}

		private void 桁300ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeBasement(300);
		}

		private void 桁1000ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChangeBasement(1000);
		}

		private int GetActiveRadix()
		{
			if (this.GetTrueActiveOperandData().IsInt())
				return 10;

			return Gnd.I.Radix;
		}

		private Operand GetTrueActiveOperandData()
		{
			if (Gnd.I.Answer.IsEmpty() == false)
				return Gnd.I.LOperand;

			return this.GetActiveOperandData();
		}

		private Operand GetActiveOperandData()
		{
			if (Gnd.I.Enzanshi.IsEmpty())
				return Gnd.I.LOperand;
			else
				return Gnd.I.ROperand;
		}

		private void InputFigure(int value)
		{
			if (this.CommonBeforeBtn())
				return;

			if (Gnd.I.Answer.IsEmpty() == false)
				this.クリア();

			int actRdx = this.GetActiveRadix();

			if (IntTools.IsRange(value, 0, actRdx - 1))
				this.GetActiveOperandData().InputFigure(value);

			this.CommonAfterBtn();
		}

		private void Fig0_Click(object sender, EventArgs e)
		{
			this.InputFigure(0);
		}

		private void Fig1_Click(object sender, EventArgs e)
		{
			this.InputFigure(1);
		}

		private void Fig2_Click(object sender, EventArgs e)
		{
			this.InputFigure(2);
		}

		private void Fig3_Click(object sender, EventArgs e)
		{
			this.InputFigure(3);
		}

		private void Fig4_Click(object sender, EventArgs e)
		{
			this.InputFigure(4);
		}

		private void Fig5_Click(object sender, EventArgs e)
		{
			this.InputFigure(5);
		}

		private void Fig6_Click(object sender, EventArgs e)
		{
			this.InputFigure(6);
		}

		private void Fig7_Click(object sender, EventArgs e)
		{
			this.InputFigure(7);
		}

		private void Fig8_Click(object sender, EventArgs e)
		{
			this.InputFigure(8);
		}

		private void Fig9_Click(object sender, EventArgs e)
		{
			this.InputFigure(9);
		}

		private void FigA_Click(object sender, EventArgs e)
		{
			this.InputFigure(10);
		}

		private void FigB_Click(object sender, EventArgs e)
		{
			this.InputFigure(11);
		}

		private void FigC_Click(object sender, EventArgs e)
		{
			this.InputFigure(12);
		}

		private void FigD_Click(object sender, EventArgs e)
		{
			this.InputFigure(13);
		}

		private void FigE_Click(object sender, EventArgs e)
		{
			this.InputFigure(14);
		}

		private void FigF_Click(object sender, EventArgs e)
		{
			this.InputFigure(15);
		}

		private void AutoReset()
		{
			if (Gnd.I.Answer.IsEmpty())
				return;

			Gnd.I.LOperand.Clear();
			Gnd.I.Enzanshi.Clear();
			Gnd.I.ROperand.Clear();
			Gnd.I.Answer.Clear();
		}

		private void BtnSign_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			this.AutoReset();

			if (Gnd.I.Answer.IsEmpty())
				this.GetActiveOperandData().ChangeSign();

			this.CommonAfterBtn();
		}

		private void BtnPeriod_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			this.AutoReset();

			if (Gnd.I.Answer.IsEmpty())
				this.GetActiveOperandData().InputDecimalPoint();

			this.CommonAfterBtn();
		}

		private void BtnBS_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			if (Gnd.I.Answer.IsEmpty())
				this.GetActiveOperandData().BackSpace();

			this.CommonAfterBtn();
		}

		private void InputEnzanshi(string enzanshi)
		{
			if (this.CommonBeforeBtn())
				return;

			try
			{
				if (Gnd.I.LOperand.IsEmpty())
				{
					// noop
				}
				else if (Gnd.I.ROperand.IsEmpty())
				{
					Gnd.I.Enzanshi.SetValue(enzanshi);
				}
				else if (Gnd.I.Answer.IsEmpty())
				{
					this.CalcStart(
						Gnd.I.LOperand.GetOperandForCalc(),
						Gnd.I.Enzanshi.GetValue(),
						Gnd.I.ROperand.GetOperandForCalc()
						);
					Gnd.I.ReservedEnzanshi = enzanshi;
				}
				else
				{
					Gnd.I.LOperand.SetOperand(Gnd.I.Answer.GetValue());
					Gnd.I.Enzanshi.SetValue(enzanshi);
					Gnd.I.ROperand.Clear();
					Gnd.I.Answer.Clear();
				}
			}
			catch (Exception e)
			{
				this.SouthMessage = e.Message;
			}
			this.CommonAfterBtn();
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			this.InputEnzanshi("+");
		}

		private void BtnSub_Click(object sender, EventArgs e)
		{
			this.InputEnzanshi("-");
		}

		private void BtnMul_Click(object sender, EventArgs e)
		{
			this.InputEnzanshi("*");
		}

		private void BtnDiv_Click(object sender, EventArgs e)
		{
			this.InputEnzanshi("/");
		}

		private void BtnEq_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			try
			{
				if (Gnd.I.Answer.IsEmpty() == false)
					Gnd.I.LOperand.SetOperand(Gnd.I.Answer.GetValue()); // [=]連打対応

				if (Gnd.I.LOperand.IsEmpty())
					Gnd.I.LOperand.SetOperand("0");

				if (Gnd.I.Enzanshi.IsEmpty())
				{
					Gnd.I.Enzanshi.SetValue("+");
					Gnd.I.ROperand.SetOperand("0");
				}
				else
				{
					if (Gnd.I.ROperand.IsEmpty())
						Gnd.I.ROperand.SetOperand(Gnd.I.LOperand.GetValue());
				}
				this.CalcStart(
					Gnd.I.LOperand.GetOperandForCalc(),
					Gnd.I.Enzanshi.GetValue(),
					Gnd.I.ROperand.GetOperandForCalc()
					);
			}
			catch (Exception ex)
			{
				this.SouthMessage = ex.Message;
				//this.DisplayArea.BackColor = Color.Red;
			}
			this.CommonAfterBtn();
		}

		private void BtnPower_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			if (Gnd.I.LOperand.IsEmpty() == false)
			{
				if (Gnd.I.Answer.IsEmpty() == false)
					Gnd.I.LOperand.SetOperand(Gnd.I.Answer.GetValue());

				Gnd.I.Enzanshi.SetValue("P");
				Gnd.I.ROperand.SetIntRange(0, int.MaxValue);
				Gnd.I.ROperand.SetInt(0);
				Gnd.I.Answer.Clear();
			}
			else
				this.SouthMessage = "NO_LEFT_OPERAND";

			this.CommonAfterBtn();
		}

		private void BtnRoot_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			if (Gnd.I.LOperand.IsEmpty() == false)
			{
				if (Gnd.I.Answer.IsEmpty() == false)
					Gnd.I.LOperand.SetOperand(Gnd.I.Answer.GetValue());

				if (Gnd.I.LOperand.IsNegative())
					Gnd.I.LOperand.ChangeSign();

				Gnd.I.Enzanshi.SetValue("R");
				Gnd.I.ROperand.SetIntRange(); // reset
				Gnd.I.ROperand.SetInt(2);
				Gnd.I.Answer.Clear();

				this.CalcStart(
					Gnd.I.LOperand.GetOperandForCalc(),
					Gnd.I.Enzanshi.GetValue(),
					Gnd.I.ROperand.GetOperandForCalc()
					);
			}
			else
				this.SouthMessage = "NO_LEFT_OPERAND";

			this.CommonAfterBtn();
		}

		private void BtnInverse_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			try
			{
				if (Gnd.I.LOperand.IsEmpty() == false)
				{
					Gnd.I.ROperand.SetOperand(
						Gnd.I.Answer.IsEmpty() ?
						Gnd.I.LOperand.GetValue() :
						Gnd.I.Answer.GetValue()
						);

					Gnd.I.Enzanshi.SetValue("/");
					Gnd.I.LOperand.SetOperand("1");
					Gnd.I.Answer.Clear();

					this.CalcStart(
						Gnd.I.LOperand.GetOperandForCalc(),
						Gnd.I.Enzanshi.GetValue(),
						Gnd.I.ROperand.GetOperandForCalc()
						);
				}
				else
					throw new Exception("NO_LEFT_OPERAND");
			}
			catch (Exception ex)
			{
				this.SouthMessage = ex.Message;
			}
			this.CommonAfterBtn();
		}

		private void BtnC_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			this.クリア();
			this.CommonAfterBtn();
		}

		private void BtnCE_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			if (Gnd.I.Answer.IsEmpty() == false)
			{
				Gnd.I.Answer.Clear();
			}
			else if (Gnd.I.ROperand.IsEmpty() == false)
			{
				Gnd.I.ROperand.Clear();

				if (Gnd.I.Enzanshi.GetValue() == "P")
					Gnd.I.Enzanshi.Clear();
			}
			else if (Gnd.I.Enzanshi.IsEmpty() == false)
			{
				Gnd.I.Enzanshi.Clear();
			}
			else
			{
				Gnd.I.LOperand.Clear();
			}
			this.CommonAfterBtn();
		}

		private void BtnMC_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			Gnd.I.MemoryOperand.Clear();
			this.CommonAfterBtn();
		}

		private void BtnMR_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			if (Gnd.I.Answer.IsEmpty())
			{
				Operand aod = this.GetActiveOperandData();

				if (aod.IsInt() == false)
					aod.SetOperand(Gnd.I.MemoryOperand.GetValue());
			}
			else
			{
				this.クリア();
				Gnd.I.LOperand.SetOperand(Gnd.I.MemoryOperand.GetValue());
			}
			this.CommonAfterBtn();
		}

		private void BtnMS_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			if (Gnd.I.Answer.IsEmpty() == false)
				Gnd.I.MemoryOperand.SetOperand(Gnd.I.Answer.GetValue());

			this.CommonAfterBtn();
		}

		private void MemoryPlusMinus(string mpmEnzanshi)
		{
			if (this.CommonBeforeBtn())
				return;

			if (Gnd.I.Answer.IsEmpty() == false)
			{
				if (Gnd.I.MemoryOperand.IsEmpty() == false)
				{
					Gnd.I.MemoryStoreMode = true;

					this.CalcStart(
						Gnd.I.MemoryOperand.GetOperandForCalc(),
						mpmEnzanshi,
						Gnd.I.Answer.GetOperandForCalc()
						);
				}
				else
					Gnd.I.MemoryOperand.SetOperand(Gnd.I.Answer.GetValue());
			}
			else
				this.SouthMessage = "NO_ANSWER";

			this.CommonAfterBtn();
		}

		private void BtnMPlus_Click(object sender, EventArgs e)
		{
			this.MemoryPlusMinus("+");
		}

		private void BtnMMinus_Click(object sender, EventArgs e)
		{
			this.MemoryPlusMinus("-");
		}

		private void AllButtons_KeyPress(object sender, KeyPressEventArgs e)
		{
			string key = "" + e.KeyChar;

			switch (key.ToUpper())
			{
				case "0": this.InputFigure(0); break;
				case "1": this.InputFigure(1); break;
				case "2": this.InputFigure(2); break;
				case "3": this.InputFigure(3); break;
				case "4": this.InputFigure(4); break;
				case "5": this.InputFigure(5); break;
				case "6": this.InputFigure(6); break;
				case "7": this.InputFigure(7); break;
				case "8": this.InputFigure(8); break;
				case "9": this.InputFigure(9); break;
				case "A": this.InputFigure(10); break;
				case "B": this.InputFigure(11); break;
				case "C": this.InputFigure(12); break;
				case "D": this.InputFigure(13); break;
				case "E": this.InputFigure(14); break;
				case "F": this.InputFigure(15); break;
				case ".": this.BtnPeriod_Click(null, null); break;
				case "+": this.InputEnzanshi("+"); break;
				case "-":
					{
						if (this.GetActiveOperandData().IsEmpty())
							this.BtnSign_Click(null, null);
						else
							this.InputEnzanshi("-");
					}
					break;
				case "*": this.InputEnzanshi("*"); break;
				case "/": this.InputEnzanshi("/"); break;
				case "N": this.BtnCE_Click(null, null); break;
				case "L": this.BtnC_Click(null, null); break;
				case "P": this.BtnPower_Click(null, null); break;
				case "R": this.BtnRoot_Click(null, null); break;
				case "I": this.BtnInverse_Click(null, null); break;
				case "\x08": this.BtnBS_Click(null, null); break;

				default:
					return;
			}
			e.Handled = true;
			this.BtnEq.Focus();
		}

		private void 日付の計算DToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			this.MT_Enabled = false;
			this.Visible = false;

			using (Form f = new DateWin())
			{
				f.ShowDialog();
			}
			this.Visible = true;
			this.MT_Enabled = true;

			this.ToTopCount = TO_TOP_MAX;

			this.CommonAfterBtn();
		}

		private void 単位の変換UToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.CommonBeforeBtn())
				return;

			this.MT_Enabled = false;
			this.Visible = false;

			UnitTh.I = new UnitTh();

			using (Form f = new UnitWin())
			{
				f.ShowDialog();
			}
			UnitTh.I.End();
			UnitTh.I = null;

			this.Visible = true;
			this.MT_Enabled = true;

			this.ToTopCount = TO_TOP_MAX;

			this.CommonAfterBtn();
		}
	}

	public class HGridGuide
	{
		private Control _owner;
		private int _between;
		private List<Control> _contentList = new List<Control>();
		private List<int> _spanList = new List<int>();

		public HGridGuide(Control owner, int between)
		{
			_owner = owner;
			_between = between;
		}

		public HGridGuide Add(Control content, int span = 1)
		{
			_contentList.Add(content);
			_spanList.Add(span);

			return this;
		}

		private int _lastL = -1;
		private int _lastW = -1;

		public void Refresh()
		{
			int ol = _owner.Left;
			int ow = _owner.Width;

			if (ol == _lastL && ow == _lastW)
				return;

			int w = (ow + _between) / _contentList.Count;

			for (int c = 0; c < _contentList.Count; c++)
			{
				Control content = _contentList[c];

				if (content == null)
					continue;

				content.Left = ol + w * c;
				content.Width = w * _spanList[c] - _between;
			}

			_lastL = ol;
			_lastW = ow;
		}
	}
}
