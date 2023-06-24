using System;
using UnityEngine;

namespace Gameplay
{
    public class AppleView : MonoBehaviour, ICollidable
    {
        [SerializeField] private GameObject _halfOne;
        [SerializeField] private GameObject _halfTwo;
        
        [SerializeField] private SpriteRenderer _image;
        [SerializeField] private Collider2D _collider;

        public event Action AppleSplited;
        public GameObject CollidedGameObject => this.gameObject;
        public void React(ICollidable initiator)
        {
            _collider.enabled = false;
            _image.enabled = false;

            _halfOne.transform.parent = null;
            _halfOne.GetComponent<SpriteRenderer>().enabled = true;
            _halfOne.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            _halfOne.GetComponent<Rigidbody2D>().velocity = Vector2.left * 2;
            
            _halfTwo.transform.parent = null;
            _halfTwo.GetComponent<SpriteRenderer>().enabled = true;
            _halfTwo.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            _halfTwo.GetComponent<Rigidbody2D>().velocity = Vector2.right * 2;
            
            AppleSplited?.Invoke();
        }
    }
}