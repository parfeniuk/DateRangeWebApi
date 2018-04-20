using System;
using System.Globalization;
using DateRangeWebApi.ConsoleClient.WebClient;

namespace DateRangeWebApi.ConsoleClient.ConsoleApp
{
    public class ConsoleApplication : IConsoleApplication
    {
        private HttpClient client;

        public ConsoleApplication()
        {
            client = new HttpClient();
        }

        public bool Continue(string choice)
        {
            if (string.IsNullOrEmpty(choice)) return true;
            if (choice.ToLower() != Commands.exit.ToString().ToLower()) return true;
            else return false;
        }

        public string DisplayMenuResult()
        {
            Console.WriteLine("\r\nСписок команд:\r\n");
            Console.WriteLine($"{Commands.create.ToString()} - Ввести новый диапазон дат");
            Console.WriteLine($"{Commands.getall.ToString()} - Просмотр всех диапазонов дат");
            Console.WriteLine($"{Commands.getintersect.ToString()} - Получить диапазон дат, который пересекаются с заданным диапазоном");
            Console.WriteLine($"{Commands.exit.ToString()}");
            Console.WriteLine($"\r\nВведите команду: \r\n");
            var result = Console.ReadLine();
            Console.Clear();
            return result;
        }

        public void Finish()
        {
            Console.WriteLine("Finished!\n");
            Console.ReadLine();
        }

        public void Run()
        {
            string choice;
            do
            {
                choice = DisplayMenuResult();
                UserCommandApply(choice);
            } while (Continue(choice));
        }

        public void UserCommandApply(string choice)
        {
            if (Enum.IsDefined(typeof(Commands), choice.ToLower()))
            {
                switch ((Commands)Enum.Parse(typeof(Commands), choice, true))
                {
                    case (Commands.getall):// Start Test
                        {
                            client.GetAll();
                        }
                        break;
                    case (Commands.getintersect): // Test Results
                        {
                            Console.WriteLine("Введите начальную дату диапазона: ");
                            DateTime dateStart;
                            if (!DateTime.TryParse(Console.ReadLine(),
                                CultureInfo.CurrentCulture,DateTimeStyles.None, out dateStart))
                            {
                                Console.WriteLine("Неверный формат даты!");
                                break;
                            };
                            Console.WriteLine("Введите конечную дату диапазона: ");
                            DateTime dateEnd;
                            if (!DateTime.TryParse(Console.ReadLine(),
                                CultureInfo.CurrentCulture, DateTimeStyles.None, out dateEnd))
                            {
                                Console.WriteLine("Неверный формат даты!");
                                break;
                            };
                            client.GetIntersected(dateStart, dateEnd);
                        }
                        break;
                    case (Commands.create): // Test Results
                        {
                            Console.WriteLine("Введите начальную дату диапазона: ");
                            DateTime dateStart;
                            if (!DateTime.TryParse(Console.ReadLine(), out dateStart))
                            {
                                Console.WriteLine("Неверный формат даты!");
                                break;
                            };
                            Console.WriteLine("Введите конечную дату диапазона: ");
                            DateTime dateEnd;
                            if (!DateTime.TryParse(Console.ReadLine(), out dateEnd))
                            {
                                Console.WriteLine("Неверный формат даты!");
                                break;
                            };
                            client.Create(dateStart, dateEnd);
                        }
                        break;
                    case Commands.exit: // Exit
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Введена неверная команда");
            }
        }
    }
}
