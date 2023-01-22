using Xunit;

public class UnitText
{
    [Fact]
    public void TestAis()
    {
        Assert.Equal("𐤕h𐤕m𐤕an𐤕", Abstract.AIS.computation("human", "chimpanzee"));
    }


    [Theory]
    [InlineData("human", "chimpanzee")]
    [InlineData("google", "gompoe")]
    public void TestAisWithParameters(string value1, string value2)
    {
        Assert.NotEqual("𐤕", Abstract.AIS.computation(value1, value2));
    }
}