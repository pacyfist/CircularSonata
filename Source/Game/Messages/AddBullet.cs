using FlaxEngine;
using Flaxible;

namespace Game.Game.Messages
{
    public class AddBullet : Mediator.Message
    {
        public Actor Gunner { get; set; }
    }
}
