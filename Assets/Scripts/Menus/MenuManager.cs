using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject earthMenu;
    [SerializeField] GameObject overlay;

    public void ActivateMenu(Menus menu)
    {
        switch (menu)
        {
            case Menus.EARTH_MENU:
                overlay.SetActive(false);
                earthMenu.SetActive(true);
                break;
            case Menus.OVERLAY:
                overlay.SetActive(true);
                earthMenu.SetActive(false);
                break;
            default:
                break;
        }
    }


}
