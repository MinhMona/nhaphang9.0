using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public static class NotificationTemplate
    {
        public static readonly string NEW_CUSTOMER= "Có khách hàng mới với UserName là {0}";
        public static readonly string NEW_COMPLAIN = "Có đơn khiếu nại mới cho đơn hàng {0}";
        public static readonly string DONE_COMPLAIN = "Người quản lý đã duyệt đơn khiếu nại cho đơn hàng {0}";
        public static readonly string DEL_COMPLAIN = "Người quản lý đã hủy đơn khiếu nại cho đơn hàng {0}";
        public static readonly string NEW_WITHDRAW = "Có yêu cầu rút tiền mới từ {0}";
        public static readonly string DONE_WITHDRAW = " Người quản lý đã duyệt lệnh rút tiền";
        public static readonly string DEL_WITHDRAW = " Người quản lý đã hủy lệnh rút tiền";
        public static readonly string NEW_RECHARGE = "Có yêu cầu nạp tiền mới từ {0}";
        public static readonly string DONE_RECHARGE = "Bạn vừa được nạp {0} VNĐ vào tài khoản";
        public static readonly string DEL_RECHARGE = "Yêu cầu nạp {0} đã hủy";
        public static readonly string NEW_ORDER = "Có đơn hàng {0} mới với ID là {1}";
        public static readonly string UPDATE_PRODUCT = "Có cập nhật mới về sản phẩm thuộc đơn hàng {0}";
        public static readonly string DEPOSIT_MAIN_ORDER = "Đơn hàng mua hộ {0} đã được đặt cọc";
        public static readonly string PAYMENT_ORDER = "Đơn {0} ID {1} đã được thanh toán";
        public static readonly string ORDERED_MAIN_ORDER = "Đơn hàng mua hộ {0} đã được mua hàng";
        public static readonly string REMOVE_PRODUCT = "Đơn hàng mua hộ {0} có sản phẩm bị xóa";
        public static readonly string ADD_PRODUCT = "Thêm sản phẩm {0} vào giỏ hàng thành công";
        public static readonly string EMPTY_PRODUCT = "Đơn hàng  mua hộ {0} có sản phẩm bị hết hàng";
        public static readonly string VN_WAREHURSE_ORDER = "Đơn {0} ID {1} đã về kho Việt Nam";
        public static readonly string TQ_WAREHURSE_ORDER = "Đơn {0} ID {1} đã về kho Trung Quốc";
        public static readonly string DONE_ORDER = "Đơn {0} ID {1} của bạn đã được hoàn thành";
        public static readonly string DEL_ORDER = "Đơn {0} ID {1} của bạn đã bị hủy";
        public static readonly string REFUND_ORDER = "Bạn được hoàn {0} VNĐ từ đơn {1} ID {2} ";
        public static readonly string CONTACT_US = "Có người dùng cần liên hệ";
        public static readonly string CHECKED_ORDER = "Đơn {0} ID {1} đã được duyệt";
    }

    public static class NotificationOrderTypeTemplate
    {
        public static readonly string MAIN_ORDER = "hàng mua hộ";
        public static readonly string MAIN_ORDER_OTHER = "hàng mua hộ khác";
        public static readonly string TRANSPORTATION_ORDER = "hàng ký gửi";
        public static readonly string PAYMENT_ORDER = "thanh toán hộ";
    }
    public enum NotificationTag
    {
        Finance = 1,
        Order = 2,
        Cart = 3,
        Complain = 4
    }

    public enum NotificationTitleIndex
    {
        NewCustomer = 1,
        NewComplain = 2,
        DoneComplain = 3,
        DelComplain = 4,
        NewWithdraw = 5,
        DoneWithdraw = 6,
        DelWithdraw = 7,
        NewRecharge = 8,
        DoneRecharge = 9,
        DelRecharge = 10,
        NewOrder = 11,
        UpdateProduct = 12,
        DepositMainOrder = 13,
        PaymentOrder = 14,
        OrderedMainOrder = 15,
        RemoveProduct = 16,
        AddProduct = 17,
        EmptyProduct = 18,
        VnWarehurseOrder = 19,
        TqWarehurseOrder = 20,
        DoneOrder = 21,
        DelOrder = 22,
        RefundOrder = 23,
        ContactUs = 24,
        CheckedOrder = 25
    }

    public static class NotificationTitle
    {
        public static string[] Title = {
            "Có tài khoản mới",
            "Có khiếu nại mới",
            "Có khiếu nại được duyệt",
            "Có khiếu nại bị hủy",
            "Có yêu cầu rút tiền mới",
            "Có yêu cầu rút tiền được duyệt",
            "Có yêu cầu rút tiền bị hủy",
            "Có yêu cầu nạp tiền mới",
            "Có yếu cầu nạp tiền được duyệt",
            "Có yêu cầu nạp tiền bị hủy",
            "Có đơn hàng mới",
            "Có sản phẩm đơn hàng được chỉnh sửa",
            "Có đơn hàng được đặt cọc",
            "Có đơn hàng được thanh toán",
            "Có đơn hàng đã được mua hàng",
            "Có sản phẩm đơn hàng bị xóa",
            "Có sản phẩm được thêm vào giỏ hàng",
            "Có sản phẩm đơn hàng hết hàng",
            "Đơn hàng đã về kho Việt Nam",
            "Đơn hàng đã về kho Trung Quốc",
            "Có đơn hàng hoàn thành",
            "Có đơn hàng bị hủy",
            "Có đơn hàng hoàn tiền",
            "Có khách hàng cần liên hệ",
            "Có đơn hàng được duyệt"};
            
    }
}
