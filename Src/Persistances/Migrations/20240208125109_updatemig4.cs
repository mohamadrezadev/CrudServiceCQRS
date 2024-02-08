using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistances.Migrations
{
    /// <inheritdoc />
    public partial class updatemig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price", "imageURl" },
                values: new object[] { "گوشی موبایل شیائومی مدل 13T Pro 5G ظرفیت 512 گیگابایت رم 12 گیگابایت", "شیائومی مدل 13T Pro 5G", 27700000, "https://www.technolife.ir/image/small_product-TLP-28793_c8143e09-d41c-45a3-89cf-67cc8a8e8ce2.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price", "imageURl" },
                values: new object[] { "گوشی موبايل سامسونگ مدل Galaxy S24 Plus 5G ظرفیت 256 گیگابایت رم 12 گیگابایت", "موبايل سامسونگ مدل Galaxy S24 Plus 5G ", 20900000, "https://www.technolife.ir/image/small_product-TLP-28800_c90207e3-ccdc-4630-900a-337299189f08.png" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "imageURl" },
                values: new object[] { 1, "One small reduction of the notch, one giant leap for the iPhone! That's the best description for the most minor iPhone upgrade yet - the Apple iPhone 13.", "Apple iPhone 13", 30000000, "https://www.technolife.ir/image/small_product-TLP-4993_e62cc295-8d95-469e-bfa1-7bda32e2ee7b.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price", "imageURl" },
                values: new object[] { "One small reduction of the notch, one giant leap for the iPhone! That's the best description for the most minor iPhone upgrade yet - the Apple iPhone 13.", "Apple iPhone 13", 30000000, "https://www.technolife.ir/image/small_product-TLP-4993_e62cc295-8d95-469e-bfa1-7bda32e2ee7b.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price", "imageURl" },
                values: new object[] { "گوشی موبایل شیائومی مدل 13T Pro 5G ظرفیت 512 گیگابایت رم 12 گیگابایت", "شیائومی مدل 13T Pro 5G", 27700000, "https://www.technolife.ir/image/small_product-TLP-28793_c8143e09-d41c-45a3-89cf-67cc8a8e8ce2.png" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "imageURl" },
                values: new object[] { 4, "گوشی موبايل سامسونگ مدل Galaxy S24 Plus 5G ظرفیت 256 گیگابایت رم 12 گیگابایت", "موبايل سامسونگ مدل Galaxy S24 Plus 5G ", 20900000, "https://www.technolife.ir/image/small_product-TLP-28800_c90207e3-ccdc-4630-900a-337299189f08.png" });
        }
    }
}
