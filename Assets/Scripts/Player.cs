using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;
    private float speed = 6f;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;
    public float shootingCooldown = 1f;
    private bool canShoot = true;
    private InputAction move;

    // Start is called before the first frame update
    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        Vector2 moveValue = move.ReadValue<Vector2>();
        transform.Translate(moveValue * speed * Time.deltaTime);

        if (transform.position.x > horizontalScreenLimit)
        {
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0);
        }
        else if (transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, verticalScreenLimit, 0);
        }
        else if (transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0);
        }

    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Instantiate(laserPrefab, transform.position + Vector3.up, Quaternion.identity);
            canShoot = false;
            StartCoroutine("Cooldown");
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(shootingCooldown);
        canShoot = true;
    }
}
