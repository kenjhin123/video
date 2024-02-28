using SocialWebModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWebServices.Services.VideoService
{
    public interface IVideoService
    {
        public List<Video> GetVideoList();
        public Video GetVideoById(long id);
        public void CreateVideo(Video video);
        public void UpdateVideo(Video video);

        public void DeleteVideo(long id);
        public void AddActor(long id, List<Actor> actor);




    }
}
