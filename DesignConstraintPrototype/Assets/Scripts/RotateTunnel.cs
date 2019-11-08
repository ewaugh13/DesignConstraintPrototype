using System.Collections;
using UnityEngine;

public class RotateTunnel : MonoBehaviour
{
    #region Instance Variables
    [SerializeField]
    [Tooltip("The amount to rotate left (angles ) the tunnel")]
    private float rotationAmountLeft = 90.0f;
    [SerializeField]
    [Tooltip("The amount to rotate right (angles negative) the tunnel")]
    private float rotationAmountRight = -90.0f;
    [SerializeField]
    [Tooltip("The amount of time it takes to rotate the tunnel (in seconds)")]
    private float timeToRotate = 1.0f;
    [SerializeField]
    [Tooltip("The ball object itself")]
    private GameObject ball = null;
    [SerializeField]
    [Tooltip("The roof of the tunnel")]
    private GameObject roof = null;
    [SerializeField]
    [Tooltip("The floor of the tunnel")]
    private GameObject floor = null;
    #endregion

    #region Hidden Variables
    private Vector3 rotationPoint = Vector3.zero;
    private bool isRotating = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rotationPoint = new Vector3(0.0f,
            Mathf.Abs((roof.transform.localPosition.y - floor.transform.localPosition.y) / 2.0f),
            0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRotating)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                isRotating = true;
                StartCoroutine(RotateTunnelOverTime(timeToRotate, rotationAmountLeft));
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                isRotating = true;
                StartCoroutine(RotateTunnelOverTime(timeToRotate, rotationAmountRight));
            }
        }
    }

    private IEnumerator RotateTunnelOverTime(float timeToRotate, float rotateAmount)
    {
        float currentRotation = this.gameObject.transform.eulerAngles.z;
        float targetRotation = currentRotation + rotateAmount;

        float elapsedTime = 0;
        ball.GetComponent<Rigidbody>().isKinematic = true;
        while (elapsedTime < timeToRotate)
        {
            elapsedTime += Time.deltaTime;
            float zRotationAmount = Mathf.Lerp(currentRotation, targetRotation, elapsedTime / timeToRotate);
            this.gameObject.transform.RotateAround(rotationPoint, Vector3.forward, zRotationAmount - this.gameObject.transform.eulerAngles.z);

            yield return null;
        }
        isRotating = false;
        ball.GetComponent<Rigidbody>().isKinematic = false;
    }
}