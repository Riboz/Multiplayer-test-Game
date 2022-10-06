using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Playercode : MonoBehaviourPunCallbacks
{
   
   public int oburoyuncubutonukodu;
   public string[] questions =  new string[10];
   public int sorubitis,rakippuan,seninpuan,sorucevap;
   public string[] Answers=new string[40];
   
  public  Button[] answerbutton=new Button[4];
  public Text yourscore,enemyscore,questiontext;
  
  
    public void FixedUpdate()
   {
     yourscore.text="Your score= "+seninpuan;

     enemyscore.text="Rival score= "+rakippuan;
   }
   [PunRPC]
   public void Oburoyuncutiklananbuton(int oburoyuncubutonkod)
   {
    
      sorubitis+=1;
     oburoyuncubutonukodu=oburoyuncubutonkod;
     if(sorubitis==2)
     {
      StartCoroutine(sayac());
     }
    
     
   }
   IEnumerator sayac()
   {
yield return new WaitForSeconds(0.2f);
if(oburoyuncubutonukodu==sorucevap)
      {
      rakippuan+=1;
      }
      
      for(int a=0;a<=3;a++)
      {
      answerbutton[a].GetComponent<Image>().color=Color.black;
      answerbutton[a].interactable=true;
      }
      sorubitis=0;
      // yeni soruya geçilinir ve yeni sorunun doğru cevabı değiştirilir
        NewQuestionPart();
      // ayrıca şıklar düzenlenir
        yield break;
   }
  public void tiklanilanbuton(int tiklama)
  {
   sorubitis+=1;

    if(sorubitis==2)
     {
      StartCoroutine(sayac());
     }
   if(tiklama==sorucevap)
   {
      seninpuan+=1;
   }
   answerbutton[tiklama].GetComponent<Image>().color=Color.blue;
   for(int b=0;b<=3;b++)
   {
   answerbutton[b].interactable=false;
   }
   
   GetComponent<PhotonView>().RPC("Oburoyuncutiklananbuton",RpcTarget.Others,tiklama);
  }
  int i=0;
  
  void NewQuestionPart()
  {
    for(int b=0;b<=3;b++)
    {
      answerbutton[b].GetComponentInChildren<Text>().text="";
    }
    i+=1;
    if(i<10){ questiontext.text=questions[i]; }
    

    
        if(i==0)
      {
        sorucevap=1;
      answerbutton[0].GetComponentInChildren<Text>().text=Answers[0];
       answerbutton[1].GetComponentInChildren<Text>().text=Answers[1];
        answerbutton[2].GetComponentInChildren<Text>().text=Answers[2];
         answerbutton[3].GetComponentInChildren<Text>().text=Answers[3];
  
        Answers[1]="ankara";
      }
       if(i==1)
      {
        sorucevap=2;
      answerbutton[0].GetComponentInChildren<Text>().text=Answers[4];
       answerbutton[1].GetComponentInChildren<Text>().text=Answers[5];
        answerbutton[2].GetComponentInChildren<Text>().text=Answers[6];
         answerbutton[3].GetComponentInChildren<Text>().text=Answers[7];
  
        Answers[2]="Van gölü";
      }


        if(i==2)
      {
        sorucevap=2;
      answerbutton[0].GetComponentInChildren<Text>().text=Answers[8];
       answerbutton[1].GetComponentInChildren<Text>().text=Answers[9];
        answerbutton[2].GetComponentInChildren<Text>().text=Answers[10];
         answerbutton[3].GetComponentInChildren<Text>().text=Answers[11];
  
      
        Answers[2]="Everest dağı";
      }


       if(i==3)
      {
        
        sorucevap=3;
      answerbutton[0].GetComponentInChildren<Text>().text=Answers[12];
       answerbutton[1].GetComponentInChildren<Text>().text=Answers[13];
        answerbutton[2].GetComponentInChildren<Text>().text=Answers[14];
         answerbutton[3].GetComponentInChildren<Text>().text=Answers[15];
        Answers[3]="Çin";
      }


       if(i==4)
      {
        sorucevap=0;
      answerbutton[0].GetComponentInChildren<Text>().text=Answers[16];
       answerbutton[1].GetComponentInChildren<Text>().text=Answers[17];
        answerbutton[2].GetComponentInChildren<Text>().text=Answers[18];
         answerbutton[3].GetComponentInChildren<Text>().text=Answers[19];
        Answers[0]="Kaliforniya";

      }


      if(i==5)
      {
        sorucevap=1;
      answerbutton[0].GetComponentInChildren<Text>().text=Answers[20];
       answerbutton[1].GetComponentInChildren<Text>().text=Answers[21];
        answerbutton[2].GetComponentInChildren<Text>().text=Answers[22];
         answerbutton[3].GetComponentInChildren<Text>().text=Answers[23];
        Answers[1]="Nokia";
      }


      if(i==6)
      {
        sorucevap=1;
      answerbutton[0].GetComponentInChildren<Text>().text=Answers[24];
       answerbutton[1].GetComponentInChildren<Text>().text=Answers[25];
        answerbutton[2].GetComponentInChildren<Text>().text=Answers[26];
         answerbutton[3].GetComponentInChildren<Text>().text=Answers[27];
          Answers[1]=" Kristof Kolomb ";
      }


       if(i==7)
      {
        sorucevap=2;
      answerbutton[0].GetComponentInChildren<Text>().text=Answers[28];
       answerbutton[1].GetComponentInChildren<Text>().text=Answers[29];
        answerbutton[2].GetComponentInChildren<Text>().text=Answers[30];
         answerbutton[3].GetComponentInChildren<Text>().text=Answers[31];
          Answers[2]=" Atatürk ";
      }


      if(i==8)
      {
        sorucevap=3;
      answerbutton[0].GetComponentInChildren<Text>().text=Answers[32];
       answerbutton[1].GetComponentInChildren<Text>().text=Answers[33];
        answerbutton[2].GetComponentInChildren<Text>().text=Answers[34];
         answerbutton[3].GetComponentInChildren<Text>().text=Answers[35];
        Answers[3]=" Steve Jobs ";
      }


      if(i==9)
      {
        sorucevap=3;
      answerbutton[0].GetComponentInChildren<Text>().text=Answers[36];
       answerbutton[1].GetComponentInChildren<Text>().text=Answers[37];
        answerbutton[2].GetComponentInChildren<Text>().text=Answers[38];
         answerbutton[3].GetComponentInChildren<Text>().text=Answers[39];
        Answers[3]=" Elon Musk ";
        
      }
       
    answerbutton[sorucevap].GetComponentInChildren<Text>().text=Answers[sorucevap];
    if(i==10)
    {
       PhotonNetwork.LeaveRoom();
       // kazananı göster sonra  load scene at
       
       SceneManager.LoadScene("SampleScene");
       
    }
    // dorğu cevab yerine bir string oluştur ve bu stringden doğru olan şıkkı koy 
    //çift katlı bir matris yap
   // her playerin dokunabildiği tuşlar olucak olay şu şekilde işliyor  4 buton var her oyuncu istediği şıkka tıklıyor 10 saniye sonra şıklak karşılaştırılıyor 
   // 4 buttondan birine tıklanıldığı an bütün butonlar dokunulmaz olur ve dokunulan butonun int değeri karşıdaki oyuncuya aktarılır ve bir sonraki soruya geçilir
   // bütün sorular bittiğinde rakibin puanı  ve senin puanın ekranda gözükür ve odadan atar
   
}
}
