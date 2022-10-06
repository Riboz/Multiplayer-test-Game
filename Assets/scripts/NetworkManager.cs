using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public InputField Joinname,createname,yourname;
    public GameObject Joinpanel,Waitingpanel,gamepanel;
    public GameObject player1;
    public Text vs;
    public string kurucu,giren;
IEnumerator looks()
{
    yield return new WaitForSeconds(2f);
     if(PhotonNetwork.InRoom)
    {
        Joinpanel.SetActive(false);
        if(GetComponent<PhotonView>().IsMine)
        {
         Waitingpanel.SetActive(true);  
        }
      
    }
}
    public void CreateButton()
    {
    PhotonNetwork.JoinOrCreateRoom(createname.text,new RoomOptions{MaxPlayers=2,IsOpen=true,IsVisible=true},TypedLobby.Default);
    StartCoroutine(looks());
    isim=true;
    
   
    // butona tıklamada if ismine larım sonra istediğimb utona tıklayınca rpc ile tıklanılan butonu gönderir sonra hangisi doğru kararıın alırım.

    // panel acilsin
    }
    public bool isim=true;
    public void joinroom()
    {
       PhotonNetwork.JoinRoom(Joinname.text);
       StartCoroutine(isi());
      StartCoroutine(looks());
      
        giren=yourname.text;
        isim=false;
    }
    public void RandomRoomJoin()
    {
        PhotonNetwork.JoinRandomRoom();
         StartCoroutine(isi());
         StartCoroutine(looks());
    }
    public void LeaveRoom()
    {
     PhotonNetwork.LeaveRoom();
      Joinpanel.SetActive(true);
      gamepanel.SetActive(false);
        Waitingpanel.SetActive(false);
        count=0;
        gamestart=true;
        
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        
        
    }
   [PunRPC]
    public void controlplayer(int isin)
    {
      count+=isin;
      Debug.Log(count);
    
    }
public override void OnConnectedToMaster()
{

    PhotonNetwork.JoinLobby();
}
    // Update is called once per frame
    public override void OnJoinedRoom()
    {
      
   
    player1.SetActive(true);
   

      
        GetComponent<PhotonView>().RPC("controlplayer",RpcTarget.All,1);
      if(!isim){GetComponent<PhotonView>().RPC("ala",RpcTarget.All,giren);}
          
     
    }
      [PunRPC]
    void ala(string a)
    {
        if(GetComponent<PhotonView>().IsMine)
        {
           girent.text="The player who name is ("+a+") joined the game";
        }     
    }
        
  
    public Text kurucut,girent;
    
    bool gamestart=true;
   int count=0;
    
    public IEnumerator isi()
    {
       yield return new WaitForSeconds(1f);
        if(PhotonNetwork.InRoom==true){count+=1;}
        yield break;
    }
    public IEnumerator gameui()
    {
        // bekleme panelin textine yeni gelen oyuncu ismi yazılsın
        yield return new WaitForSeconds(2f);
        // bekleme panel kapansın
        Waitingpanel.SetActive(false);
         gamepanel.SetActive(true);
        
        //oyun panel açılsın
        while(gamestart)
        {
            yield return new WaitForSeconds(0.2f);
        }


    }
    
    void FixedUpdate()
    {
        
        if(count==2)
        {
            
              StartCoroutine(gameui());
           Debug.Log("calisiyor");
          
            count+=1;

        }
    }
}
