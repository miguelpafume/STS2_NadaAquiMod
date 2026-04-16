// using BaseLib.Abstracts;
// using BaseLib.Extensions;
// using BaseLib.Utils;
// using nadaAquiMod.nadaAquiModCode.Extensions;
// using MegaCrit.Sts2.Core.Entities.Cards;
// using MegaCrit.Sts2.Core.GameActions.Multiplayer;
// using MegaCrit.Sts2.Core.Models.CardPools;
// using MegaCrit.Sts2.Core.Localization.DynamicVars;
// using MegaCrit.Sts2.Core.Commands;
// using MegaCrit.Sts2.Core.ValueProps;
// using MegaCrit.Sts2.Core.Combat;

// namespace nadaAquiMod.nadaAquiModCode.Cards;

// [Pool(typeof(POOL))]
// public class NAME() : CustomCardModel(VALUE, CardType.TYPE, CardRarity.RARITY, TargetType.TARGET)
// {
//     //Normal art: 1000x760 (Using 500x380 should also work, it will simply be scaled.)
//     //Full art: 606x852
//     public override string CustomPortraitPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigCardImagePath();
    
//     //Smaller variants of card images for efficiency:
//     //Smaller variant of normalart: 250x190
//     //Smaller variant of fullart: 250x350
//     public override string PortraitPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".CardImagePath();

//     protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(6m, ValueProp.Move)];

//     protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
//     {
//         // If card has combo
//         ComboTracker.RecordPlay(Id.Entry);

//         if (ComboTracker.WasPlayed("NADAAQUIMOD-CARD"))
//         {
            
//         }
//     }

//     protected override void OnUpgrade()
//     {
        
//     }

//     // Clear combo tracker on turb start
//     public override Task AfterSideTurnStart(CombatSide side, CombatState combatState)
//     {
//         if (side == CombatSide.Player)
//             ComboTracker.Clear();

//         return Task.CompletedTask;
//     }
// }