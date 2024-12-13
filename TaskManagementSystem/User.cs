namespace TaskManagementSystem;

public class User
{
    private int userID;
    private string name;
    private List<Task> assignedTasks;

    public User(int userId, string name)
    {
        userID = userId;
        this.name = name;
    }

    public void assignTasks(List<Task> tasksToBeAssigned)
    {
        for (int i = 0; i < tasksToBeAssigned.Count; i++)
        {
            assignedTasks.Add(tasksToBeAssigned[i]);
        }
    }

    public List<Task> getAssignedTasks()
    {
        return assignedTasks;
    }
    
    public string GetName()
    {
        return name;
    }
}