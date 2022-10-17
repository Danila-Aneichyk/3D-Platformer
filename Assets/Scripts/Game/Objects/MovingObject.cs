using System;
using DG.Tweening;
using UnityEngine;

namespace Platformer3D.Game
{
    public class MovingObject : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _fromTransform;
        [SerializeField] private Transform _toTransform;
        [SerializeField] private float _duration = 1f;
        [SerializeField] private float _delayInFromPosition = 1f; 
        [SerializeField] private float _delayInToPosition = 1f; 
        [SerializeField] private Ease _ease;

        private Tween _tween;
        public Transform FromTransform => _fromTransform;

        public Transform ToTransform => _toTransform;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            transform.position = _fromTransform.position; 
        }

        private void Start()
        {
            Play();
        }

        #endregion
        #region Public methods

        public void Play()
        {
            _tween?.Kill();

            Sequence sequence = DOTween.Sequence();
            sequence.AppendInterval(_delayInFromPosition); 
            sequence.Append(_tween = transform
                .DOMove(_toTransform.position, _duration)
                .SetEase(_ease));
            sequence.AppendInterval(_delayInToPosition);
            sequence.Append(transform
                .DOMove(_fromTransform.position, _duration)
                .SetEase(_ease));
            sequence
                .SetLoops(-1)
                .SetUpdate(UpdateType.Fixed);

            _tween = sequence; 
        }

        #endregion
    }
}