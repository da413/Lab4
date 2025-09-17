using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject player;
    public float baseOrbitSpeed = 0.5f;
    public float orbitSpeedMultiplier = 0.5f;
    private float orbitAngle;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        Vector3 offset = transform.position - player.transform.position;
        orbitAngle = Mathf.Atan2(offset.z, offset.x);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        float orbitSpeed = baseOrbitSpeed + distanceToPlayer * orbitSpeedMultiplier;
        orbitAngle += orbitSpeed * Time.deltaTime;

        Vector3 orbitOffset = new Vector3(Mathf.Cos(orbitAngle), Mathf.Sin(orbitAngle), 0f) * distanceToPlayer;
        transform.position = player.transform.position + orbitOffset;

        float targetAngle = Mathf.Atan2(directionToPlayer.x, directionToPlayer.y) * Mathf.Rad2Deg;
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z += Mathf.DeltaAngle(currentRotation.z, targetAngle - 90f);
        transform.eulerAngles = currentRotation;

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        } else if (whatIHit.tag == "Laser")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().meteorCount++;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
