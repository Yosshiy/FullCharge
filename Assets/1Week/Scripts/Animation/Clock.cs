﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clock : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] Image Buttery;
    [SerializeField] Buttery ButteryMethod;
    //マウスポインタ―がクリックされているかどうかのbool値
    bool OnPointer = false;
    bool clear;
    //クリアに必要なFillの値
    float Fill = 0.96f;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        OnPointer = true;
    }
    
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        OnPointer = false;
    }

    private void Update()
    {
        if (OnPointer)
        {
            // プレイヤーのスクリーン座標を計算する
            var screenPos = Camera.main.WorldToScreenPoint(transform.parent.position);

            // プレイヤーから見たマウスカーソルの方向を計算する
            var direction = Input.mousePosition - screenPos;

            // マウスカーソルが存在する方向の角度を取得する
            var angle = GetAngle(Vector3.zero, direction);

            // プレイヤーがマウスカーソルの方向を見るようにする
            var angles = transform.parent.localEulerAngles;
            angles.z = angle - 90;

            //範囲外の場合はスキップ
            if(angles.z > 0 && angles.z < 62)
            {
                return;
            }

            transform.parent.localEulerAngles = angles;

            //クリアしていなかったらする処理
            if(Buttery.fillAmount > Fill && !clear)
            {
                ButteryMethod.PlayAnimation();
                clear = true;
            }
            else if(Buttery.fillAmount < 1f)
            {
                Buttery.fillAmount = 1 - ((transform.parent.localEulerAngles.z - 60) / 300);

            }
        }

    }

    /// <summary>
    /// マウスカーソルが存在する方向の角度を取得
    /// </summary>
    /// <param name="from">原点</param>
    /// <param name="to">プレイヤーから見たマウスカーソル座標</param>
    private float GetAngle(Vector2 from, Vector2 to)
    {
        // 指定された2つの一から角度を求める
        var dx = to.x - from.x;
        var dy = to.y - from.y;
        var rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
