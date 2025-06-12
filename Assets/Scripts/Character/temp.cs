using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class temp : MonoBehaviour
{
    public PhotonView PV;
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            float moveX = 0f;
            float moveZ = 0f;

            if (Input.GetKey(KeyCode.W))
                moveZ += 1f;
            if (Input.GetKey(KeyCode.S))
                moveZ -= 1f;
            if (Input.GetKey(KeyCode.A))
                moveX -= 1f;
            if (Input.GetKey(KeyCode.D))
                moveX += 1f;

            Vector3 moveDir = new Vector3(moveX, 0f, moveZ).normalized;
            transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
