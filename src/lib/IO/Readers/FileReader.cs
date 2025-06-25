using Kaleidocode.Katas.Libraries.Contracts;
using Kaleidocode.Katas.Libraries.IO.Enumerations;
using Kaleidocode.Katas.Libraries.IO.Helpers;
using System.Threading;

namespace Kaleidocode.Katas.Libraries.IO.Readers
{
    public class FileReader(string filePath) : IFileReader
    {
        private string FilePath { get; set; } = filePath;

        public string[] ReadFile()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new NullReferenceException(
                    MessageTemplateHelper.GenerateGenericErrorString(ErrorCondition.ValueRequired, nameof(FilePath))
                );
            }

            try
            {
                return File.ReadAllLines(FilePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"IO Operation Failure: {ex.Message}.");
            }
        }

        public async Task<string[]?> ReadFileAsync(CancellationToken? cancellationToken = null)
        {
            if (string.IsNullOrEmpty(FilePath)) 
            { 
                throw new NullReferenceException(
                    MessageTemplateHelper.GenerateGenericErrorString(ErrorCondition.ValueRequired, nameof(FilePath))
                ); 
            }

            try
            {
                return await File.ReadAllLinesAsync(FilePath, cancellationToken ?? default);
            }
            catch (Exception ex) 
            {
                throw new Exception($"IO Operation Failure: {ex.Message}.");
            }
        }
    }
}
