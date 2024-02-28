using SocialWebModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWebServices.Services.ActorService
{
    public interface IActorService
    {
        public List<Actor> Getall();

        public void Delete(long id);
        public Actor GetById(long id);
        public void Create(Actor actor);
        public void Update(Actor actor);

    }
}
