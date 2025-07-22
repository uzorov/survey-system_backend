using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Survey.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    region = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    contact = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question = table.Column<string>(type: "text", nullable: true),
                    isallowotheranswer = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_questions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "answervariants",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    questionid = table.Column<int>(type: "integer", nullable: true),
                    answervariant = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_answervariants", x => x.id);
                    table.ForeignKey(
                        name: "fk_answervariants_questions_questionid",
                        column: x => x.questionid,
                        principalTable: "questions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "analysisresults",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_of_pipe = table.Column<string>(type: "text", nullable: true),
                    diameter_of_pipe = table.Column<string>(type: "text", nullable: true),
                    pipe_wall_thickness = table.Column<string>(type: "text", nullable: true),
                    volume_tons = table.Column<string>(type: "text", nullable: true),
                    timeline = table.Column<string>(type: "text", nullable: true),
                    interest_level = table.Column<string>(type: "text", nullable: true),
                    contactid = table.Column<int>(type: "integer", nullable: true),
                    analysisdatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_analysisresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_analysisresults_users_contactid",
                        column: x => x.contactid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "surveys",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    questionid = table.Column<int>(type: "integer", nullable: true),
                    answervariantid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_surveys", x => x.id);
                    table.ForeignKey(
                        name: "fk_surveys_answervariants_answervariantid",
                        column: x => x.answervariantid,
                        principalTable: "answervariants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_surveys_questions_questionid",
                        column: x => x.questionid,
                        principalTable: "questions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "metrics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    valuedouble = table.Column<double>(type: "double precision", nullable: false),
                    valuestring = table.Column<string>(type: "text", nullable: true),
                    valuedatetime = table.Column<string>(type: "text", nullable: true),
                    analysisresultid = table.Column<int>(type: "integer", nullable: true),
                    metricdatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_metrics", x => x.id);
                    table.ForeignKey(
                        name: "fk_metrics_analysisresults_analysisresultid",
                        column: x => x.analysisresultid,
                        principalTable: "analysisresults",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "queries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: true),
                    contactid = table.Column<int>(type: "integer", nullable: true),
                    querydatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    analysisresultmodelid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_queries", x => x.id);
                    table.ForeignKey(
                        name: "fk_queries_analysisresults_analysisresultmodelid",
                        column: x => x.analysisresultmodelid,
                        principalTable: "analysisresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_queries_users_contactid",
                        column: x => x.contactid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_analysisresults_contactid",
                table: "analysisresults",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_answervariants_questionid",
                table: "answervariants",
                column: "questionid");

            migrationBuilder.CreateIndex(
                name: "ix_metrics_analysisresultid",
                table: "metrics",
                column: "analysisresultid");

            migrationBuilder.CreateIndex(
                name: "ix_queries_analysisresultmodelid",
                table: "queries",
                column: "analysisresultmodelid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_queries_contactid",
                table: "queries",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_surveys_answervariantid",
                table: "surveys",
                column: "answervariantid");

            migrationBuilder.CreateIndex(
                name: "ix_surveys_questionid",
                table: "surveys",
                column: "questionid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "metrics");

            migrationBuilder.DropTable(
                name: "queries");

            migrationBuilder.DropTable(
                name: "surveys");

            migrationBuilder.DropTable(
                name: "analysisresults");

            migrationBuilder.DropTable(
                name: "answervariants");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "questions");
        }
    }
}
