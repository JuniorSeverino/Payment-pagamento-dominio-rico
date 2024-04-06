using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests;

[TestClass]
public class SubscriptionHandlerTests
{
    //Red, Green, Refactor
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

        var command = new CreateBoletoSubscriptionCommand();
        command.BarCode = "";
        command.FirstName = "";
        command.LastName = "";
        command.Document = "99999999999";
        command.Email = "junior@teste2.com";
        command.BarCode = "123456789";
        command.BoletoNumber = "12345698";
        command.PaymentNumber = "123123";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 60;
        command.TotalPaid = 60;
        command.Payer = "JUNIOR CORP";
        command.PayerDocument = "12345678901";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "junior@teste.com";
        command.Street = "aaa";
        command.Number = "aaa";
        command.Neighborhood = "aaa";
        command.City = "aaa";
        command.State = "aa";
        command.Country = "aa";
        command.ZipCode = "16340000";

        handler.Handle(command);

        Assert.AreEqual(false, handler.Valid);
    }
}