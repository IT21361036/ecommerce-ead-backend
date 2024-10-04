/***************************************************************
 * File Name: UserModel.cs
 * Description: Represents the structure of a user model stored in 
 *              the MongoDB database, encompassing fields for user 
 *              identification, contact information, credentials, 
 *              role, and account status.
 * Author: Saara M.K.F
 * Date Created: 02-10-2024
 * Notes: The 'Id' field is represented as a MongoDB ObjectId. 
 *        User accounts are initially set to 'Pending' status and 
 *        inactive upon creation. Ensure that passwords are securely 
 *        hashed in actual implementations.
 ***************************************************************/

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EADProject.Models
{
    public class UserModel
    {
        // Represents the unique ID of the user, stored as ObjectId in MongoDB.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        //Stores the user's name.
        public string? Name { get; set; }

        // Stores the user's email address.
        public string Email { get; set; }

        // Stores the user's password (ensure it is hashed in real implementations).
        public string Password { get; set; }

        // Stores the user's  address.
        public string? Address { get; set; }

        // Stores the user's role, e.g., Admin, User, CSR.
        public string? Role { get; set; } 

        // Indicates the user status 
        public String UserStatus { get; set; } = "Pending"; // By default, status is pending.

        // Indicates whether the user's account is active or not. Defaults to true.
        public bool IsActive { get; set; } = false; // By default, the user is not active.
    }
}

