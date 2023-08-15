using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public CharacterMovmentController characterMovment;
    public PlayerProperties playerProperties;
    public PlayerController playerController;
    public List<ShopProperties> shopProperties;
    public PlayerItemsUiController playerItems;
    private void Awake()
    {
        Instance = this;
        foreach (var item in shopProperties)
        {
            item.GenerateProduct();
        }
        
        playerProperties.ArrangeOnShelves();
        playerProperties.SetUpInitailColtes();
        playerController.WearingInitialColtes();
        playerItems.SetUpPlayerItem();
    }
}
