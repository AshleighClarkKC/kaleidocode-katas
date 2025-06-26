using Kaleidocode.Katas.Libraries.StringReader.Parsers;
using Kaleidocode.Katas.Tests.Fixtures;

namespace Kaleidocode.Katas.Tests;

public class ReaderTest : ReaderFixture
{
    [Fact]
    public void Given_FileIsProvided_WhenRead_PrintsData()
    {
        // Given
        var testFileReader = base.GetFileReader();

        // When
        var testText = testFileReader.ReadFile();

        // Then
        Assert.Equal(5, testText!.Length);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 3)]
    [InlineData(2, 1)]
    [InlineData(3, 4)]
    public void Given_FileIsProvided_WhenEachLineValidated_NumberIsGiven(int lineCount, int uniqueCharacterCount)
    {
        // Given
        var testFileFileReader = base.GetFileReader();
        var testTextCollection = testFileFileReader.ReadFile();

        // When
        var inputParser = new LineParser();
        inputParser.SetInputCollection(testTextCollection!);
        var collectedLineCount = inputParser.CollectValues();

        // Then
        Assert.Equal(uniqueCharacterCount, int.Parse(collectedLineCount.ToArray()[lineCount].Split(": ")[1]));
    }
}
