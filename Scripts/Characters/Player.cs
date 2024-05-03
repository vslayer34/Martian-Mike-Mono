using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [ExportGroup("Required Nodes")]
    [Export]
    public AnimatedSprite2D AnimatedSprite { get; private set; }

    [ExportGroup("")]

    [ExportSubgroup("Properties")]
    [Export]
    private float _gravity = 400.0f;

    private Vector2 _movementVector;



    public override void _PhysicsProcess(double delta)
    {
        if (!IsOnFloor())
        {
            _movementVector.Y += _gravity * (float)delta;
        }

        Velocity = _movementVector;
        
        MoveAndSlide();
    }
}
