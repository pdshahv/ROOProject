﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions
{
    public class BadRequestException :Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }

        public BadRequestException(string message, string details) : base(message)
        {
            details = details;
        }

        public string? Details { get; }
    }
}
