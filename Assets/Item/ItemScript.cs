using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Get");
        audioSource.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        //�ڐG���Ă���ԁi�d�Ȃ��Ă���Ƃ��j�ɌĂ΂��B
        Debug.Log("Stay");
        //DestroySelf();

    }

    private void OnTriggerExit(Collider other)
    {
        //���ꂽ���ɌĂ΂��
        Debug.Log("Exit");
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
