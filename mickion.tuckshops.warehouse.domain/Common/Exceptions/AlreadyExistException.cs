﻿namespace mickion.tuckshops.warehouse.domain.Common.Exceptions
{
    public class AlreadyExistException: Exception
    {
        public AlreadyExistException(string message): base(message) { }
    }
}
