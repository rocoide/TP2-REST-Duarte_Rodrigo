using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure
{
    public class CineContext :DbContext
    {
        public CineContext() : base()
        {

        }

        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  //ejecuta el metodo de la superclase para las convencias y configs de EF

            //creo la talba de generos
            modelBuilder.Entity<Genero>().HasData(
                new Genero { GeneroId = 1, Nombre = "Acción" },
                new Genero { GeneroId = 2, Nombre = "Aventuras" },
                new Genero { GeneroId = 3, Nombre = "Ciencia ficción" },
                new Genero { GeneroId = 4, Nombre = "Comedia" },
                new Genero { GeneroId = 5, Nombre = "Documental" },
                new Genero { GeneroId = 6, Nombre = "Drama" },
                new Genero { GeneroId = 7, Nombre = "Fantasía" },
                new Genero { GeneroId = 8, Nombre = "Musical" },
                new Genero { GeneroId = 9, Nombre = "Suspenso"},
                new Genero { GeneroId = 10, Nombre = "Terror"}
            );

            modelBuilder.Entity<Pelicula>().HasData(
                //1
                new Pelicula
                {
                    PeliculaId = 1,
                    Titulo = "Avatar",
                    Sinopsis = "Jake Sully, ex-marine en Pandora, conoce a los Na'vi y se enamora de Neytiri. Enfrenta un dilema moral: ayudar en la extracción de un mineral o proteger a los Na'vi y su hogar.",
                    Poster = "https://th.bing.com/th/id/OIP.NNDzj9c4s1ntnvDOwTDNagHaLH?w=115&h=180&c=7&r=0&o=5&pid=1.7",
                    Trailer = "https://www.youtube.com/watch?v=AZS_d_hS2dM&ab_channel=20thCenturyStudiosEspa%C3%B1a",
                    GeneroId = 3
                },

                //2
                new Pelicula
                {
                    PeliculaId = 2,
                    Titulo = "El aro",
                    Sinopsis = "Rachel, periodista, investiga una cinta maldita tras la muerte de su sobrina. Tras verla, recibe una llamada que le da 7 días para salvar su vida y la de su hijo.",
                    Poster = "https://th.bing.com/th/id/OIP.jn0LXyPMWtNfegmiSMhsZgHaKL?w=129&h=180&c=7&r=0&o=5&pid=1.7",
                    Trailer = "https://www.youtube.com/watch?v=3-1GGz_gTnQ&ab_channel=DigicineDistribuidora",
                    GeneroId = 10
                },

                //3
                new Pelicula
                {
                    PeliculaId = 3,
                    Titulo = "The sword of the stranger",
                    Sinopsis = "En la era Sengoku, un ronin llamado Nanashi protege a Kotarou y su perro Tobimaru de una organización china. Se embarcan en una peligrosa aventura en medio del conflicto de los Estados.",
                    Poster = "https://th.bing.com/th/id/OIP.8RmTep5x66mXiB7HiOqUUgHaLg?w=116&h=180&c=7&r=0&o=5&pid=1.7",
                    Trailer = "https://tinyurl.com/3rdpbv3h",
                    GeneroId = 2
                },

                //4
                new Pelicula
                {
                    PeliculaId = 4,
                    Titulo = "Asesinato en el expreso de oriente",
                    Sinopsis = "Durante un trayecto del tren Orient-Express se produce un asesinato. Cuando una avalancha detiene el tren, el prestigioso detective Hércules Poirot sube al vehículo para investigar quién es el asesino, pero todos los pasajeros parecen sospechosos.",
                    Poster = "https://th.bing.com/th/id/OIP.wqhKWgCaUmC5LAWP0auNzQHaLP?w=178&h=271&c=7&r=0&o=5&pid=1.7",
                    Trailer = "https://www.youtube.com/watch?v=f8ne09GR8aE&ab_channel=20thCenturyStudiosEspa%C3%B1a",
                    GeneroId = 9
                },

                //5
                new Pelicula
                {
                    PeliculaId = 5,
                    Titulo = "Shrek 2",
                    Sinopsis = "Cuando Shrek y la princesa Fiona regresan de su luna de miel, los padres de ella los invitan a visitar el reino de Muy Muy Lejano para celebrar la boda. Para Shrek, al que nunca abandona su fiel amigo Asno, esto constituye un gran problema.",
                    Poster = "https://th.bing.com/th/id/OIP.sI0vbZwcYD1oEHt04j1vQwAAAA?w=115&h=180&c=7&r=0&o=5&pid=1.7",
                    Trailer = "https://www.youtube.com/watch?v=xBxVgh-kgAI&ab_channel=JoyasDeLaAnimaci%C3%B3n",
                    GeneroId = 7
                },

                //6
                new Pelicula
                {
                    PeliculaId = 6,
                    Titulo = "El dictador",
                    Sinopsis = "Un tirano de África del Norte arriesga su vida para asegurar que la democracia nunca llegue al país al que mantiene oprimido.",
                    Poster = "https://th.bing.com/th/id/OIP.Bq0l0fHXM3N9ieG_JyiuNwHaLH?w=115&h=180&c=7&r=0&o=5&pid=1.7",
                    Trailer = "https://www.youtube.com/watch?v=i9qH93yZAdo&ab_channel=TrailersyEstrenos",
                    GeneroId = 4
                },

                //7
                new Pelicula
                {
                    PeliculaId = 7,
                    Titulo = "Mario Bros",
                    Sinopsis = "Dos hermanos plomeros, Mario y Luigi, caen por las alcantarillas y llegan a un mundo subterráneo mágico en el que deben enfrentarse al malvado Bowser para rescatar a la princesa Peach, quien ha sido forzada a aceptar casarse con él.",
                    Poster = "https://th.bing.com/th/id/OIP.e8BVI2EbDHPGc8b7-UUqLAHaJQ?w=178&h=223&c=7&r=0&o=5&pid=1.7",
                    Trailer = "https://www.youtube.com/watch?v=SvJwEiy2Wok&ab_channel=SensaCineTRAILERS",
                    GeneroId = 7
                },

                //8
                new Pelicula
                {
                    PeliculaId = 8,
                    Titulo = "Caceria en Venecia",
                    Sinopsis = "Después de la II Guerra Mundial, Poirot vuelve a investigar en Venecia en una noche de terror y misterio. Cuando un invitado muere en una sesión de espiritismo, el detective retirado se sumerge en un oscuro enigma.",
                    Poster = "https://th.bing.com/th/id/OIP.PwZP-r6lwxa7jqI9VHU7cwAAAA?w=123&h=180&c=7&r=0&o=5&pid=1.7",
                    Trailer = "https://www.youtube.com/watch?v=JymKmSe5TOk&ab_channel=20thCenturyStudiosLA",
                    GeneroId = 9
                },

                //9
                new Pelicula
                {
                    PeliculaId = 9,
                    Titulo = "El ultimo samurai",
                    Sinopsis = "Tras la Guerra de Secesión, el Capitán Nathan Algren y el líder samurái Katsumoto se enfrentan a un Japón en transformación. El emperador japonés los une en un choque de culturas mientras Algren entrena a un nuevo ejército.",
                    Poster = "https://th.bing.com/th/id/OIP.1SYaJrlCFCqwOq52VzLG-wHaLH?w=125&h=187&c=7&r=0&o=5&pid=1.7",
                    Trailer = "https://www.youtube.com/watch?v=-c74IrUQAoc&ab_channel=DeTrailers",
                    GeneroId = 6
                },

                //10
                new Pelicula
                {
                    PeliculaId = 10,
                    Titulo = "Casino",
                    Sinopsis = "Robert De Niro, Sharon Stone y Joe Pesci protagonizan la fascinante película de Martin Scorsese que le echa un vistazo a la manera en que la ambición ciega, la pasión candente y la codicia de 24 quilates derrumbaron el imperio de un casino de Las Vegas.",
                    Poster = "https://th.bing.com/th/id/OIP.o9U2d0zadTrIXP6E1_Ew7AHaEK?pid=ImgDet&rs=1",
                    Trailer = "https://www.youtube.com/watch?v=EJXDMwGWhoA&ab_channel=Movieclips",
                    GeneroId = 1
                },

                //11
                new Pelicula
                {
                    PeliculaId = 11,
                    Titulo = "El gran Gatsby",
                    Sinopsis = "Los años 20 nunca han estado mejor descritos que en esta romántica y suntuosa nueva versión del clásico de F. Scott Fitzgerald sobre la Era del Jazz.",
                    Poster = "https://th.bing.com/th/id/OIP.IhQIQ8q8Bo9uhAWjgJoc0AHaK-?pid=ImgDet&rs=1",
                    Trailer = "https://www.youtube.com/watch?v=tgx3mpSUwBA&ab_channel=WarnerBros.PicturesEspa%C3%B1a",
                    GeneroId = 6
                },

                //12
                new Pelicula
                {
                    PeliculaId = 12,
                    Titulo = "El lobo de wall street",
                    Sinopsis = "Un bróker que disfruta de un estilo de vida decadente y desenfrenado trata de eludir al FBI mientras él y sus compañeros se hacen ricos gracias a unos negocios turbios.",
                    Poster = "https://th.bing.com/th/id/OIP.ZC32-wAQQGPVQ64Psduo2AHaLH?pid=ImgDet&rs=1",
                    Trailer = "https://www.youtube.com/watch?v=DEMZSa0esCU&ab_channel=TrailersyEstrenos",
                    GeneroId = 6
                },

                //13
                new Pelicula
                {
                    PeliculaId = 13,
                    Titulo = "8 noches de locura",
                    Sinopsis = "Comedia animada que sigue las andanzas de un joven que realiza servicios comunitarios tras ser arrestado durante las fiestas de fin de año.",
                    Poster = "https://tinyurl.com/yyuasf93",
                    Trailer = "https://www.youtube.com/watch?v=q0Nsh8cb000&ab_channel=JaimeRodd",
                    GeneroId = 8
                },

                //14
                new Pelicula
                {
                    PeliculaId = 14,
                    Titulo = "El asesinato de jesse james",
                    Sinopsis = "Jesse James planea su próximo gran robo pero su cabeza tiene precio por varios crímenes anteriores: quien capture a Jesse recibirá una gran recompensa. Varias personas le persiguen, incluso es traicionado por un miembro de su propia banda.",
                    Poster = "https://th.bing.com/th/id/OIP.LjuYRh2pKrTATwL-Mou12gAAAA?pid=ImgDet&rs=1",
                    Trailer = "https://www.youtube.com/watch?v=twadXH9PGgE&ab_channel=LeandroC",
                    GeneroId = 6
                },

                //15
                new Pelicula
                {
                    PeliculaId = 15,
                    Titulo = "Fragmentado",
                    Sinopsis = "La película sigue a Kevin, quien tiene 23 personalidades debido a su trastorno de identidad disociativo. Secuestra a tres adolescentes y espera la aparición de su personalidad más temible, La Bestia.",
                    Poster = "https://th.bing.com/th/id/OIP.M8qy4VxDSysV7wg_GscNEwHaKk?w=118&h=180&c=7&r=0&o=5&pid=1.7",
                    Trailer = "https://www.youtube.com/watch?v=3fQ82KWRRfo&ab_channel=CineHome",
                    GeneroId = 6
                },

                //16
                new Pelicula
                {
                    PeliculaId = 16,
                    Titulo = "El gato con botas: El último deseo",
                    Sinopsis = "El Gato con Botas descubre que su pasión por la aventura le ha pasado factura: ha consumido ocho de sus nueve vidas, por ello emprende un viaje épico para encontrar el mítico Último Deseo y restaurar sus nueve vidas",
                    Poster = "https://pics.filmaffinity.com/puss_in_boots_the_last_wish-897078202-mmed.jpg",
                    Trailer = "https://www.youtube.com/watch?v=QaiUm8jNiCk&ab_channel=UniversalSpain",
                    GeneroId = 2
                },

                //17
                new Pelicula
                {
                    PeliculaId = 17,
                    Titulo = "Lilo & Stich",
                    Sinopsis = "Lilo, una niña hawaiana solitaria, encuentra a Stitch, un experimento alienígena en la Tierra. A través del amor y la unión familiar de \"ohana,\" transforman sus vidas y enseñan el valor del cuidado y la amistad.",
                    Poster = "https://pics.filmaffinity.com/lilo_stitch-502239805-mmed.jpg",
                    Trailer = "https://www.youtube.com/watch?v=9OAC55UWAQs&ab_channel=RottenTomatoesClassicTrailers",
                    GeneroId = 2
                },

                //18
                new Pelicula
                {
                    PeliculaId = 18,
                    Titulo = "Dog: Una aventura salvaje",
                    Sinopsis = "El ranger del ejército Briggs debe llevar a Lulu, un perro de guerra, de Washington a Arizona para un emotivo funeral, enfrentando sus traumas y problemas emocionales en el camino.",
                    Poster = "https://pics.filmaffinity.com/dog-263685812-mmed.jpg",
                    Trailer = "https://www.youtube.com/watch?v=LJcVhteNnSY&ab_channel=TrailersInSpanish",
                    GeneroId = 6
                },

                //19
                new Pelicula
                {
                    PeliculaId = 19,
                    Titulo = "WALL•E",
                    Sinopsis = "En el año 2800, WALL•E, un robot de limpieza en un planeta Tierra devastado, conoce a EVE, una exploradora robot. Juntos emprenden una emocionante aventura galáctica, cambiando sus vidas para siempre.",
                    Poster = "https://pics.filmaffinity.com/walloe-973488527-mmed.jpg",
                    Trailer = "https://www.youtube.com/watch?v=CZ1CATNbXg0&ab_channel=RottenTomatoesClassicTrailers",
                    GeneroId = 2
                },

                //20
                new Pelicula
                {
                    PeliculaId = 20,
                    Titulo = "Happy Feet",
                    Sinopsis = "Comedia familiar que narra la historia de unos pingüinos en la Antártida. Para atraer a su pareja los pingüinos deben entonar una canción, pero uno de ellos no sabe cantar, pero es un gran bailarín de claqué.",
                    Poster = "https://pics.filmaffinity.com/happy_feet-637452144-mmed.jpg",
                    Trailer = "https://www.youtube.com/watch?v=aIBsnOyJB7Y&ab_channel=WarnerMoviesOnDemand",
                    GeneroId = 2
                }
            );

            modelBuilder.Entity<Sala>().HasData(
                //1
                new Sala
                {
                    SalaId = 1,
                    Nombre = "sala 1",
                    Capacidad = 5
                },

                //2
                new Sala
                {
                    SalaId = 2,
                    Nombre = "sala 2",
                    Capacidad = 15
                },

                //3
                new Sala
                {
                    SalaId = 3,
                    Nombre = "sala 3",
                    Capacidad = 35
                }
            );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SC0U42I\SQLEXPRESS;Database=rokopop2DB;Trusted_Connection=True;TrustServerCertificate=True");
        }

    }
}
