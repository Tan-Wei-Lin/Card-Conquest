using UnityEngine;
using Mirror;

public class drawCards : NetworkBehaviour
{
    public PlayerManager PlayerManager;

    public void OnClick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
        PlayerManager.CmdDealCards(); 
    }
    
}
