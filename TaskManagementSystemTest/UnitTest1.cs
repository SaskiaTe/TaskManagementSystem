using TaskManagementSystem;

namespace TaskManagementSystemTest;

[TestClass]
public class UserTest
{
    [TestMethod]
    public void TestGetName()
    {
        // Arrange
        User user = new User(1, "John Doe");

        // Act
        string name = user.GetName();

        // Assert
        Assert.AreEqual("John Doe", name);
    }

}