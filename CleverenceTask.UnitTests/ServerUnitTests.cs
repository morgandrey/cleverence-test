using CleverenceTest;

namespace CleverenceTask.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ServerUnitTests
{
    [TestMethod]
    public void When_AddToCount_Expect_AddValueToCount()
    {
        // Arrange
        var tasks = new List<Task>();
        var expected = 5000;

        // Act
        for (int i = 0; i < 5000; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                tasks.Add(Task.Factory.StartNew(Server.GetCount));
            }

            tasks.Add(Task.Factory.StartNew(() => Server.AddToCount(1)));
        }

        Task.WaitAll(tasks.ToArray());

        // Assert
        Assert.AreEqual(expected, Server.GetCount());
    }
}