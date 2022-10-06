using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buton : MonoBehaviour
{
    public Playercode playercode;
    

    public int butonundegeri;
   public void butonbilgitiklama()
    {
        playercode.tiklanilanbuton(butonundegeri);
    }
}
