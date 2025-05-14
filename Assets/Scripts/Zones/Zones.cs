using System.Collections.Generic;
using UnityEngine;

public class Zones : MonoBehaviour
{
    public static Zones Instance;
    public HandManager Hand;
    public PickZone Pick;
    public DiscardZone Discard;
    

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        
    }
}
