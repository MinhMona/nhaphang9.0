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
            PermissionArray.CNWarehouse,
            PermissionArray.ContactUs,
            PermissionArray.CustomerBenefit,
            PermissionArray.CustomerTalk,
            PermissionArray.Menu,
            PermissionArray.Post,
            PermissionArray.PostCategory,
            PermissionArray.Service,
            PermissionArray.Step,
            PermissionArray.VNWarehouse,
            PermissionArray.VolumeFee,
            PermissionArray.WebConfiguration,
            PermissionArray.WeightFee
        };
    }
}
