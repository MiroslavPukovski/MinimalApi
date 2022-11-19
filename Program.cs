using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCartList.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options => {
                options.AddPolicy("AllowAll", a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            var dbPath = Path.Join("./shoppingcart.db");
            var conn = new SqliteConnection($"Data Source={dbPath}");
            builder.Services.AddDbContext<ShoppingCartDbContext>(opt => opt.UseSqlite(conn));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseAuthorization();

            //return All
            app.MapGet("/shoppingcart", async (ShoppingCartDbContext db) =>
            await db.ShoppingCarts.ToListAsync()
            );

            //return picked items
            app.MapGet("/shoppingcart/pickedup", async (ShoppingCartDbContext db) =>
            await db.ShoppingCarts.Where(x => x.isPickedUp).ToListAsync()
            );

            //return specific item by id
            app.MapGet("/shoppingcart/{id}", async (int id, ShoppingCartDbContext db) =>
            await db.ShoppingCarts.FindAsync(id)
            is ShoppingCart shoppingCart
            ? Results.Ok(shoppingCart)
            : Results.NotFound()
            );

            //update
            app.MapPut("/shoppingcart/{id}", async (int id, ShoppingCart shoppingCart, ShoppingCartDbContext db) =>
            {
                var record = await db.ShoppingCarts.FindAsync(id);
                if(record == null) return Results.NotFound();

                record.ItemName = shoppingCart.ItemName;
                record.isPickedUp = shoppingCart.isPickedUp;
                record.Quantity = shoppingCart.Quantity;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            //create new
            app.MapPost("/shoppingcart", async (ShoppingCart shoppingCart, ShoppingCartDbContext db) =>
            {
                db.Add(shoppingCart);

                await db.SaveChangesAsync();

                return Results.Created($"/shoppingcart/{shoppingCart.Id}",shoppingCart);
            });

            //delete
            app.MapDelete("/shoppingcart/{id}", async (int id, ShoppingCartDbContext db) =>
            {
                var record = await db.ShoppingCarts.FindAsync(id);
                if (record == null) return Results.NotFound();

                db.Remove(record);

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            app.Run();
        }
    }
}