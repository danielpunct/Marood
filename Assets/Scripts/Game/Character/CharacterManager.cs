using UnityEngine;

class CharacterManager : MonoBehaviour
{
    CharacterMoveBehaviour characterMoveBehaviour;

    void Awake()
    {
        characterMoveBehaviour = gameObject.AddComponent<CharacterMoveBehaviour>();
        gameObject.AddComponent<CharacterVisualization>();
    }

    public void Init(Tile originTile)
    {
        characterMoveBehaviour.Init(originTile.Location.X, originTile.Location.Y);
    }
}
