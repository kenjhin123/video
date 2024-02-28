using SocialWebModel;
using SocialWebModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWebServices.Services.ActorService
{
    public class ActorService:IActorService
    {
        private readonly AppDbContext _appDbContext;
        public ActorService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //getList
        public List<Actor> Getall()
        {
           var res = _appDbContext.actors.ToList();
            return res;
        }
        //Read
        public Actor GetById(long id)
        {
            return _appDbContext.actors.FirstOrDefault(x => x.Id == id);

        }
        //Create
        public void Create(Actor actor)
        {
            _appDbContext.actors.Add(actor);
            _appDbContext.SaveChanges();
        }
        //Update
        public void Update(Actor actor)
        {
            var updateActor = _appDbContext.actors.FirstOrDefault(x=>x.Id == actor.Id);
            if (updateActor != null)
            {
                updateActor.Name = actor.Name;
                updateActor.Description = actor.Description;
                updateActor.Size = actor.Size;
                _appDbContext.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
        //Delete
        public void Delete(long id)
        {
            _appDbContext.actors.Remove(GetById(id));
            _appDbContext.SaveChanges();
        }
    }
}
