using Dalamud.Interface.Components;

namespace TextAdvance.Gui;

internal static class TabTerritory
{
    private static uint SelectedKey = uint.MaxValue;
    private static bool OnlyModded = false;
    private static string Filter = string.Empty;
    internal static void Draw()
    {
        ImGui.Checkbox(Loc.GlobalEnableOverridesLocal, ref C.GlobalOverridesLocal);
        ImGuiEx.TextWrapped(Loc.GlobalEnableOverridesLocalHelp);
        ImGuiEx.Text(Loc.CurrentPluginStateGlobal);
        ImGui.SameLine(0, 0);
        ImGuiEx.Text(P.Enabled ? ImGuiColors.ParsedGreen : ImGuiColors.DalamudRed, P.Enabled ? Loc.StateEnabled : Loc.StateDisabled);
        ImGui.SameLine(0, 0);
        ImGuiEx.Text(Loc.CurrentPluginStateLocal);
        ImGui.SameLine(0, 0);
        ImGuiEx.Text(P.IsTerritoryEnabled() ? ImGuiColors.ParsedGreen : ImGuiColors.DalamudRed, P.IsTerritoryEnabled() ? Loc.StateEnabled : Loc.StateDisabled);
        ImGuiEx.SetNextItemFullWidth();
        if (ImGui.BeginCombo("##terrselect", P.TerritoryNames.TryGetValue(SelectedKey, out var selected) ? selected : Loc.SelectArea))
        {
            ImGui.SetNextItemWidth(200f);
            ImGui.InputTextWithHint("##selectflts", Loc.Filter, ref Filter, 50);
            ImGui.SameLine();
            ImGui.Checkbox(Loc.OnlyModified, ref OnlyModded);
            if (P.TerritoryNames.TryGetValue(Svc.ClientState.TerritoryType, out var current) && ImGui.Selectable(Loc.CurrentArea(current)))
            {
                SelectedKey = Svc.ClientState.TerritoryType;
            }
            ImGui.Separator();
            foreach (var x in P.TerritoryNames)
            {
                if (Filter != string.Empty && !x.Value.Contains(Filter, StringComparison.OrdinalIgnoreCase)) continue;
                if (OnlyModded && !C.TerritoryConditions.ContainsKey(x.Key)) continue;
                if (ImGui.Selectable(x.Value, C.TerritoryConditions.ContainsKey(x.Key)))
                {
                    SelectedKey = x.Key;
                }
                if (ImGui.IsWindowAppearing() && SelectedKey == x.Key)
                {
                    ImGui.SetScrollHereY();
                }
            }
            ImGui.EndCombo();
        }
        if (P.TerritoryNames.ContainsKey(SelectedKey))
        {
            if (C.TerritoryConditions.TryGetValue(SelectedKey, out var settings))
            {
                if (ImGui.Button(Loc.RemoveCustomSettings))
                {
                    C.TerritoryConditions.Remove(SelectedKey);
                }
                ImGui.Checkbox(Loc.AutomaticQuestAccept, ref settings.EnableQuestAccept);
                ImGui.Checkbox(Loc.AutomaticQuestComplete, ref settings.EnableQuestComplete);
                ImGui.Checkbox(Loc.AutomaticRewardPickBeta, ref settings.EnableRewardPick);
                ImGui.Checkbox(Loc.AutomaticTalkSkip, ref settings.EnableTalkSkip);
                ImGui.Checkbox(Loc.SemiAutomaticRequestHandin, ref settings.EnableRequestHandin);
                ImGui.Checkbox(Loc.AutomaticRequestFillNew, ref settings.EnableRequestFill);
                ImGui.Checkbox(Loc.AutomaticEscDuringCutscene, ref settings.EnableCutsceneEsc);
                ImGui.Checkbox(Loc.AutomaticCutsceneSkipConfirmation, ref settings.EnableCutsceneSkipConfirm);
                ImGui.Checkbox($"{Loc.AutomaticQuestObjectInteraction}（IN）", ref settings.EnableAutoInteract);
                ImGuiComponents.HelpMarker(Loc.HelpQuestObjectInteraction);
                ImGui.Separator();
                ImGui.Checkbox(Loc.DisplayQuestTargetIndicators, ref settings.QTIQuestEnabled);
                ImGui.ColorEdit4(Loc.QuestTargetIndicatorColor, ref settings.QTIQuestColor, ImGuiColorEditFlags.NoInputs);
                ImGui.Checkbox(Loc.QuestTargetIndicatorTether, ref settings.QTIQuestTether);
                ImGui.SetNextItemWidth(60f);
                ImGui.DragFloat(Loc.QuestTargetIndicatorThickness, ref settings.QTIQuestThickness, 0.02f, 1f, 10f);
            }
            else
            {
                ImGuiEx.Text(Loc.NoCustomAreaSettings);
                if (ImGui.Button(Loc.CreateCustomSettings))
                {
                    C.TerritoryConditions[SelectedKey] = new();
                }
            }
        }
    }
}
