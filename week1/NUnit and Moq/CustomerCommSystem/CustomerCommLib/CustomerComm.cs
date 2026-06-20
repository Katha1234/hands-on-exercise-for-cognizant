using System;

namespace CustomerCommLib
{
    public class CustomerComm
    {
        private readonly IMailSender _mailSender;
 
        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }
 
        public bool SendMailToCustomer()
        {
            string customerEmail = "cust123@abc.com";
            string emailMessage = "Some Message";
            
            bool isSent = _mailSender.SendMail(customerEmail, emailMessage);
            return isSent;
        }
    }
}