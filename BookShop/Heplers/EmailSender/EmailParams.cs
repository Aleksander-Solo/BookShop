namespace BookShop.Heplers.EmailSender
{
    public class EmailParams
    {
        public string HostSmpt { get; set; }
        public bool EnableSsl { get; set; }
        public int Port { get; set; }
        public string SenderEmail { get; set; }
        public string SenderEmailPassword { get; set; }
        public string SenderName { get; set; }
    }
}
