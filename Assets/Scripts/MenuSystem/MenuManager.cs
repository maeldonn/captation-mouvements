﻿using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Panel currentPanel = null;

    private List<Panel> panelHistory = new List<Panel>();

    private void Start()
    {
        SetupPanels();
    }

    private void SetupPanels()
    {
        Panel[] panels = GetComponentsInChildren<Panel>();

        foreach (Panel panel in panels)
        {
            panel.Setup(this);
        }
        currentPanel.Show();
    }

    public void GoToPrevious()
    {
        if (panelHistory.Count == 0)
        {
            // System.Diagnostics.Process.GetCurrentProcess().Kill(); // To quit in developement
            Application.Quit();
            return;
        }

        int lastIndex = panelHistory.Count - 1;
        SetCurrent(panelHistory[lastIndex]);
        panelHistory.RemoveAt(lastIndex);
    }

    public void SetCurrentWithHistory(Panel newPanel)
    {
        panelHistory.Add(currentPanel);
        SetCurrent(newPanel);
    }

    private void SetCurrent(Panel newPanel)
    {
        currentPanel.Hide();

        currentPanel = newPanel;
        currentPanel.Show();
    }

    public void GoToDefault()
    {
        SetCurrent(panelHistory[0]);
        panelHistory.RemoveRange(1, panelHistory.Count - 1);
    }
}