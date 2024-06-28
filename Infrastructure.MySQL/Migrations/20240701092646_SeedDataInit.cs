using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "IsStock", "ProductDescription", "ProductName", "ProductPrice", "Qty" },
                values: new object[,]
                {
                    { "151987ae-da8c-43a3-9923-faccf5b32b95", true, "Quần Short Kaki Nam AVIANO 5 Màu, Quần Đùi Co Giãn Phối Cạp Chun", "Quần Short nam AVIANO được làm từ chất liệu kaki mềm có độ đàn hồi, khả năng chịu lực tốt", 600000m, 50 },
                    { "511e3a9e-1cbd-4355-92f4-ff25d838979b", true, "Làm ẩm kép để bảo vệ môi, dưỡng ẩm kép, tạo môi mọng nước, trị liệu spa hàng ngày cho môi ", "Ong Son Dầu Nước Bóng Thủy Tinh Trong Suốt Son Bóng Sửa Chữa Khô Nứt Lột Chăm Sóc Môi Nữ Toot Môi Dầu", 300000m, 50 },
                    { "c09628ea-441e-4486-a019-e4005e1b1644", true, "", "Quần Đùi Nam Nữ Thun Cotton \r\n                    AmericanStyle Đập Tan Nóng Bức Mặc Nhà, Mặc Làm Quần Ngủ Có Bigsize", 500000m, 100 }
                });

            migrationBuilder.InsertData(
                table: "Iventories",
                columns: new[] { "ID", "ProductID", "Qty" },
                values: new object[,]
                {
                    { "25234940-3176-4647-80d1-0a159a298863", "c09628ea-441e-4486-a019-e4005e1b1644", 100 },
                    { "6aa1576c-6ff0-49f3-bbf6-02fb33905fc7", "151987ae-da8c-43a3-9923-faccf5b32b95", 50 },
                    { "de33bc93-7157-436f-87da-b88dc27b207a", "511e3a9e-1cbd-4355-92f4-ff25d838979b", 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Iventories",
                keyColumn: "ID",
                keyValue: "25234940-3176-4647-80d1-0a159a298863");

            migrationBuilder.DeleteData(
                table: "Iventories",
                keyColumn: "ID",
                keyValue: "6aa1576c-6ff0-49f3-bbf6-02fb33905fc7");

            migrationBuilder.DeleteData(
                table: "Iventories",
                keyColumn: "ID",
                keyValue: "de33bc93-7157-436f-87da-b88dc27b207a");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: "151987ae-da8c-43a3-9923-faccf5b32b95");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: "511e3a9e-1cbd-4355-92f4-ff25d838979b");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: "c09628ea-441e-4486-a019-e4005e1b1644");
        }
    }
}
