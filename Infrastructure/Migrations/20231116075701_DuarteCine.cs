using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DuarteCine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_Genero",
                        column: x => x.Genero,
                        principalTable: "Generos",
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
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false)
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
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.TicketId, x.FuncionId });
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Generos",
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
                columns: new[] { "PeliculaId", "Genero", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, 3, "https://pics.filmaffinity.com/avatar-208925608-large.jpg", "Jake Sully, ex-marine en Pandora, conoce a los Na'vi y se enamora de Neytiri. Enfrenta un dilema moral: ayudar en la extracción de un mineral o proteger a los Na'vi y su hogar.", "Avatar", "https://www.youtube.com/embed/AZS_d_hS2dM?si=B-ZQPUNuNGgUurNB" },
                    { 2, 10, "https://pics.filmaffinity.com/the_ring-712833488-large.jpg", "Rachel, periodista, investiga una cinta maldita tras la muerte de su sobrina. Tras verla, recibe una llamada que le da 7 días para salvar su vida y la de su hijo.", "El aro", "https://www.youtube.com/embed/gmiG3txcgis?si=zGQ4lWJEAOhs_M1d" },
                    { 3, 2, "https://pics.filmaffinity.com/stranger_mukoh_hadan-241452338-large.jpg", "En la era Sengoku, un ronin llamado Nanashi protege a Kotarou y su perro Tobimaru de una organización china. Se embarcan en una peligrosa aventura en medio del conflicto de los Estados.", "The sword of the stranger", "https://www.youtube.com/embed/xlEIQKTLN3M?si=Suc8AjE8PaTrzi5d" },
                    { 4, 9, "https://pics.filmaffinity.com/murder_on_the_orient_express-328389244-large.jpg", "Durante un trayecto del tren Orient-Express se produce un asesinato. Cuando una avalancha detiene el tren, el prestigioso detective Hércules Poirot sube al vehículo para investigar quién es el asesino, pero todos los pasajeros parecen sospechosos.", "Asesinato en el expreso de oriente", "https://www.youtube.com/embed/JQQeJFn4xwE?si=yABg6asb-kyc_4KU" },
                    { 5, 7, "https://pics.filmaffinity.com/shrek_2-288126730-large.jpg", "Cuando Shrek y la princesa Fiona regresan de su luna de miel, los padres de ella los invitan a visitar el reino de Muy Muy Lejano para celebrar la boda. Para Shrek, al que nunca abandona su fiel amigo Asno, esto constituye un gran problema.", "Shrek 2", "https://www.youtube.com/embed/V6X5ti4YlG8?si=zpOM27gg3KfA6w-t" },
                    { 6, 4, "https://pics.filmaffinity.com/the_dictator-138905408-large.jpg", "Un tirano de África del Norte arriesga su vida para asegurar que la democracia nunca llegue al país al que mantiene oprimido.", "El dictador", "https://www.youtube.com/embed/S8y9NTGPENc?si=Ow3fbboNUmP287Do" },
                    { 7, 7, "https://th.bing.com/th/id/OIP.e8BVI2EbDHPGc8b7-UUqLAHaJQ?w=178&h=223&c=7&r=0&o=5&pid=1.7", "Dos hermanos plomeros, Mario y Luigi, caen por las alcantarillas y llegan a un mundo subterráneo mágico en el que deben enfrentarse al malvado Bowser para rescatar a la princesa Peach, quien ha sido forzada a aceptar casarse con él.", "Mario Bros", "https://www.youtube.com/watch?v=SvJwEiy2Wok&ab_channel=SensaCineTRAILERS" },
                    { 8, 9, "https://pics.filmaffinity.com/a_haunting_in_venice-814202842-large.jpg", "Después de la II Guerra Mundial, Poirot vuelve a investigar en Venecia en una noche de terror y misterio. Cuando un invitado muere en una sesión de espiritismo, el detective retirado se sumerge en un oscuro enigma.", "Caceria en Venecia", "https://www.youtube.com/embed/p6JFBV0UOAE?si=qjFbPtLgrx4MNW0l" },
                    { 9, 6, "https://pics.filmaffinity.com/the_last_samurai-270445769-large.jpg", "Tras la Guerra de Secesión, el Capitán Nathan Algren y el líder samurái Katsumoto se enfrentan a un Japón en transformación. El emperador japonés los une en un choque de culturas mientras Algren entrena a un nuevo ejército.", "El ultimo samurai", "https://www.youtube.com/embed/-c74IrUQAoc?si=_j0htIcn9dO3-jxB" },
                    { 10, 1, "https://pics.filmaffinity.com/casino-348445329-large.jpg", "Robert De Niro, Sharon Stone y Joe Pesci protagonizan la fascinante película de Martin Scorsese que le echa un vistazo a la manera en que la ambición ciega, la pasión candente y la codicia de 24 quilates derrumbaron el imperio de un casino de Las Vegas.", "Casino", "https://www.youtube.com/embed/xbNR2kcyut4?si=9mEo22fNQmanmR63" },
                    { 11, 6, "https://pics.filmaffinity.com/the_great_gatsby-737648170-large.jpg", "Los años 20 nunca han estado mejor descritos que en esta romántica y suntuosa nueva versión del clásico de F. Scott Fitzgerald sobre la Era del Jazz.", "El gran Gatsby", "https://www.youtube.com/embed/tgx3mpSUwBA?si=jBV8YSxpfdHOCzJv" },
                    { 12, 6, "https://pics.filmaffinity.com/the_wolf_of_wall_street-675195906-large.jpg", "Un bróker que disfruta de un estilo de vida decadente y desenfrenado trata de eludir al FBI mientras él y sus compañeros se hacen ricos gracias a unos negocios turbios.", "El lobo de wall street", "https://www.youtube.com/embed/DEMZSa0esCU?si=YASj53vD5mZJa8JD" },
                    { 13, 8, "https://pics.filmaffinity.com/8_crazy_nights-470524560-large.jpg", "Comedia animada que sigue las andanzas de un joven que realiza servicios comunitarios tras ser arrestado durante las fiestas de fin de año.", "8 noches de locura", "https://www.youtube.com/embed/q0Nsh8cb000?si=Y3Lzn-nvtOR_rAbY" },
                    { 14, 6, "https://pics.filmaffinity.com/creep_aka_peachfuzz-908632647-large.jpg", "Aaron acepta un trabajo que promete 1.000 dólares al día por participar en un rodaje. En una cabaña perdida en el bosque conocerá a Josef, el sujeto de la película que debe filmar. Las cosas se complicarán.", "Creep", "https://www.youtube.com/embed/Gp7tBypjwDo?si=ec6ynOAy5z9fQCwh" },
                    { 15, 6, "https://pics.filmaffinity.com/split-172094905-large.jpg", "La película sigue a Kevin, quien tiene 23 personalidades debido a su trastorno de identidad disociativo. Secuestra a tres adolescentes y espera la aparición de su personalidad más temible, La Bestia.", "Fragmentado", "https://www.youtube.com/embed/3fQ82KWRRfo?si=elqswZsGW2EA4qk6" },
                    { 16, 2, "https://pics.filmaffinity.com/puss_in_boots_the_last_wish-897078202-large.jpg", "El Gato con Botas descubre que su pasión por la aventura le ha pasado factura: ha consumido ocho de sus nueve vidas, por ello emprende un viaje épico para encontrar el mítico Último Deseo y restaurar sus nueve vidas", "El gato con botas: El último deseo", "https://www.youtube.com/embed/QaiUm8jNiCk?si=1C3824sACM2z6oJa" },
                    { 17, 2, "https://pics.filmaffinity.com/lilo_stitch-502239805-large.jpg", "Lilo, una niña hawaiana solitaria, encuentra a Stitch, un experimento alienígena en la Tierra. A través del amor y la unión familiar de \"ohana,\" transforman sus vidas y enseñan el valor del cuidado y la amistad.", "Lilo & Stich", "https://www.youtube.com/embed/_WbTe5hjSkE?si=8akglF_dbD1fC0_i" },
                    { 18, 6, "https://pics.filmaffinity.com/dog-263685812-large.jpg", "El ranger del ejército Briggs debe llevar a Lulu, un perro de guerra, de Washington a Arizona para un emotivo funeral, enfrentando sus traumas y problemas emocionales en el camino.", "Dog: Una aventura salvaje", "https://www.youtube.com/embed/boykOMsSjmQ?si=2KzjNHAVG2ClJ3fd" },
                    { 19, 2, "https://pics.filmaffinity.com/walloe-973488527-large.jpg", "En el año 2800, WALL•E, un robot de limpieza en un planeta Tierra devastado, conoce a EVE, una exploradora robot. Juntos emprenden una emocionante aventura galáctica, cambiando sus vidas para siempre.", "WALL•E", "https://www.youtube.com/embed/qF7p4lZ00RA?si=nIIF4PG8T7hJJaxt" },
                    { 20, 2, "https://pics.filmaffinity.com/happy_feet-637452144-large.jpg", "Comedia familiar que narra la historia de unos pingüinos en la Antártida. Para atraer a su pareja los pingüinos deben entonar una canción, pero uno de ellos no sabe cantar, pero es un gran bailarín de claqué.", "Happy Feet", "https://www.youtube.com/embed/aIBsnOyJB7Y?si=LCUmnYiKaaZfqPEf" }
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
                name: "IX_Peliculas_Genero",
                table: "Peliculas",
                column: "Genero");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");
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
                name: "Generos");
        }
    }
}
