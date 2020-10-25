using System;
using System.Collections;

namespace Cryptocop.Software.API.Models.Entities
{
    public class JwtToken
    {
        public int Id { get; set; }
        public bool Blacklisted { get; set; }
    }
}