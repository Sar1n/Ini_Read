using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ini_read;
using System.Diagnostics;

namespace IniTest
{

	[TestClass]
	public class DefaultTest
	{
		[TestMethod]
		public void ReadingFile()
		{
			var Reader = IniRead.Parse(@"C:\data\Projects\ini_read\ini\test.ini");

			bool testbool = Reader.GetBool("user","active");
			Debug.WriteLine("bool value " + testbool);
			Assert.IsTrue (testbool == true);

			testbool = Reader.GetBool("kek", "for");
			Debug.WriteLine("bool value " + testbool);
			Assert.IsTrue(testbool == true);

			string teststring = Reader.GetString("kek", "want");
			Debug.WriteLine("string value " + teststring);
			Assert.IsTrue(teststring == "connect");

			double testdouble = Reader.GetDouble("user", "pi");
			Debug.WriteLine("double value " + testdouble);
			Assert.IsTrue(testdouble == 3.14159);

			int testint = Reader.GetInt("kek", "hilarious");
			Debug.WriteLine("int value " + testint);
			Assert.IsTrue(testint == 3);
		}
	}
}
