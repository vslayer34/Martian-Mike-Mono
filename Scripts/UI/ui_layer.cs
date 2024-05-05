using Godot;
using System;

public partial class ui_layer : CanvasLayer
{
    [ExportGroup("Required Nodes")]
    [Export]
    public HUD HUDNode { get; private set; }

    [Export]
    public WinScreen WinScreenNode { get; private set; }



    /// <summary>
    /// Show or hide the win screen
    /// </summary>
    /// <param name="isShown"></param>
    public void ShowWinScreen(bool isShown) => WinScreenNode.Visible = isShown;
}
