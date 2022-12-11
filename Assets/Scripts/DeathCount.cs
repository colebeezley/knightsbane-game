using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCount : MonoBehaviour
{
     public TextMeshProUGUI deathCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     deathCount.SetText(PlayerPrefs.GetInt("DeathCount").ToString());
    }
    
}
