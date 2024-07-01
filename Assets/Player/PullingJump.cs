using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;
    private bool isGrounded; // 地面に接触しているかどうかを判定するフラグ
    private int jumpCount;
    [SerializeField]
    private int maxAirJumpCount = 2; // 空中での最大ジャンプ回数

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpCount = maxAirJumpCount + 1; // 初回の地面からのジャンプを含めた合計ジャンプカウントを初期化
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
            // クリックした座標と離した座標の差分を取得
            Vector3 dist = clickPosition - Input.mousePosition;
            // クリックとリリースが同じ座標ならば無視
            if (dist.magnitude == 0) { return; }

            // ジャンプ可能かどうかをチェック
            if (jumpCount > 0)
            {
                rb.velocity = dist.normalized * jumpPower;
                if (isGrounded)
                {
                    isGrounded = false; // 地面から離れたら地面にいない状態にする
                }
                jumpCount--; // ジャンプ回数を減少
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 地面に接触した場合のみジャンプ回数をリセット
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("地面に衝突した");
            isGrounded = true;
            jumpCount = maxAirJumpCount + 1; // 初回の地面からのジャンプを含めてリセット
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 地面から離れたときの処理
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("地面から離脱した");
            isGrounded = false;
        }
    }
}
