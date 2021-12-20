using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindObjectTrig : MonoBehaviour
{
    [SerializeField] private Text findObjTxt;
    [SerializeField] public Animator anim;
    // Start is called before the first frame update
    public ItemPicker IP;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        findObjTxt.gameObject.SetActive(true);
        if (IP.globalInventory == 1)
        {
            anim.SetBool("isOpened", true);
            findObjTxt.gameObject.SetActive(false);
        }
        else 
        {
            anim.SetBool("isOpened", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        findObjTxt.gameObject.SetActive(false);
    }
}
