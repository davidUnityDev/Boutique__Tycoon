using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopProperties : MonoBehaviour
{
    public MarketType type;
    public ProductType productType;
    [Header("Items")]
    public List<Sprite> productsItemsIcons = new List<Sprite>();
    public List<ProductProperties> products = new List<ProductProperties>();
    public PlayerProperties player;

    public Sprite iconOfWorker;

    public void GenerateProduct()
    {
        for (int i = 0; i < productsItemsIcons.Count; i++)
        {
            switch (productType)
            {
                case ProductType.Hat:
                    products.Add(new ProductProperties() { Name = $"Hat {i}", price = 100, sprite = productsItemsIcons[i], type = ProductType.Hat });
                    break;
                case ProductType.Tshirt:
                    products.Add(new ProductProperties() { Name = $"T-Shirt {i}", price = 100, sprite = productsItemsIcons[i], type = ProductType.Tshirt });
                    break;
                case ProductType.Pats:
                    products.Add(new ProductProperties() { Name = $"Pats {i}", price = 100, sprite = productsItemsIcons[i], type = ProductType.Pats });
                    break;
                default:
                    break;
            }
        }

        
    }
}

public enum MarketType
{
    Seller,
    Buyer
}
