using Godot;
using BaseLib.Abstracts;

using nadaAquiMod.nadaAquiModCode.Extensions;

namespace nadaAquiMod.nadaAquiModCode.Character;

public class JesterCardPool : CustomCardPoolModel
{
    public override string Title => Jester.CharacterId;
    
    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();

    public override float H => 0.708f; // Hue
    public override float S => 1f; // Saturation
    public override float V => 1f; // Brightness

    // Color of small card icons
    public override Color DeckEntryCardColor => new(0x6400C9FF);
    
    public override bool IsColorless => false;
}