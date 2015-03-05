using System;

namespace FormsIoC.Autofac.iOS
{
	public class Settings : ISettings
	{
		public Settings ()
		{
			Console.WriteLine ("Settings");
		}
	}
}