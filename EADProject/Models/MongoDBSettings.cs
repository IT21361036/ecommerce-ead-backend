/***************************************************************
* File Name: MongoDBSettings.cs
 * Description: This class holds configuration settings for connecting
 *              to a MongoDB database. The settings include the 
 *              connection string and the database name, which are 
 *              essential for establishing and managing database
 *              connections within the application.
 * Author: Saara M.K.F
 * Date Created: 28-09-2024
 * Notes: The settings in this class are injected into the application's 
 *        services through dependency injection, allowing easy and 
 *        centralized access to the MongoDB connection configuration.
 ***************************************************************/

namespace EADProject.Models
{
    public class MongoDBSettings
    {
        // MongoDB connection string required to establish a database connection
        public required string ConnectionString { get; set; }

        // Name of the MongoDB database to be used
        public required string DatabaseName { get; set; }
    }
}
