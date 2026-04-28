using BaseLib.Utils;
using BaseLib.Abstracts;
using BaseLib.Extensions;

using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models.CardPools;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

using nadaAquiMod.nadaAquiModCode.Combo;
using nadaAquiMod.nadaAquiModCode.Extensions;
using nadaAquiMod.nadaAquiModCode.Character;

namespace nadaAquiMod.nadaAquiModCode.Cards;

[Pool(typeof(JesterCardPool))]
public class AdaWong() : CustomCardModel(2, CardType.Skill, CardRarity.Rare, TargetType.AnyEnemy)
{
    public override string CustomPortraitPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigCardImagePath();
    public override string PortraitPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".CardImagePath();

    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<BufferPower>(1m), new PowerVar<ArtifactPower>(1m)];

	public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

	protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<BufferPower>(), HoverTipFactory.FromPower<ArtifactPower>()];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
		ArgumentNullException.ThrowIfNull(cardPlay.Target, "cardPlay.Target");
		ArgumentNullException.ThrowIfNull(cardPlay.Target.Monster, "cardPlay.Target.Monster");
               
        if (cardPlay.Target.Monster.IntendsToAttack)
        {
            await PowerCmd.Apply<BufferPower>(base.Owner.Creature, base.DynamicVars["BufferPower"].BaseValue, base.Owner.Creature, this);
        }
        else
        {
            await PowerCmd.Apply<ArtifactPower>(base.Owner.Creature, base.DynamicVars["ArtifactPower"].BaseValue, base.Owner.Creature, this);
        }

        if (ComboTracker.WasPlayed("NADAAQUIMOD-SABLE_WARD"))
        {
            await CreatureCmd.Stun(cardPlay.Target);
            
            await ComboVfx.OnComboTriggered("PORNOZÃO LÉSBICO!", ComboVfxType.Stun);
            await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);

            ComboTracker.ConsumeCombo("NADAAQUIMOD-SABLE_WARD");
        }
        else
        {
            await Message.ShowMessage("Imagina só um crossover...");
        }
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars["BufferPower"].UpgradeValueBy(1m);
        base.DynamicVars["ArtifactPower"].UpgradeValueBy(1m);
    }
}