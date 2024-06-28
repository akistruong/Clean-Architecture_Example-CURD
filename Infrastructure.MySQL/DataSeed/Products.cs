using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MySQL.DataSeed
{
    public class Products
    {
      public static List<Entities.Product> ProductInit()
        {
            return new List<Product>()
            {
                new Product()
                {
                    ProductID= "c09628ea-441e-4486-a019-e4005e1b1644",
                    ProductDescription="",
                    ProductName=@"Quần Đùi Nam Nữ Thun Cotton 
                    AmericanStyle Đập Tan Nóng Bức Mặc Nhà, Mặc Làm Quần Ngủ Có Bigsize",
                    Qty=100,
                    ProductPrice=500000
                   
                   
                },
                  new Product()
                {
                    ProductID= "511e3a9e-1cbd-4355-92f4-ff25d838979b",
                    ProductDescription=@"Làm ẩm kép để bảo vệ môi, dưỡng ẩm kép, tạo môi mọng nước, trị liệu spa hàng ngày cho môi ",
                    ProductName=@"Ong Son Dầu Nước Bóng Thủy Tinh Trong Suốt Son Bóng Sửa Chữa Khô Nứt Lột Chăm Sóc Môi Nữ Toot Môi Dầu",
                    Qty=50,
                     ProductPrice=300000

                },
                    new Product()
                {
                    ProductID="151987ae-da8c-43a3-9923-faccf5b32b95",
                    ProductDescription=@"Quần Short Kaki Nam AVIANO 5 Màu, Quần Đùi Co Giãn Phối Cạp Chun",
                    ProductName=@"Quần Short nam AVIANO được làm từ chất liệu kaki mềm có độ đàn hồi, khả năng chịu lực tốt",
                    Qty=50,
                     ProductPrice=600000

                }
            };
        }
    }
}
