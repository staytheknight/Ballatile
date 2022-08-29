using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject warningSymbol;
    public GameObject anchor;

    public bool isInvert;
    public float velocity = 30f;
    public int spawnTimer = 5;
    public int spawnRepeat = 5;

    


    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("WarningSymbol", spawnTimer-1, spawnRepeat);

        // Supposed to invoke blink
        // I DON'T THINK THIS WORKS
        InvokeRepeating("Blink", 0, 0.2f);
    }

    // Update is called once per frame
    void Rotate()
    {
        if (!isInvert)
        {
            transform.RotateAround(anchor.transform.position, Vector3.forward, Time.deltaTime * velocity);
        }
        else
        {
            transform.RotateAround(anchor.transform.position, Vector3.forward, Time.deltaTime * -velocity);
        }
    }

    // Instatiates a new warning symbol sprite and then destroys it shortly after
    void WarningSymbol()
    {
        Vector3 spawnerPos = transform.position;
        GameObject warningInst = Instantiate(warningSymbol, spawnerPos, Quaternion.identity);
        Destroy(warningInst, 0.75f);
    }

    // Supposed to turn the renderer for the warning symbol on and off for a blink
    // I DON'T THINK THIS WORKS
    IEnumerator Blink()
    {
        Renderer warningSprite = warningSymbol.GetComponent<Renderer>();

        warningSprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        warningSprite.enabled = true;
    }

    // Constantly rotates the spawner
    private void Update()
    {
        Rotate();
    }
}
