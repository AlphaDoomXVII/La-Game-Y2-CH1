using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    void Pickup()
    {
       
    }



    private void OnMouseDown()
    {
        Pickup();   
    }
      
}
