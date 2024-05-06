using Godot;
using System;
using System.Runtime.InteropServices;

public partial class AudioManager : Node2D
{
    [ExportCategory("Sound Clips")]
    [Export]
    public AudioStream JumpSFX { get; private set; }

    [Export]
    public AudioStream HurtSFX { get; private set; }

    private AudioStreamPlayer2D _audioPlayer;
    private AudioStream _playedAudio;



    public async void PlaySFX(SFXType whatSound)
    {
        switch (whatSound)
        {
            case SFXType.JUMP:
                _playedAudio = JumpSFX;
                break;
            
            case SFXType.HURT:
                _playedAudio = HurtSFX;
                break;

            default:
                GD.PrintErr("Not a valid sound type");
                return;
        }

        _audioPlayer = new AudioStreamPlayer2D();
        _audioPlayer.Name = "SFXPlayer";
        _audioPlayer.Stream = _playedAudio;
        _audioPlayer.MaxDistance = 4000.0f;
        _audioPlayer.Attenuation = 0.0f;
        AddChild(_audioPlayer);
        _audioPlayer.Play();

        await ToSignal(_audioPlayer, AudioStreamPlayer2D.SignalName.Finished);
        _audioPlayer.QueueFree();
    }
}

public enum SFXType
{
    JUMP,
    HURT
}