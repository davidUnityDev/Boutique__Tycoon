using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteractionControlle : MonoBehaviour
{
    public GameObject shopkeeperMassage;
    [SerializeField] private ShopProperties shopProperties;
    //ShopUiController.Instance.SetUpShopPage(this);
    public void OnCollisionEnter2D(Collision2D collision)
    {
        shopkeeperMassage.SetActive(true);
        SetUpOptionButton();
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        shopkeeperMassage.SetActive(false);
        ShopUiController.Instance.optionPanel.panel.SetActive(false);
    }
    public void SetUpOptionButton()
    {
        ShopUiController.Instance.optionPanel.panel.SetActive(true);
        ShopUiController.Instance.optionPanel.yesOption.onClick.RemoveAllListeners();
        ShopUiController.Instance.optionPanel.yesOption.onClick.AddListener(() =>
        {
            GameController.Instance.playerProperties.ShowClotsAndMoneyCount();
            GameController.Instance.characterMovment.enabled = false;
            ShopUiController.Instance.SetUpShopPage(shopProperties);
            ShopUiController.Instance.panel.SetActive(true);
        });

        ShopUiController.Instance.optionPanel.noOption.onClick.RemoveAllListeners();
        ShopUiController.Instance.optionPanel.noOption.onClick.AddListener(() =>
        {
            shopkeeperMassage.SetActive(false);
        });
    }

}
