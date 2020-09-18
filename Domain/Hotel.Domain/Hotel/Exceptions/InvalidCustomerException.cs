﻿namespace Hotel.Domain.Hotel.Exceptions
{
    using Common;

    public class InvalidCustomerException: BaseDomainException
    {
        public InvalidCustomerException()
        {
        }

        public InvalidCustomerException(string error) => this.Error = error;
    }
}
