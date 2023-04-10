using System;
using UnityEngine;

namespace DiscordStats
{
	public class DiscordProcessManager : MonoBehaviour
	{
		public void OnDestroy()
		{
			bool flag = GameObject.Find("dsProcMan") == null;
			if (flag)
			{
				new GameObject("dsProcMan").AddComponent<DiscordProcessManager>();
			}
		}

		public void OnApplicationQuit()
		{
			Discord.process.Kill();
		}
	}
}
