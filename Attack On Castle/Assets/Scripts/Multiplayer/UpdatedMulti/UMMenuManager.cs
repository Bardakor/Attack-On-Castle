using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMMenuManager : MonoBehaviour
{
    public static UMMenuManager Instance;
    [SerializeField] UMMenu[] menus;

    void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                OpenMenu(menus[i]);
            }
            else if (menus[i].isOpen)
            {
                CloseMenu(menus[i]);
            }
        }
    }

    private void CloseMenu(UMMenu menu)
    {
        menu.Close();
    }

    public void OpenMenu(UMMenu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].isOpen)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
    }
}
