using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;
using nadaAquiMod.nadaAquiModCode.Extensions;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.CardPools;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.MonsterMoves.Intents;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Entities.Creatures;

namespace nadaAquiMod.nadaAquiModCode.Cards;

[Pool(typeof(ColorlessCardPool))]
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
        
        // Add card to combo pile
        ComboTracker.RecordPlay(Id.Entry);

        bool intendsDebuff = cardPlay.Target.Monster.NextMove.Intents.Any(i => i.IntentType == IntentType.Debuff);
        
        if (intendsDebuff)
        {
            await PowerCmd.Apply<ArtifactPower>(base.Owner.Creature, base.DynamicVars["ArtifactPower"].BaseValue, base.Owner.Creature, this);
        }
        else if (cardPlay.Target.Monster.IntendsToAttack)
        {
            await PowerCmd.Apply<BufferPower>(base.Owner.Creature, base.DynamicVars["BufferPower"].BaseValue, base.Owner.Creature, this);
        }

        // Stuns all enemies in case the combo is activated
        if (ComboTracker.WasPlayed("NADAAQUIMOD-SABLE_WARD"))
        {
		    ArgumentNullException.ThrowIfNull(CombatState, "CombatState");
            foreach (Creature enemy in CombatState.Enemies)
            {
                await CreatureCmd.Stun(enemy);
            }

            ComboTracker.Remove(Id.Entry);
            ComboTracker.Remove("NADAAQUIMOD-SABLE_WARD");
        }
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars["BufferPower"].UpgradeValueBy(1m);
        base.DynamicVars["ArtifactPower"].UpgradeValueBy(1m);
        base.EnergyCost.UpgradeBy(-1);
    }

    public override Task AfterSideTurnStart(CombatSide side, CombatState combatState)
    {
        if (side == CombatSide.Player)
            ComboTracker.Clear();

        return Task.CompletedTask;
    }
}