static void Main()
{
    List<string> tasks = new List<string>();
    Console.WriteLine("Менеджер задач");
    Console.WriteLine("Здесь вы можете записывать и хранить ваши задачи");
    Console.WriteLine();

    while (true)
    {
        if (!DoAction(tasks))
        {
            return;
        }

        Console.WriteLine("Далее:");
        Console.ReadLine();
    }

}

static void PrintMainMenu()
{
    Console.WriteLine("1 - Добавить задачу");
    Console.WriteLine("2 - Показать список");
    Console.WriteLine("3 - Удалить по номеру");
    Console.WriteLine("4 - Очистить всё");
    Console.WriteLine("5 - Выход");
}

static int NumberOfAction()
{
    const int listLength = 5;
    var numberOfAction = 0;
    
    while (numberOfAction < 1)
    {
        Console.WriteLine("Выберите действие:");
        PrintMainMenu();
        Console.WriteLine("Введите номер действия:");
        
        var isParsed = int.TryParse(Console.ReadLine(), out var number);
        
        if (!isParsed)
        {
            Console.WriteLine("Вы ввели некорректное значение. Пожалуйста, введите число.");
            continue;
        }
        
        if (number < 1 || number > listLength)
        {
            Console.WriteLine("Вы ввели некорректный номер задачи! Попробуйте ещё раз.");
            continue;
        }

        numberOfAction = number;
    }
    
    return numberOfAction;
}

static void AddTheTask(List<string> tasksList)
{
    var task = "";
    while (string.IsNullOrEmpty(task)) 
    {
        Console.WriteLine("Введите задачу:");
        task = Console.ReadLine();
    }
    
    tasksList.Add(task);
    
    Console.WriteLine("Задача добавлена!");
}

static void PrintTasksList(List<string> tasksList)
{
    if (tasksList.Count == 0)
    {
        Console.WriteLine("У вас пока нет добавленных задач.");
        return;
    }

    var counter = 0;
    
    Console.WriteLine("Ваш текущий список задач:");
    
    foreach (var task in tasksList)
    {
        counter += 1;
        Console.WriteLine($"{counter}. {task}");
    }
}

static void DeleteTheTask(List<string> tasksList)
{
    Console.WriteLine("Выберите задачу, которую вы хотите удалить.");
    PrintTasksList(tasksList);
    var indexOfTask = -1;
    
    while (indexOfTask < 0)
    {
        Console.WriteLine("Введите номер задачи: ");
        var isParsed = int.TryParse(Console.ReadLine(), out var number);
        
        if (!isParsed)
        {
            Console.WriteLine("Вы ввели некорректный номер! Пожалуйста, введите число.");
            continue;
        }

        if (number < 1 || number > tasksList.Count)
        {
            Console.WriteLine("Вы ввели некорректный номер задачи! Попробуйте ещё раз.");
            continue;
        }
        
        indexOfTask = number - 1;
    }
    
    tasksList.RemoveAt(indexOfTask);
    
    Console.WriteLine("Задача удалена");
}

static void ClearAll(List<string> tasksList)
{
    tasksList.Clear();
    Console.WriteLine("Ваш список очищен.");
}

static bool DoAction(List<string> tasks)
{
    var number = NumberOfAction();

    switch (number)
    {
        case 1:
            AddTheTask(tasks);
            break;
        case 2:
            PrintTasksList(tasks);
            break;
        case 3:
            DeleteTheTask(tasks);
            break;
        case 4:
            ClearAll(tasks);
            break;
        case 5:
            return false;
    }

    return true;
}

Main();