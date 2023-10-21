﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CineContext))]
    partial class CineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Funcion", b =>
                {
                    b.Property<int>("FuncionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(4);

                    b.Property<TimeSpan>("Horario")
                        .HasColumnType("time")
                        .HasColumnOrder(5);

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int")
                        .HasColumnName("PeliculaId")
                        .HasColumnOrder(2);

                    b.Property<int>("SalaId")
                        .HasColumnType("int")
                        .HasColumnName("SalaId")
                        .HasColumnOrder(3);

                    b.HasKey("FuncionId");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("SalaId");

                    b.ToTable("Funciones");
                });

            modelBuilder.Entity("Domain.Entity.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneroId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GeneroId");

                    b.ToTable("Genero");

                    b.HasData(
                        new
                        {
                            GeneroId = 1,
                            Nombre = "Acción"
                        },
                        new
                        {
                            GeneroId = 2,
                            Nombre = "Aventuras"
                        },
                        new
                        {
                            GeneroId = 3,
                            Nombre = "Ciencia ficción"
                        },
                        new
                        {
                            GeneroId = 4,
                            Nombre = "Comedia"
                        },
                        new
                        {
                            GeneroId = 5,
                            Nombre = "Documental"
                        },
                        new
                        {
                            GeneroId = 6,
                            Nombre = "Drama"
                        },
                        new
                        {
                            GeneroId = 7,
                            Nombre = "Fantasía"
                        },
                        new
                        {
                            GeneroId = 8,
                            Nombre = "Musical"
                        },
                        new
                        {
                            GeneroId = 9,
                            Nombre = "Suspenso"
                        },
                        new
                        {
                            GeneroId = 10,
                            Nombre = "Terror"
                        });
                });

            modelBuilder.Entity("Domain.Entity.Pelicula", b =>
                {
                    b.Property<int>("PeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PeliculaId"));

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sinopsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PeliculaId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Peliculas");

                    b.HasData(
                        new
                        {
                            PeliculaId = 1,
                            GeneroId = 3,
                            Poster = "https://th.bing.com/th/id/OIP.NNDzj9c4s1ntnvDOwTDNagHaLH?w=115&h=180&c=7&r=0&o=5&pid=1.7",
                            Sinopsis = "Jake Sully, ex-marine en Pandora, conoce a los Na'vi y se enamora de Neytiri. Enfrenta un dilema moral: ayudar en la extracción de un mineral o proteger a los Na'vi y su hogar.",
                            Titulo = "Avatar",
                            Trailer = "https://www.youtube.com/watch?v=AZS_d_hS2dM&ab_channel=20thCenturyStudiosEspa%C3%B1a"
                        },
                        new
                        {
                            PeliculaId = 2,
                            GeneroId = 10,
                            Poster = "https://th.bing.com/th/id/OIP.jn0LXyPMWtNfegmiSMhsZgHaKL?w=129&h=180&c=7&r=0&o=5&pid=1.7",
                            Sinopsis = "Rachel, periodista, investiga una cinta maldita tras la muerte de su sobrina. Tras verla, recibe una llamada que le da 7 días para salvar su vida y la de su hijo.",
                            Titulo = "El aro",
                            Trailer = "https://www.youtube.com/watch?v=3-1GGz_gTnQ&ab_channel=DigicineDistribuidora"
                        },
                        new
                        {
                            PeliculaId = 3,
                            GeneroId = 2,
                            Poster = "https://th.bing.com/th/id/OIP.8RmTep5x66mXiB7HiOqUUgHaLg?w=116&h=180&c=7&r=0&o=5&pid=1.7",
                            Sinopsis = "En la era Sengoku, un ronin llamado Nanashi protege a Kotarou y su perro Tobimaru de una organización china. Se embarcan en una peligrosa aventura en medio del conflicto de los Estados.",
                            Titulo = "The sword of the stranger",
                            Trailer = "https://tinyurl.com/3rdpbv3h"
                        },
                        new
                        {
                            PeliculaId = 4,
                            GeneroId = 9,
                            Poster = "https://th.bing.com/th/id/OIP.wqhKWgCaUmC5LAWP0auNzQHaLP?w=178&h=271&c=7&r=0&o=5&pid=1.7",
                            Sinopsis = "Durante un trayecto del tren Orient-Express se produce un asesinato. Cuando una avalancha detiene el tren, el prestigioso detective Hércules Poirot sube al vehículo para investigar quién es el asesino, pero todos los pasajeros parecen sospechosos.",
                            Titulo = "Asesinato en el expreso de oriente",
                            Trailer = "https://www.youtube.com/watch?v=f8ne09GR8aE&ab_channel=20thCenturyStudiosEspa%C3%B1a"
                        },
                        new
                        {
                            PeliculaId = 5,
                            GeneroId = 7,
                            Poster = "https://th.bing.com/th/id/OIP.sI0vbZwcYD1oEHt04j1vQwAAAA?w=115&h=180&c=7&r=0&o=5&pid=1.7",
                            Sinopsis = "Cuando Shrek y la princesa Fiona regresan de su luna de miel, los padres de ella los invitan a visitar el reino de Muy Muy Lejano para celebrar la boda. Para Shrek, al que nunca abandona su fiel amigo Asno, esto constituye un gran problema.",
                            Titulo = "Shrek 2",
                            Trailer = "https://www.youtube.com/watch?v=xBxVgh-kgAI&ab_channel=JoyasDeLaAnimaci%C3%B3n"
                        },
                        new
                        {
                            PeliculaId = 6,
                            GeneroId = 4,
                            Poster = "https://th.bing.com/th/id/OIP.Bq0l0fHXM3N9ieG_JyiuNwHaLH?w=115&h=180&c=7&r=0&o=5&pid=1.7",
                            Sinopsis = "Un tirano de África del Norte arriesga su vida para asegurar que la democracia nunca llegue al país al que mantiene oprimido.",
                            Titulo = "El dictador",
                            Trailer = "https://www.youtube.com/watch?v=i9qH93yZAdo&ab_channel=TrailersyEstrenos"
                        },
                        new
                        {
                            PeliculaId = 7,
                            GeneroId = 7,
                            Poster = "https://th.bing.com/th/id/OIP.e8BVI2EbDHPGc8b7-UUqLAHaJQ?w=178&h=223&c=7&r=0&o=5&pid=1.7",
                            Sinopsis = "Dos hermanos plomeros, Mario y Luigi, caen por las alcantarillas y llegan a un mundo subterráneo mágico en el que deben enfrentarse al malvado Bowser para rescatar a la princesa Peach, quien ha sido forzada a aceptar casarse con él.",
                            Titulo = "Mario Bros",
                            Trailer = "https://www.youtube.com/watch?v=SvJwEiy2Wok&ab_channel=SensaCineTRAILERS"
                        },
                        new
                        {
                            PeliculaId = 8,
                            GeneroId = 9,
                            Poster = "https://th.bing.com/th/id/OIP.PwZP-r6lwxa7jqI9VHU7cwAAAA?w=123&h=180&c=7&r=0&o=5&pid=1.7",
                            Sinopsis = "Después de la II Guerra Mundial, Poirot vuelve a investigar en Venecia en una noche de terror y misterio. Cuando un invitado muere en una sesión de espiritismo, el detective retirado se sumerge en un oscuro enigma.",
                            Titulo = "Caceria en Venecia",
                            Trailer = "https://www.youtube.com/watch?v=JymKmSe5TOk&ab_channel=20thCenturyStudiosLA"
                        },
                        new
                        {
                            PeliculaId = 9,
                            GeneroId = 6,
                            Poster = "https://th.bing.com/th/id/OIP.1SYaJrlCFCqwOq52VzLG-wHaLH?w=125&h=187&c=7&r=0&o=5&pid=1.7",
                            Sinopsis = "Tras la Guerra de Secesión, el Capitán Nathan Algren y el líder samurái Katsumoto se enfrentan a un Japón en transformación. El emperador japonés los une en un choque de culturas mientras Algren entrena a un nuevo ejército.",
                            Titulo = "El ultimo samurai",
                            Trailer = "https://www.youtube.com/watch?v=-c74IrUQAoc&ab_channel=DeTrailers"
                        },
                        new
                        {
                            PeliculaId = 10,
                            GeneroId = 1,
                            Poster = "https://th.bing.com/th/id/OIP.o9U2d0zadTrIXP6E1_Ew7AHaEK?pid=ImgDet&rs=1",
                            Sinopsis = "Robert De Niro, Sharon Stone y Joe Pesci protagonizan la fascinante película de Martin Scorsese que le echa un vistazo a la manera en que la ambición ciega, la pasión candente y la codicia de 24 quilates derrumbaron el imperio de un casino de Las Vegas.",
                            Titulo = "Casino",
                            Trailer = "https://www.youtube.com/watch?v=EJXDMwGWhoA&ab_channel=Movieclips"
                        },
                        new
                        {
                            PeliculaId = 11,
                            GeneroId = 6,
                            Poster = "https://th.bing.com/th/id/OIP.IhQIQ8q8Bo9uhAWjgJoc0AHaK-?pid=ImgDet&rs=1",
                            Sinopsis = "Los años 20 nunca han estado mejor descritos que en esta romántica y suntuosa nueva versión del clásico de F. Scott Fitzgerald sobre la Era del Jazz.",
                            Titulo = "El gran Gatsby",
                            Trailer = "https://www.youtube.com/watch?v=tgx3mpSUwBA&ab_channel=WarnerBros.PicturesEspa%C3%B1a"
                        },
                        new
                        {
                            PeliculaId = 12,
                            GeneroId = 6,
                            Poster = "https://th.bing.com/th/id/OIP.ZC32-wAQQGPVQ64Psduo2AHaLH?pid=ImgDet&rs=1",
                            Sinopsis = "Un bróker que disfruta de un estilo de vida decadente y desenfrenado trata de eludir al FBI mientras él y sus compañeros se hacen ricos gracias a unos negocios turbios.",
                            Titulo = "El lobo de wall street",
                            Trailer = "https://www.youtube.com/watch?v=DEMZSa0esCU&ab_channel=TrailersyEstrenos"
                        },
                        new
                        {
                            PeliculaId = 13,
                            GeneroId = 8,
                            Poster = "https://tinyurl.com/yyuasf93",
                            Sinopsis = "Comedia animada que sigue las andanzas de un joven que realiza servicios comunitarios tras ser arrestado durante las fiestas de fin de año.",
                            Titulo = "8 noches de locura",
                            Trailer = "https://www.youtube.com/watch?v=q0Nsh8cb000&ab_channel=JaimeRodd"
                        },
                        new
                        {
                            PeliculaId = 14,
                            GeneroId = 6,
                            Poster = "https://th.bing.com/th/id/OIP.LjuYRh2pKrTATwL-Mou12gAAAA?pid=ImgDet&rs=1",
                            Sinopsis = "Jesse James planea su próximo gran robo pero su cabeza tiene precio por varios crímenes anteriores: quien capture a Jesse recibirá una gran recompensa. Varias personas le persiguen, incluso es traicionado por un miembro de su propia banda.",
                            Titulo = "El asesinato de jesse james",
                            Trailer = "https://www.youtube.com/watch?v=twadXH9PGgE&ab_channel=LeandroC"
                        },
                        new
                        {
                            PeliculaId = 15,
                            GeneroId = 6,
                            Poster = "https://th.bing.com/th/id/OIP.M8qy4VxDSysV7wg_GscNEwHaKk?w=118&h=180&c=7&r=0&o=5&pid=1.7",
                            Sinopsis = "La película sigue a Kevin, quien tiene 23 personalidades debido a su trastorno de identidad disociativo. Secuestra a tres adolescentes y espera la aparición de su personalidad más temible, La Bestia.",
                            Titulo = "Fragmentado",
                            Trailer = "https://www.youtube.com/watch?v=3fQ82KWRRfo&ab_channel=CineHome"
                        },
                        new
                        {
                            PeliculaId = 16,
                            GeneroId = 2,
                            Poster = "https://pics.filmaffinity.com/puss_in_boots_the_last_wish-897078202-mmed.jpg",
                            Sinopsis = "El Gato con Botas descubre que su pasión por la aventura le ha pasado factura: ha consumido ocho de sus nueve vidas, por ello emprende un viaje épico para encontrar el mítico Último Deseo y restaurar sus nueve vidas",
                            Titulo = "El gato con botas: El último deseo",
                            Trailer = "https://www.youtube.com/watch?v=QaiUm8jNiCk&ab_channel=UniversalSpain"
                        },
                        new
                        {
                            PeliculaId = 17,
                            GeneroId = 2,
                            Poster = "https://pics.filmaffinity.com/lilo_stitch-502239805-mmed.jpg",
                            Sinopsis = "Lilo, una niña hawaiana solitaria, encuentra a Stitch, un experimento alienígena en la Tierra. A través del amor y la unión familiar de \"ohana,\" transforman sus vidas y enseñan el valor del cuidado y la amistad.",
                            Titulo = "Lilo & Stich",
                            Trailer = "https://www.youtube.com/watch?v=9OAC55UWAQs&ab_channel=RottenTomatoesClassicTrailers"
                        },
                        new
                        {
                            PeliculaId = 18,
                            GeneroId = 6,
                            Poster = "https://pics.filmaffinity.com/dog-263685812-mmed.jpg",
                            Sinopsis = "El ranger del ejército Briggs debe llevar a Lulu, un perro de guerra, de Washington a Arizona para un emotivo funeral, enfrentando sus traumas y problemas emocionales en el camino.",
                            Titulo = "Dog: Una aventura salvaje",
                            Trailer = "https://www.youtube.com/watch?v=LJcVhteNnSY&ab_channel=TrailersInSpanish"
                        },
                        new
                        {
                            PeliculaId = 19,
                            GeneroId = 2,
                            Poster = "https://pics.filmaffinity.com/walloe-973488527-mmed.jpg",
                            Sinopsis = "En el año 2800, WALL•E, un robot de limpieza en un planeta Tierra devastado, conoce a EVE, una exploradora robot. Juntos emprenden una emocionante aventura galáctica, cambiando sus vidas para siempre.",
                            Titulo = "WALL•E",
                            Trailer = "https://www.youtube.com/watch?v=CZ1CATNbXg0&ab_channel=RottenTomatoesClassicTrailers"
                        },
                        new
                        {
                            PeliculaId = 20,
                            GeneroId = 2,
                            Poster = "https://pics.filmaffinity.com/happy_feet-637452144-mmed.jpg",
                            Sinopsis = "Comedia familiar que narra la historia de unos pingüinos en la Antártida. Para atraer a su pareja los pingüinos deben entonar una canción, pero uno de ellos no sabe cantar, pero es un gran bailarín de claqué.",
                            Titulo = "Happy Feet",
                            Trailer = "https://www.youtube.com/watch?v=aIBsnOyJB7Y&ab_channel=WarnerMoviesOnDemand"
                        });
                });

            modelBuilder.Entity("Domain.Entity.Sala", b =>
                {
                    b.Property<int>("SalaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalaId"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SalaId");

                    b.ToTable("Salas");

                    b.HasData(
                        new
                        {
                            SalaId = 1,
                            Capacidad = 5,
                            Nombre = "sala 1"
                        },
                        new
                        {
                            SalaId = 2,
                            Capacidad = 15,
                            Nombre = "sala 2"
                        },
                        new
                        {
                            SalaId = 3,
                            Capacidad = 35,
                            Nombre = "sala 3"
                        });
                });

            modelBuilder.Entity("Domain.Entity.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<int>("FuncionId")
                        .HasColumnType("int")
                        .HasColumnName("funcionID")
                        .HasColumnOrder(2);

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(3);

                    b.HasKey("TicketId");

                    b.HasIndex("FuncionId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Domain.Entity.Funcion", b =>
                {
                    b.HasOne("Domain.Entity.Pelicula", "Peliculas")
                        .WithMany("Funciones")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Sala", "Salas")
                        .WithMany("Funciones")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peliculas");

                    b.Navigation("Salas");
                });

            modelBuilder.Entity("Domain.Entity.Pelicula", b =>
                {
                    b.HasOne("Domain.Entity.Genero", "Generos")
                        .WithMany("Peliculas")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generos");
                });

            modelBuilder.Entity("Domain.Entity.Ticket", b =>
                {
                    b.HasOne("Domain.Entity.Funcion", "Funciones")
                        .WithMany("Tickets")
                        .HasForeignKey("FuncionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("Domain.Entity.Funcion", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Domain.Entity.Genero", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("Domain.Entity.Pelicula", b =>
                {
                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("Domain.Entity.Sala", b =>
                {
                    b.Navigation("Funciones");
                });
#pragma warning restore 612, 618
        }
    }
}
