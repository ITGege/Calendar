using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Mainly : MonoBehaviour
{
    [SerializeField] private RectTransform[] tfs = new RectTransform[] { };

    //btn
    [SerializeField] private Button btn_L;
    [SerializeField] private Button btn_R;

    void Start()
    {
        //绑定按钮事件
        btn_R.onClick.AddListener(RightBtnClickEvent);
        btn_L.onClick.AddListener(LeftBtnClickEvent);
    }


    /// <summary>
    /// 逻辑工作
    /// </summary>
    void LeftBtnClickEvent()
    {
        for (int i = tfs.Length; i > 0; i--)
        {
            int tem = i % tfs.Length;

            if (tem == 0)
            {
                tfs[tem].anchoredPosition = tfs[i - 1].anchoredPosition;
                tfs[tem].sizeDelta = tfs[i - 1].sizeDelta;
            }
            else
            {
                tfs[tem].DOAnchorPos(tfs[i - 1].anchoredPosition, 0.2f);
                tfs[tem].DOSizeDelta(tfs[i - 1].sizeDelta, 0.2f);
            }
        }
    }


    void RightBtnClickEvent()
    {
        for (int i = 0; i < tfs.Length; i++)
        {
            int tem = (i + 1) % tfs.Length;
            /*动画*/
            if (i == 0)
            {
                tfs[i].anchoredPosition = tfs[tem].anchoredPosition;
                tfs[i].sizeDelta = tfs[tem].sizeDelta;
            }
            else
            {
                tfs[i].DOAnchorPos(tfs[tem].anchoredPosition, 0.2f);
                tfs[i].DOSizeDelta(tfs[tem].sizeDelta, 0.2f);
            }
        }
    }
}