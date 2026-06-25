namespace TextAdvance.Gui;

internal sealed class ConfigBuilder
{
    private readonly List<(string Name, Action Draw)> sections = [];
    private string currentName;

    public ConfigBuilder Section(string name)
    {
        this.currentName = name;
        return this;
    }

    public ConfigBuilder Widget(Action draw)
    {
        this.sections.Add((this.currentName ?? string.Empty, draw));
        return this;
    }

    public void Draw()
    {
        foreach (var section in this.sections)
        {
            ImGui.PushStyleColor(ImGuiCol.Header, ImGuiColors.DalamudGrey3);
            ImGui.CollapsingHeader(section.Name, ImGuiTreeNodeFlags.DefaultOpen | ImGuiTreeNodeFlags.NoTreePushOnOpen);
            ImGui.PopStyleColor();

            if (ImGui.BeginChild($"##section-{section.Name}", new Vector2(ImGui.GetContentRegionAvail().X, 0), true))
            {
                section.Draw();
            }
            ImGui.EndChild();
            ImGui.Spacing();
        }
    }
}
