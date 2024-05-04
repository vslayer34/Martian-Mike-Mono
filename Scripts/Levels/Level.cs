using Godot;
using MartianMikeMono.Scripts.Environment;
using MartianMikeMono.Scripts.Helper;
using MartianMikeMono.Scripts.Resources;
using System;

namespace MartianMikeMono.Scripts.Levels;
public partial class Level : Node2D
{
    [ExportGroup("Required")]
    [Export]
    public GameEvents GameEvents { get; private set; }

    [Export]
    public Area2D DeathZone { get; private set; }

    [Export]
    public StartArea PlayerSpawnPosition { get; private set; }

    [Export]
    public Player PlayerNode { get; private set; }



    // GameLoop Methods----------------------------------------------------------------------------
    public override void _Ready()
    {
        ResetPositionAndSpeed(PlayerNode);
        GameEvents.TouchedPlayer += OnTrapTocuhedPlayer;
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

    public override void _ExitTree()
    {
        GameEvents.TouchedPlayer -= OnTrapTocuhedPlayer;
    }


    // Member Methods------------------------------------------------------------------------------

    /// <summary>
    /// Reset the position and speed of the passed<c>Player</c>reference
    /// </summary>
    /// <param name="player">Reference passed by other signal of the player</param>
    private void ResetPositionAndSpeed(Player player)
    {
        player.Velocity = Vector2.Zero;
        player.GlobalPosition = PlayerSpawnPosition.GetSpawnPosition();
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
            ResetPositionAndSpeed(player);
        }
    }

    /// <summary>
    /// reset player position and speed
    /// </summary>
    private void OnTrapTocuhedPlayer(Player player)
    {
        ResetPositionAndSpeed(player);
    }
}