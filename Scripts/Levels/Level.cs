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
    public PackedScene NextLevel { get; private set; }

    [Export]
    public Area2D DeathZone { get; private set; }

    [Export]
    public StartArea PlayerSpawnPosition { get; private set; }

    [Export]
    public FinishArea EndPoint { get; private set; }

    [Export]
    public Player PlayerNode { get; private set; }
    [ExportGroup("")]

    [Export]
    public HUD HUDNode { get; private set; }


    // Level timer properties
    [ExportCategory("Level Timer")]
    private Timer _levelTimer;

    [Export]
    private float _levelTime = 5;
    private float _timeLeft;

    // Determine if the player finished the level to stop the timer
    private bool _isLevelFinished;
    



    // GameLoop Methods----------------------------------------------------------------------------
    public override void _Ready()
    {
        ResetPositionAndSpeed(PlayerNode);
        GameEvents.TouchedPlayer += OnTrapTocuhedPlayer;
        DeathZone.BodyEntered += OnDeathZoneBodyEntered;
        EndPoint.BodyEntered += OnFinishAreaBodyEnterd;
        
        // Create the level timer at the start of the game and set time left to level time
        _timeLeft = _levelTime;
        _levelTimer = new Timer();
        
        _levelTimer.Name = "LevelTimer";
        _levelTimer.WaitTime = 1.0f;
        _levelTimer.Timeout += OnLevelTimerTimeout;
        AddChild(_levelTimer);
        _levelTimer.Start();
        HUDNode.UpdateTime(_timeLeft);
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

    /// <summary>
    /// Called when the player reach the finish point
    /// </summary>
    /// <param name="body"></param>
    private async void OnFinishAreaBodyEnterd(Node2D body)
    {
        if (body is Player player)
        {
            _isLevelFinished = true;
            EndPoint.Animate();
            player.DisabeControls();
            await ToSignal(GetTree().CreateTimer(1.5f), Timer.SignalName.Timeout);
            GetTree().ChangeSceneToPacked(NextLevel);
        }
    }

    private void OnLevelTimerTimeout()
    {
        if (_isLevelFinished)
        {
            return;
        }
        
        if (_timeLeft < 0)
        {
            ResetPositionAndSpeed(PlayerNode);
            _timeLeft = _levelTime;
        }
        
        HUDNode.UpdateTime(_timeLeft--);
    }
}