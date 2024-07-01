using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���Ǘ��̂��߂ɕK�v

public class NextScene1 : MonoBehaviour
{
    private int itemCount = 0; // �擾�����A�C�e���̃J�E���g
    [SerializeField]
    private int requiredItemCount = 5; // �K�v�ȃA�C�e���̐�

    // �A�C�e�����擾�����Ƃ��ɌĂ΂��֐�
    public void CollectItem()
    {
        itemCount++;
        Debug.Log("�A�C�e���擾: " + itemCount);

        if (itemCount >= requiredItemCount)
        {
            LoadNextScene();
        }
    }

    // ���̃V�[�������[�h����֐�
    private void LoadNextScene()
    {
        // �V�[�������w�肵�Ď��̃V�[�������[�h����
        //SceneManager.LoadScene("NextSceneName");

        // �܂��́A���݂̃V�[���C���f�b�N�X�Ɋ�Â��Ď��̃V�[�������[�h����
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
