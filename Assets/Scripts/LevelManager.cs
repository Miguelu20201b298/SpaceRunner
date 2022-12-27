using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelobj;
    public List<Level> TodosLosNiveles = new List<Level>();
    public List<Level> NivelesActuales = new List<Level>();
    public Transform levelStartPosition;
    private void Awake()
    {
        if (levelobj == null)
        {
            levelobj = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateInitial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddLevel()
    {
        int aleatorio = Random.Range(0, TodosLosNiveles.Count);
        Level nivel;
        Vector3 posicionGenerar = Vector3.zero;
        if(NivelesActuales.Count==0)
        {
            nivel = Instantiate(TodosLosNiveles[0]);
            posicionGenerar = levelStartPosition.position;
        }else
        {
            nivel = Instantiate(TodosLosNiveles[aleatorio]);
            posicionGenerar = NivelesActuales[NivelesActuales.Count - 1].endPoint.position;
        }
        nivel.transform.SetParent(this.transform,false);
        Vector3 correcion = new Vector3(posicionGenerar.x - nivel.startPoint.position.x, posicionGenerar.y - nivel.startPoint.position.y, 0);
        nivel.transform.position = correcion;
        NivelesActuales.Add(nivel);
    }
    public void RemoveLevel()
    {
        Level nivelViejo = NivelesActuales[0];
        NivelesActuales.RemoveAt(0);
        Destroy(nivelViejo.gameObject);
    }

    public void RemoveAllLevels()
    {
        while(NivelesActuales.Count>0)
        {
            RemoveLevel();
        }
    }

    public void GenerateInitial()
    {
        for(int i=0; i<2;i++)
        {
            AddLevel();
        }
    }
}
