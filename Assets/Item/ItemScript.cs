using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private NextScene1 nextScene1; // NextScene1スクリプトをフィールドとして宣言

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        nextScene1 = FindObjectOfType<NextScene1>(); // NextScene1スクリプトを自動的に取得
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
        //接触している間（重なっているとき）に呼ばれる。
        Debug.Log("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        //離れた時に呼ばれる
        Debug.Log("Exit");
    }

    private IEnumerator HandleItemCollection()
    {
        yield return new WaitForSeconds(1.0f); // アニメーションが再生されるのを待機
        nextScene1.CollectItem(); // アイテム取得を通知
        DestroySelf(); // アイテムを削除
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
