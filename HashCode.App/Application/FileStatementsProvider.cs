using HashCode.App.Interfaces;
using HashCode.App.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode.App.Application
{
    public class FileStatementsProvider : IStatementsProvider<ProblemStatement>
    {
        private readonly ILogger<FileStatementsProvider> _logger;
        private readonly ApplicationConfig _appConfig;

        public FileStatementsProvider(ILogger<FileStatementsProvider> logger, ApplicationConfig appConfig)
        {
            _logger = logger;
            _appConfig = appConfig;
        }

        public async Task<ProblemStatement> GetProblemStatement()
        {
            var stopWatch = Stopwatch.StartNew();
            var fileToProcess = Path.Combine(_appConfig.StatementsPath, _appConfig.FileToProcess);
            var lines = await File.ReadAllLinesAsync(fileToProcess);
            var mainData = lines[0].Split(" ").Select(data => int.Parse(data)).ToList();
            var types = lines[1].Split(" ").Select(data => int.Parse(data)).ToList();
            var statement = new ProblemStatement(mainData[0], mainData[1], types);
            _logger.LogInformation("File loaded in {0}s", (float)stopWatch.ElapsedMilliseconds / 1000);
            return statement;
        }
    }
}
