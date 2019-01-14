using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace WTCalc
{
	public class Gnd
	{
		private Gnd()
		{ }

		public static Gnd I = new Gnd();

		public readonly string APP_UUID = "{54cd739b-f249-4a7b-9678-fabfc40ac8be}";
		public readonly string KEISAN_UUID = "{9ae71f57-ef61-463c-8bbd-72e07eb5e1ba}";
		public readonly string INVALID_ANSWER = "--";
		public readonly int OPERAND_LENMAX = 1000000;
		public readonly string INT_OPERAND_SUFFIX = " (10)";

		public MainWin MW;
		public TCalcBase[] TCalcs;

		public int Radix = 10;
		public int Basement = 30;

		public Operand LOperand = new Operand();
		public Enzanshi Enzanshi = new Enzanshi();
		public Operand ROperand = new Operand();
		public Operand Answer = new Operand();
		public Operand MemoryOperand = new Operand();

		public string ReservedEnzanshi; // null == 予約ナシ
		public bool MemoryStoreMode;

		public int MainWin_L;
		public int MainWin_T;
		public int MainWin_W; // 0 as not saved
		public int MainWin_H;

		public object UnitWin_Anything_01;
		public object UnitWin_Anything_02;

		public void Save()
		{
			try
			{
				List<string> lines = new List<string>();

				lines.Add("" + MainWin_L);
				lines.Add("" + MainWin_T);
				lines.Add("" + MainWin_W);
				lines.Add("" + MainWin_H);

				File.WriteAllLines(SaveDataFile, lines, Encoding.ASCII);
			}
			catch
			{
				FileTools.DeleteFile(SaveDataFile);
			}
		}

		public void Load()
		{
			try
			{
				string[] lines = File.ReadAllLines(SaveDataFile, Encoding.ASCII);
				int c = 0;

				MainWin_L = int.Parse(lines[c++]);
				MainWin_T = int.Parse(lines[c++]);
				MainWin_W = int.Parse(lines[c++]);
				MainWin_H = int.Parse(lines[c++]);
			}
			catch
			{
				MainWin_L = 0;
				MainWin_T = 0;
				MainWin_W = 0;
				MainWin_H = 0;
			}
		}

		private string _saveDataFile;

		private string SaveDataFile
		{
			get
			{
				if (_saveDataFile == null)
					_saveDataFile = Path.Combine(BootTools.SelfDir, "WTCalc.dat");

				return _saveDataFile;
			}
		}

		public bool Is初回起動()
		{
			return File.Exists(SaveDataFile) == false; // ? Save()未実行
		}

		public Unit.GroupList _unitGroupList;

		public Unit.GroupList UnitGroupList
		{
			get
			{
				if (_unitGroupList == null)
					_unitGroupList = Unit.GroupList.Load();

				return _unitGroupList;
			}
		}
	}
}
