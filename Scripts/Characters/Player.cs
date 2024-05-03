using Godot;
using MartianMikeMono.Scripts.Helper;
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

    [Export]
    private float _jumpForce = 200.0f;

    [Export]
    private float _speed = 125.0f;

    
    // Hold the direction of the player movement to apply it to the velocity
    private Vector2 _movementVector;



    public override void _PhysicsProcess(double delta)
    {
        // Apply gravity
        if (!IsOnFloor())
        {
            _movementVector.Y += _gravity * (float)delta;
        }

        // Apply jump
        if (Input.IsActionJustPressed(InputActionConstants.JUMP) && IsOnFloor())
        {
            _movementVector.Y = -1 * _jumpForce;
        }

        // Apply left and right movement
        float direction = Input.GetAxis(InputActionConstants.MOVE_LEFT, InputActionConstants.MOVE_RIGHT);
        _movementVector.X = direction * _speed;

        Velocity = _movementVector;
        
        MoveAndSlide();
    }
}
