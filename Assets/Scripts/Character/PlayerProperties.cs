using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerProperties : MonoBehaviour
{
    public List<ProductProperties> chlotes = new List<ProductProperties>();

    public List<TshirtProperties> tShirts = new List<TshirtProperties>();

    public List<HatProperties> hats = new List<HatProperties>();

    public List<PatsProperties> pats = new List<PatsProperties>();

    public Text clotesCount;
    public Text moneyCount;
    public int money;

    [HideInInspector]
    public ProductProperties currentTshirt;
    [HideInInspector]
    public ProductProperties currentHat;
    [HideInInspector]
    public ProductProperties currentPats;

    [Header("Clothes Icon")]
    public SpriteRenderer hatSprite;
    public SpriteRenderer tShirtSprite;
    public SpriteRenderer patsSprite;
    public void SetUpInitailColtes()
    {
        currentTshirt = tShirts[0];
        currentHat = hats[0];
        currentPats = pats[0];
    }
    public void ArrangeOnShelves()
    {
        foreach (var item in chlotes)
        {
            switch (item.type)
            {
                case ProductType.Hat:
                    hats.Add(new HatProperties() { Name = item.Name, price=item.price, sprite=item.sprite,type=item.type});
                    break;
                case ProductType.Tshirt:
                    tShirts.Add(new TshirtProperties() { Name = item.Name, price = item.price, sprite = item.sprite, type = item.type });
                    break;
                case ProductType.Pats:
                    pats.Add(new PatsProperties() { Name = item.Name, price = item.price, sprite = item.sprite, type = item.type });
                    break;
                default:
                    break;
            }
        }
    }
    public void ShowClotsAndMoneyCount()
    {
        int count = tShirts.Count + hats.Count + pats.Count;
        clotesCount.text = $"{count}";
        moneyCount.text = $"${money}";
        if(ShopUiController.Instance!=null)
            ShopUiController.Instance.moneyCount.text= $"Your balance\n<b>${money}</b>";
    }

}
