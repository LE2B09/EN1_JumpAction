using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private GameObject player;
    public float yOffset;   // y�������̃I�t�Z�b�g
    public float zOffset;   // z�������̃I�t�Z�b�g

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
