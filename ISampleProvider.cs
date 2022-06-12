namespace SineWaveGenerator
{
    internal interface ISampleProvider
    {
        public int SampleRate { get; }

        public void Read(short[] buffer);
    }
}
