using Lab6.Http.Common;
using System.Threading.Tasks;

internal class Program
{
    private static object _locker = new object();

    public static async Task Main(string[] args)
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5214/api/")
        };

        var taskApiClient = new TaskApiClient(httpClient);

        await ManageTasks(taskApiClient);
    }

    private static async Task ManageTasks(ITaskApi taskApi)
    {
        //PrintMenu();

        while (true)
        {
            string[] weatherArray = new string[7]; // Создаём массив из 5 элементов

            // Заполняем массив данными о погоде
            weatherArray[0] = "Cloudy";
            weatherArray[1] = "Clear";
            weatherArray[2] = "Variable Cloud";
            weatherArray[3] = "Cloudy";
            weatherArray[4] = "Variable Cloud";
            weatherArray[5] = "Rain";
            weatherArray[6] = "Light rain";
            Console.Clear();
            var tasks = await taskApi.GetAllAsync();
            Console.Clear();
            Console.WriteLine($"| Id    |     NameCity         |      Weather    |");
            foreach (var task in tasks)
            {
                Console.WriteLine($"| {task.Id,5} | {task.Name,20} | {task.Active,15} | ");
            }
            Thread.Sleep(5000);
            Random random = new Random();

            int CityStatus = random.Next(1, 5);
            int CityStatus11 = random.Next(1, 7);
            Console.WriteLine(CityStatus);
            Console.WriteLine(CityStatus11);
            string CityStatus1 = CityStatus.ToString();
            var TaskIdString = CityStatus1;
            int.TryParse(TaskIdString, out var userId);
            var task1 = await taskApi.GetAsync(userId);
            var Name = task1?.Name;
            var Active = task1?.Active;

            var newTask = new TaskItem(
                id: task1.Id,
                name: task1?.Name,
                active: weatherArray[CityStatus11]
            );
            var addResult = await taskApi.UpdateAsync(CityStatus, newTask);
        }
    }
}