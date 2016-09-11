using System;
using System.ComponentModel.DataAnnotations;

namespace FPTB.Data.Model
{
    public class ContactMessage
    {
        [Key]
        public int MessageId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string MessageBody { get; set; }

        public DateTime DateCreated{ get; set; }

    }
}
