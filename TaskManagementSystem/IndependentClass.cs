namespace TaskManagementSystem;

public class IndependentClass
{
    // User Fake Class
    private int userID;
    private string name;
    private List<Task> assignedTasks;

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
    
    //TaskList
    
}