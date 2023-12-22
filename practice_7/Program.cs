using Newtonsoft.Json;

namespace practice_7
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("[get by id];[get by title];[get by date];[get all];[add new];[exit]");
                Console.Write("Write Command: ");
                string? command = Console.ReadLine();
                switch (command)
                {
                    case "get by id":
                        var taskById = GetTaskById();
                        if (taskById == null) continue;
                        Console.WriteLine($"Title: {taskById.Title}; Description: {taskById.Description}; Date: {taskById.Date}");
                        var editTaskById = EditTask(taskById);
                        if (editTaskById == null) continue;
                        Console.WriteLine($"Title: {editTaskById.Title}; Description: {editTaskById.Description}; Date: {editTaskById.Date}");
                        continue;
                    case "get by title":
                        var taskByTitle = GetTaskByTitle();
                        if (taskByTitle == null) continue;
                        Console.WriteLine($"Title: {taskByTitle.Title}; Description: {taskByTitle.Description}; Date: {taskByTitle.Date}");
                        var editTaskByTitle = EditTask(taskByTitle);
                        if (editTaskByTitle == null) continue;
                        Console.WriteLine($"Title: {editTaskByTitle.Title}; Description: {editTaskByTitle.Description}; Date: {editTaskByTitle.Date}");
                        continue;
                    case "get by date":
                        var tasksByDate = GetTasksByDate();
                        if(tasksByDate!=null && tasksByDate.Count!=0) foreach (var task in tasksByDate) 
                            Console.WriteLine($"Title: {task.Title}; Description: {task.Description}; Date: {task.Date}");
                        else Console.WriteLine("ERROR, not found tasks");
                        continue;
                    case "get all":
                        var tasksAll = GetTasks();
                        if(tasksAll!=null) foreach (var task in tasksAll)
                            Console.WriteLine($"Title: {task.Title}; Description: {task.Description}; Date: {task.Date}");
                        else Console.WriteLine("ERROR, not found tasks");
                        continue;
                    case "add new":
                        var taskNew = AddNewTask();
                        Console.WriteLine($"Title: {taskNew.Title}; Description: {taskNew.Description}; Date: {taskNew.Date}");
                        continue;
                    case "exit":
                        break;
                    default:
                        Console.WriteLine("ERROR, not found command");
                        continue;
                }
                break;
            }
        }

        private static TaskItem? EditTask(TaskItem task)
        {
            var allTasks = GetTasks();
            if (allTasks == null) return null;
            int taskIndex = allTasks.FindIndex(x => x.Id == task.Id);
            Console.WriteLine("[edit];[delete];[exit]");
            Console.Write("Write command: ");
            string? command = Console.ReadLine();
            switch (command)
            {
                case "edit":
                    Console.Write("title: ");
                    string? title = Console.ReadLine();
                    Console.Write("description: ");
                    string? description = Console.ReadLine();
                    Console.Write("date: ");
                    string? dateString = Console.ReadLine();
                    TaskItem editTaskItem = new TaskItem(
                        task.Id,
                        !string.IsNullOrEmpty(title) ? title : task.Title,
                        !string.IsNullOrEmpty(description) ? description : task.Description,
                        !string.IsNullOrEmpty(dateString) ? DateOnly.Parse(dateString) : task.Date);
                    allTasks[taskIndex] = editTaskItem;
                    string serializeObjectEdit = JsonConvert.SerializeObject(allTasks, Formatting.Indented);
                    File.WriteAllText(FilePath, serializeObjectEdit);
                    return editTaskItem;
                case "delete":
                    allTasks.RemoveAt(taskIndex);
                    string serializeObjectDelete = JsonConvert.SerializeObject(allTasks, Formatting.Indented);
                    File.WriteAllText(FilePath, serializeObjectDelete);
                    break;
                case "exit":
                    break;
                default:
                    Console.WriteLine("ERROR, not found command");
                    break;
            }
            return null;
        }

        private static TaskItem? GetTaskByTitle()
        {
            Console.Write("Write Title: ");
            string? needTitle = Console.ReadLine();
            var tasks = GetTasks();
            try
            {
                var task = tasks?.Single(x => x.Title == needTitle);
                return task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private static TaskItem AddNewTask()
        {
            Console.Write("Write Title: ");
            string? title = Console.ReadLine();
            Console.Write("Write Description: ");
            string? description = Console.ReadLine();
            Console.Write("Write Date: ");
            string? dateString = Console.ReadLine();
            var tasks = GetTasks();
            TaskItem task = new TaskItem(
                tasks?.Max(x => x.Id) + 1 ?? 0,
                !string.IsNullOrEmpty(title) ? title : string.Empty,
                !string.IsNullOrEmpty(description) ? description : string.Empty,
                !string.IsNullOrEmpty(dateString) ? DateOnly.Parse(dateString) : DateOnly.FromDateTime(DateTime.Now).AddDays(7));
            tasks?.Add(task);
            string serializeObject = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(FilePath, serializeObject);
            return task;
        }

        private static List<TaskItem>? GetTasksByDate()
        {
            var allTasks = GetTasks();
            Console.WriteLine("[today];[tomorrow];[this week];[this month];[done];[not done]");
            Console.Write("Write time: ");
            string? time = Console.ReadLine();
            switch (time)
            {
                case "today":
                    return allTasks?.FindAll(x => x.Date == DateOnly.FromDateTime(DateTime.Now));
                case "tomorrow":
                    return allTasks?.FindAll(x => x.Date == DateOnly.FromDateTime(DateTime.Now).AddDays(1));
                case "this week":
                    return allTasks?.FindAll(x =>
                        x.Date > DateOnly.FromDateTime(DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek)) &&
                        x.Date <= DateOnly.FromDateTime(DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek + 7)));
                case "this month":
                    return allTasks?.FindAll(x => x.Date.Month == DateTime.Now.Month);
                case "not done":
                    return allTasks?.FindAll(x => x.Date >= DateOnly.FromDateTime(DateTime.Now));
                case "done":
                    return allTasks?.FindAll(x => x.Date < DateOnly.FromDateTime(DateTime.Now));
                case "exit":
                    return null;
                default:
                    Console.WriteLine("ERROR, not found command");
                    return null;
            }
        }

        private static TaskItem? GetTaskById()
        {
            Console.Write("Write Id: ");
            string? needIdString = Console.ReadLine();
            int needId = !string.IsNullOrEmpty(needIdString) ? int.Parse(needIdString) : 0;
            var tasks = GetTasks();
            try
            {
                var task = tasks?.Single(x => x.Id == needId);
                return task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private static List<TaskItem>? GetTasks()
        {
            try
            {
                using var jsonFile = new StreamReader(FilePath);
                string jsonString = jsonFile.ReadToEnd();
                jsonFile.Close();
                List<TaskItem>? tasks = JsonConvert.DeserializeObject<List<TaskItem>>(jsonString);
                return tasks;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private const string FilePath = "../../../Tasks.json";
    }
}