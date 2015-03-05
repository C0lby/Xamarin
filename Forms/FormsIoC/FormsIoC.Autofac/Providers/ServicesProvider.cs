using System.Diagnostics;

namespace FormsIoC.Autofac
{
	public class ServicesProvider
	{
		ServicesProxy proxy;
		ISettings settings;

		public ServicesProvider (ServicesProxy proxy, ISettings settings)
		{
			this.proxy = proxy;
			this.settings = settings;

			Debug.WriteLine ("ServicesProvider Instantiated (proxy is {0} null)", proxy == null ? string.Empty : "not");
		}

		public void PrintLn (string str)
		{
			Debug.WriteLine (str);
		}

		public void TestSettings ()
		{
			settings.PrintLn ("Settings Works!");
		}
	}
}