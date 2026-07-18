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
                   new Subscription{ Name="Novatos",  Fee=49.99M, SubscriptProgram="Começe a jogar", Duration = Subscription.DurationTime.Monthly},
                    new Subscription{ Name="Experts",  Fee=149.99M, SubscriptProgram="Alta competição", Duration = Subscription.DurationTime.Quarterly}
                ];
                await dbContext.Subscriptions.AddRangeAsync(subscriptions);
                haAdicao = true;
            }

            // Se não houver MyUser, cria-os
            var myUsers = Array.Empty<MyUser>();
            if (!dbContext.AppUsers.Any())
            {
                myUsers = [
                    new MyUser { Name="João Silva", BirthDate=DateOnly.Parse("1999-12-31"),CellPhone="92345687"},
                    new MyUser { Name="Maria Santos", BirthDate=DateOnly.Parse("2000-12-15"),CellPhone="9612347"  },
                    new MyUser { Name="Ana Costa", BirthDate=DateOnly.Parse("2000-12-15"),CellPhone=""  }
                  ];
                await dbContext.AppUsers.AddRangeAsync(myUsers);
                haAdicao = true;
            }



            // Se não houver Campos, cria-os
            var fields = Array.Empty<Field>();
            if (!dbContext.TennisFields.Any())
            {
                fields = [
                    new Field { Name = "Campo Central", Surface = Field.SurfaceType.Clay, IsIndoor = false },
                    new Field { Name = "Campo 2", Surface = Field.SurfaceType.HardCourt, IsIndoor = false },
                    new Field { Name = "Pavilhão A", Surface = Field.SurfaceType.Synthetic, IsIndoor = true }
                ];
                await dbContext.TennisFields.AddRangeAsync(fields);
                haAdicao = true;
            }

            // Se não houver Funcionários, cria-os
            var employees = Array.Empty<Employee>();
            if (!dbContext.Employees.Any())
            {
                employees = [
                    new Employee { Name = "Carlos Ferreira", Position = "Treinador", Salary = 1400.00m, HireDate = new DateTime(2022, 9, 1) },
                    new Employee { Name = "Rita Almeida", Position = "Rececionista", Salary = 1000.00m, HireDate = new DateTime(2023, 3, 15) }
                ];
                await dbContext.Employees.AddRangeAsync(employees);
                haAdicao = true;
            }

            // Se não houver Jogos, cria-os
            // (associados aos campos e funcionários criados acima)
            if (!dbContext.Matches.Any() && fields.Length > 0 && employees.Length > 0)
            {
                var matches = new Match[] {
                    new Match { MatchDate = DateTime.Now.AddDays(2).Date.AddHours(10), DurationMinutes = 90,
                       Field = fields[0], Employee = employees[0] },
                    new Match { MatchDate = DateTime.Now.AddDays(3).Date.AddHours(18), DurationMinutes = 60,
                       Field = fields[2] }
                };
                await dbContext.Matches.AddRangeAsync(matches);
                haAdicao = true;
            }


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

