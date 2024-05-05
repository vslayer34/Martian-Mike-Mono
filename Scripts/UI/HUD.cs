using Godot;
using System;

public partial class HUD : Control
{
    [ExportGroup("Required Nodes")]
    [Export]
    public Label TimeLabel { get; private set; }



    public void UpdateTime(float time)
    {
        TimeLabel.Text = $"TIME: {time}";
    }
}
