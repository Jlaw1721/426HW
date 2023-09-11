using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Checkpoint : MonoBehaviour
{
    public int notificationDelay = 2;
    public GameObject player;
    public GameObject notification;
    PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    // Start is called before the first frame update
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if ((player.transform.position.x > transform.position.x) && (model.spawnPoint.position.x != this.transform.position.x))
        {
            model.spawnPoint = this.transform;
            notification.SetActive(true);
            StartCoroutine(CheckpointNotification(notificationDelay));
        }
    }

    IEnumerator CheckpointNotification(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        notification.SetActive(false);
        Destroy(this);
    }
}
