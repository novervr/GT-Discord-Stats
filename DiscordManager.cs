using System;
using System.IO;
using System.Linq;
using Steamworks;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace DiscordStats
{
	public class DiscordManager : MonoBehaviour
	{
		private void OnDestroy()
		{
			bool flag = GameObject.Find("managerDiscordStats") == null;
			if (flag)
			{
				new GameObject("managerDiscordStats").AddComponent<DiscordManager>();
			}
		}
		private void Update()
		{
			this.UpdateStatus();
		}
		private void UpdateStatus()
		{
			this.stats = string.Format("Current room code: {0}, People in code: {1}, Current Map: {2}");
			File.WriteAllLines("data.txt", new string[]
			{
				this.GetImageMapKey(),
				this.WherePlaying(),
				this.stats
			});
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021AC File Offset: 0x000003AC
		private int GetSteamStat(string key)
		{
			return SteamUserStats.GetStatInt(key);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021C4 File Offset: 0x000003C4
		private string GetImageMapKey()
		{
			bool flag = this.allMapsInDiscord.Contains(this.GetMapNameInLower());
			string result;
			if (flag)
			{
				result = this.GetMapNameInLower();
			}
			else
			{
				result = "notfound";
			}
			return result;
		}
		private string GetMapNameInLower()
		{
			bool flag = SceneManager.GetActiveScene().name == "Menu";
			string result;
			if (flag)
			{
				result = "menu";
			}
			else
			{
				try
				{
					bool flag2 = MapLoaderBehaviour.CurrentMap.name == "";
					if (flag2)
					{
						result = GameObject.Find("WORLD/MAP").transform.GetChild(0).gameObject.name.Replace("(Clone)", "").ToLower();
					}
					else
					{
						result = MapLoaderBehaviour.CurrentMap.name.ToLower();
					}
				}
				catch
				{
					result = "menu";
				}
			}
			return result;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000022B0 File Offset: 0x000004B0
		private string WherePlaying()
		{
			bool flag = SceneManager.GetActiveScene().name == "Menu";
			string result;
			if (flag)
			{
				result = "Located in Menu";
			}
			else
			{
				bool flag2 = MapLoaderBehaviour.CurrentMap.name == "";
				if (flag2)
				{
					result = "Playing on " + GameObject.Find("WORLD/MAP").transform.GetChild(0).gameObject.name.Replace("(Clone)", "").ToLower() + " map";
				}
				else
				{
					result = "Playing on " + MapLoaderBehaviour.CurrentMap.name + " map";
				}
			}
			return result;
		}

		// Token: 0x04000002 RID: 2
		private string[] allMapsInDiscord = new string[]
		{
			"forest",
			"caves",
			"canyons",
			"city",
			"mountains",
			"sky jungle"
		};

		// Token: 0x04000003 RID: 3
		private string stats;
	}
}
