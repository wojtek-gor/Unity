using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Lab4Zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int ile = 10;
    public List<Material> materials = new List<Material>();
    // obiekt do generowania
    public GameObject block;
    Vector3 min, max;

    void Start()
    {
        Collider colider = GetComponent<Collider>();
        max = colider.bounds.max;
        min = colider.bounds.min;
        UnityEngine.Debug.Log(max.x);
        UnityEngine.Debug.Log(min.x);
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)min.x+1, (int)max.x-1).OrderBy(x => System.Guid.NewGuid()).Take(ile));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)min.z+1, (int)max.z-1).OrderBy(x => System.Guid.NewGuid()).Take(ile));

        for (int i = 0; i < ile; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            UnityEngine.Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        UnityEngine.Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            
            var blok = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            var kolor = blok.GetComponent<Renderer>();
            int rozmiar = this.materials.Count;
            UnityEngine.Debug.Log(rozmiar);
            var barwa = this.materials[Random.Range(0, rozmiar)];
            kolor.material.SetColor("_Color", barwa.color);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}