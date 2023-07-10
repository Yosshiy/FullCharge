using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] Buttery buttery;
    [SerializeField] Image ButtonImage;
    [SerializeField] Image EffectImage;
    [SerializeField] float MoveValue;
    [SerializeField] bool Osudake;
    float Image_y;

    private void Start()
    {
        Image_y = ButtonImage.rectTransform.anchoredPosition.y;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (!Osudake)
        {
            PlayAnimation();
        }
        else
        {
            PlayAnimation1();
        }
    }

    void PlayAnimation()
    {
        DOTween.Sequence()
               .Append(ButtonImage.rectTransform.DOLocalMoveY(Image_y - MoveValue, 1))
               .Join(EffectImage.transform.DOScale(2,0.5f))
               .AppendCallback(() => buttery.FullCharge())
               .SetLink(this.gameObject);
    }
    
    void PlayAnimation1()
    {
        DOTween.Sequence()
               .Append(ButtonImage.rectTransform.DOLocalMoveY(Image_y - MoveValue, 1))
               .Join(EffectImage.transform.DOScale(2,0.5f))
               .AppendCallback(() =>
               {
                   GetComponent<Image>().raycastTarget = false;
               })
               .SetLink(this.gameObject);
    }
}
