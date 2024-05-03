using System;
using Godot;
using MartianMikeMono.Scripts.Resources;


namespace MartianMikeMono.Scripts.Traps;
public partial class Trap : Node2D
{
    [ExportGroup("Required Nodes")]
    [Export]
    public GameEvents GameEvents { get; private set; }

    private Area2D _collisionArea;



    public override void _Ready()
    {
        _collisionArea = GetNode<Area2D>("Area2D");
        _collisionArea.BodyEntered += OnTrapBodyEntered;
    }


    // Signal Methods------------------------------------------------------------------------------
    /// <summary>
    /// Called when the player hit the trap
    /// </summary>
    /// <param name="body"></param>
    private void OnTrapBodyEntered(Node2D body)
    {
        if (body is Player player)
        {
            GameEvents.EmitSignal(GameEvents.SignalName.TouchedPlayer, player);
        }
    }
}