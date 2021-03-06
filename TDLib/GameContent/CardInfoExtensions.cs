using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using APIPlugin;
using BepInEx.Bootstrap;
using DiskCardGame;
using InscryptionAPI.Card;
using UnityEngine;

namespace TDLib.GameContent {
	/// <summary>
	/// Extensions for <see cref="CardInfo"/>.
	/// </summary>
	public static class CardInfoExtensions {

		/// <summary>
		/// Returns this card's high-res portrait. If none exists (and GBCFallback is true) it will use an upscaled version of the card's GBC portrait. Will return images of either 114x94 or 125x190.
		/// </summary>
		/// <param name="card">The card in question.</param>
		/// <param name="GBCFallback">If this is true, if a card has no high-res portrait it will return an upscaled version of the card's GBC portrait.</param>
		/// <param name="allWizardsAreGBC">Treat all Wizard cards as if they have no high-res portrait.</param>
		public static Texture2D GetPortrait(this CardInfo card, bool GBCFallback = true, bool allWizardsAreGBC = true) {
			if (card.portraitTex == null || (card.temple == CardTemple.Wizard && allWizardsAreGBC)) {
				//Card is native to Act 2 or is a wizard card, so we will use the GBC portrait
				return GBCFallback? GetUpscaledGBCPortrait(card) : null;
			} else return card.portraitTex.texture;
		}

		/// <summary>
		/// Returns a card's GBC portrait, upscaled to 114x94. If no such portrait exists it will return null.
		/// </summary>
		/// <param name="card">The card in question.</param>
		public static Texture2D GetUpscaledGBCPortrait(this CardInfo card) {
			//For some reason GBC portraits are unreadable, and since we do not have
			//access to the game assets to change that we will need to do some sketchy stuff to read the pixels
			//Credit to https://support.unity.com/hc/en-us/articles/206486626-How-can-I-get-pixels-from-unreadable-textures-

			MainPlugin.logger.LogDebug($"Card {card.name} has no high-res portrait");

			if (card.pixelPortrait == null) {
				MainPlugin.logger.LogDebug($"Card {card.name} has no GBC portrait");
				return null;
			}

			Texture2D texture = card.pixelPortrait.texture;

			// Create a temporary RenderTexture of the same size as the texture
			RenderTexture tmp = RenderTexture.GetTemporary(
								114,
								94,
								0,
								RenderTextureFormat.Default,
								RenderTextureReadWrite.Linear);


			// Blit the pixels on texture to the RenderTexture
			Graphics.Blit(texture, tmp);


			// Backup the currently set RenderTexture
			RenderTexture previous = RenderTexture.active;


			// Set the current RenderTexture to the temporary one we created
			RenderTexture.active = tmp;


			// Create a new readable Texture2D to copy the pixels to it
			Texture2D myTexture2D = new Texture2D(114, 94);


			// Copy the pixels from the RenderTexture to the new Texture
			myTexture2D.ReadPixels(new Rect(0, 0, tmp.width, tmp.height), 0, 0);
			myTexture2D.Apply();


			// Reset the active RenderTexture
			RenderTexture.active = previous;


			// Release the temporary RenderTexture
			RenderTexture.ReleaseTemporary(tmp);


			// "myTexture2D" now has the same pixels from "texture"
			return myTexture2D;
		}

		/// <summary>
		/// Does this card provide a gem usable for card playing?
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static bool IsGem(this CardInfo x) {
			return x.HasAbility(Ability.GainGemBlue) || x.HasAbility(Ability.GainGemGreen) || x.HasAbility(Ability.GainGemOrange);
		}

		/// <summary>
		/// Does this card have special behaviours when sacrificed?
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static bool IsSpecialSacc(this CardInfo x) {
			List<Ability> bloodSigils = new List<Ability>() { 
				Ability.TripleBlood,
				Ability.Sacrificial
			};
			if(Chainloader.PluginInfos.ContainsKey("extraVoid.inscryption.voidSigils")) {
				bloodSigils.AddRange(GetVoidBloodSigils());
			}
			if(Chainloader.PluginInfos.ContainsKey("org.memez4life.inscryption.customsigils")) {
				bloodSigils.AddRange(GetMemezBloodSigils());
			}
			bool outp = false;
			foreach(Ability ability in x.Abilities) {
				if(bloodSigils.Contains(ability)) {
					MainPlugin.logger.LogDebug($"{x.name} is special sacc");
					outp = true;
					break;
				}
			}
			return outp;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IEnumerable<Ability> GetVoidBloodSigils() {
			yield return voidSigils.void_Pathetic.ability;
			yield return voidSigils.void_BloodGrowth.ability;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IEnumerable<Ability> GetMemezBloodSigils() {
			yield return Custom_Sigils.Bi_Blood.ability;
			yield return Custom_Sigils.Quadra_Blood.ability;
		}

		/// <summary>
		/// Does this card have special behaviours for its bone count?
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static bool IsSpecialBone(this CardInfo x) {
			List<Ability> boneSigils = new List<Ability>() {
				Ability.QuadrupleBones
			};
			if(Chainloader.PluginInfos.ContainsKey("extraVoid.inscryption.voidSigils")) {
				boneSigils.AddRange(GetVoidBoneSigils());
			}
			if(Chainloader.PluginInfos.ContainsKey("org.memez4life.inscryption.customsigils")) {
				boneSigils.AddRange(GetMemezBoneSigils());
			}
			bool outp = false;
			foreach(Ability ability in x.Abilities) {
				if(boneSigils.Contains(ability)) {
					outp = true;
					MainPlugin.logger.LogDebug($"{x.name} is special bone");
					break;
				}
			}
			return outp;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IEnumerable<Ability> GetVoidBoneSigils() {
			yield return voidSigils.void_Boneless.ability;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IEnumerable<Ability> GetMemezBoneSigils() {
			yield return Custom_Sigils.TwoDeathBones.ability;
			yield return Custom_Sigils.ThreeDeathBones.ability;
			yield return Custom_Sigils.FiveDeathBones.ability;
			yield return Custom_Sigils.SixDeathBones.ability;
		}

		/// <summary>
		/// Returns a random nature card with the Gem trait.
		/// </summary>
		/// <param name="seed">The random seed to use.</param>
		/// <returns></returns>
		public static CardInfo GetRandomGem(int seed) {
			var cards = CardManager.AllCardsCopy;
			//cards.RemoveAll();
			cards.RemoveAll((card) => {
				return !(card.temple == CardTemple.Nature && card.traits.Contains(Trait.Gem));
			});
			if (cards.Count == 0) return CardLoader.GetCardByName("RingWorm");
			return cards[SeededRandom.Range(0, cards.Count, seed)];
		}

	}
}
