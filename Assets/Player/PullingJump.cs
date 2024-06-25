using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;
    private bool isCanJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            //クリックした座標と話した座標の差分を取得
            Vector3 dist = clickPosition - Input.mousePosition;
            //クリックとリリースが同じ座標ならば無視
            if (dist.magnitude == 0) { return; }

            // オブジェクトがジャンプできるかどうかをチェック
            if (isCanJump)
            {
                rb.velocity = dist.normalized * jumpPower;
                isCanJump = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("衝突した");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("接触中");

        //衝突している点の情報が複数格納されている
        ContactPoint[] contacts = collision.contacts;
        //0番目の衝突情報から、衝突している点の法線を取得
        Vector3 otherNormal = contacts[0].normal;
        //上方向を示すベクトル。長さは1。
        Vector3 upVector = new Vector3(0, 1, 0);
        //上方向と法線の内積。二つのべっくとるはともに長さが1なので、cosθの結果がdotUN変数に入る
        float dotUN = Vector3.Dot(upVector, otherNormal);
        //内積値に逆三角関数arccosを掛けて角度を算出。それを度数法へ変換する。これで角度が算出できた。
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        //二つのベクトルがなす角度が45度より小さければフタタ浴びジャンプ可能とする
        if (dotDeg <= 45)
        {
            isCanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("離脱した");
        isCanJump = false;
    }
}
