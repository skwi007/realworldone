using System.Drawing;

namespace Core.UsesCases.CatImages
{
    public class CatImages : ICatImages
    {
        private const string URL = "https://cataas.com/";
        public async Task<byte[]> GetUpsideDownCatImages()
        {
            string urlParameters = "cat";

            return await NewMethod(urlParameters);
        }

        public async Task<byte[]> GetUpsideDownCuteCatImages()
        {
            string urlParameters = "cat/cute";

            return await NewMethod(urlParameters);
        }

        public async Task<byte[]> GetUpsideDownCatImagesWithAWord(string word)
        {
            string urlParameters = "cat/says/" + word;

            return await NewMethod(urlParameters);
        }

        public async Task<byte[]> GetUpsideDownCatImagesWithAWordAndFilter(string word, string filter)
        {
            string urlParameters = "cat/says/" + word + "?filter=" + filter;

            return await NewMethod(urlParameters);
        }

        public async Task<byte[]> GetUpsideDownFilterCatImages(string filter)
        {
            string urlParameters = "cat?filter=" + filter;

            return await NewMethod(urlParameters);
        }

        private async Task<byte[]> NewMethod(string urlParameters)
        {
            Image image = await GetCatImageAsync(URL + urlParameters);

            image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            return ImageToByteArray(image);
        }

        private static async Task<Image> GetCatImageAsync(string URL)
        {
            byte[] bytes;
            using (var client = new HttpClient())
            {
                using var response = await client.GetAsync(URL);
                bytes = await response.Content.ReadAsByteArrayAsync();
                var base64String = Convert.ToBase64String(bytes);
            }
            return ByteArrayToImage(bytes);
        }
        private static byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        private static Image ByteArrayToImage(byte[] bytes)
        {
            MemoryStream ms = new(bytes);
            return Image.FromStream(ms);
        }
    }
}
