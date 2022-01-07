using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Upside_downKittenGenerator.Controllers;
using Xunit;

namespace Tests.ControllersTests
{
    public class CatImagesControllerTests
    {

        private readonly CatImagesController _catImagesController;
        public CatImagesControllerTests()
        {
            _catImagesController = new CatImagesController();
        }
        #region GetAnUpsideDownImageOfACat

        [Fact]
        public async Task ShouldReturnFileContentResult_WhenCalling_GetAnUpsideDownImageOfACat()
        {
            var result = await _catImagesController.GetAnUpsideDownImageOfACat();
            Assert.IsType<FileContentResult>(result);
        }
        #endregion GetAnUpsideDownImageOfACat

        #region GetAnUpsideDownImageOfACutCat
        [Fact]
        public async Task ShouldReturnFileContentResult_WhenCalling_GetAnUpsideDownImageOfACutCat()
        {
            var result = await _catImagesController.GetAnUpsideDownImageOfACutCat();
            Assert.IsType<FileContentResult>(result);
        }
        #endregion GetAnUpsideDownImageOfACutCat


        #region GetAnUpsideDownImageOfACatWithFilter
        [Theory]
        [InlineData("mono")]
        [InlineData("negative")]
        public async Task GivenGoodFilter_WhenCalling_GetAnUpsideDownImageOfACatWithFilter_ReturnFileContentResult(string filter)
        {
            var result = await _catImagesController.GetAnUpsideDownImageOfACatWithFilter(filter);
            Assert.IsType<FileContentResult>(result);
        }
        #endregion GetAnUpsideDownImageOfACatWithFilter

        #region GetAnUpsideDownImageOfACatWithAWord
        [Theory]
        [InlineData("word")]
        [InlineData("azertyuiopmlkjhgfdsqwxcvbnazer")]
        public async Task GivenGoodWord_WhenCalling_GetAnUpsideDownImageOfACatWithFilter_ReturnFileContentResult(string word)
        {
            var result = await _catImagesController.GetAnUpsideDownImageOfACatWithAWord(word);
            Assert.IsType<FileContentResult>(result);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("azertyuiopmlkjhgfdsqwxcvbnazert")]
        public async Task GivenWrongWord_WhenCalling_GetAnUpsideDownImageOfACatWithAWord_ReturnFileContentResult(string word)
        {
            var result = await _catImagesController.GetAnUpsideDownImageOfACatWithAWord(word);
            Assert.IsType<BadRequestObjectResult>(result);
        }
        #endregion GetAnUpsideDownImageOfACatWithAWord

        #region GetAnUpsideDownImageOfACatWithAWordAndAFilter
        [Theory]
        [InlineData("a", "paint")]
        [InlineData("azertyuiopmlkjhgfdsqwxcvbnazer", "blur")]
        public async Task GivenGoodWordAndGoodFilter_WhenCalling_GetAnUpsideDownImageOfACatWithFilter_ReturnFileContentResult(string word, string filter)
        {
            var result = await _catImagesController.GetAnUpsideDownImageOfACatWithAWordAndAFilter(word, filter);
            Assert.IsType<FileContentResult>(result);
        }

        [Theory]
        [InlineData("a", "pain")]
        [InlineData("azertyuiopmlkjhgfdsqwxcvbnazer", "blurr")]
        public async Task GivenGoodWordAndWrongFilter_WhenCalling_GetAnUpsideDownImageOfACatWithFilter_ReturnFileContentResult(string word, string filter)
        {
            var result = await _catImagesController.GetAnUpsideDownImageOfACatWithAWordAndAFilter(word, filter);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Theory]
        [InlineData("1", "paint")]
        [InlineData("azertyuiopmlkjhgfdsqwxcvbnazert", "blur")]
        public async Task GivenWrongWordAndGoodFilter_WhenCalling_GetAnUpsideDownImageOfACatWithFilter_ReturnFileContentResult(string word, string filter)
        {
            var result = await _catImagesController.GetAnUpsideDownImageOfACatWithAWordAndAFilter(word, filter);
            Assert.IsType<BadRequestObjectResult>(result);
        }
        #endregion GetAnUpsideDownImageOfACatWithAWordAndAFilter

    }
}
