﻿using Domain.Common;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IQueryRepository
    {
        int ExecuteNonQuery(string commandText);
    }
}
