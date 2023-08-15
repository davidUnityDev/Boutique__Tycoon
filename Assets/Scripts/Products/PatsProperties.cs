using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PatsProperties : ProductProperties
{
    public PatsProperties() { }
    public PatsProperties(ProductProperties productProperties)
    {
        Name = productProperties.Name;
        price = productProperties.price;
        type = productProperties.type;
        sprite = productProperties.sprite;
    }
    public override void WearingClots(PlayerProperties playerProperties)
    {
        playerProperties.patsSprite.sprite = sprite;
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
        playerController.pats.Add(this);
        GameController.Instance.playerItems.SetUpPlayerItem();
    }
    public override void SellClotes(PlayerProperties playerController)
    {
        PatsProperties tmpProduct = playerController.pats.Where((x) => x.sprite == sprite).FirstOrDefault();
        if (tmpProduct == default)
        {
            ShopUiController.Instance.warningForNotExsistItem.SetActive(true);
            ShopUiController.Instance.warnigPanel.SetActive(true);
            return;
        }
        playerController.money += price;
        playerController.pats.Remove(tmpProduct);
        GameController.Instance.playerItems.SetUpPlayerItem();
    }
}
