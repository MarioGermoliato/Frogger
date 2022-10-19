using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{
    [SerializeField] private int velocidadeFrog;
    [SerializeField] private Vector3 target;

    private void Start()
    {
        target = transform.position;
    }

    private void Update()
    {
        MovimentoSapo();

        if (transform.position.y >= 5.4f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void MovimentoSapo()
    {        
        transform.position = Vector3.MoveTowards(transform.position, target, velocidadeFrog * Time.deltaTime);

        if (transform.position != target)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            target += Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            target += Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            target += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            target += Vector3.left;
        }

        if (transform.position == target)
        {
            target = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
