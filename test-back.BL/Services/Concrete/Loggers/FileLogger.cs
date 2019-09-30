using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TestBack.BL.Services.Abstraction;
using TestBack.Models;
using System.Linq;
using TestBack.BL.Common;

namespace TestBack.BL.Services.Concrete.Loggers
{
    internal class FileLogger : ILogger
    {
        private const string fileName = "log.txt";
        private readonly string filePath;

        public FileLogger()
        {
            filePath = $"{Directory.GetCurrentDirectory()}/{fileName}";
        }

        public async Task Log(string message)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Write, 4096, true))
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    await sw.WriteLineAsync($"{DateTime.Now} {message}");
                }
            }
            catch(Exception ex)
            {
                throw new LoggerException(ex.Message, ex);
            }
        }

        public async Task Log(Result item)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(   $"{nameof(item.ProjectId)} {item.ProjectId} " +
                                  $"{nameof(item.Success)}   {item.Success } " +
                                  $"{nameof(item.Errors)}    {item?.Errors?.First()} " +
                                  $"{nameof(item.Data)}      {item.Data}");

            await Log(builder.ToString());
        }
    }
}
