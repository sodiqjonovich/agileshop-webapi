using AgileShop.Service.Validators;
namespace AgileShop.UnitTest.ValidatorTests;

public class PhoneNumberValidatorTest
{
    [Theory]
    [InlineData("+998331211314")]
    [InlineData("+998331211315")]
    [InlineData("+998661211314")]
    [InlineData("+998331211304")]
    [InlineData("+998941211314")]
    [InlineData("+998331211344")]
    [InlineData("+998331211514")]
    [InlineData("+998901211314")]
    [InlineData("+998991211314")]
    public void ShouldReturnCorrect(string phone)
    {
        var result = PhoneNumberValidator.IsValid(phone);
        Assert.True(result);
    }

    [Theory]
    [InlineData("998976260619")]
    [InlineData("AABBCCDD")]
    [InlineData("+9989762606191")]
    [InlineData("+99897626T619")]
    [InlineData("-99897626T619")]
    [InlineData("&99897626T619")]
    [InlineData("+99897626619")]
    [InlineData("+9989 626619")]
    [InlineData("+998 97 626 06 19")]
    public void ShouldReturnWrong(string phone)
    {
        var result = PhoneNumberValidator.IsValid(phone);
        Assert.False(result);
    }
}
