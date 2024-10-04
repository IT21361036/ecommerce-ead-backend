/***************************************************************
 * File Name: ProductModel.cs
 * Description: Represents the Product model which defines the schema 
 *              for products stored in the MongoDB database. This 
 *              model includes various fields such as product name, 
 *              description, price, stock quantity, category, and vendor 
 *              information, ensuring that all necessary product 
 *              attributes are captured.
 * Author: Saara M.K.F
 * Date Created: 30-10-2024
 * Notes: This class includes a flag (`IsLowStock`) that is set to 
 *        true when the stock quantity reaches a critical low level. 
 *        This can be used to trigger notifications or alerts for 
 *        restocking purposes. The image URL field (`Imgurl`) allows 
 *        storing the product's visual representation.
 ***************************************************************/

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EADProject.Models
{
    // Represents a product entity in the system.
    public class ProductModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        // Name of the product.
        public string Name { get; set; }

        // Image of the product.
        public string? Imgurl { get; set; }

        // Detailed description of the product.
        public string Description { get; set; }

        // Price of the product.
        public decimal Price { get; set; }

        // Quantity of the product in stock.
        public int StockQuantity { get; set; }

        // Flag to indicate if the product stock is low.
        public bool IsLowStock { get; set; } = false;

        // Vendor ID associated with the product.
        public string VendorId { get; set; }

        // Category name to which the product belongs.
        public string CategoryName { get; set; }
    }
}
