namespace ATM.Core.Validations
{
    public static class RequestValidator
    {
        public static void Validate<TRequest>(TRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request can not be null.");
            }
        }
    }
}

