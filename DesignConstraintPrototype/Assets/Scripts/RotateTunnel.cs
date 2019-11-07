using System.Collections;
using UnityEngine;

public class RotateTunnel : MonoBehaviour
{
    #region Instance Variables
    [SerializeField]
    [Tooltip("The amount to rotate (angles) the tunnel")]
    private float rotationAmount = 90.0f;
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
        //this.gameObject.transform.RotateAround(Vector3.zero, Vector3.forward, 1.0f);
        if (Input.GetKeyDown(KeyCode.Space) && !isRotating)
        {
            isRotating = true;
            StartCoroutine(RotateTunnelOverTime(timeToRotate));
            //this.gameObject.transform.RotateAround(rotationPoint, Vector3.forward, rotationAmount);
            //this.gameObject.transform.Rotate(0, 0, 90.0f);

            //for (int i = 0; i < this.gameObject.transform.childCount; i++)
            //{
            //    this.gameObject.transform.GetChild(i).transform.RotateAround(Vector3.zero, Vector3.forward, rotationAmount);
            //}
        }
    }

    private IEnumerator RotateTunnelOverTime(float timeToRotate)
    {
        float currentRotation = this.gameObject.transform.eulerAngles.z;
        float targetRotation = currentRotation + rotationAmount;

        float elapsedTime = 0;
        ball.GetComponent<Rigidbody>().isKinematic = true;
        while (elapsedTime < timeToRotate)
        {
            elapsedTime += Time.deltaTime;
            float zRotationAmount = Mathf.Lerp(currentRotation, targetRotation, elapsedTime / timeToRotate);
            this.gameObject.transform.RotateAround(rotationPoint, Vector3.forward, Mathf.Abs(zRotationAmount - this.gameObject.transform.eulerAngles.z));

            yield return null;
        }
        isRotating = false;
        ball.GetComponent<Rigidbody>().isKinematic = false;
    }
}
