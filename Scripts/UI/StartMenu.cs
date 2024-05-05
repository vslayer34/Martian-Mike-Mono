using Godot;
using System;

public partial class StartMenu : Control
{
    [ExportGroup("Required Nodes")]
    [Export]
    public Button StartButton { get; private set; }

    [Export]
    public Button QuitButton { get; private set; }



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        StartButton.Pressed += OnStartButtonPressed;
        QuitButton.Pressed += OnQuitButtonPressed;
    }

    // Signal Methods------------------------------------------------------------------------------

    /// <summary>
    /// Load the first game level
    /// </summary>
    private void OnStartButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/level.tscn");
    }

    /// <summary>
    /// Quit the game
    /// </summary>
    private void OnQuitButtonPressed()
    {
        GetTree().Quit();
    }
}
