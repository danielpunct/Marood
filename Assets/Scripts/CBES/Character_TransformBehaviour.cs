
using Slash.Unity.Common.ECS;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character_TransformBehaviour : EntityComponentBehaviour<TransformComponent>
{
    #region Methods
    public float rotationSpeed = 7;
    public float speed = 7;
    private CharacterController controller;

    protected override void OnStart()
    {
        controller = this.GetComponent<CharacterController>();
    }

    protected void Update()
    {
        if (this.Component != null)
        {
            // Update transform.
            //this.transform.position = this.Component.Position.ToVector3XY();
            MoveTowards(this.Component.Destination);
        }
    }

    void MoveTowards(Vector3 position)
    {
        //mevement direction
        var position_plane = position; 
        var my_position_plane = transform.position; my_position_plane.y = 0;
        Vector3 dir = position_plane - my_position_plane;

        // Rotate towards the target
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);

        Vector3 forwardDir = transform.forward;
        forwardDir = forwardDir * speed;
        float speedModifier = Vector3.Dot(dir.normalized, transform.forward);
        forwardDir *= speedModifier;
        if (speedModifier > 0.195f)
        {
            controller.SimpleMove(forwardDir);
            //if (!GetComponent<Animation>()["walk"].enabled)
            //    GetComponent<Animation>().CrossFade("walk");
        }
        //else if (!GetComponent<Animation>()["idle"].enabled)
        //    GetComponent<Animation>().CrossFade("idle");
    }

    #endregion
}