using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_minimal_api_uuid_postgres.Migrations
{
    /// <inheritdoc />
    public partial class EnablePgcrypto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS \"pgcrypto\";");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP EXTENSION IF EXISTS \"pgcrypto\";");
        }
    }
}
