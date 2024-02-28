using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialWebModel.Entity;
using SocialWebServices.Services.VideoService;

namespace SocialWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_videoService.GetVideoList());

        }
        [HttpPost]
        public IActionResult Post( Video video)
        {
            _videoService.CreateVideo(video);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put( Video video)
        {
            _videoService.UpdateVideo(video);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(long id)
        {
            _videoService.DeleteVideo(id);
            return Ok();
        }
        [HttpPut("id")]
        public IActionResult actionResult(long id,[FromBody]List<Actor> actors)
        {
            _videoService.AddActor(id, actors);
            return Ok();
        }
    }
}
