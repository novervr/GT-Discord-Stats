using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace DiscordStats
{
	public static class Discord
	{
		public static void Main()
		{
			Discord.process = Process.Start(Path.Combine(ModAPI.Metadata.MetaLocation, "App/DiscordConsole.exe"));
			bool flag = GameObject.Find("dsProcMan") == null;
			if (flag)
			{
				new GameObject("dsProcMan").AddComponent<DiscordProcessManager>();
			}
		}

		public static Process process;
	}
}
