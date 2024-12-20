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
        assignedTasks = new List<Task>();
    }

    public void assignTasks(List<Task> tasksToBeAssigned)
    {
        if (tasksToBeAssigned != null)
        {
            for (int i = 0; i < tasksToBeAssigned.Count; i++)
            {
                assignedTasks.Add(tasksToBeAssigned[i]);
            }
        }
    }

    public List<Task> getAssignedTasks()
    {
        return assignedTasks;
    }
        
    public string getName()
    {
        return name;
    }
}