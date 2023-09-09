using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int coin { get; private set; }
    private GameObject mainCam;
    private bool multiplyCoin = false;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        mainCam = FindObjectOfType<Camera>().gameObject;
    }

    public void AddCoin()
    {
        if (multiplyCoin) coin += 2;
        else coin++;
    }

    public void MultiplyCoin()
    {
        StartCoroutine(MultiplyCoins());
    }

    public void RemoveCoin()
    {
        coin -= 5;
    }

    public void ReverseCamera()
    {
        StartCoroutine(ReverseCameraCoroutine());
    }

    public void Turbo()
    {
        StartCoroutine(TurboCoroutine());
    }

    private IEnumerator TurboCoroutine()
    {
        Time.timeScale = 3f;
        yield return new WaitForSeconds(10f);
        Time.timeScale = 1f;
    }

    private IEnumerator ReverseCameraCoroutine()
    {
        mainCam.transform.Rotate(0, 0, 180);
        yield return new WaitForSeconds(10f);
        mainCam.transform.Rotate(0, 0, 180);
    }

    private IEnumerator MultiplyCoins()
    {
        multiplyCoin = true;
        yield return new WaitForSeconds(5f);
        multiplyCoin = false;
    }

}
