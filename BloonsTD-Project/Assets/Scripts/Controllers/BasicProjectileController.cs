using System;
using UnityEngine;

namespace TMG.BloonsTD.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BasicProjectileController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxRange;
        
        private Rigidbody2D _rigidbody;
        private Vector3 _startPosition;
        private float DistanceTraveled => Vector3.Distance(_startPosition, transform.position);

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _startPosition = transform.position;
            _rigidbody.AddForce(transform.up * _speed, ForceMode2D.Impulse);
        }

        private void Update()
        {
            if (DistanceTraveled > _maxRange)
            {
                Destroy(gameObject);
            }
        }
    }
}