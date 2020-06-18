using Microsoft.EntityFrameworkCore.Migrations;

namespace EarthquakeHorses4.Migrations
{
    public partial class CRUD2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cheval",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Taille = table.Column<float>(nullable: false),
                    Robe = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cheval_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contrat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cour",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Place = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Niveau = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Information",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Lieu = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Information", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Information_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Licence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Validite = table.Column<int>(nullable: false),
                    Tarif = table.Column<float>(nullable: false),
                    Niveau = table.Column<string>(nullable: true),
                    Categorie = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licence_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lieu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lieu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materiel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(nullable: true),
                    Tarif = table.Column<float>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Taille = table.Column<float>(nullable: false),
                    Unite = table.Column<string>(nullable: true),
                    Couleur = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materiel_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paiement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Du = table.Column<float>(nullable: false),
                    Motif = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    ContratId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paiement_Contrat_ContratId",
                        column: x => x.ContratId,
                        principalTable: "Contrat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pension",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarif = table.Column<float>(nullable: false),
                    Engagement = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    ContratId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    ChevalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pension", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pension_Cheval_ChevalId",
                        column: x => x.ChevalId,
                        principalTable: "Cheval",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pension_Contrat_ContratId",
                        column: x => x.ContratId,
                        principalTable: "Contrat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pension_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sceance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(nullable: false),
                    ContratId = table.Column<int>(nullable: false),
                    CourId = table.Column<int>(nullable: false),
                    LieuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sceance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sceance_Contrat_ContratId",
                        column: x => x.ContratId,
                        principalTable: "Contrat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sceance_Cour_CourId",
                        column: x => x.CourId,
                        principalTable: "Cour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sceance_Lieu_LieuId",
                        column: x => x.LieuId,
                        principalTable: "Lieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationMateriel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratId = table.Column<int>(nullable: false),
                    MaterielId = table.Column<int>(nullable: false),
                    Lieu = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationMateriel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationMateriel_Contrat_ContratId",
                        column: x => x.ContratId,
                        principalTable: "Contrat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationMateriel_Materiel_MaterielId",
                        column: x => x.MaterielId,
                        principalTable: "Materiel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationMateriel_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SceanceUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SceanceId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceanceUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SceanceUser_Sceance_SceanceId",
                        column: x => x.SceanceId,
                        principalTable: "Sceance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SceanceUser_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cheval_UserId1",
                table: "Cheval",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Information_UserId1",
                table: "Information",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Licence_UserId1",
                table: "Licence",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_LocationMateriel_ContratId",
                table: "LocationMateriel",
                column: "ContratId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationMateriel_MaterielId",
                table: "LocationMateriel",
                column: "MaterielId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationMateriel_UserId1",
                table: "LocationMateriel",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Materiel_UserId1",
                table: "Materiel",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Paiement_ContratId",
                table: "Paiement",
                column: "ContratId");

            migrationBuilder.CreateIndex(
                name: "IX_Pension_ChevalId",
                table: "Pension",
                column: "ChevalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pension_ContratId",
                table: "Pension",
                column: "ContratId");

            migrationBuilder.CreateIndex(
                name: "IX_Pension_UserId1",
                table: "Pension",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sceance_ContratId",
                table: "Sceance",
                column: "ContratId");

            migrationBuilder.CreateIndex(
                name: "IX_Sceance_CourId",
                table: "Sceance",
                column: "CourId");

            migrationBuilder.CreateIndex(
                name: "IX_Sceance_LieuId",
                table: "Sceance",
                column: "LieuId");

            migrationBuilder.CreateIndex(
                name: "IX_SceanceUser_SceanceId",
                table: "SceanceUser",
                column: "SceanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SceanceUser_UserId1",
                table: "SceanceUser",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Information");

            migrationBuilder.DropTable(
                name: "Licence");

            migrationBuilder.DropTable(
                name: "LocationMateriel");

            migrationBuilder.DropTable(
                name: "Paiement");

            migrationBuilder.DropTable(
                name: "Pension");

            migrationBuilder.DropTable(
                name: "SceanceUser");

            migrationBuilder.DropTable(
                name: "Materiel");

            migrationBuilder.DropTable(
                name: "Cheval");

            migrationBuilder.DropTable(
                name: "Sceance");

            migrationBuilder.DropTable(
                name: "Contrat");

            migrationBuilder.DropTable(
                name: "Cour");

            migrationBuilder.DropTable(
                name: "Lieu");
        }
    }
}
