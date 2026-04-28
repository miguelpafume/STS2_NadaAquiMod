using BaseLib.Utils;
using BaseLib.Abstracts;
using BaseLib.Extensions;

using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

using nadaAquiMod.nadaAquiModCode.Combo;
using nadaAquiMod.nadaAquiModCode.Character;
using nadaAquiMod.nadaAquiModCode.Extensions;

namespace nadaAquiMod.nadaAquiModCode.Cards;

[Pool(typeof(JesterCardPool))]
public class DefendJester() : CustomCardModel(1, CardType.Skill, CardRarity.Basic, TargetType.Self)
{
    public override string CustomPortraitPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigCardImagePath();
    public override string PortraitPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".CardImagePath();

	public override bool GainsBlock => true;

	protected override HashSet<CardTag> CanonicalTags => new HashSet<CardTag> { CardTag.Defend };

    protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(5m, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
		await CreatureCmd.GainBlock(base.Owner.Creature, base.DynamicVars.Block, cardPlay);
    }

    protected override void OnUpgrade()
    {
		base.DynamicVars.Block.UpgradeValueBy(3m);
    }
}