using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
    [SerializeField] Text Clear1;
    [SerializeField] Text Clear2;

    private void Start()
    {
        DOTween.Sequence()
               .AppendInterval(6)
               .Append(Clear1.DOText("STAGE COMPLETE", 2))
               .Append(Clear1.rectTransform.DOPunchScale(Vector3.one * 0.2f, 1, 3))
               .Append(Clear2.DOText("REPLAY TO ENTER", 2))
               .Append(Clear2.rectTransform.DOPunchScale(Vector3.one * 0.2f, 1, 3))
               .SetLink(this.gameObject);



        Observable.EveryUpdate()
                  .Where(x => Clear2.text == "REPLAY TO ENTER")
                  .Where(x => Input.GetKeyDown(KeyCode.Return))
                  .Subscribe(x => SceneManager.LoadScene("Title"))
                  .AddTo(this);
    }
}
