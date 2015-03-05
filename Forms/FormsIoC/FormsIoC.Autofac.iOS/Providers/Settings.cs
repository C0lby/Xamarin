using System;

namespace FormsIoC.Autofac.iOS
{
	public class Settings : ISettings
	{
		public Settings ()
		{
			Console.WriteLine ("Settings Instantiated");
		}

		public void PrintLn (string str)
		{
			Console.WriteLine (str);
		}
	}
}