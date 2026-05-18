# Nada Aqui Mod

A custom character mod for **Slay the Spire 2** that adds the **Jester** class. Built on [Alchyr's mod template](https://github.com/Alchyr/ModTemplate-StS2) and **BaseLib**.

Originally a collaborative idea between me and my friends to play together; solo-developed by me.

> Status: very early development.

## The Jester

A trickster class designed around three interlocking mechanics:

- **Hype** - a momentum counter built during combat that gates or amplifies certain cards. Decays 20% each round and resets at the end of combat.
- **Joke / Punchline (Combo)** - "joke" cards set up "punchline" payoffs, rewarding sequencing across turns and specific cards interactions.
- **Gambling** - percentage-based card and relic effects centered on risk/reward.

## Building

1. Copy `Directory.Build.props.example` to `Directory.Build.props`.
2. Fill in the required paths:
   - `GodotPath` - your Mono Godot 4.5.1 install.
   - `Sts2Path` - your Slay the Spire 2 install directory.
3. Build the solution (`nadaAquiMod.sln`).

## Dependencies

- [BaseLib](https://github.com/Alchyr/BaseLib-StS2/tree/v3.0.8) = v3.0.8 - required mod framework.
- Slay the Spire 2.
- Mono Godot 4.5.1.

## Layout

```
nadaAquiMod/         Godot assets (images, localization, mod_image)
nadaAquiModCode/     C# source
  Character/         Jester class, card/relic/potion pools
  Cards/             Card implementations
  Combo/             Joke/Punchline tracking, VFX, patches
  Hype/              Hype mechanic
  Gambling/          Gambling mechanic
  Relics/            Jester relics
```
