using Xunit;

public class UnitText
{
    [Fact]
    public void TestAis()
    {
        Assert.Equal("π€hπ€mπ€anπ€", Abstract.AIS.computation("human", "chimpanzee"));
    }


    [Theory]
    [InlineData("human", "chimpanzee")]
    [InlineData("google", "gompoe")]
    public void TestAisWithParameters(string value1, string value2)
    {
        Assert.NotEqual("π€", Abstract.AIS.computation(value1, value2));
    }
}