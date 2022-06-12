using System;


namespace SineWaveGenerator
{
    internal interface ISoundPlayer : IDisposable
    {
        public SoundPlayerState State { get; }

        public void Play();
        public void Pause();
    }
}
