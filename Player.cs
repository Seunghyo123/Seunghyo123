using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed; // 속도
    // 캐릭터와 경계선
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchLeft;
    public bool isTouchRight;

    void Update()
    {
        // 충돌 함수
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;
        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }
    //캐릭터 오브젝트와 경계선이 부딪혔을 때
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border") 
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true; break;
                case "Bottom":
                    isTouchBottom = true; break;
                case "Left":
                    isTouchLeft = true; break;
                case "Right":
                    isTouchRight = true; break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false; break;
                case "Bottom":
                    isTouchBottom = false; break;
                case "Left":
                    isTouchLeft = false; break;
                case "Right":
                    isTouchRight = false; break;
            }
        }
    }
}
