using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;

public class Number : MonoBehaviour
{
    [SerializeField] List<Text> Slot;
    [SerializeField] Buttery Buttery;
    [SerializeField] Image ButteryImage;
    [SerializeField] Canvas Stage;
    int index;
    bool play;

    private void Start()
    {
        Observable.EveryUpdate()
                  .Where(x => Stage.gameObject.activeSelf)
                  .Where(x => Input.anyKeyDown)
                  .Subscribe(x => Keyjudge(Input.inputString))
                  .AddTo(this);
    }

    async void Keyjudge(string key)
    {
        if (play)
        {
            return;
        }

        try
        {
            var value = int.Parse(key);
            int ind = int.Parse(key);

            Slot[index].text = ind.ToString();
            index++;

            if (index == Slot.Count)
            {
                play = true;
                var maxindex = Slot[0].text + Slot[1].text + Slot[2].text;

                if(int.Parse(maxindex) == 100)
                {
                    await ClearAnimation();
                }
                else
                {
                    await StartAnimation();
                }

                index = 0;

                for (int i = 0; i < Slot.Count; i++)
                {
                    Slot[i].text = "-";
                }
                play = false;
            }


        }
        catch (System.FormatException e)
        {
            Debug.LogException(e);
        }


    }

    async UniTask StartAnimation()
    {
        await DOTween.Sequence()
                     .AppendCallback(() =>
                     {
                         for (int i = 0; i < Slot.Count; i++)
                         {
                             Slot[i].transform.DOPunchRotation(new Vector3(0,0,25), 1, 7);
                         }
                     })
                     .AppendInterval(1f);
    }
    
    async UniTask ClearAnimation()
    {
        await DOTween.Sequence()
                     .AppendCallback(() =>
                     {
                         for (int i = 0; i < Slot.Count; i++)
                         {
                             Slot[i].transform.DOPunchScale(Vector3.one * 0.5f, 1);
                         }
                     })
                     .AppendInterval(1f)
                     .Append(ButteryImage.DOFillAmount(1,1))
                     .AppendCallback(() =>
                     {
                         Buttery.PlayAnimation();
                     });
    }
}
