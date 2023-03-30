using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.HomePageModels
{
    public class CustomerBenefitModel : HomeModel
    {
        public int? Type { get; set; }

        public string TypeName
        {
            get
            {
                switch (Type)
                {
                    case 1:
                        return "Cam kết của chúng tôi";
                    case 2:
                        return "Quyền lợi của khách hàng";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
