using TaskManagementSystem;
using Task = TaskManagementSystem.Task;

namespace TaskManagmentSystem
{
    [TestClass]
    public class TasklistTest
    {
        private Tasklist tasklist;
        private Task task1;
        private Task task2;
        private User testUser;

        [TestInitialize]
        public void Setup()
        {
            tasklist = new Tasklist();
            testUser = new User(1, "John Doe");
            task1 = new Task("Task 1", "Description 1", DateOnly.FromDateTime(DateTime.Now), 1, 2, Status.OFFEN, testUser);
            task2 = new Task("Task 2", "Description 2", DateOnly.FromDateTime(DateTime.Now), 2, 3, Status.INBEARBEITUNG, testUser);
        }

        [TestMethod]
        public void TestAddTask()
        {
            tasklist.addTask(task1);
            var tasks = tasklist.getAllTasks();

            Assert.AreEqual(1, tasks.Count);
            Assert.AreEqual(task1, tasks[0]);
        }

        [TestMethod]
        public void TestRemoveTask()
        {
            tasklist.addTask(task1);
            tasklist.removeTask(task1);
            var tasks = tasklist.getAllTasks();

            Assert.AreEqual(0, tasks.Count);
        }

        [TestMethod]
        public void TestFilterTasks()
        {
            tasklist.addTask(task1);
            tasklist.addTask(task2);

            var filteredTasks = tasklist.filterTasks(Status.OFFEN);

            Assert.AreEqual(1, filteredTasks.Count);
            Assert.AreEqual(task1, filteredTasks[0]);
        }

        [TestMethod]
        public void TestModifyTask()
        {
            tasklist.addTask(task1);
            var modifiedTask = new Task("Modified Task", "Modified Description", DateOnly.FromDateTime(DateTime.Now), 1, 2, Status.OFFEN, testUser);

            tasklist.modifyTask(task1, modifiedTask);
            var tasks = tasklist.getAllTasks();

            Assert.AreEqual(1, tasks.Count);
            Assert.AreEqual(modifiedTask, tasks[0]);
        }
    }
}
