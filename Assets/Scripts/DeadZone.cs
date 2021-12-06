using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    GameObject spawnPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.damaged();
            }

            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null)
            {
                controller.enabled = false;
            }

            other.transform.position = spawnPosition.transform.position;

            StartCoroutine(enableController(controller));
        }
    }

    IEnumerator enableController(CharacterController controller)
    {
        yield return new WaitForSeconds(0.1f);
        controller.enabled = true;
    }
}
