﻿using UnityEngine;

namespace CERV.MouvementRecognition.Menus
{
    public class Panel : MonoBehaviour
    {
        private Canvas canvas = null;
        private MenuManager menuManager = null;

        private void Awake()
        {
            canvas = GetComponent<Canvas>();
        }

        public void Setup(MenuManager menuManager)
        {
            this.menuManager = menuManager;
            Hide();
        }

        public void Show()
        {
            canvas.enabled = true;
        }

        public void Hide()
        {
            canvas.enabled = false;
        }
    }
}