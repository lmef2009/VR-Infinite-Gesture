﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Edwon.VR.Gesture
{
    // this script should be placed on the panels parent
    public class VRGestureUIPanelManager : MonoBehaviour
    {

        private string initialPanel = "Select Neural Net Menu";
        [HideInInspector]
        public string currentPanel;

        public delegate void PanelFocusChanged(string panelName);
        public static event PanelFocusChanged OnPanelFocusChanged;

        List<CanvasGroup> panels;

        [HideInInspector]
        public CanvasGroup canvasGroup;

        void Start()
        {
            // get the panels below me
            canvasGroup = gameObject.GetComponent<CanvasGroup>();
            panels = new List<CanvasGroup>();
            CanvasGroup[] panelsTemp = transform.GetComponentsInChildren<CanvasGroup>();
            for (int i = 0; i < panelsTemp.Length; i++)
            {
                if (panelsTemp[i] != canvasGroup)
                    panels.Add(panelsTemp[i]);
            }

            if (VRGestureManager.Instance.stateInitial == VRGestureManagerState.ReadyToDetect)
            {
                initialPanel = "Detect Menu";
            }

            // initialize initial panel focused
            FocusPanel(initialPanel);
        }

        public void FocusPanel(string panelName)
        {

            currentPanel = panelName;

            if (OnPanelFocusChanged != null)
            {
                OnPanelFocusChanged(panelName);
            }

            foreach (CanvasGroup panel in panels)
            {
                if (panel.gameObject.name == panelName)
                {
                    // turn panel on
                    panel.alpha = 1f;
                    panel.interactable = true;
                    panel.blocksRaycasts = true;
                }
                else
                {
                    // turn panel off
                    panel.alpha = 0f;
                    panel.interactable = false;
                    panel.blocksRaycasts = false;
                }
            }
        }

    }
}