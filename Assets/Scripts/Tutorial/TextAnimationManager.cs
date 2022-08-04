using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimationManager : MonoBehaviour
{
    private Animator textAnimator;
    // Start is called before the first frame update
    void Start()
    {
        //�ϐ�textAnimator�ɁAAnimator�R���|�[�l���g��ݒ肷��B
        textAnimator = gameObject.GetComponent<Animator>();

        //statrAnimationMethod��3�b��ɌĂяo���B
        Invoke(nameof(startAnimationMethod), 3.0f);
    }

    // Update is called once per frame
    void startAnimationMethod()
    {
        //�w�肵�����Ԍ��Bool�^�̃p�����[�^�ł���setText��True�ɂ���
        textAnimator.SetBool("setText", true);
    }
}
