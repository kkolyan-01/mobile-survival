using UnityEngine;
using UnityEngine.Events;


namespace Survival.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHhealthPoints;
        [SerializeField] private int _healthPoints;
        [SerializeField] private UnityEvent Die;
        
        public bool isDead { get; set; }

        public void TakeDamage(int damage)
        {
            if(isDead) return;
            _healthPoints -= damage;
            _healthPoints = Mathf.Max(_healthPoints, 0);
            print(_healthPoints);
            if (_healthPoints == 0)
            {
                isDead = true;
                Die.Invoke();
            }
        }

        public void SelfDestroy()
        {
            Destroy(gameObject);
        }
    }
}

