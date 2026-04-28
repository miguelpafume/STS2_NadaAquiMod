using Godot;
using MegaCrit.Sts2.Core.Helpers;
using MegaCrit.Sts2.Core.Nodes;
using MegaCrit.Sts2.Core.Nodes.Vfx;
using MegaCrit.Sts2.Core.TestSupport;
using MegaCrit.Sts2.Core.Commands;

namespace nadaAquiMod.nadaAquiModCode.Combo;

public static class Message
{
    public static async Task ShowMessage(string name)
    {
		ArgumentNullException.ThrowIfNull(NGame.Instance, "NGame.Instance");
		ArgumentNullException.ThrowIfNull(NGame.Instance.CurrentRunNode, "NGame.Instance.CurrentRunNode");

        if (TestMode.IsOn) return;

        var banner = NFullscreenTextVfx.Create(name);
        if (banner != null) NGame.Instance.CurrentRunNode.GlobalUi.AddChildSafely(banner);

        await Cmd.CustomScaledWait(0.15f, 0.3f);
    }
}