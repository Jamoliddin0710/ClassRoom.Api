using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoom.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskCourses_AspNetUsers_CourseId",
                table: "TaskCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCourses_Tasks_TaskId",
                table: "TaskCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskCourses",
                table: "TaskCourses");

            migrationBuilder.RenameTable(
                name: "TaskCourses",
                newName: "UserTask");

            migrationBuilder.RenameColumn(
                name: "TaskStatus",
                table: "UserTask",
                newName: "Status");

            migrationBuilder.RenameIndex(
                name: "IX_TaskCourses_TaskId",
                table: "UserTask",
                newName: "IX_UserTask_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskCourses_CourseId",
                table: "UserTask",
                newName: "IX_UserTask_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTask",
                table: "UserTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTask_AspNetUsers_CourseId",
                table: "UserTask",
                column: "CourseId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTask_Tasks_TaskId",
                table: "UserTask",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTask_AspNetUsers_CourseId",
                table: "UserTask");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTask_Tasks_TaskId",
                table: "UserTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTask",
                table: "UserTask");

            migrationBuilder.RenameTable(
                name: "UserTask",
                newName: "TaskCourses");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TaskCourses",
                newName: "TaskStatus");

            migrationBuilder.RenameIndex(
                name: "IX_UserTask_TaskId",
                table: "TaskCourses",
                newName: "IX_TaskCourses_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTask_CourseId",
                table: "TaskCourses",
                newName: "IX_TaskCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskCourses",
                table: "TaskCourses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCourses_AspNetUsers_CourseId",
                table: "TaskCourses",
                column: "CourseId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCourses_Tasks_TaskId",
                table: "TaskCourses",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
