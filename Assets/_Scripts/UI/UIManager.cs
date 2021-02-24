using System;
using UnityEngine;

namespace Survival.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager s;
    
        public GameObject pickaxeMenu;

        private void Awake()
        {
            CreateSingleton();
        }

        private void Start()
        {
            pickaxeMenu.SetActive(false);
        }

        private void CreateSingleton()
        {
            if(s == null)
                s = this;
            else
                Debug.LogError("Попытка создания второго UIManager");
        }
    }
}

