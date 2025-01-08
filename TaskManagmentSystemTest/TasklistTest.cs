namespace TaskManagementSystem.Tests
{
    [TestClass]
    public class TasklistTests
    {
        [TestMethod]
        public void TestAddTask()
        {
            var tasklist = new Tasklist();
            var user = new User(1, "John Doe");
            var task = new Task("Test Task", "Description", DateOnly.FromDateTime(DateTime.Now), 1, 5, Status.OFFEN, user);

            tasklist.addTask(task);

            Assert.AreEqual(1, tasklist.getAllTasks().Count);
            Assert.AreEqual(task, tasklist.getAllTasks()[0]);
        }

        [TestMethod]
        public void TestRemoveTask()
        {
            var tasklist = new Tasklist();
            var user = new User(1, "John Doe");
            var task = new Task("Test Task", "Description", DateOnly.FromDateTime(DateTime.Now), 1, 5, Status.OFFEN, user);

            tasklist.addTask(task);
            tasklist.removeTask(task);

            Assert.AreEqual(0, tasklist.getAllTasks().Count);
        }

        [TestMethod]
        public void TestFilterTasks()
        {
            var tasklist = new Tasklist();
            var user = new User(1, "John Doe");
            var task1 = new Task("Task 1", "Description 1", DateOnly.FromDateTime(DateTime.Now), 1, 5, Status.OFFEN, user);
            var task2 = new Task("Task 2", "Description 2", DateOnly.FromDateTime(DateTime.Now), 1, 5, Status.INBEARBEITUNG, user);

            tasklist.addTask(task1);
            tasklist.addTask(task2);

            var filteredTasks = tasklist.filterTasks(Status.OFFEN);

            Assert.AreEqual(1, filteredTasks.Count);
            Assert.AreEqual(task1, filteredTasks[0]);
        }

        [TestMethod]
        public void TestModifyTask()
        {
            var tasklist = new Tasklist();
            var user = new User(1, "John Doe");
            var task1 = new Task("Task 1", "Description 1", DateOnly.FromDateTime(DateTime.Now), 1, 5, Status.OFFEN, user);
            var modifiedTask = new Task("Modified Task", "New Description", DateOnly.FromDateTime(DateTime.Now), 2, 10, Status.INBEARBEITUNG, user);

            tasklist.addTask(task1);
            tasklist.modifyTask(task1, modifiedTask);

            Assert.AreEqual(1, tasklist.getAllTasks().Count);
            Assert.AreEqual(modifiedTask, tasklist.getAllTasks()[0]);
        }
    }
}
