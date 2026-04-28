using Godot;

using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;

using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;

using nadaAquiMod.nadaAquiModCode.Character;
using nadaAquiMod.nadaAquiModCode.Extensions;
using nadaAquiMod.nadaAquiModCode.Combo;

namespace nadaAquiMod.nadaAquiModCode.Relics;

[Pool(typeof(JesterRelicPool))]
public abstract class CharModRelic : CustomRelicModel
{
    public override string PackedIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".RelicImagePath();
    protected override string PackedIconOutlinePath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}_outline.png".RelicImagePath();
    protected override string BigIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigRelicImagePath();

	public override RelicRarity Rarity => RelicRarity.Starter;

	public override Task AfterCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
    {


        return Task.CompletedTask;
    }
}