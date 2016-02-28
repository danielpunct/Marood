using UnityEngine;

class GridManager : MonoBehaviour
{
   void Start()
    {
        gameObject.AddComponent<BoardInteractionBehaviour>();
    }
}
