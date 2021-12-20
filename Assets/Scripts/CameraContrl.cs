using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContrl : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private Transform playerChar;
   
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerChar.position.x, playerChar.position.y,transform.position.z);
    }
}
