namespace TextAdvance.Gui;

internal static class TabChars
{
    private static string Name = "";
    internal static void Draw()
    {

        ImGui.Text(Loc.AutoEnableCharacters);
        string dele = null;
        foreach (var s in C.AutoEnableNames)
        {
            ImGui.Text(s);
            ImGui.SameLine();
            if (ImGui.SmallButton(Loc.Delete + "##" + s))
            {
                dele = s;
            }
        }
        if (ImGui.Button(Loc.AddCurrentCharacter) && Svc.ClientState.LocalPlayer != null)
        {
            C.AutoEnableNames.Add(Svc.ClientState.LocalPlayer.Name.ToString() + "@" + Svc.ClientState.LocalPlayer.HomeWorld.Value.Name.ToString());
        }
        ImGui.SameLine();
        ImGui.SetNextItemWidth(200f);
        ImGui.InputTextWithHint("##charname", Loc.CharacterName, ref Name, 50);
        ImGui.SameLine();
        if (ImGui.Button(Loc.Add))
        {
            C.AutoEnableNames.Add(Name);
            Name = "";
        }
        if (dele != null)
        {
            C.AutoEnableNames.Remove(dele);
        }
    }
}
