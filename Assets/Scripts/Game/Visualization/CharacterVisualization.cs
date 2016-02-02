using UnityEngine;

class CharacterVisualization : MonoBehaviour
{
    public int Speed { get; set; }
    public int RotationSpeed { get; set; }
    public static float MinNextTileDist { get; set; }

CharacterMoveBehaviour characterMoveBehaviour;
    Transform myTransform;

    void Awake()
    {
        myTransform = transform;
        Speed = 15;
        RotationSpeed = 2;
        MinNextTileDist = 0.1f;
    }

    void Start()
    {
        characterMoveBehaviour = GetComponent<CharacterMoveBehaviour>();
    }

    void Update()
    {
        if (!characterMoveBehaviour.IsMoving)
            return;
        //if the distance between the character and the center of the next tile is short enough
        var position_plane = characterMoveBehaviour.NextTilePos;
        position_plane.y = 0;
        var my_position_plane = transform.position;
        my_position_plane.y = 0;
        if ((position_plane - my_position_plane).sqrMagnitude < MinNextTileDist * MinNextTileDist)
        {
            if(characterMoveBehaviour.CheckDestination())
            {
                return;
            }
        }

        MoveTowards(characterMoveBehaviour.NextTilePos);
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
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);

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
            //if (!monster && !GetComponent<Animation>()["walk"].enabled)
            //    GetComponent<Animation>().CrossFade("walk");
            //else if (monster && !GetComponent<Animation>()["CreepFem"].enabled)
            //    GetComponent<Animation>().CrossFade("CreepFem");
        }
        //else if (!monster && !GetComponent<Animation>()["idle"].enabled)
        //    GetComponent<Animation>().CrossFade("idle");
        //else if (monster && !GetComponent<Animation>()["IdleFeM"].enabled)
        //    GetComponent<Animation>().CrossFade("IdleFeM");
    }

}
