
/***************************************************************
* File Name: CategoryController.cs
 * Description: This controller manages HTTP requests for product 
 *              categories, providing endpoints for creating, 
 *              retrieving, and updating category status. It ensures 
 *              seamless management of product categories in the system.
 * Author: Saara M.K.F
 * Date Created: 28 - 09 - 2024
 * Notes: This controller utilizes the CategoryService to perform 
 *        CRUD operations on categories and handle status updates.
 *        It includes endpoints for creating new categories, fetching 
 *        all categories, activating/deactivating categories, and 
 *        retrieving categories with associated product counts.
 ***************************************************************/
using EADProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/admin-notifications")]
[ApiController]
public class AdminNotificationController : ControllerBase
{
    private readonly AdminNotificationService _adminNotificationService;

    public AdminNotificationController(AdminNotificationService adminNotificationService)
    {
        _adminNotificationService = adminNotificationService;
    }

    // Get unread admin notifications
    [HttpGet("unread")]
    public async Task<IActionResult> GetUnreadAdminNotifications()
    {
        var notifications = await _adminNotificationService.GetUnreadAdminNotificationsAsync();
        return Ok(notifications);
    }

    
}
