using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Trigger_Code : MonoBehaviour
{

    Char_Code charCode;
    void Start()
    {
        charCode = transform.root.gameObject.GetComponent<Char_Code>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Yere inip inmediğinin kontrolü
    void OnTriggerEnter2D()
    {
        charCode.onGround = true;
    }
    void OnTriggerStay2D()
    {
        charCode.onGround = true;
    }
    void OnTriggerExit2D()
    {
        charCode.onGround = false;
    }
}
