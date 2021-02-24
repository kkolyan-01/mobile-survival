using System;
using Survival.Combat;
using Survival.UI;
using UnityEngine;

namespace Survival.Control
{
    public class PickaxeController : MonoBehaviour
    {
        [SerializeField] private GameObject _pickaxe;
        [SerializeField] private float _timeBetweenAttacks;
        [SerializeField] private int _damage;

        private float _timeLastAttack;
        
        private Animator _animator;
        private Health _target;

        private bool _canAttack
        {
            get
            {
                bool isTimeAttack = Time.time > _timeLastAttack + _timeBetweenAttacks;
                isTimeAttack = isTimeAttack || _timeLastAttack == 0;
                return isTimeAttack && !_target.isDead;
            }
        }
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
            enabled = false;
        }

        private void OnEnable()
        {
            _pickaxe.SetActive(true);
            UIManager.s?.pickaxeMenu.SetActive(true);
            _animator?.SetBool("PickaxeState", true);
            _animator?.ResetTrigger("CancelAttack");
        }

        private void OnDisable()
        {
            _pickaxe.SetActive(false);
            UIManager.s?.pickaxeMenu.SetActive(false);
            _animator?.SetBool("PickaxeState", false);
            _animator?.SetTrigger("CancelAttack");
        }

        public void SetTarget(Transform target)
        {
            _target = target.GetComponent<Health>();
        }

        public void Attack()
        {
            RotateToTarget();
            if(!_canAttack) return;
            _animator.SetTrigger("PickaxeMine");
        }

        private void RotateToTarget()
        {
            Vector3 angles = transform.eulerAngles;
            transform.LookAt(_target.transform);
            angles.y = transform.eulerAngles.y;
            transform.eulerAngles = angles;
        }

        // Animation Event
        private void PickaxeHit()
        {
            _target.TakeDamage(_damage);
            
            _animator.ResetTrigger("PickaxeMine");
            _pickaxe.GetComponentInChildren<AudioSource>().Play();
            _timeLastAttack = Time.time;
        }
    }
}