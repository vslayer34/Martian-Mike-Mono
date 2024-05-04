using Godot;
using System;

namespace MartianMikeMono.Scripts.Environment;
public partial class StartArea : StaticBody2D
{
    [ExportGroup("Required Nodes")]
    [Export]
    public Marker2D SpawnPosition { get; private set; }



    // Member Methods------------------------------------------------------------------------------
    /// <summary>
    /// Retuen the global position of the spawn point
    /// </summary>
    /// <returns>Spawn pint global position</returns>
    public Vector2 GetSpawnPosition() => SpawnPosition.GlobalPosition;
}
