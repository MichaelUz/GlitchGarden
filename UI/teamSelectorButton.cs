using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamSelectorButton : MonoBehaviour
{
    [SerializeField] Defender myDef;
    
    //Getter for myDef
    public Defender GetMyDef()
    {
        return myDef;
    }
}
