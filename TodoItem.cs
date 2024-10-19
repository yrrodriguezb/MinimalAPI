namespace MinimalAPI;

public class TodoItem
{
  public int Id { get; set; }
  public string Name { get; set; }
  public bool IsCompleted { get; set; }

  public TodoItem()
  { 
    Name = string.Empty;
  }

  public TodoItem(string name)
  {
    Name = name;
  }
}