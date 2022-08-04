using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimationManager : MonoBehaviour
{
    private Animator textAnimator;
    // Start is called before the first frame update
    void Start()
    {
        //変数textAnimatorに、Animatorコンポーネントを設定する。
        textAnimator = gameObject.GetComponent<Animator>();

        //statrAnimationMethodを3秒後に呼び出す。
        Invoke(nameof(startAnimationMethod), 3.0f);
    }

    // Update is called once per frame
    void startAnimationMethod()
    {
        //指定した時間後にBool型のパラメータであるsetTextをTrueにする
        textAnimator.SetBool("setText", true);
    }
}
