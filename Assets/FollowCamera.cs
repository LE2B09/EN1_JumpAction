using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private GameObject player;
    public float yOffset;   // y軸方向のオフセット
    public float zOffset;   // z軸方向のオフセット

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = player.transform.position.z;
        transform.position = new Vector3(x, y + yOffset, z + zOffset);
    }
}
