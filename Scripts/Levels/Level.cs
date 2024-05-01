using Godot;
using MartianMikeMono.Scripts.Helper;
using System;

namespace MartianMikeMono.Scripts.Levels;
public partial class Level : Node2D
{
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
}