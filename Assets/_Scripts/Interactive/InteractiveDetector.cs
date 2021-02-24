using System;
using UnityEngine;

namespace Survival.Interactive
{
    public class InteractiveDetector : MonoBehaviour
    {
        [SerializeField] private Vector3 _sizeDetectorBox; 
        private InteractiveObject _lastInteractiveObject;
        private void FixedUpdate()
        {
            InteractiveObject interactiveObject = FindIteractiveObject();

            if (interactiveObject != null)
                ActivateObject(interactiveObject);
            else
                DeactivateObject(interactiveObject);
        }

        private InteractiveObject FindIteractiveObject()
        {
            InteractiveObject interactiveObject = null;
            Collider[] colliders = Physics.OverlapBox(transform.position, _sizeDetectorBox);
            foreach (var collider in colliders)
            {
                return collider.GetComponent<InteractiveObject>();
            }
            return null;
        }

        private void ActivateObject(InteractiveObject interactiveObject)
        {
            if(_lastInteractiveObject == interactiveObject) return;
            interactiveObject.Activate();
            _lastInteractiveObject = interactiveObject;
        }

        private void DeactivateObject(InteractiveObject interactiveObject)
        {
            _lastInteractiveObject?.Deactivate();
            _lastInteractiveObject = null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawCube(transform.position, _sizeDetectorBox * 2);
        }
    }
}


