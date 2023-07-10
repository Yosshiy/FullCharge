using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class paint : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] Image Palet;
    [SerializeField] Image ButteryImage;
    [SerializeField] Image ButteryEndImage;
    [SerializeField] Buttery Buttery;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        var a = GetComponent<Image>().color;
        var b = Palet.color;
        Palet.color = a;
        GetComponent<Image>().color = b;

        if(ButteryImage.color == ButteryEndImage.color)
        {
            Buttery.PlayAnimation();
            Debug.Log("A");
        }
    }
}
