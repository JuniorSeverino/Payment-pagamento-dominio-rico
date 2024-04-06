using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class DocumentTests
{
    //Red, Green, Refactor
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CNPJ);

        Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsValid()
    {
        var doc = new Document("47517446000151", EDocumentType.CNPJ);

        Assert.IsTrue(doc.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CPF);

        Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("42526041848")]
    [DataRow("42526041812")]
    [DataRow("42526041810")]
    public void ShouldReturnErrorWhenCPFIsValid(string cpf)
    {
        var doc = new Document(cpf, EDocumentType.CPF);

        Assert.IsTrue(doc.Valid);
    }
}