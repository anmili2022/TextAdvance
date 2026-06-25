using ECommons.Funding;
using ECommons.SimpleGui;

namespace TextAdvance.Gui;

public class ConfigGui : ConfigWindow
{
    Overlay Overlay = new();
    WaitOverlay WaitOverlay = new();
    ProgressOverlay ProgressOverlay = new();
    private ConfigGui()
    {
        EzConfigGui.Init(this);
        EzConfigGui.WindowSystem.AddWindow(Overlay);
        EzConfigGui.WindowSystem.AddWindow(WaitOverlay);
        EzConfigGui.WindowSystem.AddWindow(ProgressOverlay);
    }

    public override void Draw()
    {
        if (ImGui.BeginChild("Child", new(ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y - ImGui.GetFrameHeightWithSpacing())))
        {
            PatreonBanner.DrawRight();
            ImGuiEx.EzTabBar("TextAdvanceTab", PatreonBanner.Text,
                (Loc.TabGeneralConfig, TabConfig.Draw, null, true),
                (Loc.TabTargetIndicators, TabSplatoon.Draw, null, true),
                (Loc.TabAutoEnable, TabChars.Draw, null, true),
                (Loc.TabPerAreaConfig, TabTerritory.Draw, null, true),
                InternalLog.ImGuiTab(),
                (Loc.TabDebug, TabDebug.Draw, ImGuiColors.DalamudGrey3, true)
                );
        }
        ImGui.EndChild();
    }

    public override void PreDraw()
    {
        base.PreDraw();
    }
}
