using UnityEngine;

public interface IDrag
{
    void OnStartDrag();
    void OnEndDrag(Vector3 locationOfObject);
}