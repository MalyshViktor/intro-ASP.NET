using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace intro.DAL.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string RealName { get; set; }
        public string Login { get; set; }
        public string PassHash { get; set; }
        public string PassSalt { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public DateTime RegMoment { get; set; }
        public DateTime? LogMoment { get; set; }
    }
}
