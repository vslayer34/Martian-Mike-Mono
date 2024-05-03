using Godot;
using MartianMikeMono.Scripts.Helper;
using System;

namespace MartianMikeMono.Scripts.Levels;
public partial class Level : Node2D
{
    [ExportGroup("Required")]
    [Export]
    public Area2D DeathZone { get; private set; }

    [Export]
    public Marker2D PlayerSpawnPosition { get; private set; }



    // GameLoop Methods----------------------------------------------------------------------------
    public override void _Ready()
    {
        DeathZone.BodyEntered += OnDeathZoneBodyEntered;
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustReleased(InputActionConstants.QUIT))
        {
            GetTree().Quit();
        }

        if (Input.IsActionJustReleased(InputActionConstants.RESET))
        {
            GetTree().ReloadCurrentScene();
        }
    }


    // Signal Methods------------------------------------------------------------------------------
    /// <summary>
    /// Reset the player speed to zero and its position to the spawn position
    /// </summary>
    /// <param name="body"></param>
    private void OnDeathZoneBodyEntered(Node2D body)
    {
        if (body is Player player)
        {
            player.Velocity = Vector2.Zero;
            player.GlobalPosition = PlayerSpawnPosition.Position;
        }
    }
}