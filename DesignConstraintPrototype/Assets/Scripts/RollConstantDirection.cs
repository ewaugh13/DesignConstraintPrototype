using UnityEngine;

public enum Direction
{
    Forward, Right, Back, Left
};

public class RollConstantDirection : MonoBehaviour
{
    #region Instance Variables
    [Tooltip("Direction the ball rolls in")]
    [SerializeField]
    private Direction direction = Direction.Forward;
    [Tooltip("Movement speed of ball")]
    [SerializeField]
    private float movementSpeed = 2.0f;
    [Tooltip("Rotation speed of ball")]
    [SerializeField]
    private float rotationSpeed = 10.0f;
    #endregion

    #region Hidden Variables
    private Vector3 objectMovementDirection;
    private Vector3 objectMovementRotation;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        switch (direction)
        {
            case Direction.Forward:
                objectMovementDirection = Vector3.forward;
                objectMovementRotation = Vector3.right;
                break;
            case Direction.Right:
                objectMovementDirection = Vector3.right;
                objectMovementRotation = Vector3.back;
                break;
            case Direction.Back:
                objectMovementDirection = Vector3.back;
                objectMovementRotation = Vector3.left;
                break;
            case Direction.Left:
                objectMovementDirection = Vector3.left;
                objectMovementRotation = Vector3.forward;
                break;
            default:
                objectMovementDirection = Vector3.forward;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += (objectMovementDirection * Time.deltaTime * movementSpeed);
        // TODO use quaternions
        this.gameObject.transform.eulerAngles += (objectMovementRotation * Time.deltaTime * rotationSpeed);
    }
}
