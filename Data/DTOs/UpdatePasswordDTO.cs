﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class UpdatePasswordDTO
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
