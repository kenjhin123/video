using SocialWebModel;
using SocialWebModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWebServices.Services.VideoService
{
    public class VideoService:IVideoService
    {
        private readonly AppDbContext _appDbContext;
        public VideoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //getAll
        public List<Video> GetVideoList()
        {
            return _appDbContext.video.ToList();
        }
        //Read
        public Video GetVideoById(long id) {
        
        return _appDbContext.video.FirstOrDefault(x => x.Id == id);
        }
        //Create
        public void CreateVideo(Video video)
        {
         
            _appDbContext.video.Add(video);
            _appDbContext.SaveChanges();
        }
        //Update
        public void UpdateVideo(Video video)
        {
          var updateVideo =  _appDbContext.video.FirstOrDefault(x => x.Id == video.Id);
            if (updateVideo != null)
            {
                updateVideo.Name = video.Name;
                updateVideo.Description = video.Description;
                updateVideo.Thumb = video.Thumb;
                updateVideo.Sub = video.Sub;
                updateVideo.LinkVideo = video.LinkVideo;
                updateVideo.Cateroty = video.Cateroty;
                updateVideo.View = video.View;
                updateVideo.Like = video.Like;
                _appDbContext.SaveChanges();
            }
        }
        //Delete
        public void DeleteVideo(long id)
        {
            _appDbContext.video.Remove(GetVideoById(id));
            _appDbContext.SaveChanges();
        }
        public void AddActor(long id,List<Actor> actor)
        {
            var video = _appDbContext.video.Find(id);
            video.Actors = actor;
            _appDbContext.SaveChanges();

        }
    }
}
