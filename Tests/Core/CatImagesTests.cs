using Core.UsesCases.CatImages;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Core
{
    public class CatImagesTests
    {
        private readonly ICatImages _catImages;
        public CatImagesTests()
        {
            _catImages = new CatImages();
        }

        #region GetUpsideDownCatImages

        [Fact]
        public async Task ShouldReturnBytes_WhenCalling_GetUpsideDownCatImages()
        {
            var result = await _catImages.GetUpsideDownCatImages();
            Assert.IsType<byte[]>(result);
        }

        #endregion GetUpsideDownCatImages


        #region GetUpsideDownCuteCatImages

        [Fact]
        public async Task ShouldReturnBytes_WhenCalling_GetUpsideDownCuteCatImages()
        {
            var result = await _catImages.GetUpsideDownCuteCatImages();
            Assert.IsType<byte[]>(result);
        }

        #endregion GetUpsideDownCuteCatImages


        #region GetUpsideDownFilterCatImages

        [Theory]
        [InlineData("pixel")]
        [InlineData("paint")]
        public async Task GivenGoodFilter_WhenCalling_GetUpsideDownFilterCatImages_ReturnBytes(string filter)
        {
            var result = await _catImages.GetUpsideDownFilterCatImages(filter);
            Assert.IsType<byte[]>(result);
        }

        #endregion GetUpsideDownFilterCatImages

        #region GetUpsideDownCatImagesWithAWord

        [Theory]
        [InlineData("EEEeeeeeeeeeeeeeeeeeeeeeeeeeee")]
        [InlineData("test")]
        public async Task GivenGoodWord_WhenCalling_GetUpsideDownCatImagesWithAWord_ReturnBytes(string word)
        {
            var result = await _catImages.GetUpsideDownCatImagesWithAWord(word);
            Assert.IsType<byte[]>(result);
        }

        #endregion GetUpsideDownCatImagesWithAWord

        #region GetUpsideDownCatImagesWithAWordAndFilter

        [Theory]
        [InlineData("EEEeeeeeeeeeeeeeeeeeeeeeeeeeee", "negative")]
        [InlineData("test", "mono")]
        public async Task GivenGoodWordandGoodFilter_WhenCalling_GetUpsideDownCatImagesWithAWordAndFilter_ReturnBytes(string word, string filter)
        {
            var result = await _catImages.GetUpsideDownCatImagesWithAWordAndFilter(word, filter);
            Assert.IsType<byte[]>(result);
        }

        #endregion GetUpsideDownCatImagesWithAWordAndFilter
    }
}
