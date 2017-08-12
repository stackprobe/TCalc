using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WTCalc
{
	public class WordWrapOffTools
	{
		private const int EM_SETWORDBREAKPROC = 0x00D0;
		private delegate int EditWordBreakProc(IntPtr lpch, int ichCurrent, int cch, int code);

		[DllImport("user32.dll")]
		private static extern IntPtr SendMessageW(IntPtr hWndControl, int msgId, IntPtr wParam, EditWordBreakProc lParam);

		private static int EWBP_WordWrapOff(IntPtr lpch, int ichCurrent, int cch, int code)
		{
			return ichCurrent;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="tb"></param>
		/// <returns>gcに解放されないよう、少なくともtbが解放されるまで、どこか見えるところに置くこと。</returns>
		public static object WordWrapOff(TextBox tb)
		{
			EditWordBreakProc ewbp = new EditWordBreakProc(EWBP_WordWrapOff);
			SendMessageW(tb.Handle, EM_SETWORDBREAKPROC, IntPtr.Zero, ewbp);
			return ewbp;
		}
	}
}
