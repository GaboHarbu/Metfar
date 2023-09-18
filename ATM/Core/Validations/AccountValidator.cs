namespace ATM.Core.Validations
{
    using ATM.Core.Domain;

    public class AccountValidator
    {
        public static void Validate(Account account) 
        {
            if (account == null)
            {
                throw new NullReferenceException("Account not found.");
            }
        }
    }
}
