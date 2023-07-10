using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Buttery : MonoBehaviour
{
    [SerializeField] Image ButteryImage;
    [SerializeField] Image EffectImage;
    [SerializeField] Image ClearImage;
    [SerializeField] Text Text;
    [SerializeField] GameObject Next;

    public void FullCharge()
    {
        DOTween.Sequence()
               .Append(ButteryImage.DOFillAmount(1, 1).SetEase(Ease.OutQuad))
               .AppendCallback(() => playAnimation());
    }

    public void playAnimation()
    {
        DOTween.Sequence()
               .Append(EffectImage.rectTransform.DOScale(2, 0.6f).SetEase(Ease.InOutCirc))
               .AppendInterval(1)
               .Append(ClearImage.rectTransform.DOScale(5, 1).SetEase(Ease.InBack))
               .AppendInterval(1)
               .AppendCallback(() =>
               {
                   Next.SetActive(true);
               })
               .Append(Text.DOText("CLEAR!", 1))
               .Append(Text.rectTransform.DOPunchScale(Vector3.one * 0.2f, 1, 3))
               .AppendInterval(2)
               .Append(Text.rectTransform.DORotate(new Vector3(090, 0, 0), 0.5f).SetEase(Ease.OutExpo))
               .Append(ClearImage.rectTransform.DOScale(0, 1).SetEase(Ease.OutBack))
               .SetLink(gameObject);
    }
}
