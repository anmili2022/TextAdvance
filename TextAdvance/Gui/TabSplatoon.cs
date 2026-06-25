namespace TextAdvance.Gui
{
    public static class TabSplatoon
    {
        public static void Draw()
        {
            ImGuiEx.TextWrapped(Loc.SplatoonFunctionsRequirePlugin);
            if (Svc.PluginInterface.InstalledPlugins.TryGetFirst(x => x.InternalName == "Splatoon", out var plugin))
            {
                if (plugin.IsLoaded)
                {
                    ImGuiEx.TextWrapped(EColor.Green, Loc.SplatoonInstalledEnabled(plugin.Version.ToString()));
                }
                else
                {
                    ImGuiEx.TextWrapped(EColor.Red, Loc.SplatoonInstalledDisabled(plugin.Version.ToString()));
                }
            }
            else
            {
                ImGuiEx.TextWrapped(EColor.Red, Loc.SplatoonNotInstalled);
                if (ImGui.Button(Loc.GetSplatoon)) ShellStart("https://puni.sh/plugin/Splatoon");
            }
            ImGui.Checkbox(Loc.DisplayQuestTargetIndicators, ref C.MainConfig.QTIQuestEnabled);
            ImGui.ColorEdit4(Loc.QuestTargetIndicatorColor, ref C.MainConfig.QTIQuestColor, ImGuiColorEditFlags.NoInputs);
            ImGui.Checkbox(Loc.QuestTargetIndicatorTether, ref C.MainConfig.QTIQuestTether);
            ImGuiEx.SetNextItemWidthScaled(60f);
            ImGui.DragFloat(Loc.QuestTargetIndicatorThickness, ref C.MainConfig.QTIQuestThickness, 0.02f, 1f, 10f);
            ImGui.Separator();
            ImGui.Checkbox(Loc.EnableEventObjectFinder, ref C.EObjFinder);
            ImGui.Checkbox(Loc.EnableEventNpcFinder, ref C.ENpcFinder);
            ImGuiEx.SetNextItemWidthScaled(150f);
            ImGuiEx.EnumCombo(Loc.DisplayOnlyWhileHoldingKey, ref C.FinderKey);
        }
    }
}
