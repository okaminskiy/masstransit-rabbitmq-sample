﻿using System;

namespace Domain.Messages
{
    public class AuthorizeCustomer
    {
        public Guid CustomerId;
        public string Email;
    }
}