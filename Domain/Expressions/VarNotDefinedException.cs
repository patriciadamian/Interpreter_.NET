﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.Expressions
{
    class VarNotDefinedException:DomainException
    {
        public VarNotDefinedException() { }
    }
}
