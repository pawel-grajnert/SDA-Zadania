namespace StopWatchFeature;

public interface IStopper
{
    void Start();
    void Stop();
    TimeSpan GetResult();
}