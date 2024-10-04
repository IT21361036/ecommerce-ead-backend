/***************************************************************
 * File Name: Program.cs
 * Description: This file serves as the entry point for the EAD 
 *              project, initializing and configuring all services, 
 *              middleware, and MongoDB connection settings required 
 *              for the application to run. It sets up routing, 
 *              controllers, dependency injection, CORS policies, and 
 *              Swagger for API documentation.
 * Author: Saara M.K.F
 * Date Created: 29-09-2024
 * Notes: This application uses MongoDB for data persistence. The 
 *        configuration includes the registration of multiple services 
 *        such as UserService and ProductService. CORS is enabled to 
 *        allow cross-origin requests, and Swagger is configured for 
 *        API testing and documentation during development.
 ***************************************************************/
using System.Text.Json.Serialization; 
using EADProject.Models;
using EADProject.Services;
using MongoDB.Driver;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure MongoDB settings from the appsettings.json configuration section.
        builder.Services.Configure<MongoDBSettings>(
            builder.Configuration.GetSection("MongoDBSettings"));

        // Register MongoClient as a singleton to manage the MongoDB connection.
        builder.Services.AddSingleton<IMongoClient>(s =>
            new MongoClient(builder.Configuration.GetValue<string>("MongoDBSettings:ConnectionString")));

        // Register application services like UserService, ProductService, OrderService, and CategoryService.
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<ProductService>();
        builder.Services.AddScoped<OrderService>();
        builder.Services.AddScoped<CategoryService>();
        builder.Services.AddScoped<VendorNotificationService>();
        builder.Services.AddScoped<AdminNotificationService>();

        // Add controllers to handle HTTP requests and responses.
        //builder.Services.AddControllers();

        // Add controllers with JSON options
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            // Add enum converter to serialize enums as strings
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        builder.Services.AddEndpointsApiExplorer(); // Add API explorer for endpoint discovery.
        builder.Services.AddSwaggerGen(); // Add Swagger for API documentation (if in development).

        // Add CORS policy to allow cross-origin requests from any origin.
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });

        var app = builder.Build();

        // Apply CORS policy to allow requests from all origins.
        app.UseCors("AllowAllOrigins");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            // Enable Swagger UI only in development for API testing and documentation.
            //app.UseSwagger();
            //app.UseSwaggerUI();
        }

        // Use authorization middleware to protect API endpoints.
        app.UseAuthorization();

        // Map controllers to handle API routes.
        app.MapControllers();

        // Run the application.
        app.Run();
    }
}
