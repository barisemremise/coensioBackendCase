using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoensioBackendCase.Migrations
{
    /// <inheritdoc />
    public partial class updateQuestion4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionChoices_Questions_QuestionId1",
                table: "QuestionChoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionChoices",
                table: "QuestionChoices");

            migrationBuilder.DropIndex(
                name: "IX_QuestionChoices_QuestionId1",
                table: "QuestionChoices");

            migrationBuilder.RenameColumn(
                name: "QuestionId1",
                table: "QuestionChoices",
                newName: "QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionChoices",
                table: "QuestionChoices",
                columns: new[] { "QuestionId", "ChoiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionChoices_Questions_QuestionId",
                table: "QuestionChoices",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionChoices_Questions_QuestionId",
                table: "QuestionChoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionChoices",
                table: "QuestionChoices");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "QuestionChoices",
                newName: "QuestionId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionChoices",
                table: "QuestionChoices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionChoices_QuestionId1",
                table: "QuestionChoices",
                column: "QuestionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionChoices_Questions_QuestionId1",
                table: "QuestionChoices",
                column: "QuestionId1",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
