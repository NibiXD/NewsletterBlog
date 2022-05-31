using System;

namespace Newsletter.Models
{
    public class EmailSettings
    {
        public string Host { get; set; }
        public Int32 Port { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
