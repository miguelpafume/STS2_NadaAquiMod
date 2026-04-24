using Godot;
using MegaCrit.Sts2.Core.Helpers;
using MegaCrit.Sts2.Core.Nodes;
using MegaCrit.Sts2.Core.Nodes.Vfx;
using MegaCrit.Sts2.Core.TestSupport;
using MegaCrit.Sts2.Core.Commands;

namespace nadaAquiMod.nadaAquiModCode.Combo;

public enum ComboVfxType
{
    Stun
}

public static class ComboVfx
{
    public static async Task OnComboTriggered(string name, ComboVfxType type)
    {
		ArgumentNullException.ThrowIfNull(NGame.Instance, "NGame.Instance");
		ArgumentNullException.ThrowIfNull(NGame.Instance.CurrentRunNode, "NGame.Instance.CurrentRunNode");

        if (TestMode.IsOn) return;

        var banner = NFullscreenTextVfx.Create(name);
        if (banner != null) NGame.Instance.AddChildSafely(banner);

        Color tint = new();
        Color hi = new();

        switch (type)
        {
            case ComboVfxType.Stun:
                tint  = new Color(0xFFD7008C);
                hi    = new Color(0xFF48004D);
                break;
            default:
                tint  = new Color(0xFF00008C);
                hi    = new Color(0xFF00004D);
                break;
        }

        var vig = NSmokyVignetteVfx.Create(tint, hi);
        if (vig != null) NGame.Instance.CurrentRunNode.GlobalUi.AddChildSafely(vig);

        SfxCmd.Play("event:/sfx/characters/attack_fire");
        await Cmd.CustomScaledWait(0.1f, 0.25f);
    }
}