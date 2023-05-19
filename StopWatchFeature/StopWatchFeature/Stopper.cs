namespace StopWatchFeature;

public class Stopper : IStopper
{
    private DateTime _startTime;
    private DateTime _endTime;
    private bool _isRunning;

    public Stopper()
    {
        _isRunning = false;
    }

    public void Start()
    {
        if (_isRunning)
        {
            throw new SystemException("Stopper is already running. You cannot start it again.");
        }
        _startTime = DateTime.Now;
        _isRunning = true;
    }

    public void Stop()
    {
        if (!_isRunning)
        {
            throw new SystemException("You cannot stop not running Stopper");
        }

        _endTime = DateTime.Now;
        _isRunning = false;
    }

    public TimeSpan GetResult()
    {
        if (_isRunning)
        {
            throw new SystemException("Stopper is still running!");
        }

        var result = _endTime - _startTime;

        if (result <= TimeSpan.Zero)
        {
            throw new SystemException("Time result is lower than zero!");
        }

        return result;
    }
}