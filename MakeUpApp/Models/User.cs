﻿using Microsoft.AspNetCore.Identity;

namespace MakeUpApp.Models
{
    public class User : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

    }
}

