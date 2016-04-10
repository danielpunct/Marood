using System.Collections;
using UnityEngine;

public class CharacterVisualization : CharacterMonoBehaviour
{
    public int Speed { get; set; }
    public int RotationSpeed { get; set; }
    public static float MinNextTileDist { get; set; }

    Transform myTransform;
    Animator animatorComponent_indicator;
    Animator animatorComponent_model;
    ModelAnimationState modelAnimaitonState;

    internal override void TemplateAfterAwake()
    {
        animatorComponent_indicator = GetComponent<Animator>();
        animatorComponent_model = gameObject.FindComponentInChildWithTag<Animator>("Model");
        myTransform = transform;
        Speed = 4;
        RotationSpeed = 2;
        MinNextTileDist = 0.5f;
        modelAnimaitonState = ModelAnimationState.Idle;
    }
    
    void Update()
    {
        var characterMoveBehaviour = MoveComponent;
        if (!characterMoveBehaviour.IsMoving)
        {
            if (modelAnimaitonState != ModelAnimationState.Idle)
            {
                animatorComponent_model.SetTrigger("Idle");
                modelAnimaitonState = ModelAnimationState.Idle;
            }
            return;
        }
        //if the distance between the character and the center of the next tile is short enough
        var position_plane = characterMoveBehaviour.NextDestination;
        position_plane.y = 0;
        var my_position_plane = transform.position;
        my_position_plane.y = 0;
        if ((position_plane - my_position_plane).magnitude < MinNextTileDist)
        {
            characterMoveBehaviour.MoveDestinationReached();
        }

        MoveTowards(characterMoveBehaviour.NextDestination);
    }

    void MoveTowards(Vector3 position)
    {
        var rotationSpeed = RotationSpeed;
        var speed = Speed;
        Vector3 dir;
        CharacterController CC = GetComponent<CharacterController>();
        Vector3 myPos = CC.GetComponent<Collider>().bounds.center;
        position.y = myPos.y;
        dir = position - myPos;

        // Rotate towards the target
        myTransform.rotation = Quaternion.Lerp(myTransform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);

        // Modify speed so we slow down when we are not facing the target
        Vector3 forwardDir = myTransform.forward;
        //Move Forwards - forwardDir is already normalized
        forwardDir = forwardDir * speed;
        float speedModifier = Vector3.Dot(dir.normalized, myTransform.forward);
        forwardDir *= Mathf.Clamp01(speedModifier);
        float speedModMin = 0.97f;

        if (speedModifier > speedModMin)
        {
            CC.SimpleMove(forwardDir);

            //@#$ test daca deja face miscarea asta
            if (modelAnimaitonState != ModelAnimationState.Move)
            {
                animatorComponent_model.SetTrigger("Move");
                modelAnimaitonState = ModelAnimationState.Move;
            }
        }
    }

    public void SetActiveState()
    {
        animatorComponent_indicator.SetBool("IsActive", true);
    }

    public void SetInactiveState()
    {
        animatorComponent_indicator.SetBool("IsActive", false);
    }

    public void SetTauntState()
    {
        animatorComponent_model.SetTrigger("Taunt");
    }

    public void SetAttackState()
    {
        animatorComponent_model.SetTrigger("Attack");
    }

    public void SetIdleState()
    {
        animatorComponent_model.SetTrigger("Idle");
    }

    public enum ModelAnimationState { Idle, Move }
}
