﻿namespace CMS.JWT.TokenServices
{
    /// <summary>
    /// 
    /// </summary>
    public class TokenConstants
    {
        public const string Issuer = "thisismeyouknow";
        public const string Audience = "thisismeyouknow";
        public const int ExpiryInMinutes = 5;
        public const string key = "thiskeyisverylargetobreak";
    }
}
