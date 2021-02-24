using Survival.Combat;
using Survival.Control;
using UnityEngine;

namespace Survival.Interactive
{
    [RequireComponent(typeof(Health))]
    public class PickaxeInteractiveObject : MonoBehaviour, InteractiveObject
    {
        
        public void Activate()
        {
            PickaxeController pickaxeController = PlayerController.s.GetComponent<PickaxeController>();
            pickaxeController.enabled = true;
            pickaxeController.SetTarget(transform);
        }

        public void Deactivate()
        {
            PickaxeController pickaxeController = PlayerController.s.GetComponent<PickaxeController>();
            pickaxeController.enabled = false;
        }
    }
}

