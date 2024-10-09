using Microsoft.AspNetCore.Mvc;

namespace NikaScrapApp.Web.Utility
{
    public class Notification
    {
        public string Message { get; set; }
        public string Type { get; set; } // e.g., "success", "error", "warning", "info"

    }

    public static class NotificationHelper
    {
        public static void SetNotification(Controller controller, string message, string type)
        {
            controller.TempData["Notification"] = new Notification { Message = message, Type = type };
        }

        public static Notification GetNotification(Controller controller)
        {
            if (controller.TempData["Notification"] != null)
            {
                return (Notification)controller.TempData["Notification"];
            }
            return null;
        }
    }
}
