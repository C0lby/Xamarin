using System.Diagnostics;

namespace FormsIoC.Autofac
{
	public class ServicesProvider
	{
		ServicesProxy proxy;

		public ServicesProvider (ServicesProxy proxy)
		{
			this.proxy = proxy;
			Debug.WriteLine ("ServicesProvider Instantiated (proxy is {0} null)", proxy == null ? string.Empty : "not");
		}

		public void PrintLn (string str)
		{
			Debug.WriteLine (str);
		}
	}
}