namespace CleverenceTest;

public static class Server
{
    private static int count;
    private static readonly ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();

    public static void AddToCount(int value)
    {
        readerWriterLock.EnterWriteLock();
        try
        {
            checked
            {
                count += value;
            }
        }
        finally
        {
            readerWriterLock.ExitWriteLock();
        }
    }

    public static int GetCount()
    {
        readerWriterLock.EnterReadLock();
        try
        {
            return count;
        }
        finally
        {
            readerWriterLock.ExitReadLock();
        }
    }
}