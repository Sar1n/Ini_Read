using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ini_read
{
	internal class Section
	{
		public string Name { get; private set; }
		Dictionary<string, string> keyvalue = new Dictionary<string, string>();
		public Dictionary<string, string> KeyValue { get{ return keyvalue; } }

		public Section(string n)
		{
			Name = n;
		}
	}
}
