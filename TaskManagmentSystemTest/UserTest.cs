using TaskManagementSystem;
using Task = TaskManagementSystem.Task;

namespace TaskManagmentSystem;

[TestClass]
public class UserTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void TestGetName()
        {
            User user = new User(1, "John Doe");

            string name = user.getName();

            Assert.AreEqual("John Doe", name);
        }

        [TestMethod]
        public void TestAssignTasks()
        {
            User user = new User(1, "John Doe");
            Task task1 = new Task("Task 1", "Description 1", DateOnly.FromDateTime(DateTime.Now), 1, 2, Status.OFFEN, user);
            Task task2 = new Task("Task 2", "Description 2", DateOnly.FromDateTime(DateTime.Now), 2, 3, Status.INBEARBEITUNG, user);
            List<Task> tasks = new List<Task> { task1, task2 };

            user.assignTasks(tasks);
            List<Task> assignedTasks = user.getAssignedTasks();

            Assert.AreEqual(2, assignedTasks.Count);
            Assert.AreEqual(task1, assignedTasks[0]);
            Assert.AreEqual(task2, assignedTasks[1]);
        }

        [TestMethod]
        public void TestGetAssignedTasks()
        {
            User user = new User(1, "John Doe");
            Task task1 = new Task("Task 1", "Description 1", DateOnly.FromDateTime(DateTime.Now), 1, 2, Status.OFFEN, user);
            List<Task> tasks = new List<Task> { task1 };

            user.assignTasks(tasks);
            List<Task> assignedTasks = user.getAssignedTasks();

            Assert.IsNotNull(assignedTasks);
            Assert.AreEqual(1, assignedTasks.Count);
            Assert.AreEqual(task1, assignedTasks[0]);
        }
    }
}