using System.Collections;
using System.Collections.Generic;
using Jackal;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject panelStart, panelSetting, panelApp;

    void Start()
    {
        OpenApp();
    }

    public void BuyPack()
    {
        IAPManager.OnPurchaseSuccess =
            () =>
            {
                GameDataManager.Instance.playerData.UnlockPack();
                OpenApp();
            };

        IAPManager.Instance.BuyProductID(IAPKey.PACK_UNLOCK);
    }

    public void OpenApp()
    {
        panelStart.SetActive(false);
        panelApp.SetActive(true);
    }
}