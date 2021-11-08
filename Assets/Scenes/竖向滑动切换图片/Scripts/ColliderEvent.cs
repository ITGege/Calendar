/*-------------------
 * 作者:侒
 * 时间:2021年01月25日 星期一 16:25
 * 功能:INFO
 -------------------*/

using System;
using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Logic.ChangedPic(transform.root.Find("View"),"Pic/" + other.name);
    }
}
