using UnityEngine;

public class RotateTunnel : MonoBehaviour
{

    #region Instance Variables
    [SerializeField]
    [Tooltip("The amount to rotate the tunnel")]
    private Vector3 rotationAmount = Vector3.zero;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).transform.RotateAround(Vector3.zero, Vector3.forward, 1.0f);
        }
        //this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        //this.gameObject.transform.RotateAround(Vector3.zero, Vector3.forward, 1.0f);
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Key Pressed");
        //    this.gameObject.transform.Rotate(rotationAmount, Space.Self);
        //    //this.gameObject.transform.Rotate(this.gameObject.transform.position, 90.0f);
        //}
    }
}
