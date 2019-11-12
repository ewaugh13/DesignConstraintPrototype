using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateAndMoveALittle : MonoBehaviour
{
    public GameObject copyGameObject;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newGameObject = Instantiate(copyGameObject);
        Vector3 newPosition = copyGameObject.transform.position;
        newGameObject.transform.position = newPosition + (new Vector3(5, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
