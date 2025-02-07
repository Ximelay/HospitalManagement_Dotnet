using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixHospit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitalizations_HospitalizationReason_HospitalizationReason~",
                table: "Hospitalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalizationReason",
                table: "HospitalizationReason");

            migrationBuilder.RenameTable(
                name: "HospitalizationReason",
                newName: "HospitalizationReasons");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "EmailAddress",
                keyValue: null,
                column: "EmailAddress",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Patients",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalizationReasons",
                table: "HospitalizationReasons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitalizations_HospitalizationReasons_HospitalizationReaso~",
                table: "Hospitalizations",
                column: "HospitalizationReasonId",
                principalTable: "HospitalizationReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitalizations_HospitalizationReasons_HospitalizationReaso~",
                table: "Hospitalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalizationReasons",
                table: "HospitalizationReasons");

            migrationBuilder.RenameTable(
                name: "HospitalizationReasons",
                newName: "HospitalizationReason");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Patients",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalizationReason",
                table: "HospitalizationReason",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitalizations_HospitalizationReason_HospitalizationReason~",
                table: "Hospitalizations",
                column: "HospitalizationReasonId",
                principalTable: "HospitalizationReason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
