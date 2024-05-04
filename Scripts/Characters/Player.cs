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

    private Controlable _controlState;



    public override void _Ready()
    {
        _controlState = Controlable.ENABLED;
    }

    public override void _PhysicsProcess(double delta)
    {
        float direction = 0.0f;
        // Apply gravity
        if (!IsOnFloor())
        {
            _movementVector.Y += _gravity * (float)delta;
        }

        if (_controlState == Controlable.ENABLED)
        {
            // Apply jump
            if (Input.IsActionJustPressed(InputActionConstants.JUMP) && IsOnFloor())
            {
                Jump(_jumpForce);
            }

            // Apply left and right movement
            direction = Input.GetAxis(InputActionConstants.MOVE_LEFT, InputActionConstants.MOVE_RIGHT);
        }

        _movementVector.X = direction * _speed;
        
        if (direction != 0)
        {
            AnimatedSprite.FlipH = direction < 0;
        }

        Velocity = _movementVector;
        
        MoveAndSlide();

        UpdateAnimations(direction);
    }


    /// <summary>
    /// Update the animation according to its state<br/>
    /// moving, idling, falling or jumping
    /// </summary>
    /// <param name="direction">movement input direction</param>
    private void UpdateAnimations(float direction)
    {
        if (IsOnFloor())
        {
            if (direction != 0.0f)
            {
                AnimatedSprite.Animation = AnimationsClips.Player.RUN;
            }
            else
            {
                AnimatedSprite.Animation = AnimationsClips.Player.IDLE;
            }
        }
        else
        {
            if (Velocity.Y < 0)
            {
                AnimatedSprite.Animation = AnimationsClips.Player.JUMP;
            }
            else
            {
                AnimatedSprite.Animation = AnimationsClips.Player.FALL;
            }
        }
    }

    /// <summary>
    /// make the player jump according to the given force
    /// </summary>
    /// <param name="jumpForce"></param>
    public void Jump(float jumpForce)
    {
        _movementVector.Y = -1 * jumpForce;
    }

    /// <summary>
    /// Set the control state of the player to disabled when it reach the finish line
    /// </summary>
    public void DisabeControls() => _controlState = Controlable.DISABLED;
}


internal enum Controlable
{
    ENABLED,
    DISABLED
}
