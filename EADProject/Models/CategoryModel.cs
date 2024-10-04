/***************************************************************
 * File Name: CategoryModel.cs
 * Description: Represents the data model for product categories in 
 *              the system. This model is used to store and manage 
 *              category information within the MongoDB database.
 * Author: Saara M.K.F
 * Date Created: 03-10-2024
 * Notes: The `CategoryModel` class includes details such as:
 *        - `CategoryName`: Must be unique for each category.
 *        - `CategoryCount`: Represents the number of products under the category.
 *        - `IsActive`: Indicates whether the category is active, 
 *                      which determines if it can be assigned to new products.
 ***************************************************************/

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EADProject.Models
{
    public class CategoryModel
    {
        // MongoDB document ID, represented as an ObjectId.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        // Name of the category.
        public string CategoryName { get; set; }

        //Product count
        public int? CategoryCount { get; set; }

        // Status flag indicating if the category is active.
        public bool IsActive { get; set; } = true;
    }
}
