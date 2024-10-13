using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace NikaScrapApp.Web.Utility
{
    public class Notification
    {
        public Notification(string type, string message)
        {
            this.Type = type.ToLower() == "error" ? "danger" : type.ToLower();
            this.Message = message;
            this.DisplayType = type.ToLower() == "danger" ? "Error" : type.ToLower() == "success" ? "Success" : type.ToLower() == "warning" ? "Warning" : type.ToLower() == "error" ? "Error" : type.ToLower();
        }
        public string Message { get; set; }
        public string Type { get; set; } // e.g., "success", "danger", "warning", "info"
        public string DisplayType { get; set; } 

    }

    public static class NotificationHelper
    {
        public static void SetNotification(Controller controller, string message, string type)
        {
            var notification = new Notification(type, message);
            controller.TempData["Notification"] = System.Text.Json.JsonSerializer.Serialize(notification);
        }

        public static Notification GetNotification(ITempDataDictionary tempData)
        {
            if (tempData.TryGetValue("Notification", out var obj) && obj is string notificationJson)
            {
                return System.Text.Json.JsonSerializer.Deserialize<Notification>(notificationJson);
            }
            return null;
        }

            //public static Notification GetNotification(Controller controller)
            //{
            //    if (controller.TempData["Notification"] != null)
            //    {
            //        return (Notification)controller.TempData["Notification"];
            //    }
            //    return null;
            //}
        }
    }
