using Xunit;
using System.IO;
using ChampionshipChallenge.Services;
using Microsoft.Extensions.Logging;

namespace ChampionshipChallenge.Tests
{
    public class ValidationServiceTest
    {
        ValidationService validationService = new ValidationService(new LoggerFactory().CreateLogger<ValidationService>());

        [Fact]
        public void ReadMatchesFromFile_FileNotFound_ThrowsFileNotFoundException()
        {
            string filePath = "filenotfound.txt";

            Assert.Throws<FileNotFoundException>(() => validationService.ReadMatchesFromFile(filePath));
        }
        [Fact]
        public void ReadMatchesFromFile_FileIsEmpty_ThrowsInvalidDataException()
        {
            string filePath = "emptyfile.txt";
            System.IO.File.WriteAllText(filePath, "");

            Assert.Throws<InvalidDataException>(() => validationService.ReadMatchesFromFile(filePath));
        }
        [Fact]
        public void ReadMatchesFromFile_InvalidFormatInFile_ThrowsInvalidDataException()
        {
            string filePath = "invalidfileformat.txt";

            File.WriteAllText(filePath, "TeamA 3 TeamB 2");

            var exception = Assert.Throws<InvalidDataException>(() => validationService.ReadMatchesFromFile(filePath));
            Assert.Equal("Invalid format in file.", exception.Message);

            File.Delete(filePath);
        }
        [Fact]
        public void ReadMatchesFromFile_InvalidScoreFormatInFile_ThrowsFormatException()
        {
            string filePath = "invalidscoreformatfile.txt";
            File.WriteAllText(filePath, "TeamA x, TeamB 2");

            Assert.Throws<FormatException>(() => validationService.ReadMatchesFromFile(filePath));

            File.Delete(filePath);
        }
    }
}