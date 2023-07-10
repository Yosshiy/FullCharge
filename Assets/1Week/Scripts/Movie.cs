using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Movie : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] Image PlayImage;
    [SerializeField] Sprite PlaySprite;
    [SerializeField] Sprite StopSprite;

    [SerializeField] List<Image> MovieList;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        DOTween.Sequence()
               .AppendCallback(() =>
               {
                   for (int i = 0; i < MovieList.Count; i++)
                   {
                       MovieList[i].rectTransform.DOScale(1, 1).SetDelay(i);

                   }
               })
               .AppendInterval(MovieList.Count)
               .AppendCallback(() =>
               {
                   for (int i = MovieList.Count - 1; i > -1; i--)
                   {
                       MovieList[i].rectTransform.DOScale(0, 1).SetDelay(MovieList.Count - i);

                   }
               })
               .AppendInterval(MovieList.Count)
               .SetLoops(-1, LoopType.Incremental);  
    }
}
