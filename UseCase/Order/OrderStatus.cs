﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Order
{
    public enum OrderStatus
    {
        Success,
        QuantityInvalid = -1,
        Faild = -1,
    }
}
