namespace DigitalKabadiApp.API.Helper
{
    public class SmsTemplates
    {
        public string Type { get; set; }
        public string TemplateCode { get; set; }
        public string SmsTemplate { get; set; }
    }

    public static class SmsTemplateHelper
    {
        public static List<SmsTemplates> GetSmsTemplates()
        {
            return new List<SmsTemplates>() {
              new SmsTemplates (){ Type="OTP", TemplateCode="1707172892361252510", SmsTemplate="Your Dimpy Designs Registration Verification Code is {#var#}" },
              new SmsTemplates (){ Type="OrderConfirmed", TemplateCode="1707172892347689102", SmsTemplate="Thanks for using Dimpy Designs. Your Pickup Order has been confirmed. Your Pickup code is {#var#} Our Team will collect your Order soon" },
              new SmsTemplates (){ Type="NotServing", TemplateCode="1707172892372370321", SmsTemplate="Thanks for showing interest in Dimpy Designs. Currently we are not serving in Your area. We will connect to You once operations starts in Your area" },
              new SmsTemplates (){ Type="PlaceOrder", TemplateCode="1707172892279607120", SmsTemplate="Thanks for placing Order with Dimpy Designs. Our Team will connect you soon and confirm. For any query please call at 8092929237" }
            };
        }
    }
}
