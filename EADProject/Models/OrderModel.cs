//using MongoDB.Bson.Serialization.Attributes;
//using MongoDB.Bson;

//public class OrderItemModel
//{
//    //public string ProductId { get; set; }
//    public string ProductName { get; set; }
//    public string VendorId { get; set; }
//    public int Quantity { get; set; }
//    public decimal Price { get; set; }


//    public VendorOrderStatus VendorStatus { get; set; } = VendorOrderStatus.Processing;  // Default status
//}

//public enum VendorOrderStatus
//{
//    Processing,
//    Ready,

//}

//public enum OrderStatus
//{

//    Processing,
//    VendorReady,
//    PartiallyDelivered,
//    Delivered,
//    Canceled
//}


//public class OrderModel
//{
//    [BsonId]
//    [BsonRepresentation(BsonType.ObjectId)]
//    public string? Id { get; set; }

//    public List<OrderItemModel> Items { get; set; } = new List<OrderItemModel>();

//    //public OrderStatus Status { get; set; } = OrderStatus.Processing;
//    public OrderStatus Status { get; set; } = OrderStatus.Processing;  // By default, status is pending.

//    public string ShippingAddress { get; set; }

//    public decimal TotalAmount { get; set; }

//    public string PaymentMethod { get; set; }

//    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

//    //Order count
//    public int? OrderCount { get; set; }

//    // Track cancellation requests from customers
//    public bool IsCancellationRequested { get; set; } = false;

//    // Cancellation note (if CSR/Admin cancels it)
//    public string? CancellationNote { get; set; }


//}
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

public class OrderItemModel
{
    // Name of the product in the order item.
    public string ProductName { get; set; }

    // The unique identifier for the vendor supplying this product.
    public string VendorId { get; set; }

    // Quantity of the product ordered.
    public int Quantity { get; set; }

    // Price of the product in the order item.
    public decimal Price { get; set; }

    // Status of the order item, specific to the vendor's processing.
    public VendorOrderStatus VendorStatus { get; set; } = VendorOrderStatus.Processing;  // Default status is set to 'Processing'.
}

public enum VendorOrderStatus
{
    // Indicates the vendor is still processing the order item.
    Processing,

    // Indicates the vendor has marked the item as ready for dispatch.
    Ready,
}

public enum OrderStatus
{
    // The order is currently being processed.
    Processing,

    // All vendors have marked their items as ready.
    VendorReady,

    // Some vendors have marked items as ready, others are still processing.
    PartiallyDelivered,

    // The order has been fully delivered.
    Delivered,

    // The order has been canceled.
    Canceled
}

public class OrderModel
{
    // MongoDB document ID, represented as an ObjectId.
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    // A list of items associated with the order.
    public List<OrderItemModel> Items { get; set; } = new List<OrderItemModel>();

    // The overall status of the order, default is 'Processing'.
    public OrderStatus Status { get; set; } = OrderStatus.Processing;

    // Shipping address for the order.
    public string ShippingAddress { get; set; }

    // Total amount to be paid for the order.
    public decimal TotalAmount { get; set; }

    // Payment method chosen for the order (e.g., Credit Card, PayPal).
    public string PaymentMethod { get; set; }

    // The date and time when the order was placed, default is the current UTC time.
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    // The count of how many times this order has been placed (if applicable).
    public int? OrderCount { get; set; }

    // Indicates if the customer has requested order cancellation.
    public bool IsCancellationRequested { get; set; } = false;

    // A note providing the reason for cancellation (if canceled by CSR/Admin).
    public string? CancellationNote { get; set; }
}