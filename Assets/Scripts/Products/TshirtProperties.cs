using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TshirtProperties : ProductProperties
{
    public TshirtProperties() { }
    public TshirtProperties(ProductProperties productProperties)
    {
        Name = productProperties.Name;
        price = productProperties.price;
        type = productProperties.type;
        sprite = productProperties.sprite;
    }
    public override void WearingClots(PlayerProperties playerProperties)
    {
        playerProperties.tShirtSprite.sprite = sprite;
    }
    public override void BuyClots(PlayerProperties playerController)
    {
        if (playerController.money - price < 0)
        {
            ShopUiController.Instance.warningForLessMoney.SetActive(true);
            ShopUiController.Instance.warnigPanel.SetActive(true);
            return;
        }
        Debug.Log("count before " + playerController.tShirts.Count);
        playerController.money -= price;
        playerController.tShirts.Add(this);
        GameController.Instance.playerItems.SetUpPlayerItem();
        Debug.Log("count after " + playerController.tShirts.Count);

    }
    public override void SellClotes(PlayerProperties playerController)
    {
        TshirtProperties tmpProduct = playerController.tShirts.Where((x) => x.sprite == sprite).FirstOrDefault();
        if (tmpProduct == default)
        {
            ShopUiController.Instance.warningForNotExsistItem.SetActive(true);
            ShopUiController.Instance.warnigPanel.SetActive(true);
            return;
        }
        playerController.money += price;
        playerController.tShirts.Remove(tmpProduct);
        GameController.Instance.playerItems.SetUpPlayerItem();
    }
}
