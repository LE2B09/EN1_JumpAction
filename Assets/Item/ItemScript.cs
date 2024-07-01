using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private NextScene1 nextScene1; // NextScene1�X�N���v�g���t�B�[���h�Ƃ��Đ錾

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        nextScene1 = FindObjectOfType<NextScene1>(); // NextScene1�X�N���v�g�������I�Ɏ擾
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Get");
        audioSource.Play();
        StartCoroutine(HandleItemCollection());
    }

    private void OnTriggerStay(Collider other)
    {
        //�ڐG���Ă���ԁi�d�Ȃ��Ă���Ƃ��j�ɌĂ΂��B
        Debug.Log("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        //���ꂽ���ɌĂ΂��
        Debug.Log("Exit");
    }

    private IEnumerator HandleItemCollection()
    {
        yield return new WaitForSeconds(1.0f); // �A�j���[�V�������Đ������̂�ҋ@
        nextScene1.CollectItem(); // �A�C�e���擾��ʒm
        DestroySelf(); // �A�C�e�����폜
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
