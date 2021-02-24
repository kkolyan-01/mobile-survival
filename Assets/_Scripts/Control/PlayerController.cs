using UnityEngine;

namespace Survival.Control
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController s;
    
        private void Awake()
        {
            CreateSingleton();
        }

        private void CreateSingleton()
        {
            if(s == null)
                s = this;
            else
                Debug.LogError("Попытка создания второго PlayerController");
        }
    }
}


