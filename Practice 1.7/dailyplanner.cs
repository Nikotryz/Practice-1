using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
namespace Practice_1._7
{
    class Program
    {    
        static void Main()
        {
            string path = "C:/Users/nikit/OneDrive/Рабочий стол/Practice 1/Solution1/Practice 1.7/TasksData.json";        
            List<TaskModel> allTasks = JsonConvert.DeserializeObject<List<TaskModel>>(File.ReadAllText(path));        
            if (allTasks == null) allTasks = new List<TaskModel>();
            while(true)        
            {
                Console.WriteLine("\nВведите команду\n[add] - добавить задачу\n[delete] - удалить задачу\n[edit] - отредактировать задачу\n[view all] - просмотреть все задачи\n[view past] - просмотреть прошедшие задачи\n[view upcoming] - просмотреть предстоящие задачи\n[view today] - просмотреть задачи на сегодня\n[view tomorrow] - просмотреть задачи на завтра\n[view week] - просмотреть задачи на неделю\n[exit] - выйти из программы");            
                string command = Console.ReadLine();
                Console.Clear();
                if (command == "add")            
                {
                    Console.Write("Введите название задачи: ");                
                    string title = Console.ReadLine();
                    Console.Write("Введите описание задачи: ");                
                    string description = Console.ReadLine();
                    Console.Write("До какого числа нужно сделать? (ГГГГ-ММ-ДД): ");                
                    string deadline = Console.ReadLine();
                    TaskModel task = new TaskModel(title, description, deadline);
                    int lastId;
                    if (allTasks.Count == 0) lastId = 0;
                    else lastId = allTasks.Last().Id;
                    task.SetId(lastId + 1);
                    allTasks.Add(task);
                    File.WriteAllText(path, JsonConvert.SerializeObject(allTasks));
                    Console.WriteLine("Задача была сохранена");
                    continue;
                }
                if (command == "delete")
                {
                    Console.Write("Какую задачу удалить? (Введите её номер): ");
                    int idToRemove = int.Parse(Console.ReadLine());
                    allTasks = JsonConvert.DeserializeObject<List<TaskModel>>(File.ReadAllText(path));
                    TaskModel taskToDelete = allTasks.FirstOrDefault(x => x.Id == idToRemove);
                    if (taskToDelete != null)
                    {
                        allTasks.Remove(taskToDelete);
                        File.WriteAllText(path, JsonConvert.SerializeObject(allTasks));
                        Console.WriteLine("Задача была удалена");
                    }
                    else Console.WriteLine("Задача с этим номером отсутствует");
                    continue;
                }
                if (command == "edit")
                {
                    Console.Write("Какую задачу отредактировать? (Введите её номер): ");
                    int idToEdit = int.Parse(Console.ReadLine());
                    allTasks = JsonConvert.DeserializeObject<List<TaskModel>>(File.ReadAllText(path));
                    TaskModel taskToEDit = allTasks.FirstOrDefault(x => x.Id == idToEdit);
                    Console.Clear();
                    if (taskToEDit != null)
                    {
                        while (true)
                        {
                            Console.WriteLine("Какой параметр вы хотите изменить?\n — title\n — description\n — deadline ");
                            string parameter = Console.ReadLine();
                            Console.Clear();
                            if (parameter == "title")
                            {
                                Console.Write("Введите новое название: ");
                                taskToEDit.Title = Console.ReadLine();
                                Console.WriteLine("Название отредактировано успешно\nИзменить что-то ещё? (yes, no)");
                                string choice = Console.ReadLine();
                                Console.Clear();
                                if (choice == "yes") continue;
                                if (choice == "no") break;
                            }
                            if (parameter == "description")
                            {
                                Console.Write("Введите новое описание: ");
                                taskToEDit.Description = Console.ReadLine();
                                Console.WriteLine("Описание отредактировано успешно\nИзменить что-то ещё? (yes, no)");
                                string choice = Console.ReadLine();
                                Console.Clear();
                                if (choice == "yes") continue;
                                if (choice == "no") break;
                            }
                            if (parameter == "deadline")
                            {
                                Console.Write("Введите новый дедлайн (ГГГГ-ММ-ДД): ");
                                taskToEDit.Deadline = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Дедлайн отредактирован успешно\nИзменить что-то ещё? (yes, no)");
                                string choice = Console.ReadLine();
                                Console.Clear();
                                if (choice == "yes") continue;
                                if (choice == "no") break;
                            }
                        }
                        allTasks[idToEdit-1] = taskToEDit;
                        File.WriteAllText(path, JsonConvert.SerializeObject(allTasks));
                    }
                    else Console.WriteLine("Задача с этим номером отсутствует");
                    continue;
                }
                if (command == "view all")
                {
                    allTasks = JsonConvert.DeserializeObject<List<TaskModel>>(File.ReadAllText(path));
                    if (allTasks.Count == 0)
                    {
                        Console.WriteLine("Задачи отсутствуют");
                        continue;
                    }
                    foreach (TaskModel view in allTasks)
                    {
                        Console.WriteLine($"Task {view.Id}:\nНазвание: {view.Title}\nОписание: {view.Description}\nДедлайн: {view.Deadline}");
                    }
                    continue;
                }
                if (command == "view past")
                {
                    allTasks = JsonConvert.DeserializeObject<List<TaskModel>>(File.ReadAllText(path));
                    if (allTasks.Count == 0)
                    {
                        Console.WriteLine("Задачи отсутствуют");
                        continue;
                    }
                    int count = 0;
                    foreach (TaskModel view in allTasks)
                    {
                        if (view.Deadline < DateTime.Now)
                        {
                            Console.WriteLine($"Task {view.Id}:\nНазвание: {view.Title}\nОписание: {view.Description}\nДедлайн: {view.Deadline}");
                            count += 1;
                        }
                    }
                    if (count == 0) Console.WriteLine("Прошедших задач ещё нет");
                    continue;
                }
                if (command == "view upcoming")
                {
                    allTasks = JsonConvert.DeserializeObject<List<TaskModel>>(File.ReadAllText(path));
                    if (allTasks.Count == 0)
                    {
                        Console.WriteLine("Задачи отсутствуют");
                        continue;
                    }
                    int count = 0;
                    foreach (TaskModel view in allTasks)
                    {
                        if (view.Deadline > DateTime.Now)
                        {
                            Console.WriteLine($"Task {view.Id}:\nНазвание: {view.Title}\nОписание: {view.Description}\nДедлайн: {view.Deadline}");
                            count += 1;
                        }
                    }
                    if (count == 0) Console.WriteLine("Предстоящие задачи отсутствуют");
                    continue;
                }
                if (command == "view today")
                {
                    allTasks = JsonConvert.DeserializeObject<List<TaskModel>>(File.ReadAllText(path));
                    if (allTasks.Count == 0)
                    {
                        Console.WriteLine("Задачи отсутствуют");
                        continue;
                    }
                    int count = 0;
                    foreach (TaskModel view in allTasks)
                    {
                        if (view.Deadline == DateTime.Today)
                        {
                            Console.WriteLine($"Task {view.Id}:\nНазвание: {view.Title}\nОписание: {view.Description}\nДедлайн: {view.Deadline}");
                            count += 1;
                        }
                    }
                    if (count == 0) Console.WriteLine("Задачи на сегодня отсутствуют");
                    continue;
                }
                if (command == "view tomorrow")
                {
                    allTasks = JsonConvert.DeserializeObject<List<TaskModel>>(File.ReadAllText(path));
                    if (allTasks.Count == 0)
                    {
                        Console.WriteLine("Задачи отсутствуют");
                        continue;
                    }
                    int count = 0;
                    foreach (TaskModel view in allTasks)
                    {
                        if (view.Deadline == DateTime.Today.AddDays(1))
                        {
                            Console.WriteLine($"Task {view.Id}:\nНазвание: {view.Title}\nОписание: {view.Description}\nДедлайн: {view.Deadline}");
                            count += 1;
                        }
                    }
                    if (count == 0) Console.WriteLine("Задачи на завтра отсутствуют");
                    continue;
                }
                if (command == "view week")
                {
                    allTasks = JsonConvert.DeserializeObject<List<TaskModel>>(File.ReadAllText(path));
                    if (allTasks.Count == 0)
                    {
                        Console.WriteLine("Задачи отсутствуют");
                        continue;
                    }
                    int count = 0;
                    foreach (TaskModel view in allTasks)
                    {
                        if (view.Deadline >= DateTime.Today && view.Deadline <= DateTime.Today.AddDays(7))
                        {
                            Console.WriteLine($"Task {view.Id}:\nНазвание: {view.Title}\nОписание: {view.Description}\nДедлайн: {view.Deadline}");
                            count += 1;
                        }
                    }
                    if (count == 0) Console.WriteLine("Задачи на этой недели отсутствуют");
                    continue;
                }
                if (command == "exit") break;
                else Console.WriteLine("Неправильный формат ввода");
            }    
        }
    }
    public class TaskModel
    {    
        public int Id { get; set; }
        public string Title { get; set; }    
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskModel(string title, string description, string deadline)    
        {
            Title = title;        
            Description = description;
            Deadline = DateTime.Parse(deadline);    
        }
        public void SetId(int id)
        {        
            Id = id;
        }
    }
}