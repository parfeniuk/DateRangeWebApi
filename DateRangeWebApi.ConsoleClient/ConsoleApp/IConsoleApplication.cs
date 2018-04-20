using System;
using System.Collections.Generic;
using System.Text;

namespace DateRangeWebApi.ConsoleClient.ConsoleApp
{
    public interface IConsoleApplication
    {
        void Run();
        string DisplayMenuResult();
        void UserCommandApply(string choice);
        bool Continue(string choice);
        void Finish();
    }
}
