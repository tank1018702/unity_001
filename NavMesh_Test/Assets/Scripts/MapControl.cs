using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapControl : MonoBehaviour
{
    NavMeshModifier[,] _modifiers;
    NavMeshModifier[] modifierlist;

    //public NavMeshSurface surface;
   



    void Start()
    {
         
        _modifiers = new NavMeshModifier[10, 10];
        modifierlist = transform.GetComponentsInChildren<NavMeshModifier>();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _modifiers[i, j] = modifierlist[i * 10 + j];
            }
        }
        PathInit();
        //surface.BuildNavMesh();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PathInit();
            PathGeneration();
            
        }
    }
    void PathInit()
    {
        for (int i = 0; i < modifierlist.Length; i++)
        {
            modifierlist[i].area = 3;
        }
    }

    void PathGeneration()
    {
        int r = Random.Range(0, 10);
        for (int i = 0; i < 10; i++)
        {
            DirectionChoice(i, ref r);
        }
        //surface.BuildNavMesh();
    }

    void DirectionChoice(int rows, ref int columns)
    {
        int r = Random.Range(0, 3);
        _modifiers[rows, columns].area = 0;
        switch (r)
        {
            case 0:
                //下
                break;
            case 1:
                //左           
                int r1 = -1;
                while (r1 != 0)
                {
                    r1 = Random.Range(0, 2);
                    //columns = columns > 0 ? columns - 1 : 0;
                    columns = Mathf.Max(columns - 1, 0);
                    _modifiers[rows, columns].area = 0;
                }
                break;
            case 2:
                //右
                int r2 = -1;
                while(r2 !=0)
                {
                    r2 = Random.Range(0, 2);
                    //columns = columns < 9 ? columns + 1 : 9;
                    columns = Mathf.Min(columns+1, 9);
                    _modifiers[rows, columns].area = 0;
                }
                break;
        }
    }
}
