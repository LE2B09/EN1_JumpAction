using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理のために必要

public class NextScene1 : MonoBehaviour
{
    private int itemCount = 0; // 取得したアイテムのカウント
    [SerializeField]
    private int requiredItemCount = 5; // 必要なアイテムの数

    // アイテムを取得したときに呼ばれる関数
    public void CollectItem()
    {
        itemCount++;
        Debug.Log("アイテム取得: " + itemCount);

        if (itemCount >= requiredItemCount)
        {
            LoadNextScene();
        }
    }

    // 次のシーンをロードする関数
    private void LoadNextScene()
    {
        // シーン名を指定して次のシーンをロードする
        //SceneManager.LoadScene("NextSceneName");

        // または、現在のシーンインデックスに基づいて次のシーンをロードする
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
