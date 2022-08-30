using CleverenceTest;

namespace CleverenceTask.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class AsyncCallerUnitTests
{
    [TestMethod]
    public void When_Invoke_Expect_ReturnTrue()
    {
        // Arrange
        var eventHandler = new EventHandler((_, _) => Thread.Sleep(1000));
        var asyncCaller = new AsyncCaller(eventHandler);

        // Act
        var result = asyncCaller.Invoke(1100, null!, EventArgs.Empty);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void When_Invoke_Expect_ReturnFalse()
    {
        // Arrange
        var eventHandler = new EventHandler((_, _) => Thread.Sleep(1000));
        var asyncCaller = new AsyncCaller(eventHandler);

        // Act
        var result = asyncCaller.Invoke(900, null!, EventArgs.Empty);

        // Assert
        Assert.IsFalse(result);
    }
}