using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public static class PermissionArray
    {

        /*
         *              Add  Delete  Update  View    Upload
         * Admin
         * EndUser
         * Saler
         * Ordering
         * CNWarehouse
         * VNWarehouse
         * Accountant
         * Manager
         * Marketing
         * 1 - có quyền; 
         * 0 - không quyền
         */

        //#region Account
        //public static int[,] Account = new int[,]
        //{
        //    //Add  Delete  Update  View    Upload
        //    { 1, 1, 1, 1, 1 },
        //    { 0, 0, 1, 1, 1 },
        //    { 0, 0, 0, 1, 1 },
        //    { 0, 0, 0, 1, 1 },
        //    { 0, 0, 0, 1, 1 },
        //    { 0, 0, 0, 1, 1 },
        //    { 0, 0, 0, 1, 1 },
        //    { 1, 1, 1, 1, 1 },
        //    { 0, 0, 0, 1, 1 }
        //};
        //#endregion

        #region Account
        public static int[,] Account = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };
        #endregion

        #region CNWarehouse
        public static int[,] CNWarehouse = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 }
        };
        #endregion

        #region Account
        public static int[,] ContactUs = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 }
        };
        #endregion

        #region CustomerBenefit
        public static int[,] CustomerBenefit = new int[,] 
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };
        #endregion

        #region CustomerTalk
        public static int[,] CustomerTalk = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };
        #endregion

        #region Menu
        public static int[,] Menu = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };
        #endregion

        #region Post
        public static int[,] Post = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };
        #endregion

        #region PostCategory
        public static int[,] PostCategory = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };
        #endregion

        #region Service
        public static int[,] Service = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };
        #endregion

        #region ShippingType
        public static int[,] ShippingType = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 }
        };
        #endregion

        #region Step
        public static int[,] Step = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        };
        #endregion

        #region VNWarehouse
        public static int[,] VNWarehouse = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 }
        };
        #endregion

        #region VolumeFee
        public static int[,] VolumeFee = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 }
        };
        #endregion

        #region WebConfiguration
        public static int[,] WebConfiguration = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 }
        };
        #endregion

        #region WeightFee
        public static int[,] WeightFee = new int[,]
        {
            //Add  Delete  Update  View    Upload
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 }
        };
        #endregion
    }
}
