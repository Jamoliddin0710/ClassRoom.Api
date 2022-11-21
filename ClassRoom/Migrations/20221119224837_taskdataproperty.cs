using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoom.Migrations
{
    public partial class taskdataproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskCourses_Courses_CourseId1",
                table: "TaskCourses");

            migrationBuilder.DropIndex(
                name: "IX_TaskCourses_CourseId1",
                table: "TaskCourses");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "TaskCourses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId1",
                table: "TaskCourses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskCourses_CourseId1",
                table: "TaskCourses",
                column: "CourseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCourses_Courses_CourseId1",
                table: "TaskCourses",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
