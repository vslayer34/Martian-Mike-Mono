using Godot;


namespace MartianMikeMono.Scripts.Resources;
/// <summary>
/// Contatins public events to be shared between nodes
/// </summary>
public partial class GameEvents : Resource
{
    [Signal]
    public delegate void TouchedPlayerEventHandler(Player player);
}