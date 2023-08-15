using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerItemsUiController : MonoBehaviour
{
    public GameObject panel;
    public Transform parentForTshirts;
    public Transform parentForHats;
    public Transform parentForPats;
    public GameObject prefabForItem;
    public PlayerProperties playerProperties;
    public List<GameObject> allItems = new List<GameObject>();
    public void SetUpPlayerItem()
    {

        RemoveAllItemsBoferCreatingNewOnes();
        SetUpHatsPagePage();
        SetUpPatsPagePage();
        SetUpTshirtPagePage();
        playerProperties.ShowClotsAndMoneyCount();
    }
    public void SetUpTshirtPagePage()
    {
        foreach (var item in playerProperties.tShirts)
        {
            GameObject g = Instantiate(prefabForItem, parentForTshirts);
            ItemProperties productProperties = g.GetComponent<ItemProperties>();
            productProperties.name.text = item.Name;
            productProperties.buttonName.text = $"Wear";
            productProperties.icon.sprite = item.sprite;
            productProperties.button.onClick.AddListener(() => {
                GameController.Instance.characterMovment.enabled = true;
                item.WearingClots(playerProperties);
                panel.SetActive(false);
            });
            allItems.Add(g);
        }
    }
    public void SetUpHatsPagePage()
    {
      
        foreach (var item in playerProperties.hats)
        {
            GameObject g = Instantiate(prefabForItem, parentForHats);
            ItemProperties productProperties = g.GetComponent<ItemProperties>();
            productProperties.name.text = item.Name;
            productProperties.buttonName.text = $"Wear";
            productProperties.icon.sprite = item.sprite;
            productProperties.button.onClick.AddListener(() => {
                GameController.Instance.characterMovment.enabled = true;
                item.WearingClots(playerProperties);
                panel.SetActive(false);
            });
            allItems.Add(g);
        }
    }
    public void SetUpPatsPagePage()
    {
        
        foreach (var item in playerProperties.pats)
        {
            GameObject g = Instantiate(prefabForItem, parentForPats);
            ItemProperties productProperties = g.GetComponent<ItemProperties>();
            productProperties.name.text = item.Name;
            productProperties.buttonName.text = $"Wear";
            productProperties.icon.sprite = item.sprite;
            productProperties.button.onClick.AddListener(() => {
                GameController.Instance.characterMovment.enabled = true;
                item.WearingClots(playerProperties);
                panel.SetActive(false);
            });
            allItems.Add(g);
        }
    }
    public void RemoveAllItemsBoferCreatingNewOnes()
    {
        foreach (var item in allItems)
        {
            Destroy(item.gameObject);
        }
    }
}
