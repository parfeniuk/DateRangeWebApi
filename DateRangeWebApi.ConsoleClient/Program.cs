using DateRangeWebApi.Service.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using DateRangeWebApi.ConsoleClient.ConsoleApp;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace DateRangeWebApi.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApplication app = new ConsoleApplication();
            try
            {
                app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
