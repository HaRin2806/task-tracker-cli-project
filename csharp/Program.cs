class Program
{
    static void Main(string[] args)
    {
        var manager = new TaskManager();

        if (args.Length == 0)
        {
            Console.WriteLine("No command provided");
            return;
        }

        string command = args[0];

        switch (command)
        {
            case "add":
                manager.AddTask(args[1]);
                break;

            case "update":
                manager.UpdateTask(int.Parse(args[1]), args[2]);
                break;

            case "delete":
                manager.DeleteTask(int.Parse(args[1]));
                break;

            case "mark-in-progress":
                manager.MarkStatus(int.Parse(args[1]), "in-progress");
                break;

            case "mark-done":
                manager.MarkStatus(int.Parse(args[1]), "done");
                break;

            case "list":

                if (args.Length == 1)
                    manager.ListTasks();
                else
                    manager.ListTasks(args[1]);

                break;

            default:
                Console.WriteLine("Unknown command");
                break;
        }
    }
}