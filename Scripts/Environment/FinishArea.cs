using Godot;
using MartianMikeMono.Scripts.Helper;
using System;

public partial class FinishArea : Area2D
{
    [Export]
    public AnimatedSprite2D AnimatedSprite { get; private set; }

    
    
    public void Animate() => AnimatedSprite.Play(AnimationsClips.FinishArea.WIN);
}
