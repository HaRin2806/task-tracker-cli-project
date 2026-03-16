using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Text.Json;

public class TaskManager
{
    private const string FileName = "task.json";

    private List<TaskItem> LoadTasks()
{
    if (!File.Exists(FileName))
    {
        File.WriteAllText(FileName, "[]");
    }
    string json = File.ReadAllText(FileName);

    return JsonSerializer.Deserialize<List<TaskItem>>(json);
}

private void SaveTasks(List<TaskItem> tasks)
{
    string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
    {
        WriteIndented = true
    });

    File.WriteAllText(FileName, json);
}
public void AddTask(string description)
{
    var tasks = LoadTasks();

    int newId = tasks.Count == 0 ? 1 : tasks[tasks.Count - 1].Id + 1;

    var task = new TaskItem
    {
        Id = newId,
        Description = description,
        Status = "todo",
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now
    };

    tasks.Add(task);

    SaveTasks(tasks);

    Console.WriteLine($"Task added successfully (ID: {newId})");
}
public void UpdateTask(int id, string description)
{
    var tasks = LoadTasks();

    var task = tasks.Find(t => t.Id == id);

    if (task == null)
    {
        Console.WriteLine("Task not found");
        return;
    }

    task.Description = description;
    task.UpdatedAt = DateTime.Now;

    SaveTasks(tasks);

    Console.WriteLine("Task updated");
}
public void DeleteTask(int id)
{
    var tasks = LoadTasks();

    var task = tasks.Find(t => t.Id == id);

    if (task == null)
    {
        Console.WriteLine("Task not found");
        return;
    }

    tasks.Remove(task);

    SaveTasks(tasks);

    Console.WriteLine("Task deleted");
}
public void MarkStatus(int id, string status)
{
    var tasks = LoadTasks();

    var task = tasks.Find(t => t.Id == id);

    if (task == null)
    {
        Console.WriteLine("Task not found");
        return;
    }

    task.Status = status;
    task.UpdatedAt = DateTime.Now;

    SaveTasks(tasks);

    Console.WriteLine($"Task marked as {status}");
}
public void ListTasks(string status = null)
{
    var tasks = LoadTasks();

    foreach (var task in tasks)
    {
        if (status == null || task.Status == status)
        {
            Console.WriteLine($"{task.Id} | {task.Description} | {task.Status}");
        }
    }
}
}

