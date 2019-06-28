using System;
using System.Diagnostics;

namespace CSMP.Agent.Linux
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			Process.Start(new ProcessStartInfo("dotnet", "--info") { RedirectStandardOutput = true });
		}
	}
}
