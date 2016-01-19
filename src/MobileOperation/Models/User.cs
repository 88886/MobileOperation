using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MobileOperation.Models
{
    public class User : IdentityUser
    {
        [MaxLength(64)]
        public string Department { get; set; }

        public int PositionLevel { get; set; }
        
        [MaxLength(64)]
        public string Position { get; set; }
    }
}
