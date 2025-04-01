using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Curtain : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    
    public static Curtain Instance { get; private set; }
    
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Show() => canvas.gameObject.SetActive(true);

    public void Hide() => canvas.gameObject.SetActive(false);
}
