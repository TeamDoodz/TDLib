# TDLib
TDLib is an assortment of methods used by most of my Inscryption mods. It contains helper methods for loading files from disk, plenty of card extension methods, and more.
If you are a modder and would like to use TDLib, go ahead as long as you abide by the terms of the license.
## What does this mod do?
On its own, nothing. However, other mods can hook into this one to gain more functionality without having to write reduntant code.
Here is a list of all features, in no particular order:
### String AsRegex
Turns a string array into a regular expression that can match any of the provided strings. <br/>
For example, an input of `{"hello","world","123"}` would give an output of `"(hello)|(world)|(123)"`.
### List GetRandom
Returns a random value from a list using the specified seed.
### List Swap
Swaps two different entries on a list.
### List Shuffle
Shuffles a list using the modernized Fisher-Yates shuffle algorithm.
### Dictionary SafeSet/SafeGet
Allows you to get/set values in a Dictionary without worrying about `IndexOutOfRangeException`s.
### CardInfo GetPortrait
Returns the portrait of a card. If the card is for GBC only, it will return an upscaled version of its GBC portrait.
### CardInfo GetUpscaledGBCPortrait
Returns the GBC portrait of a card, upscaled to 114x94.
### CardInfo IsGem
Returns true if given card has the Emerald, Ruby, or Sapphire mox sigils.
### Ability SynergyWithGems
Returns true if this sigil would benefit the player more if there was a gem on the board (gem dependant, etc.)
### Ability SynergyWithConduit
Returns true if this sigil has an effect if within a circuit.
### BoardManager GemsOnBoard
Counts how many gem cards are on the board.
### BoardManager ConduitsOnBoard
Counts how many conduit cards are on the board.
### AssetManager
General utility for getting files from disk. Supports PNG, TXT, CSV, and Asset Bundles.
## Changelog
### 1.1.0
 * Added Asset Bundles to the Asset Manager
### 1.0.0
 * Initial Release