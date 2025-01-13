using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;

namespace OfflineRadio.Utilities
{
    public class Downloader
    {
        public async Task<string> DownloadProgram(string url, string title)
        {
            string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{title}.exe");

            await DownloadAsync(url, savePath);

            return savePath;
        }

        public static async Task DownloadAsync(string url, string savePath)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Simulate downloading data from the URL
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(savePath, content);
                    }
                    else
                    {
                        throw new Exception($"Failed to download file. Status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred during download: {ex.Message}");
            }

        }
}
}

