using HashCode.App.Interfaces;
using HashCode.App.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode.App.Application
{
    public class ResultFileGenerator : IResultFileGenerator<Result>
    {
        private readonly ILogger<ResultFileGenerator> _logger;
        private readonly ApplicationConfig _appConfig;

        public ResultFileGenerator(ILogger<ResultFileGenerator> logger, ApplicationConfig appConfig)
        {
            _logger = logger;
            _appConfig = appConfig;
        }

        public async Task Generate(Result result)
        {
            var stopWatch = Stopwatch.StartNew();
            var dataString = new StringBuilder();
            var resultFilePath = Path.Combine(_appConfig.ResultsPath, $"{_appConfig.FileToProcess.Split('.')[0]}{_appConfig.ResultFileSuffix}");
            dataString.AppendLine(result.Items.Count.ToString());
            dataString.AppendLine(string.Join(" ", result.Items));
            using FileStream fs = File.OpenWrite(resultFilePath);
            byte[] info = new UTF8Encoding(true).GetBytes(dataString.ToString());
            await fs.WriteAsync(info, 0, info.Length);
            _logger.LogInformation("Result file generated in {0}, elapsed time: {1}s", resultFilePath, (float)stopWatch.ElapsedMilliseconds / 1000);
        }
    }
}
