using UnityEngine;

namespace Gameplay
{
    public interface ICollidable
    {
        GameObject CollidedGameObject { get; }
        void React(ICollidable initiator);
    }
}