using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class HatProperties : ProductProperties
{
    public HatProperties() { }
    public HatProperties(ProductProperties productProperties)
    {
        Name = productProperties.Name;
        price = productProperties.price;
        type = productProperties.type;
        sprite = productProperties.sprite;
    }
    public override void WearingClots(PlayerProperties playerProperties)
    {
        playerProperties.hatSprite.sprite = sprite;
    }
    public override void BuyClots(PlayerProperties playerController)
    {
        if (playerController.money - price < 0)
        {
            ShopUiController.Instance.warningForLessMoney.SetActive(true);
            ShopUiController.Instance.warnigPanel.SetActive(true);
            return;
        }
        playerController.money -= price;
        playerController.hats.Add(this);
        GameController.Instance.playerItems.SetUpPlayerItem();

    }
    public override void SellClotes(PlayerProperties playerController)
    {
        HatProperties tmpProduct = playerController.hats.Where((x) => x.sprite == sprite).FirstOrDefault();
        if (tmpProduct == default)
        {
            ShopUiController.Instance.warningForNotExsistItem.SetActive(true);
            ShopUiController.Instance.warnigPanel.SetActive(true);
            return;
        }
        playerController.money += price;
        playerController.hats.Remove(tmpProduct);
        GameController.Instance.playerItems.SetUpPlayerItem();
    }
}
