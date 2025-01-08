namespace TaskManagementSystem;

public class Tasklist
{
    private List<Task> _tasks;

    public Tasklist()
    {
        _tasks = new List<Task>();
    }

    public void addTask(Task toBeAddedTask)
    {
        _tasks.Add(toBeAddedTask);
    }

    public void removeTask(Task toBeRemovedTask)
    {
        _tasks.Remove(toBeRemovedTask);
    }

    public List<Task> getAllTasks()
    {
        return _tasks;
    }

    public List<Task> filterTasks(Status statusToFilter)
    {
        List<Task> filteredTasks = new List<Task>();
        for (int i = 0; i < _tasks.Count; i++)
        {
            if (statusToFilter == _tasks.ElementAt(i).getStatus())
            {
                filteredTasks.Add(_tasks.ElementAt(i));
            }
        }
        return filteredTasks;
    }

    public void modifyTask(Task toBeModifiedTask, Task modifiedTask)
    {
        _tasks.Add(modifiedTask);
        _tasks.Remove(toBeModifiedTask);
    }
}