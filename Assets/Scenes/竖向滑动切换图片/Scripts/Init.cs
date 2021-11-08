using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Init : MonoBehaviour
{
    [SerializeField] private RectTransform View;
    private readonly string path = "Prefabs/Item";
    [HideInInspector]
    public static int Pos;
    [HideInInspector]
    public static bool isPlay;

    void Start()
    {
        Logic.GenerateMonth(View, 12, path);
    }
    
    private void Update()
    {
        if (!isPlay) return;
        float tem = Mathf.Lerp(View.anchoredPosition.y, Pos, 0.15f);
        View.anchoredPosition = new Vector2(View.anchoredPosition.x, tem);
        
        Invoke("Setplay",0.4f);
    }
    
    void Setplay()
    {
        isPlay = false;
        foreach (Transform t in View)
        {
            t.GetComponent<Button>().enabled = true;
        }
    }
}