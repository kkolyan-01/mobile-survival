using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Survival.Control
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private Joystick _joystick;

        private Rigidbody _rigidbody;
        private Animator _animator;
        private Vector3 _direction;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            UpdaterDirection();
            Move();
            RotateToDirection();
            UpdateAnimate();
        }

        private void UpdaterDirection()
        {
            _direction = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
            _direction += new Vector3(_joystick.Horizontal,0, _joystick.Vertical);
            if(_direction.magnitude > 1)
                _direction = _direction.normalized;
        }
        

        private void Move()
        {
            if(_direction == Vector3.zero) return;
            
            Vector3 velocity = _direction * _maxSpeed;
            velocity.y = _rigidbody.velocity.y;
            _rigidbody.velocity = velocity;
        }
        
        private void RotateToDirection()
        {
            if(_direction == Vector3.zero) return;
            transform.rotation = Quaternion.LookRotation(_direction);
        }

        private void UpdateAnimate()
        {
            Vector3 velocity = _rigidbody.velocity;
            velocity.y = 0;
            float speed = (float) Math.Round(velocity.magnitude, 2);
            _animator.SetFloat("Speed", speed);
        }
    }
}

