using UnityEngine;

namespace Gameplay.KnifeSystem
{
    public class KnifeView : MonoBehaviour, ICollidable
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Collider2D _collider;
        
        public GameObject CollidedGameObject => this.gameObject;
        
        public void MakeThrow()
        {
            _rigidbody2D.velocity = Vector2.up * 30;
            _collider.enabled = true;
        }

        public void React(ICollidable initiator)
        {
            _rigidbody2D.velocity = (Vector2.down + Vector2.left) * 10;
            _rigidbody2D.gravityScale = 1;
            _rigidbody2D.freezeRotation = false;
        }
        
        private void OnCollisionEnter2D(Collision2D collider)
        {
            ICollidable collidable = collider.gameObject.GetComponent<ICollidable>();
            collidable?.React(this);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            ICollidable collidable = collider.gameObject.GetComponent<ICollidable>();
            collidable?.React(this);
        }
    }
}
