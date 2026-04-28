using Godot;
using BaseLib.Abstracts;
using BaseLib.Utils.NodeFactories;

using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Relics;

using nadaAquiMod.nadaAquiModCode.Extensions;
using nadaAquiMod.nadaAquiModCode.Combo;
using nadaAquiMod.nadaAquiModCode.Cards;

namespace nadaAquiMod.nadaAquiModCode.Character;

public class Jester : PlaceholderCharacterModel
{
    public const string CharacterId = "TheJester";
    
    public static readonly Color Color = new(0x6400C9FF); // #6400c9
    public override Color NameColor => Color;

    public override CharacterGender Gender => CharacterGender.Neutral;
    public override int StartingHp => 70;
	public override int StartingGold => 99;
    
    public override IEnumerable<CardModel> StartingDeck => [
        ModelDb.Card<StrikeJester>(),
        ModelDb.Card<StrikeJester>(),
        ModelDb.Card<StrikeJester>(),
        ModelDb.Card<StrikeJester>(),
        ModelDb.Card<DefendJester>(),
        ModelDb.Card<DefendJester>(),
        ModelDb.Card<DefendJester>(),
        ModelDb.Card<DefendJester>(),
        ModelDb.Card<AdaWong>(),
        ModelDb.Card<SableWard>()
    ];

    public override IReadOnlyList<RelicModel> StartingRelics =>
    [
        ModelDb.Relic<BurningBlood>()
    ];
    
    public override CardPoolModel CardPool => ModelDb.CardPool<JesterCardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<JesterRelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<JesterPotionPool>();

	public override Color MapDrawingColor => new Color(0x6400C9FF);
    
    /*  PlaceholderCharacterModel will utilize placeholder basegame assets for most of your character assets until you
        override all the other methods that define those assets. 
        These are just some of the simplest assets, given some placeholders to differentiate your character with. 
        You don't have to, but you're suggested to rename these images. */
    public override Control CustomIcon
    {
        get
        {
            var icon = NodeFactory<Control>.CreateFromResource(CustomIconTexturePath);
            icon.SetAnchorsAndOffsetsPreset(Control.LayoutPreset.FullRect);
            return icon;
        }
    }

    public override string CustomIconTexturePath => "character_icon_jester.png".CharacterUiPath();
    public override string CustomCharacterSelectIconPath => "char_select_jester.png".CharacterUiPath();
    public override string CustomCharacterSelectLockedIconPath => "char_select_jester_locked.png".CharacterUiPath();
    public override string CustomMapMarkerPath => "map_marker_jester.png".CharacterUiPath();
}