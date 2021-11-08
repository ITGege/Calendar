/*-------------------
 * 作者:侒
 * 时间:2021年01月25日 星期一 15:41
 * 功能:INFO
 -------------------*/

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Logic
{
    /// <summary>
    /// 生成月份
    /// </summary>
    /// <param name="_root">根物体</param>
    /// <param name="_num">月份数量</param>
    /// <param name="_path">预制路径</param>
    public static void GenerateMonth(Transform _root, ushort _num, string _path)
    {
        GameObject pfb = Resources.Load<GameObject>(_path);

        for (int i = 1; i <= _num; i++)
        {
            Transform temObj = GameObject.Instantiate(pfb).transform;
            temObj.name = i.ToString();
            temObj.GetChild(0).GetComponent<Text>().text = "0" + i;
            temObj.SetParent(_root);

            temObj.GetComponent<Button>().onClick.AddListener(() =>
            {
                Move(temObj.name);
                foreach (Transform t in temObj.parent)
                {
                    t.GetComponent<Button>().enabled = false;
                }
            });
        }
    }


    /// <summary>
    /// 加载精灵
    /// </summary>
    /// <param name="_item"></param>
    /// <param name="_path"></param>
    public static void ChangedPic(Transform _item, string _path)
    {
        _item.GetComponent<Image>().sprite = Resources.Load<Sprite>(_path);
    }

    public static void TargetPosMove(string _num, UnityAction<int> onProcess)
    {
        if (_num == "1")
        {
            onProcess.Invoke(0);
        }
        else
        {
            onProcess.Invoke((int.Parse(_num) - 1) * 70);
        }
    }

    /// <summary>
    /// 移动
    /// </summary>
    /// <param name="num"></param>
    public static void Move(string num)
    {
        Logic.TargetPosMove(num, pos =>
        {
            Init.Pos = pos;
            Init.isPlay = true;
        });
    }
}