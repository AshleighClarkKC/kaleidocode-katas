using Kaleidocode.Katas.Libraries.IO.Helpers;
using Kaleidocode.Katas.Libraries.IO.Enumerations;

namespace Kaleidocode.Katas.Libraries.IO.Readers
{
    public class FileReader(string filePath)
    {
        private string FilePath { get; set; } = filePath;

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
