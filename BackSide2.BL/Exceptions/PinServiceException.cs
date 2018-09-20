﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BackSide2.BL.Exceptions
{
    [Serializable]
    public class PinServiceException : ApplicationException
    {
        public PinServiceException()
        {
        }

        public PinServiceException(string message) : base(message)
        {
        }

        public PinServiceException(string message, Exception ex) : base(message)
        {
            Ex = ex;
        }

        // Конструктор для обработки сериализации типа
        protected PinServiceException(SerializationInfo info,
            StreamingContext contex)
            : base(info, contex)
        {
        }

        public Exception Ex { get; }
    }
}