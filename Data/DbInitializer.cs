using Aula03.Pages;
using Events.API.Models;

namespace Events.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context) {
            if (context.Clients!.Any()) {
                return;
            }

            var events = new ClientModel[] {
                new ClientModel{
                    Name ="Torneio de truco", 
                    Description = "Campeonado acadêmico de CC da UTFPR", 
                    Date = DateTime.Parse("2023-04-01")
                },
            };
            var events = new ClientModel[] {
                new ClientModel{
                    Name ="Torneio de truco", 
                    Description = "Campeonado acadêmico de CC da UTFPR", 
                    Date = DateTime.Parse("2023-04-01")
                },
            };

            context.AddRange(events);
            context.SaveChanges();
        }
    }
}