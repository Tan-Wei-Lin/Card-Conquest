using UnityEngine;
using System.Collections.Generic;
using Mirror; 

public class PlayerManager : NetworkBehaviour
{
    public GameObject Action1;
    public GameObject Action2;
    public GameObject Action3;
    public GameObject Action4;
    public GameObject Action5;
    public GameObject Action6;
    public GameObject Action7;
    public GameObject PlayerArea;
    public GameObject EnemyArea;

    List<GameObject> cards  = new List<GameObject>();

    public override void OnStartClient()
    {
        base.OnStartClient();

        PlayerArea = GameObject.Find("PlayerArea");
        EnemyArea = GameObject.Find("EnemyArea");
    }

    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();

        cards.Add(Action1);
        cards.Add(Action2); 
        cards.Add(Action3);
        cards.Add(Action4);
        cards.Add(Action5);
        cards.Add(Action6);
        cards.Add(Action7);
    }

    [Command]
    public void CmdDealCards()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject card = Instantiate(cards[Random.Range(0,cards.Count)], new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(card, connectionToClient);
            RpcShowCard(card, "Dealt");
        }
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, string type)
    {
        if(type == "Dealt")
        {
            if (isOwned)
            {
                card.transform.SetParent(PlayerArea.transform, false);
            }
            else
            {
                card.transform.SetParent(EnemyArea.transform, false);
                card.GetComponent<CardFlipper>().Flip();
            }
        }
        else if(type == "Played")
        {

        }
    }
}
