﻿using log4net;
using PointsGenerator.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointsGenerator.ConsoleApp.Implementations
{
    public class LoggerService : ILoggerService
    {
        private readonly ILog logger;

        public LoggerService(ILog logger)
        {
            this.logger = logger;
        }

        public void Error(Exception ex)
        {
            logger.Error(ex);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void RunWithExceptionLogging(Action actionToRun, bool isSilent = false)
        {
            try { actionToRun(); }
            catch (Exception ex)
            {
                logger.Error("Error: ", ex);

                if (isSilent) return;

                throw;
            }
        }

        public T RunWithExceptionLogging<T>(Func<T> functionToRun, bool isSilent = false)
        {
            try { return functionToRun(); }
            catch (Exception ex)
            {
                logger.Error("Error: ", ex);

                if (isSilent) return default(T);

                throw;
            }
        }
    }
}