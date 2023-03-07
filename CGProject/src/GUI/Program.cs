using System;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Клас с входната точка на програмата.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Входна точка. Създава и показва главната форма на програмата.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
