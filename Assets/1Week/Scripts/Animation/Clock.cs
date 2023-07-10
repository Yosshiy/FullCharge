using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clock : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] Image Buttery;
    [SerializeField] Buttery ButteryMethod;
    bool A;
    bool clear;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        A = true;
    }
    
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        A = false;
    }

    private void Update()
    {
        if (A)
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

            if(angles.z > 0 && angles.z < 62)
            {
                return;
            }

            transform.parent.localEulerAngles = angles;

            if(Buttery.fillAmount > 0.96f && !clear)
            {
                ButteryMethod.playAnimation();
                clear = true;
            }
            else if(Buttery.fillAmount < 0.99f)
            {
                Buttery.fillAmount = 1 - ((transform.parent.localEulerAngles.z - 60) / 300);

            }
        }

    }

    public float GetAngle(Vector2 from, Vector2 to)
    {
        // 指定された2つの一から角度を求める
        var dx = to.x - from.x;
        var dy = to.y - from.y;
        var rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
