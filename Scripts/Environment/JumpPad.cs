using Godot;
using MartianMikeMono.Scripts.Helper;
using System;

public partial class JumpPad : Area2D
{
    [ExportGroup("Required Nodes")]
    [Export]
    public AnimatedSprite2D AnimatedSprite { get; private set; }

    [ExportGroup("")]

    [Export]
    private float _launchForce = 300.0f;



    // Game Loop nethods---------------------------------------------------------------------------
    public override void _Ready()
    {
        BodyEntered += OnJumpPadBodyEntered;
        AnimatedSprite.AnimationFinished += SwitchToIdle;
    }


    // Signal Methods------------------------------------------------------------------------------
    /// <summary>
    /// Play the catpult animations and catpult the player into the air
    /// and after the animations is finisihed return to the idle state
    /// </summary>
    private void OnJumpPadBodyEntered(Node2D body)
    {
        if (body is Player player)
        {
            AnimatedSprite.Play(AnimationsClips.JumpPad.CATAPULT);
            player.Jump(_launchForce);
        }
    }

    private void SwitchToIdle()
    {
        if (AnimatedSprite.Animation != AnimationsClips.JumpPad.CATAPULT)
        {
            return;
        }

        AnimatedSprite.Animation = AnimationsClips.JumpPad.IDLE;
    }
}
