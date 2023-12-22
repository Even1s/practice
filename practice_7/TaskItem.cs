namespace practice_7;

public class TaskItem
{
    public int Id { get; }
    public string Title { get; }
    public string Description { get; }
    public DateOnly Date { get; }

    public TaskItem(int id, string title, string description, DateOnly date)
    {
        Id = id;
        Title = title;
        Description = description;
        Date = date;
    }
}