﻿using System;
using UnityEngine;
using UnityEngine.VR.Menus;

public class CreateTestPluginMenu : MonoBehaviour, IMenu
{
    public bool visible { get { return gameObject.activeSelf; } set { gameObject.SetActive(value); } }
}
