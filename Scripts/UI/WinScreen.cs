using Godot;
using System;

public partial class WinScreen : Control
{
    [ExportGroup("Required Nodes")]
    [Export]
    public Button NextButton { get; private set; }



    public override void _Ready()
    {
        NextButton.Pressed += OnNextButtonPressed;
    }

    
    private void OnNextButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/UI/start_menu.tscn");
    }
}
