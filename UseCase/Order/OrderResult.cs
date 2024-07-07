using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Order
{
    public class OrderResult
    {
        public string Message { get; }
        public OrderStatus statusCode { get; }

        public OrderResult(string message, OrderStatus statusCode)
        {
            Message = message;
            this.statusCode = statusCode;
        }
    public static readonly OrderResult Success = new OrderResult("Đặt hàng thành công!", OrderStatus.Success);
    public static readonly OrderResult QtyInvalid = new OrderResult("Số lượng không đáp ứng yêu cầu của bạn!", OrderStatus.QuantityInvalid);
    public static readonly OrderResult Faild = new OrderResult("Đặt hàng thất bại!", OrderStatus.QuantityInvalid);
    }
}
