using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsController : MonoBehaviour
{
    [SerializeField] private Transform[] pointsDireita;
    [SerializeField] private Transform[] pointsEsquerda;
    [SerializeField] private int maxVelocididade;
    [SerializeField] private int minVelocidade;
    [SerializeField] private Transform[] carros;


    private void Start()
    {
        StartCoroutine("AbriuFarol");
        StartCoroutine("CDCarro");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            InstanciarCarro();
        }
    }


    private void InstanciarCarro()
    {
        int sorteio = Random.Range(0, 10);
        if (sorteio > 5)
        {
            Transform novoCarro = Instantiate(carros[Random.Range(0, carros.Length)], pointsDireita[Random.Range(0, pointsDireita.Length)].position, Quaternion.identity);
            novoCarro.GetComponent<Car>().direcaoCarro = -1;
            novoCarro.GetComponent<Car>().velocidade = Random.Range(minVelocidade, maxVelocididade);
        }
        else
        {
            Transform novoCarro = Instantiate(carros[Random.Range(0, carros.Length)], pointsEsquerda[Random.Range(0, pointsEsquerda.Length)].position, Quaternion.identity);
            novoCarro.GetComponent<Car>().direcaoCarro = 1;
            novoCarro.GetComponent<Car>().velocidade = Random.Range(1, maxVelocididade);
        }
    }

    private IEnumerator CDCarro()
    {
        InstanciarCarro();
        yield return new WaitForSeconds(Random.Range(0, 3));
        StartCoroutine("CDCarro");
    }

    private IEnumerator AbriuFarol()
    {
        for (int a = 0; a < 8; a++)
        {
            InstanciarCarro();
        }
        yield return new WaitForSeconds(Random.Range(4, 8));
        StartCoroutine("AbriuFarol");
    }
}
