﻿namespace CMS.Models
{
    public class AuthToken
    {
        public long ExpiresIn { get; set; }

        public string AccessToken { get; set; }
    }
}
