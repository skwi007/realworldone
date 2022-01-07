using Core.UsesCases.CatImages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Upside_downKittenGenerator.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CatImagesController : ControllerBase
    {
        private ICatImages _catImages;
        public CatImagesController()
        {
            _catImages = new CatImages();
        }

        /// <summary>
        /// To Get an upside down image of a cat
        /// </summary>
        /// <remarks>
        /// You must be authorized
        /// </remarks>
        /// <returns>upside down image of a cat</returns>
        [HttpGet("GetAnUpsideDownImageOfACat")]
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAnUpsideDownImageOfACat()
        {
            return File(await _catImages.GetUpsideDownCatImages(), "image/jpeg");
        }

        /// <summary>
        /// To Get an upside down image of a cute cat
        /// </summary>
        /// <remarks>
        /// You must be authorized
        /// </remarks>
        /// <returns>upside down image of a cat</returns>
        [HttpGet("GetAnUpsideDownImageOfACuteCat")]
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAnUpsideDownImageOfACutCat()
        {
            return File(await _catImages.GetUpsideDownCuteCatImages(), "image/jpeg");
        }

        /// <summary>
        /// To Get an upside down image of a cat with a filter
        /// </summary>
        /// <remarks>
        /// Filter are : blur, mono, sepia, negative, paint, pixel.
        /// You must be authorized
        /// </remarks>
        /// <returns>upside down image of a cat</returns>
        [HttpGet("GetAnUpsideDownImageOfACatWithFilter")]
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAnUpsideDownImageOfACatWithFilter([Required] string filter)
        {
            if (Regex.Match(filter.ToLower(), @"\b(blur|mono|sepia|negative|paint|pixel)\b").Success)
                return File(await _catImages.GetUpsideDownFilterCatImages(filter), "image/jpeg");

            return BadRequest("Please only use filter : blur, mono, sepia, negative, paint, pixel");
        }

        /// <summary>
        /// To Get an upside down image of a cat with a word.
        /// </summary>
        /// <remarks>
        /// The word length limit is 30.
        /// You must be authorized
        /// </remarks>
        /// <returns>upside down image of a cat</returns>
        [HttpGet("GetAnUpsideDownImageOfACatWithAWord")]
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAnUpsideDownImageOfACatWithAWord([Required] string word)
        {
            if (word.Length < 31 && Regex.Match(word, "^[a-zA-Z]+$").Success)
                return File(await _catImages.GetUpsideDownCatImagesWithAWord(word), "image/jpeg");

            return BadRequest("Only word without space with maximum 30 characters please");
        }

        /// <summary>
        /// To Get an upside down image of a cat with a word and a filter
        /// </summary>
        /// <remarks>
        /// Filter are : blur, mono, sepia, negative, paint, pixel.
        /// You must be authorized
        /// </remarks>
        /// <returns>upside down image of a cat with a word</returns>
        [HttpGet("GetAnUpsideDownImageOfACatWithAWordAndAFilter")]
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAnUpsideDownImageOfACatWithAWordAndAFilter([Required] string word, [Required] string filter)
        {
            if (!Regex.Match(filter.ToLower(), @"\b(blur|mono|sepia|negative|paint|pixel)\b").Success)
                return BadRequest("Please only use filter : blur, mono, sepia, negative, paint, pixel");

            if (word.Length < 31 && Regex.Match(word, "^[a-zA-Z]+$").Success)
                return File(await _catImages.GetUpsideDownCatImagesWithAWordAndFilter(word, filter), "image/jpeg");

            return BadRequest("Only word without space with maximum 30 characters please");
        }
    }
}
