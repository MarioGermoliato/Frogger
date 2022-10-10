using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public int direcaoCarro;
    public int velocidade;

    private void Start()
    {
        StartCoroutine("DestroyCar");
    }

    private void Update()
    {
        AcelerarCarro();

    }


    private void AcelerarCarro()
    {
        transform.Translate(Vector3.right * direcaoCarro * velocidade * Time.deltaTime);
    }

    IEnumerator DestroyCar()
    {
        yield return new WaitForSeconds(15);

        Destroy(gameObject);
    }
}