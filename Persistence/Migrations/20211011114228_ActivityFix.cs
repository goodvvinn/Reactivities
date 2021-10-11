namespace Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ActivityFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivitiyAttendees_Activities_ActivityId",
                table: "ActivitiyAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivitiyAttendees_AspNetUsers_AppUserId",
                table: "ActivitiyAttendees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivitiyAttendees",
                table: "ActivitiyAttendees");

            migrationBuilder.RenameTable(
                name: "ActivitiyAttendees",
                newName: "ActivityAttendees");

            migrationBuilder.RenameIndex(
                name: "IX_ActivitiyAttendees_ActivityId",
                table: "ActivityAttendees",
                newName: "IX_ActivityAttendees_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityAttendees",
                table: "ActivityAttendees",
                columns: new[] { "AppUserId", "ActivityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityAttendees_Activities_ActivityId",
                table: "ActivityAttendees",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityAttendees_AspNetUsers_AppUserId",
                table: "ActivityAttendees",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAttendees_Activities_ActivityId",
                table: "ActivityAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAttendees_AspNetUsers_AppUserId",
                table: "ActivityAttendees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityAttendees",
                table: "ActivityAttendees");

            migrationBuilder.RenameTable(
                name: "ActivityAttendees",
                newName: "ActivitiyAttendees");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityAttendees_ActivityId",
                table: "ActivitiyAttendees",
                newName: "IX_ActivitiyAttendees_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivitiyAttendees",
                table: "ActivitiyAttendees",
                columns: new[] { "AppUserId", "ActivityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitiyAttendees_Activities_ActivityId",
                table: "ActivitiyAttendees",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitiyAttendees_AspNetUsers_AppUserId",
                table: "ActivitiyAttendees",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
