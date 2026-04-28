using BaseLib.Abstracts;
using Godot;

using nadaAquiMod.nadaAquiModCode.Extensions;
namespace nadaAquiMod.nadaAquiModCode.Character;

public class JesterPotionPool : CustomPotionPoolModel
{
    public override Color LabOutlineColor => Jester.Color;
    
    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
}