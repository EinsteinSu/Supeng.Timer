namespace Supeng.Timer
{
    public interface ISportsTimer
    {
        long CurrentSeconds { get; }
        void Start();
        void Stop();
        void Reset();
    }
}