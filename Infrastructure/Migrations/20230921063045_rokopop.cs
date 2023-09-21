using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rokopop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    funcionID = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_funcionID",
                        column: x => x.funcionID,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "GeneroId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acción" },
                    { 2, "Aventuras" },
                    { 3, "Ciencia ficción" },
                    { 4, "Comedia" },
                    { 5, "Documental" },
                    { 6, "Drama" },
                    { 7, "Fantasía" },
                    { 8, "Musical" },
                    { 9, "Suspenso" },
                    { 10, "Terror" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad", "Nombre" },
                values: new object[,]
                {
                    { 1, 5, "sala 1" },
                    { 2, 15, "sala 2" },
                    { 3, 35, "sala 3" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "GeneroId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, 3, "https://th.bing.com/th/id/OIP.NNDzj9c4s1ntnvDOwTDNagHaLH?w=115&h=180&c=7&r=0&o=5&pid=1.7", "Jake Sully, ex-marine en Pandora, conoce a los Na'vi y se enamora de Neytiri. Enfrenta un dilema moral: ayudar en la extracción de un mineral o proteger a los Na'vi y su hogar.", "Avatar", "https://www.youtube.com/watch?v=AZS_d_hS2dM&ab_channel=20thCenturyStudiosEspa%C3%B1a" },
                    { 2, 10, "https://th.bing.com/th/id/OIP.jn0LXyPMWtNfegmiSMhsZgHaKL?w=129&h=180&c=7&r=0&o=5&pid=1.7", "Rachel, periodista, investiga una cinta maldita tras la muerte de su sobrina. Tras verla, recibe una llamada que le da 7 días para salvar su vida y la de su hijo.", "El aro", "https://www.youtube.com/watch?v=3-1GGz_gTnQ&ab_channel=DigicineDistribuidora" },
                    { 3, 2, "https://th.bing.com/th/id/OIP.8RmTep5x66mXiB7HiOqUUgHaLg?w=116&h=180&c=7&r=0&o=5&pid=1.7", "En la era Sengoku, un ronin llamado Nanashi protege a Kotarou y su perro Tobimaru de una organización china. Se embarcan en una peligrosa aventura en medio del conflicto de los Estados.", "The sword of the stranger", "https://tinyurl.com/3rdpbv3h" },
                    { 4, 9, "https://th.bing.com/th/id/OIP.wqhKWgCaUmC5LAWP0auNzQHaLP?w=178&h=271&c=7&r=0&o=5&pid=1.7", "Durante un trayecto del tren Orient-Express se produce un asesinato. Cuando una avalancha detiene el tren, el prestigioso detective Hércules Poirot sube al vehículo para investigar quién es el asesino, pero todos los pasajeros parecen sospechosos.", "Asesinato en el expreso de oriente", "https://www.youtube.com/watch?v=f8ne09GR8aE&ab_channel=20thCenturyStudiosEspa%C3%B1a" },
                    { 5, 7, "https://th.bing.com/th/id/OIP.sI0vbZwcYD1oEHt04j1vQwAAAA?w=115&h=180&c=7&r=0&o=5&pid=1.7", "Cuando Shrek y la princesa Fiona regresan de su luna de miel, los padres de ella los invitan a visitar el reino de Muy Muy Lejano para celebrar la boda. Para Shrek, al que nunca abandona su fiel amigo Asno, esto constituye un gran problema.", "Shrek 2", "https://www.youtube.com/watch?v=xBxVgh-kgAI&ab_channel=JoyasDeLaAnimaci%C3%B3n" },
                    { 6, 4, "https://th.bing.com/th/id/OIP.Bq0l0fHXM3N9ieG_JyiuNwHaLH?w=115&h=180&c=7&r=0&o=5&pid=1.7", "Un tirano de África del Norte arriesga su vida para asegurar que la democracia nunca llegue al país al que mantiene oprimido.", "El dictador", "https://www.youtube.com/watch?v=i9qH93yZAdo&ab_channel=TrailersyEstrenos" },
                    { 7, 7, "https://th.bing.com/th/id/OIP.e8BVI2EbDHPGc8b7-UUqLAHaJQ?w=178&h=223&c=7&r=0&o=5&pid=1.7", "Dos hermanos plomeros, Mario y Luigi, caen por las alcantarillas y llegan a un mundo subterráneo mágico en el que deben enfrentarse al malvado Bowser para rescatar a la princesa Peach, quien ha sido forzada a aceptar casarse con él.", "Mario Bros", "https://www.youtube.com/watch?v=SvJwEiy2Wok&ab_channel=SensaCineTRAILERS" },
                    { 8, 9, "https://th.bing.com/th/id/OIP.PwZP-r6lwxa7jqI9VHU7cwAAAA?w=123&h=180&c=7&r=0&o=5&pid=1.7", "Después de la II Guerra Mundial, Poirot vuelve a investigar en Venecia en una noche de terror y misterio. Cuando un invitado muere en una sesión de espiritismo, el detective retirado se sumerge en un oscuro enigma.", "Caceria en Venecia", "https://www.youtube.com/watch?v=JymKmSe5TOk&ab_channel=20thCenturyStudiosLA" },
                    { 9, 6, "https://th.bing.com/th/id/OIP.1SYaJrlCFCqwOq52VzLG-wHaLH?w=125&h=187&c=7&r=0&o=5&pid=1.7", "Tras la Guerra de Secesión, el Capitán Nathan Algren y el líder samurái Katsumoto se enfrentan a un Japón en transformación. El emperador japonés los une en un choque de culturas mientras Algren entrena a un nuevo ejército.", "El ultimo samurai", "https://www.youtube.com/watch?v=-c74IrUQAoc&ab_channel=DeTrailers" },
                    { 10, 1, "https://th.bing.com/th/id/OIP.o9U2d0zadTrIXP6E1_Ew7AHaEK?pid=ImgDet&rs=1", "Robert De Niro, Sharon Stone y Joe Pesci protagonizan la fascinante película de Martin Scorsese que le echa un vistazo a la manera en que la ambición ciega, la pasión candente y la codicia de 24 quilates derrumbaron el imperio de un casino de Las Vegas.", "Casino", "https://www.youtube.com/watch?v=EJXDMwGWhoA&ab_channel=Movieclips" },
                    { 11, 6, "https://th.bing.com/th/id/OIP.IhQIQ8q8Bo9uhAWjgJoc0AHaK-?pid=ImgDet&rs=1", "Los años 20 nunca han estado mejor descritos que en esta romántica y suntuosa nueva versión del clásico de F. Scott Fitzgerald sobre la Era del Jazz.", "El gran Gatsby", "https://www.youtube.com/watch?v=tgx3mpSUwBA&ab_channel=WarnerBros.PicturesEspa%C3%B1a" },
                    { 12, 6, "https://th.bing.com/th/id/OIP.ZC32-wAQQGPVQ64Psduo2AHaLH?pid=ImgDet&rs=1", "Un bróker que disfruta de un estilo de vida decadente y desenfrenado trata de eludir al FBI mientras él y sus compañeros se hacen ricos gracias a unos negocios turbios.", "El lobo de wall street", "https://www.youtube.com/watch?v=DEMZSa0esCU&ab_channel=TrailersyEstrenos" },
                    { 13, 8, "https://tinyurl.com/yyuasf93", "Comedia animada que sigue las andanzas de un joven que realiza servicios comunitarios tras ser arrestado durante las fiestas de fin de año.", "8 noches de locura", "https://www.youtube.com/watch?v=q0Nsh8cb000&ab_channel=JaimeRodd" },
                    { 14, 6, "https://th.bing.com/th/id/OIP.LjuYRh2pKrTATwL-Mou12gAAAA?pid=ImgDet&rs=1", "Jesse James planea su próximo gran robo pero su cabeza tiene precio por varios crímenes anteriores: quien capture a Jesse recibirá una gran recompensa. Varias personas le persiguen, incluso es traicionado por un miembro de su propia banda.", "El asesinato de jesse james", "https://www.youtube.com/watch?v=twadXH9PGgE&ab_channel=LeandroC" },
                    { 15, 6, "https://th.bing.com/th/id/OIP.M8qy4VxDSysV7wg_GscNEwHaKk?w=118&h=180&c=7&r=0&o=5&pid=1.7", "La película sigue a Kevin, quien tiene 23 personalidades debido a su trastorno de identidad disociativo. Secuestra a tres adolescentes y espera la aparición de su personalidad más temible, La Bestia.", "Fragmentado", "https://www.youtube.com/watch?v=3fQ82KWRRfo&ab_channel=CineHome" },
                    { 16, 2, "https://pics.filmaffinity.com/puss_in_boots_the_last_wish-897078202-mmed.jpg", "El Gato con Botas descubre que su pasión por la aventura le ha pasado factura: ha consumido ocho de sus nueve vidas, por ello emprende un viaje épico para encontrar el mítico Último Deseo y restaurar sus nueve vidas", "El gato con botas: El último deseo", "https://www.youtube.com/watch?v=QaiUm8jNiCk&ab_channel=UniversalSpain" },
                    { 17, 2, "https://pics.filmaffinity.com/lilo_stitch-502239805-mmed.jpg", "Lilo, una niña hawaiana solitaria, encuentra a Stitch, un experimento alienígena en la Tierra. A través del amor y la unión familiar de \"ohana,\" transforman sus vidas y enseñan el valor del cuidado y la amistad.", "Lilo & Stich", "https://www.youtube.com/watch?v=9OAC55UWAQs&ab_channel=RottenTomatoesClassicTrailers" },
                    { 18, 6, "https://pics.filmaffinity.com/dog-263685812-mmed.jpg", "El ranger del ejército Briggs debe llevar a Lulu, un perro de guerra, de Washington a Arizona para un emotivo funeral, enfrentando sus traumas y problemas emocionales en el camino.", "Dog: Una aventura salvaje", "https://www.youtube.com/watch?v=LJcVhteNnSY&ab_channel=TrailersInSpanish" },
                    { 19, 2, "https://pics.filmaffinity.com/walloe-973488527-mmed.jpg", "En el año 2800, WALL•E, un robot de limpieza en un planeta Tierra devastado, conoce a EVE, una exploradora robot. Juntos emprenden una emocionante aventura galáctica, cambiando sus vidas para siempre.", "WALL•E", "https://www.youtube.com/watch?v=CZ1CATNbXg0&ab_channel=RottenTomatoesClassicTrailers" },
                    { 20, 2, "https://pics.filmaffinity.com/happy_feet-637452144-mmed.jpg", "Comedia familiar que narra la historia de unos pingüinos en la Antártida. Para atraer a su pareja los pingüinos deben entonar una canción, pero uno de ellos no sabe cantar, pero es un gran bailarín de claqué.", "Happy Feet", "https://www.youtube.com/watch?v=aIBsnOyJB7Y&ab_channel=WarnerMoviesOnDemand" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_GeneroId",
                table: "Peliculas",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_funcionID",
                table: "Tickets",
                column: "funcionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
