using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WTCalc
{
	public class RichTextMan
	{
		private RichTextBox Rtb;

		public RichTextMan(RichTextBox rtb)
		{
			this.Rtb = rtb;
		}

		public void Clear()
		{
			string DUMMY_TEXT = "\n"; // これで "" になる。

			RichTextBox rtb = new RichTextBox();

			rtb.Text = DUMMY_TEXT;
			rtb.SelectionStart = 0;
			rtb.SelectionLength = DUMMY_TEXT.Length;
			rtb.SelectionProtected = true;

			this.Rtb.Rtf = rtb.SelectedRtf;
		}

		private class TokenInfo
		{
			public string Token;
			public Font Font;
			public Color Color;
		}

		private List<TokenInfo> Tokens = new List<TokenInfo>();

		public void AddToken(string token, Font font, Color color)
		{
			if (token == "")
				return;

			this.Tokens.Add(new TokenInfo()
			{
				Token = token,
				Font = font,
				Color = color,
			});
		}

		public void Commit()
		{
			RichTextBox rtb = new RichTextBox();

			rtb.Rtf = this.Rtb.Rtf;

			int startPos = rtb.Text.Length;

			rtb.SelectionStart = rtb.Text.Length;
			rtb.SelectionLength = 0;
			rtb.SelectionProtected = false;

			StringBuilder sb = new StringBuilder();

			foreach (TokenInfo token in this.Tokens)
			{
				sb.Append(token.Token);
			}
			rtb.SelectedText = "" + sb;

			foreach (TokenInfo token in this.Tokens)
			{
				rtb.SelectionStart = startPos;
				rtb.SelectionLength = token.Token.Length;
				rtb.SelectionFont = token.Font;
				rtb.SelectionColor = token.Color;

				startPos += token.Token.Length;
			}
			rtb.SelectionStart = 0;
			rtb.SelectionLength = rtb.Text.Length;
			rtb.SelectionProtected = true;

			using (new FreezeUi(this.Rtb))
			{
				this.Rtb.Rtf = rtb.SelectedRtf;
				this.Rtb.SelectionStart = this.Rtb.Text.Length;
				this.Rtb.SelectionLength = 0;

				try
				{
					this.Rtb.Focus();
					this.Rtb.ScrollToCaret();
				}
				catch (Exception e)
				{
					SystemTools.WriteLog(e);
				}
			}
			this.Tokens.Clear();
		}

		public void AllClear()
		{
			this.Clear();
			this.Tokens.Clear();
		}

		#region メイン画面用

		private static readonly string COMMON_FONTNAME = "Tahoma";

		public void AddOperand(string operand)
		{
			if (operand.EndsWith(Gnd.I.INT_OPERAND_SUFFIX))
			{
				this.AddOperandMain(operand.Substring(0, operand.Length - Gnd.I.INT_OPERAND_SUFFIX.Length));
				this.AddOperandSuffix(Gnd.I.INT_OPERAND_SUFFIX);
			}
			else
			{
				this.AddOperandMain(operand);
			}
		}

		public void AddOperandMain(string operand)
		{
			this.AddToken(operand, new Font(COMMON_FONTNAME, 12f, FontStyle.Regular), Color.Black);
		}

		public void AddOperandSuffix(string operand)
		{
			this.AddToken(operand, new Font(COMMON_FONTNAME, 8f, FontStyle.Regular), Color.Gray);
		}

		public void AddRadix(string radix)
		{
			this.AddToken(radix, new Font(COMMON_FONTNAME, 8f, FontStyle.Regular), Color.Black);
		}

		public void AddEnzanshi(string enzanshi)
		{
			this.AddToken(enzanshi, new Font(COMMON_FONTNAME, 10f, FontStyle.Regular), Color.DarkBlue);
		}

		public void AddAnswer(string answer)
		{
			this.AddToken(answer, new Font(COMMON_FONTNAME, 12f, FontStyle.Regular), Color.Blue);
		}

		public void RefreshUi()
		{
			this.Clear();

			if (Gnd.I.MemoryOperand.IsEmpty() == false)
			{
				//this.AddEnzanshi("[M]\n" + Gnd.I.MemoryOperand.GetOperandForUI() + "\n");
			}
			this.AddOperand(Gnd.I.LOperand.GetValueForUi());
			this.AddEnzanshi("\n" + Gnd.I.Enzanshi.GetValueForUi() + "\n");
			this.AddOperand(Gnd.I.ROperand.GetValueForUi());

			if (Gnd.I.Answer.IsEmpty() == false)
			{
				this.AddEnzanshi("\n=\n");
				this.AddAnswer(Gnd.I.Answer.GetValueForUi());
			}
			if (Gnd.I.CP.IsRunning() || Gnd.I.KP.IsRunning() || Gnd.I.K2.IsRunning())
			{
				this.AddEnzanshi("\nCalculating...");
			}
			this.Commit();
		}

		#endregion

		#region 日付の計算用

		private static readonly string TEXT_COMMON_FONTNAME = "メイリオ";

		public void AddYMD(string value)
		{
			this.AddToken(value, new Font(COMMON_FONTNAME, 12f, FontStyle.Regular), Color.DarkGreen);
		}

		public void AddYMDSuffix(string suffix)
		{
			this.AddToken(suffix, new Font(TEXT_COMMON_FONTNAME, 10f, FontStyle.Regular), Color.DarkCyan);
		}

		public void AddText(string text)
		{
			this.AddToken(text, new Font(TEXT_COMMON_FONTNAME, 10f, FontStyle.Regular), Color.Black);
		}

		public void AddComment(string comment)
		{
			this.AddToken(comment, new Font(COMMON_FONTNAME, 9f, FontStyle.Regular), Color.Gray);
		}

		public void AddBlank()
		{
			this.AddToken(" ", new Font(COMMON_FONTNAME, 8f, FontStyle.Regular), Color.Black);
		}

		public void AddDate(DateData dd)
		{
			CalcOperand[] ymd = dd.GetDate();

			this.AddDate(
				ymd[0].ToString(),
				ymd[1].ToString(),
				ymd[2].ToString(),
				dd.GetJWeekDay()
				);
		}

		public void AddDate(string y, string m, string d, string weekDay = null)
		{
			this.AddYMD(y);
			this.AddBlank();
			this.AddYMDSuffix("年");
			this.AddBlank();

			this.AddYMD(m);
			this.AddBlank();
			this.AddYMDSuffix("月");
			this.AddBlank();

			this.AddYMD(d);
			this.AddBlank();
			this.AddYMDSuffix("日");

			if (weekDay != null)
			{
				this.AddBlank();
				this.AddYMDSuffix("(" + weekDay + "曜日)");
			}
		}

		#endregion
	}
}
