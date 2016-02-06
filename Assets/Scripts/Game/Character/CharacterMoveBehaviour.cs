﻿using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveBehaviour : MonoBehaviour
{

    CharacterVisualization characterVisualization;

    BoardMovement boardMovement;

    public bool IsMoving { get { return boardMovement.IsMoving; } }
    public Vector3 NextDestination { get { return boardMovement.NextTilePos; } }

    public void MoveDestinationReached()
    {
        boardMovement.CheckPathDestination();
    }

    void Awake()
    {
        boardMovement = new BoardMovement();
        boardMovement.IsMoving = false;
    }

    void Start()
    {
        //all the animations by default should loop
        //GetComponent<Animation>().wrapMode = WrapMode.Loop;
        //caching the transform for better performance
        characterVisualization = GetComponent<CharacterVisualization>();
    }

    public void Init(int x, int y)
    {
        var t = gameObject.transform;
        t.localPosition = GridBoard.Instance.CalcWorldPosFromCoords(x, y);
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
        t.SetParent(GridBoard.Instance.transform);
        gameObject.layer = GridBoard.Instance.gameObject.layer;

        boardMovement.SetOrigin(x, y);
    }
}