using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class PermissionList
    {
        public static readonly List<int[,]> Permissions = new List<int[,]>
        {
            PermissionArray.Account,
            PermissionArray.WebConfiguration,
            PermissionArray.CustomerBenefit,
            PermissionArray.CustomerTalk,
            PermissionArray.Step,
            PermissionArray.Service
        };
    }
}
