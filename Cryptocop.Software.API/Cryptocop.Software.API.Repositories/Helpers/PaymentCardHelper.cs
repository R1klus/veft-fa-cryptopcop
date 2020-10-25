using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace Cryptocop.Software.API.Repositories.Helpers
{
    public class PaymentCardHelper
    {
        
        public static string MaskPaymentCard(string paymentCardNumber)
        {
            var paymentCardLength = paymentCardNumber.Length;
            var maskedPaymentCardNumber = new string('*', paymentCardLength-4)+paymentCardNumber
                .Remove(0, paymentCardLength-4);
            return maskedPaymentCardNumber;
        }
    }
}