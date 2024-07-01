using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;
    private bool isGrounded; // �n�ʂɐڐG���Ă��邩�ǂ����𔻒肷��t���O
    private int jumpCount;
    [SerializeField]
    private int maxAirJumpCount = 2; // �󒆂ł̍ő�W�����v��

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpCount = maxAirJumpCount + 1; // ����̒n�ʂ���̃W�����v���܂߂����v�W�����v�J�E���g��������
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            // �N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = clickPosition - Input.mousePosition;
            // �N���b�N�ƃ����[�X���������W�Ȃ�Ζ���
            if (dist.magnitude == 0) { return; }

            // �W�����v�\���ǂ������`�F�b�N
            if (jumpCount > 0)
            {
                rb.velocity = dist.normalized * jumpPower;
                if (isGrounded)
                {
                    isGrounded = false; // �n�ʂ��痣�ꂽ��n�ʂɂ��Ȃ���Ԃɂ���
                }
                jumpCount--; // �W�����v�񐔂�����
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �n�ʂɐڐG�����ꍇ�̂݃W�����v�񐔂����Z�b�g
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("�n�ʂɏՓ˂���");
            isGrounded = true;
            jumpCount = maxAirJumpCount + 1; // ����̒n�ʂ���̃W�����v���܂߂ă��Z�b�g
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // �n�ʂ��痣�ꂽ�Ƃ��̏���
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("�n�ʂ��痣�E����");
            isGrounded = false;
        }
    }
}
