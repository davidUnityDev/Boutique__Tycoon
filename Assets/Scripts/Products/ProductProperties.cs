using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[Serializable]
public  class ProductProperties 
{
    public string Name;
    public ProductType type;
    public int price;
    public Sprite sprite;
    public virtual void WearingClots(PlayerProperties playerController) { }
    public virtual void BuyClots(PlayerProperties playerController) { }
    public virtual void SellClotes(PlayerProperties playerController) { }

}
public enum ProductType
{ 
    Hat,
    Tshirt,
    Pats
}