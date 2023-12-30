using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendamentoDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class statusDeletado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "D_E_L_E_T_",
                table: "Tarefas",
                nullable: false,
                maxLength: 1,
                defaultValue: "");
               
        }

         
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
