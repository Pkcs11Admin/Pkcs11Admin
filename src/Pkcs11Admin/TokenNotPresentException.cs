using System;

namespace Net.Pkcs11Admin
{
    public class TokenNotPresentException : Exception
    {
        public TokenNotPresentException()
            : base("Token/card is not present in the slot/reader")
        {

        }

        public TokenNotPresentException(string message)
            : base(message)
        {

        }

        public TokenNotPresentException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
