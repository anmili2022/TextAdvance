using Dalamud.Interface.Components;
using ECommons.SplatoonAPI;
using Lumina.Excel.Sheets;

namespace TextAdvance.Gui;

internal static class TabConfig
{
    public static string Filter = "";
    internal static void Draw()
    {
        if (P.BlockList.Count > 0)
        {
            ImGuiEx.TextWrapped(EColor.RedBright, Loc.BlockedByPlugins(string.Join(",", P.BlockList)));
            if (ImGui.SmallButton(Loc.RemoveAllLocks))
            {
                P.BlockList.Clear();
            }
        }

        if (S.IPCProvider.IsInExternalControl())
        {
            ImGuiEx.TextWrapped(EColor.RedBright, Loc.ExternallyControlledBy(S.IPCProvider.Requester));
            if (ImGui.SmallButton(Loc.CancelExternalControl))
            {
                S.IPCProvider.Requester = null;
                S.IPCProvider.ExternalConfig = null;
            }
        }

        new ConfigBuilder()
        .Section(Loc.SectionPluginOperation)
        .Widget(() =>
        {
            ImGui.Checkbox(Loc.EnablePluginNonPersistent, ref P.Enabled);
            ImGui.Checkbox(Loc.DontAutoDisableOnLogout, ref C.DontAutoDisable);
            ImGui.Checkbox(Loc.EnableQuestTargetIndicatorsGlobal, ref C.QTIEnabled);
            ImGui.Indent();
            ImGui.Checkbox(Loc.EnableIndicatorsWhenDisabled, ref C.QTAEnabledWhenTADisable);
            ImGui.Checkbox(Loc.EnableFinderWhenDisabled, ref C.QTAFinderEnabledWhenTADisable);
            if (C.QTIEnabled)
            {
                if (!Splatoon.IsConnected())
                {
                    ImGuiEx.TextWrapped(EColor.PurpleBright, Loc.SplatoonRequiredForIndicators);
                }
            }
            ImGui.Unindent();
            ImGui.SetNextItemWidth(150f);
            ImGui.SliderFloat(Loc.AutoInteractMaxRadius, ref C.AutoInteractMaxRadius, 3f, 10f);
            ImGuiEx.HelpMarker(Loc.AutoInteractRadiusWarning, ImGuiColors.DalamudOrange, FontAwesomeIcon.ExclamationTriangle.ToIconString());
        })

        .Section(Loc.SectionKeybinds)
        .Widget(() =>
        {
            ImGui.Text(Loc.HoldToDisable);
            ImGui.SetNextItemWidth(200f);
            ImGuiEx.EnumCombo("##HoldDisable", ref C.TempDisableButton);
            ImGui.Text(Loc.HoldToEnable);
            ImGui.SetNextItemWidth(200f);
            ImGuiEx.EnumCombo("##HoldEnable", ref C.TempEnableButton);
        })

        .Section(Loc.SectionFunctions)
        .Widget(() =>
        {
            ImGui.Checkbox($"{Loc.AutomaticQuestAccept}（QA）", ref C.MainConfig.EnableQuestAccept);
            ImGuiComponents.HelpMarker(Loc.HelpQuestAccept);
            ImGui.Checkbox($"{Loc.AutomaticQuestComplete}（QC）", ref C.MainConfig.EnableQuestComplete);
            ImGuiComponents.HelpMarker(Loc.HelpQuestComplete);
            ImGui.Checkbox($"{Loc.AutomaticRewardPick}（RP）", ref C.MainConfig.EnableRewardPick);
            ImGuiComponents.HelpMarker(Loc.HelpRewardPick);
            ImGui.Checkbox($"{Loc.AutomaticTalkSkip}（TS）", ref C.MainConfig.EnableTalkSkip);
            ImGuiComponents.HelpMarker(Loc.HelpTalkSkip);
            ImGui.Checkbox($"{Loc.AutoConfirmRequestHandins}（RH）", ref C.MainConfig.EnableRequestHandin);
            ImGuiComponents.HelpMarker(Loc.HelpRequestHandins);
            ImGui.Checkbox($"{Loc.AutomaticRequestFill}（RF）", ref C.MainConfig.EnableRequestFill);
            ImGuiComponents.HelpMarker(Loc.HelpRequestFill);
            if (C.MainConfig.EnableRequestFill)
            {
                ImGui.Indent();
                ImGui.SetNextItemWidth(200f);
                if (ImGui.BeginCombo("##RequestFillQuality", C.MainConfig.RequestFillQualityPreference.ToString()))
                {
                    if (ImGui.Selectable("NQ", C.MainConfig.RequestFillQualityPreference == RequestFillQualityPreference.NQ))
                        C.MainConfig.RequestFillQualityPreference = RequestFillQualityPreference.NQ;
                    if (ImGui.Selectable("HQ", C.MainConfig.RequestFillQualityPreference == RequestFillQualityPreference.HQ))
                        C.MainConfig.RequestFillQualityPreference = RequestFillQualityPreference.HQ;
                    if (ImGui.Selectable(Loc.Any, C.MainConfig.RequestFillQualityPreference == RequestFillQualityPreference.Any))
                        C.MainConfig.RequestFillQualityPreference = RequestFillQualityPreference.Any;
                    ImGui.EndCombo();
                }
                ImGui.SameLine();
                ImGuiComponents.HelpMarker(Loc.HelpRequestFillQuality);
                ImGui.Unindent();
            }
            ImGui.Checkbox($"{Loc.AutomaticEscDuringCutscene}（CS）", ref C.MainConfig.EnableCutsceneEsc);
            ImGuiComponents.HelpMarker(Loc.HelpCutsceneEsc);
            ImGui.Checkbox($"{Loc.AutomaticCutsceneSkipConfirmation}（CC）", ref C.MainConfig.EnableCutsceneSkipConfirm);
            ImGuiComponents.HelpMarker(Loc.HelpCutsceneSkipConfirmation);
            ImGui.Checkbox($"{Loc.AutomaticQuestObjectInteraction}（IN）", ref C.MainConfig.EnableAutoInteract);
            ImGuiComponents.HelpMarker(Loc.HelpQuestObjectInteraction);
        })

        .Section(Loc.SectionOverlay)
        .Widget(() =>
        {
            ImGui.Checkbox(Loc.EnableOverlayWhenPluginEnabled, ref C.EnableOverlay);
            if (C.EnableOverlay)
            {
                ImGui.SetNextItemWidth(100f);
                ImGui.DragFloat2(Loc.OverlayOffset, ref C.OverlayOffset);
            }
        })

        .Section(Loc.SectionNotifications)
        .Widget(() =>
        {
            ImGui.Checkbox(Loc.DisableManualStateNotification, ref C.NotifyDisableManualState);
            ImGui.Checkbox(Loc.DisableAutoEnableLoginNotification, ref C.NotifyDisableOnLogin);
            ImGui.Checkbox(Loc.DisableRewardPickChatNotification, ref C.PickRewardSilent);
        })

        .Section(Loc.SectionRewardPickingOrder)
        .Widget(() =>
        {
            ImGuiEx.TextWrapped(Loc.RewardPrecisionWarning);
            ImGuiEx.EnumOrderer("", C.PickRewardOrder);
        })

        .Section(Loc.SectionNavigation)
        .Widget(() =>
        {
            ImGui.Checkbox($"{Loc.Enabled}##autointeract", ref C.Navmesh);
            ImGuiEx.PluginAvailabilityIndicator([new("vnavmesh")]);
            ImGui.Checkbox(Loc.AutoInteractUponArrival, ref C.NavmeshAutoInteract);
            ImGui.SetNextItemWidth(200f);
            var current = C.Mount == -1 ? Loc.NoMount : (C.Mount == 0 ? Loc.MountRoulette : $"{Utils.GetMountName(C.Mount)}");
            if (ImGui.BeginCombo($"##mount", current))
            {
                ImGui.InputTextWithHint($"##fltr", Loc.Search, ref Filter, 50);
                if (ImGui.Selectable(Loc.NoMount, C.Mount == -1)) C.Mount = -1;
                if (ImGui.Selectable(Loc.MountRoulette, C.Mount == 0)) C.Mount = 0;
                foreach (var x in Svc.Data.GetExcelSheet<Mount>())
                {
                    var n = x.Singular.ExtractText();
                    if (n == "") continue;
                    if (Filter != "" && !n.Contains(Filter, StringComparison.OrdinalIgnoreCase)) continue;
                    if (C.Mount == x.RowId && ImGui.IsWindowAppearing()) ImGui.SetScrollHereY();
                    if (ImGui.Selectable($"{n}##{x.RowId}", C.Mount == x.RowId))
                    {
                        C.Mount = (int)x.RowId;
                    }
                }
                ImGui.EndCombo();
            }
            ImGui.Checkbox(Loc.UseSprintAndPeloton, ref C.UseSprintPeloton);
            ImGui.Checkbox(Loc.PrintNavigationStatusToChat, ref C.NavStatusChat);
            ImGui.Checkbox(Loc.AllowFlightExperimental, ref C.EnableFlight);
            //ImGui.Checkbox($"Allow teleporting to the nearest Aetheryte to a flag", ref C.EnableTeleportToFlag);
        })

        .Draw();
    }
}
