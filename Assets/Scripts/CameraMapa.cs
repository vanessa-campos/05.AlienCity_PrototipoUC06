using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMapa : MonoBehaviour
{
    public Transform RefPlayer;

    private void Update()
    {
        transform.position = new Vector3(RefPlayer.position.x, transform.position.y, RefPlayer.position.z);
    }
}
