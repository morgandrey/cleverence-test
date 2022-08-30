namespace CleverenceTest;

public static class Server
{
    private static int count;
    private static readonly ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();

    public static void AddToCount(int value)
    {
        _readerWriterLock.EnterWriteLock();
        try
        {
            checked
            {
                count += value;
            }
        }
        finally
        {
            _readerWriterLock.ExitWriteLock();
        }
    }

    public static int GetCount()
    {
        _readerWriterLock.EnterReadLock();
        try
        {
            return count;
        }
        finally
        {
            _readerWriterLock.ExitReadLock();
        }
    }
}