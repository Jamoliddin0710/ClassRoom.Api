using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoom.Migrations
{
    public partial class tasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Courses_CourseId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCourses_Courses_CourseId",
                table: "TaskCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCourses_Task_TaskId",
                table: "TaskCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_Task_CourseId",
                table: "Tasks",
                newName: "IX_Tasks_CourseId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "TaskCourses",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId1",
                table: "TaskCourses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TaskCourses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TaskStatus",
                table: "TaskCourses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "TaskCourses",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TaskCourses_CourseId1",
                table: "TaskCourses",
                column: "CourseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCourses_AspNetUsers_CourseId",
                table: "TaskCourses",
                column: "CourseId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCourses_Courses_CourseId1",
                table: "TaskCourses",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCourses_Tasks_TaskId",
                table: "TaskCourses",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Courses_CourseId",
                table: "Tasks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskCourses_AspNetUsers_CourseId",
                table: "TaskCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCourses_Courses_CourseId1",
                table: "TaskCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCourses_Tasks_TaskId",
                table: "TaskCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Courses_CourseId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskCourses_CourseId1",
                table: "TaskCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "TaskCourses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TaskCourses");

            migrationBuilder.DropColumn(
                name: "TaskStatus",
                table: "TaskCourses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskCourses");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_CourseId",
                table: "Task",
                newName: "IX_Task_CourseId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "TaskCourses",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Courses_CourseId",
                table: "Task",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCourses_Courses_CourseId",
                table: "TaskCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCourses_Task_TaskId",
                table: "TaskCourses",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
