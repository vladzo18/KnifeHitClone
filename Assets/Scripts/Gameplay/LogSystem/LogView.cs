using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gameplay.LogSystem
{
    public class LogView : MonoBehaviour, ICollidable
    {
        [SerializeField] private Transform _knifeContainer;
        [SerializeField] private List<AppleView> _appleViews;

        public GameObject CollidedGameObject => this.gameObject;
        public List<AppleView> AppleViews => _appleViews;

        private Transform _transform;
        
        private void Start()
        {
            _transform = this.transform;
            
            _transform
                .DORotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void React(ICollidable initiator)
        {
            Transform knifeTransform = initiator.CollidedGameObject.transform;
            
            knifeTransform.parent = _knifeContainer;
            knifeTransform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            knifeTransform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            
            MakeShakeEffect();
        }

        private void MakeShakeEffect()
        {
            _transform.DOJump((_transform.position + Vector3.up * 0.05f), 1, 1, 0.2f);
            _transform.DOJump((_transform.position + Vector3.down * 0.05f), 1, 1, 0.2f);
        }
    }
}
