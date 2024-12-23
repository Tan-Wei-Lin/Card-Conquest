using UnityEngine;

public class DragDrop : MonoBehaviour
{

    public GameObject Canvas;
    private bool isDragging=false;
    
    void Start()
    {
        Canvas = GameObject.Find("GameCanvas");
    }
    
    public void StartDrag()
    {
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
    }

    
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform,true);
        }
    }
}
