using System;
using System.Collections.Generic;
using System.Text;

namespace F1Stats.Data
{
    public class TokenModel
    {
        /// <summary>
        /// JWT token granted to the user
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Expiration date of the token
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}
