using DW_Projeto_API.Models;

namespace DW_Projeto_API.Data.Seed
{
    internal class DbInitializer
    {

        internal static async void Initialize(ApplicationDbContext dbContext)
        {

            /*
             * https://stackoverflow.com/questions/70581816/how-to-seed-data-in-net-core-6-with-entity-framework
             * 
             * https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0#initialize-db-with-test-data
             * https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/data/ef-mvc/intro/samples/5cu/Program.cs
             * https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0300
             */


            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            // var auxiliar
            bool haAdicao = false;




            // Se não houver Subscrições, cria-as
            var subscriptions = Array.Empty<Subscription>();

            if (!dbContext.Subscriptions.Any())
            {
                subscriptions = [
                    new Subscription{ Name="Novatos",  Fee=49.99M, SubscriptProgram="Começe a jogar"},
                    new Subscription{ Name="Experts",  Fee=149.99M, SubscriptProgram="Alta competição"}
                ];
                await dbContext.Subscriptions.AddRangeAsync(subscriptions);
                haAdicao = true;
            }



            /* tratar do warnig no myUsers 
            // Se não houver MyUser, cria-os
            var myUsers = Array.Empty<MyUser>();
            if (!dbContext.Members.Any())
            {
                myUsers = [
                    new MyUser { Name="João Silva", BirthDate=DateOnly.Parse("1999-12-31"),CellPhone="92345687"},
                    new MyUser { Name="Maria Santos", BirthDate=DateOnly.Parse("2000-12-15"),CellPhone="9612347"  },
                    new MyUser { Name="Ana Costa", BirthDate=DateOnly.Parse("2000-12-15"),CellPhone=""  }
                  ];
                await dbContext.Members.AddRangeAsync(myUsers);
                haAdicao = true;
            }
            */

            /* TODO
            // Se não houver campos, cria-os
            var fields = Array.Empty<>(Field);
            if (!dbContext.Fields.Any())
            {
                fields = [
                  
                    ];
                await dbContext.Fields.AddRangeAsync(fields);
                haAdicao = true;
            }
            */

            //TODO - Match e employees


            try
            {
                if (haAdicao)
                {
                    // tornar persistentes os dados
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
}
