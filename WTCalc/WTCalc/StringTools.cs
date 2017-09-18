using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WTCalc
{
	public class StringTools
	{
		public static readonly Encoding ENCODING_SJIS = Encoding.GetEncoding(932);

		public static string Reverse(string str)
		{
			StringBuilder buff = new StringBuilder();

			for (int index = str.Length - 1; 0 <= index; index--)
			{
				buff.Append(str[index]);
			}
			return buff.ToString();
		}

		public static string RPad(string str, int minlen, char chrPad)
		{
			while (str.Length < minlen)
			{
				str = chrPad + str;
			}
			return str;
		}

		public static bool HasSameChar(string str)
		{
			for (int j = 1; j < str.Length; j++)
				for (int i = 0; i < j; i++)
					if (str[i] == str[j])
						return true;

			return false;
		}

		public static string ThousandComma(string operand)
		{
			int insPos = operand.IndexOf('.');

			if (insPos == -1)
				insPos = operand.Length;

			int endPos = operand.StartsWith("-") ? 1 : 0;

			for (; ; )
			{
				insPos -= 3;

				if (insPos <= endPos)
					break;

				operand = operand.Insert(insPos, ",");
			}
			return operand;
		}

		public static bool IsCharOnly(string str, string chrSet)
		{
			foreach (char chr in str)
				if (chrSet.Contains(chr) == false)
					return false;

			return true;
		}

		public static bool HasChar(string str, string chrSet)
		{
			foreach (char chr in str)
				if (chrSet.Contains(chr))
					return true;

			return false;
		}

		public static bool IsNaturalNumberOrZero(string str)
		{
			return IsCharOnly(str, "0123456789");
		}

		public static bool IsNaturalNumber(string str)
		{
			return IsCharOnly(str, "0123456789") && HasChar(str, "123456789");
		}

		public static string ReplaceSet(string str, string oldChrSet, string newChrSet)
		{
			for (int index = 0; index < oldChrSet.Length; index++)
				str = str.Replace(oldChrSet[index], newChrSet[index % newChrSet.Length]);

			return str;
		}

		public static string TrimNumber(string str)
		{
			str = ReplaceSet(str, "　０１２３４５６７８９", " 0123456789");
			str = str.Trim();
			return str;
		}

		public static int stricmp(string str1, string str2)
		{
			if (str1 == null && str2 == null)
				return 0;

			if (str1 == null) // null < str2
				return -1;

			if (str2 == null) // str1 > null
				return 1;
			
			return string.Compare(str1.ToLower(), str2.ToLower());
		}

		public static bool ContainsOnly(string str, string valids)
		{
			foreach (char chr in str)
				if (valids.Contains(chr) == false)
					return false;

			return true;
		}

		public const string DIGIT = "0123456789";
	}
}
