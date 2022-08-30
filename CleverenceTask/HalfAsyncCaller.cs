namespace CleverenceTest;

public class HalfAsyncCaller
{
    private readonly EventHandler _handler;

    public HalfAsyncCaller(EventHandler handler)
    {
        _handler = handler;
    }
    
    public bool Invoke(int milliseconds, object sender, EventArgs args)
    {
        var task = Task.Factory.StartNew(() => _handler.Invoke(sender, args));
        return task.Wait(milliseconds);
    }
}