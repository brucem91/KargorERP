using System;

namespace KargorERP.Data.Models.Identity
{
    public class UserSessionToken : Model
    {
        public string Token { get; set; }
        public Guid UserId { get; set; }
    }
}