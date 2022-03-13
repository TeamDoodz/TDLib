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
### CardInfo IsSpecialSacc
Returns true if given card has Worthy Sacrifice or Many Lives sigils.
### CardInfo IsSpecialBone
Returns true if given card has the Bone King sigil.
### Ability SynergyWithGems
Returns true if this sigil would benefit the player more if there was a gem on the board (gem dependant, etc.)
### Ability SynergyWithConduit
Returns true if this sigil has an effect if within a circuit.
### BoardManager GemsOnBoard
Counts how many gem cards are on the board.
### BoardManager ConduitsOnBoard
Counts how many conduit cards are on the board.
### GetRandomGem
Returns a random gem card from the Nature temple.
### GetTypesWithAttribute
Returns all types in the specified assembly that have the specified attribute.
### AutoInit
Automatically calls the `Init()` static method on this type when the plugin starts.
### ConfigHelperBase
Classes to help simplify mods with lots of config options.
### AssetManager
General utility for getting files from disk. Supports PNG, TXT, CSV.
### EventsManager
Several events that mods can hook into, avoiding the need to create patches.
## Changelog
### 1.2.0
* Mod now requires Kaycee's Mod and the API 2.0.
* Added LoadPNGPath to AssetsManager
* Added CardInfo IsSpecialSacc
* Added CardInfo IsSpecialBone
* Added GetTypesWithAttribute
* Added AutoInit
* Added EventsManager
* Added ConfigHelperBase
* Mod now compiles with XML docs
### 1.1.0
 * Added Ability SynergyWithGems
 * Added Ability SynergyWithConduit
 * Added BoardManager GemsOnBoard
 * Added BoardManager ConduitsOnBoard
 * Added GetRandomGem
### 1.0.0
 * Initial Release