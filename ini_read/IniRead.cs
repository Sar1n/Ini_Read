using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ini_read
{
	public class IniRead
	{
		static string pattern = @"\S*\.ini";
		List<Section> inisections = new List<Section>();

		public static IniRead Parse(string path)
		{
			var ini_reader = new IniRead();

			if (Regex.IsMatch(path, pattern, RegexOptions.IgnoreCase))
			{
				StreamReader reader = new StreamReader(path);
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					line = TrimComment(line);
					if (line.Length == 0) continue;
					if (line.StartsWith("[") && line.Contains("]"))
					{
						int index = line.IndexOf(']');
						string name = line.Substring(1, index - 1).Trim();
						var finded_section = ini_reader.inisections.Find( x => x.Name == name);

						if (finded_section == null)
							ini_reader.inisections.Add(new Section(name));
						else
							continue;
					}
					if (line.Contains("="))
					{
						int index = line.IndexOf('=');
						string key = line.Substring(0, index).Trim();
						string value = line.Substring(index + 1).Trim();
						ini_reader.inisections.Last().KeyValue.Add(key, value);
					}
				}
				reader.Close();
			}
			else throw new FormatException ();
			return ini_reader;
		}

		private static string TrimComment(string s)
		{
			if (s.Contains(";"))
			{
				int index = s.IndexOf(';');
				s = s.Substring(0, index).Trim();
			}
			return s;
		}

		public int GetInt(string section, string key)
		{
			return int.Parse(inisections.Find(x => x.Name == section).KeyValue[key]);
		}

		public bool GetBool(string section, string key)
		{
			if ((inisections.Find(x => x.Name == section).KeyValue[key] == "true") || (inisections.Find(x => x.Name == section).KeyValue[key] == "1"))
				return true;
			else
				return false;
		}

		public string GetString(string section, string key)
		{
			return inisections.Find(x => x.Name == section).KeyValue[key]; 
		}

		public double GetDouble(string section, string key)
		{
			return double.Parse(inisections.Find(x => x.Name == section).KeyValue[key]);
		}

		private IniRead() { }
	} 
}