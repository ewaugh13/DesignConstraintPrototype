using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private string ObstacleArea = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // If the player enters a trigger, the player resets
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            // get the current position of the player
            ObstacleArea = this.gameObject.tag;

            if (ObstacleArea.Equals("Area1"))
            {
                // Move the player to area 1 start
            }

            if (ObstacleArea.Equals("Area2"))
            {
                // Move the player to area 1 start
            }

            if (ObstacleArea.Equals("Area3"))
            {
                // Move the player to area 3 start
            }

        }
    }
}
