using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_TD1_1.Migrations
{
    public partial class AjoutProduitMarqueTypeProduit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_e_marque_mar",
                columns: table => new
                {
                    mar_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mar_nom = table.Column<string>(type: "character varying(85)", maxLength: 85, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mar", x => x.mar_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_typeproduit_typ",
                columns: table => new
                {
                    typ_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    typ_nom = table.Column<string>(type: "character varying(85)", maxLength: 85, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typ", x => x.typ_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_produit_pro",
                columns: table => new
                {
                    pro_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pro_nom = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    pro_desc = table.Column<string>(type: "character varying(905)", maxLength: 905, nullable: true),
                    pro_nomphoto = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    pro_uriphoto = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    pro_idtype = table.Column<int>(type: "integer", nullable: false),
                    pro_idmarque = table.Column<int>(type: "integer", nullable: false),
                    pro_stockreel = table.Column<int>(type: "integer", nullable: false),
                    pro_stockmin = table.Column<int>(type: "integer", nullable: false),
                    pro_stockmax = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pro", x => x.pro_id);
                    table.ForeignKey(
                        name: "fk_pro_mar",
                        column: x => x.pro_idmarque,
                        principalTable: "t_e_marque_mar",
                        principalColumn: "mar_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pro_typ",
                        column: x => x.pro_idtype,
                        principalTable: "t_e_typeproduit_typ",
                        principalColumn: "typ_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_produit_pro_pro_idmarque",
                table: "t_e_produit_pro",
                column: "pro_idmarque");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_produit_pro_pro_idtype",
                table: "t_e_produit_pro",
                column: "pro_idtype");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_produit_pro");

            migrationBuilder.DropTable(
                name: "t_e_marque_mar");

            migrationBuilder.DropTable(
                name: "t_e_typeproduit_typ");
        }
    }
}
