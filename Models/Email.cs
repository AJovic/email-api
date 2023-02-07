using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmailApp.Models
{
    public enum Importances
    {
        Low,
        Normal,
        High
    }

    public class Email
    {
        public int ID { get; set; }
        [MaxLength(255)]
        public string From { get; set; }
        [MaxLength(255)]
        public string To { get; set; }
        public string Cc { get; set; }
        [MaxLength(255)]
        public string Subject { get; set; }
        public Importances Importance { get; set; }
        public string Content { get; set; }
    }
}
