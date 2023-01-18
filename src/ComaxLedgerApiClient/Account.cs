﻿namespace CommunAxiom.Ledger.Api.Contracts
{
    public class Account
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
