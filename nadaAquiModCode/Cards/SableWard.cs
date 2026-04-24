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

namespace nadaAquiMod.nadaAquiModCode.Cards;

[Pool(typeof(ColorlessCardPool))]
public class SableWard() : CustomCardModel(2, CardType.Skill, CardRarity.Rare, TargetType.AnyEnemy)
{
    public override string CustomPortraitPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigCardImagePath();
    public override string PortraitPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".CardImagePath();

    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<VulnerablePower>(1m), new PowerVar<WeakPower>(1m)];

	protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<WeakPower>(), HoverTipFactory.FromPower<VulnerablePower>()];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
		ArgumentNullException.ThrowIfNull(cardPlay.Target, "cardPlay.Target");
		ArgumentNullException.ThrowIfNull(cardPlay.Target.Monster, "cardPlay.Target.Monster");
        
        if (cardPlay.Target.Monster.IntendsToAttack)
        {
            await PowerCmd.Apply<WeakPower>(cardPlay.Target, base.DynamicVars["WeakPower"].BaseValue, base.Owner.Creature, this);
        }
        else
        {
            await PowerCmd.Apply<VulnerablePower>(cardPlay.Target, base.DynamicVars["VulnerablePower"].BaseValue, base.Owner.Creature, this);
        }

        if (ComboTracker.WasPlayed("NADAAQUIMOD-ADA_WONG"))
        {
            await CreatureCmd.Stun(cardPlay.Target);

            await ComboVfx.OnComboTriggered("PORNOZÃO LÉSBICO!", ComboVfxType.Stun);
            await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);

            ComboTracker.ConsumeCombo("NADAAQUIMOD-ADA_WONG");
        }
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars["WeakPower"].UpgradeValueBy(1m);
        base.DynamicVars["VulnerablePower"].UpgradeValueBy(1m);
    }
}