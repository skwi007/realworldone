namespace Core.UsesCases.CatImages
{
    public interface ICatImages
    {
        Task<byte[]> GetUpsideDownCatImages();
        Task<byte[]> GetUpsideDownCuteCatImages();
        Task<byte[]> GetUpsideDownFilterCatImages(string filter);
        Task<byte[]> GetUpsideDownCatImagesWithAWord(string word);
        Task<byte[]> GetUpsideDownCatImagesWithAWordAndFilter(string word, string filter);
    }
}
