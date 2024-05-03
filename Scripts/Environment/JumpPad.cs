using Godot;
using MartianMikeMono.Scripts.Helper;
using System;

public partial class JumpPad : Area2D
{
    [ExportGroup("Required Nodes")]
    [Export]
    public AnimatedSprite2D AnimatedSprite { get; private set; }



    // Game Loop nethods---------------------------------------------------------------------------
    public override void _Ready()
    {
        BodyEntered += OnJumpPadBodyEntered;
    }


    // Signal Methods------------------------------------------------------------------------------
    private void OnJumpPadBodyEntered(Node2D body)
    {
        AnimatedSprite.Animation = AnimationsClips.JumpPad.CATAPULT;
    }
}
