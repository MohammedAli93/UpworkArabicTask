using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMUSIC : MonoBehaviour
{
    public static BGMUSIC instance;

    private void Awake() {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
