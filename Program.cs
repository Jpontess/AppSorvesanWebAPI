
using AppSorvesanWeb.Data;
using AppSorvesanWeb.Services;
using Microsoft.EntityFrameworkCore;

namespace AppSorvesanWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //conex�o com o sql server AppSorvesanDb
            var connection = builder.Configuration.GetConnectionString("DefaultConnetion");
            builder.Services.AddDbContext<SorveteriaContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            // Nova instancia ser� criada para cada requisi��o http.
            builder.Services.AddScoped<IPedidoService, PedidoService>();

           

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
