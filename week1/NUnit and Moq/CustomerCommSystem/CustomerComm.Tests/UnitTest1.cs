using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        
        // FIX 1: Change CustomerComm to CustomerCommLib.CustomerComm
        private CustomerCommLib.CustomerComm _customerComm;

        [OneTimeSetUp]
        public void Init()
        {
            _mockMailSender = new Mock<IMailSender>();

            _mockMailSender
                .Setup(sender => sender.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            // FIX 2: Change new CustomerComm to new CustomerCommLib.CustomerComm
            _customerComm = new CustomerCommLib.CustomerComm(_mockMailSender.Object);
        }

        [TestCase]
        public void SendMailToCustomer_WhenInvoked_ShouldReturnTrue()
        {
            bool result = _customerComm.SendMailToCustomer();

            Assert.That(result, Is.True);
            
            _mockMailSender.Verify(sender => sender.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}