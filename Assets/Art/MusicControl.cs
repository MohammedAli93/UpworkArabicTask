using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicControl : MonoBehaviour
{
    //public static MusicControl instance;
    [SerializeField]
    Slider volumSlider;
    private MusicControl instance;

    // Start is called before the first frame update


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolum"))
        {
            PlayerPrefs.SetFloat("musicVolum", 1);
            load();
        }
        else
        {
            load();
        }
    }

    public void ChangeVolum()
    {
        AudioListener.volume = volumSlider.value;
    }
    private void load()
    {
        volumSlider.value = PlayerPrefs.GetFloat("musicVolum");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolum", volumSlider.value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
