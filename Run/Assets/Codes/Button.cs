using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    Char_Code c= new Char_Code();
    public GameObject obj;
    public  void ButtonOnClick()
    {
        obj.SetActive(false);
        c.ButtonRestart();
    }
}
