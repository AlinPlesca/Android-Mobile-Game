using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlefollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform bat;
   
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(bat.position.x, bat.position.y, transform.position.z);
    }
}
