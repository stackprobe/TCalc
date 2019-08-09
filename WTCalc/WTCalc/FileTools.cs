using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace WTCalc
{
	public static class FileTools
	{
		public static string[] TryReadAllLines(string file, Encoding encoding)
		{
			for (int c = 1; c <= 10; c++)
			{
				try
				{
					return File.ReadAllLines(file, encoding);
				}
				catch (Exception e)
				{
					SystemTools.WriteLog(e);
				}
				SystemTools.WriteLog("ファイルの読み込みに失敗しました。リトライします。: " + c + ", " + file);
				Thread.Sleep(100 * c);
			}
			SystemTools.WriteLog("ファイルの読み込みを諦めました。");
			return null;
		}

		public static void DeleteFile(string file)
		{
			for (int c = 1; c <= 10; c++)
			{
				try
				{
					if (File.Exists(file))
						File.Delete(file);

					return;
				}
				catch (Exception e)
				{
					SystemTools.WriteLog(e);
				}
				SystemTools.WriteLog("ファイル [" + file + "] の削除に失敗しました。リトライします。: " + c + ", " + file);
				Thread.Sleep(100 * c);
			}
			throw new Exception("ファイル [" + file + "] の削除を諦めました。");
		}
	}
}
