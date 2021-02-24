using UnityEngine;

namespace Survival.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        private void Update()
        {
            transform.position = _target.position;
        }
    }
}


