using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WTCalc
{
	public class Unit
	{
		public class GroupList
		{
			public List<Group> Groups = new List<Group>();

			public static GroupList Load()
			{
				string file = "WTCalcUnit.xml";

				if (File.Exists(file) == false)
					file = "../../../../doc/" + file;

				return new GroupList(XLoader.Load(file));
			}

			public GroupList(XNode root)
			{
				Calc calc = new Calc();

				foreach (XNode g in root.ReferChildren("group"))
				{
					Group group = new Group()
					{
						Name = g.RefChildText("name"),
					};

					foreach (XNode u in g.ReferChildren("unit"))
					{
						Unit unit = new Unit()
						{
							Name = u.RefChildText("name"),
							RateNumer = calc.DoCalc(calc.DoCalc(
								u.RefChildText("rate", "1"), '*',
								u.RefChildText("rate2", "1")), '*',
								u.RefChildText("ireci", "1")
								),
							RateDenom = calc.DoCalc(calc.DoCalc(
								u.RefChildText("reci", "1"), '*',
								u.RefChildText("reci2", "1")), '*',
								u.RefChildText("irate", "1")
								),
							Origin = u.RefChildText("origin", "0"),
							Default = int.Parse(u.RefChildText("default", "0")),
						};

						group.Units.Add(unit);
					}
					this.Groups.Add(group);
				}
			}
		}

		public class Group
		{
			public string Name;
			public List<Unit> Units = new List<Unit>();

			public int GetDefaultIndex(int value)
			{
				for (int index = 0; index < this.Units.Count; index++)
				{
					if (this.Units[index].Default == value)
					{
						return index;
					}
				}
				return 0; // not found
			}
		}

		public string Name;
		public string RateNumer;
		public string RateDenom;
		public string Origin;
		public int Default;
	}
}
