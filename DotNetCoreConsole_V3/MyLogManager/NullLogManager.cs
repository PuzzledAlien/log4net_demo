//=====================================================

//Copyright (C) 2016-2019 Fanjia

//All rights reserved

//CLR版 本:    4.0.30319.42000

//创建时间:     2019/1/16 16:14:12

//创 建 人:   徐晓航

//======================================================

using System;
using System.IO;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace MyLogManager
{
    public class NullLogManager
    {
        private static ILoggerRepository _loggerRepository;

        private static ILoggerRepository LoggerRepository
        {
            get
            {
                if (_loggerRepository != null)
                {
                    return _loggerRepository;
                }
                _loggerRepository = LogManager.CreateRepository(nameof(NullLogManager));
                XmlConfigurator.ConfigureAndWatch(_loggerRepository, new FileInfo("log4net.config"));
                return _loggerRepository;
            }
        }

        public static ILog GetMyLog<T>(T t)
        {
            return LogManager.GetLogger(LoggerRepository.Name, t.GetType());
        }

        public static ILog GetMyLog(object obj)
        {
            return LogManager.GetLogger(LoggerRepository.Name, obj.GetType());
        }

        public static ILog GetMyLog(Type type)
        {
            return LogManager.GetLogger(LoggerRepository.Name, type);
        }

        public static ILog GetMyLog()
        {
            return LogManager.GetLogger(LoggerRepository.Name, nameof(GetMyLog));
        }
    }
}
