using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public PlayerProperties playerProperties;
    public void WearingInitialColtes()
    {

        playerProperties.currentTshirt.WearingClots(playerProperties);
        playerProperties.currentHat.WearingClots(playerProperties);
        playerProperties.currentPats.WearingClots(playerProperties);
    }

    public void WearChlotes(ProductProperties chlotes)
    {
        chlotes.WearingClots(playerProperties);
    }
}
