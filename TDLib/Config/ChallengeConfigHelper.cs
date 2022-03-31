using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BepInEx.Configuration;
using TDLib;

namespace TDLib.Config {
	public class ChallengeConfigHelper : ConfigHelperBase<ChallengeConfigHelper.ChallengeConfigData> {
		public string ChallengeName { get; }
		public ChallengeConfigData Default { get;  }

		public struct ChallengeConfigData {
			public string Title;
			public string Description;
			public int Points;
		}

		public ChallengeConfigHelper(ConfigFile file, ChallengeConfigData DefaultData) {
			this.Default = DefaultData;
			this.ChallengeName = Regex.Replace(DefaultData.Title, @"\s", "");
			this.file = file;
		}
		public ChallengeConfigHelper(ConfigFile file, ChallengeConfigData DefaultData, string Name) {
			this.Default = DefaultData;
			this.ChallengeName = Name;
			this.file = file;
		}

		protected Dictionary<string, Func<string>> customParse = new Dictionary<string, Func<string>>();
		public string ParseText(string description) {
			foreach(var parse in customParse) {
				description = description.Replace($"{{{parse.Key}}}", parse.Value.Invoke());
            }
			return description;
        }

		private ChallengeConfigData valueCache;
		private bool cacheFilled = false;
		public override ChallengeConfigData GetValue() {
			if (cacheFilled) return valueCache;
			else {
				valueCache = new ChallengeConfigData() {
					Title = file.Bind($"Challenges.{ChallengeName}", "Title", Default.Title, "The title of the challenge.").Value,
					Description = file.Bind($"Challenges.{ChallengeName}", "Description", Default.Description, "The description of the challenge.").Value,
					Points = file.Bind($"Challenges.{ChallengeName}", "Points", Default.Points, "How many Challenge Points this challenge is worth.").Value,
				};
				cacheFilled = true;
				return valueCache;
			}
		}
	}
}
