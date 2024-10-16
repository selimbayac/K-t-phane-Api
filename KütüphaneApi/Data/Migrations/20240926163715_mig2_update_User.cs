using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class mig2_update_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var userIdExists = migrationBuilder.Sql("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Books' AND COLUMN_NAME = 'UserId'").ToString();

            if (userIdExists == "1") // Eğer sütun mevcutsa
            {
                // UserId sütununu kaldır
                migrationBuilder.DropColumn(
                    name: "UserId",
                    table: "Books");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "UserId",
               table: "Books",
               type: "int",
               nullable: true);

            // UserId için indeks oluşturma
            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

            // Dış anahtar ilişkisinin tekrar eklenmesi
            migrationBuilder.AddForeignKey(
                name: "FK_Books_Kullanici_UserId",
                table: "Books",
                column: "UserId",
                principalTable: "Kullanici",
                principalColumn: "Id");
        }
    }
}
