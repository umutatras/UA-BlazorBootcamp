using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VideoTransciberApp.BlazorUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        [HttpPost("/upload")]
        public async Task<IActionResult> UploadAsync(VideoUploadRequest request,CancellationToken token)
        {
            if(request.Video.Length>0)
            {

            }
            return Ok();
        }
    }
    public class VideoUploadRequest
    {
        public IFormFile Video { get; set; }
        public string[] Languages { get; set; }
    }
}
