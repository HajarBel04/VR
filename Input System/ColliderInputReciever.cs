using UnityEngine;

public class ColliderInputReciever : InputReciever
{
    private Vector3 clickPosition;

    private void Update() 
    {   
        if (Input.GetMouseButtonDown(0))
        {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            clickPosition = hit.point;
            // Debug.Log($"Hit {hit.collider.gameObject.name} at {clickPosition}");
            OnInputRecieved();
        }
        }
    }

    public override void OnInputRecieved()
    {
        foreach (var handler in inputHandlers)
        {
            handler.ProcessInput(clickPosition, null, null);
        }
    }
}
