using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUiController : MonoBehaviour
{
    public static ShopUiController Instance;
    public GameObject panel;
    public Text shopMassage;
    public Image workerIcon;
    public Transform parentForProducts;
    public GameObject prefabOfProduct;
    public GameObject warnigPanel;
    public GameObject warningForLessMoney;
    public GameObject warningForNotExsistItem;
    public MassageOptionController optionPanel;
    public List<GameObject> shopItems = new List<GameObject>();
    public Text moneyCount;
    private void Awake()
    {
        Instance = this;
    }
    public void SetUpShopPage(ShopProperties shopProperties)
    {
        RemoveParentForProductsElements();
        foreach (var item in shopProperties.products)
        {
            GameObject g = Instantiate(prefabOfProduct,parentForProducts);
            ItemProperties productProperties = g.GetComponent<ItemProperties>();
            productProperties.name.text = item.Name;
            if (shopProperties.type == MarketType.Buyer)
            {
                shopMassage.text = "What do you want to Sell? ";
 
                 productProperties.buttonName.text = $"Sell : ${item.price+20}";
            }
            else
            {
                shopMassage.text = "What do you want to Buy?";
                productProperties.buttonName.text = $"Buy : ${item.price}";
            }
            productProperties.icon.sprite =item.sprite;
            productProperties.button.onClick.AddListener(() => {

                switch (shopProperties.productType)
                {
                    case ProductType.Hat:
                        HatProperties hat = new HatProperties(item);
                        if (shopProperties.type == MarketType.Buyer)// if shop is buyer, the price is incrising for bringing revenu to player
                        {
                            hat.price = item.price+20;
                            hat.SellClotes(shopProperties.player);
                        }
                        else
                            hat.BuyClots(shopProperties.player);
                        break;
                    case ProductType.Tshirt:
                        TshirtProperties tshirt = new TshirtProperties(item);
                        if (shopProperties.type == MarketType.Buyer)
                        {
                            tshirt.price = item.price + 20;
                            tshirt.SellClotes(shopProperties.player);
                        }
                        else
                            tshirt.BuyClots(shopProperties.player);
                        break;
                    case ProductType.Pats:
                        PatsProperties pats = new PatsProperties(item);
                        if (shopProperties.type == MarketType.Buyer)
                        {
                            pats.price = item.price + 20;
                            pats.SellClotes(shopProperties.player);
                        }
                        else
                            pats.BuyClots(shopProperties.player);
                        break;
                    default:
                        break;
                }
            });
            workerIcon.sprite = shopProperties.iconOfWorker;
            shopItems.Add(g);
        }
    }
    public void RemoveParentForProductsElements()
    {
        foreach (var item in shopItems)
        {
            Destroy(item.gameObject);
        }
    }
}
