using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class EnumConstant
    {
        public enum WalletHistoryType
        {
            Recharge = 1, //User recharge
            AdminRecharge = 2, //Admin recharge for user
        }

        public enum RechargeStatus
        {
            Canceled = 0,
            Pending = 1,
            Approved = 2,
        }
    }
}
