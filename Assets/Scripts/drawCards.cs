using UnityEngine;

public class drawCards : MonoBehaviour
{
    public GameObject Action1;
    public GameObject Action2;
    public GameObject Action3;
    public GameObject Action4;
    public GameObject Action5;
    public GameObject Action6;
    public GameObject Action7;
    public GameObject PlayerArea;

    public void OnClick()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject card = Instantiate(Action1, new Vector2(0, 0), Quaternion.identity); 
            card.transform.SetParent(PlayerArea.transform, false);
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
