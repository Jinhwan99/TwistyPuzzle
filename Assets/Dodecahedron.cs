using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodecahedron : TwistyPuzzle
{
    //private static string path = "Object/Dodecahedron/";
    public Dodecahedron(){
        Debug.Log("new dodecahedron");
        shape=2;
        count=0;
    }

    public override void MakeAPuzzle()
    {
        count=0;
        if(size==1){
            Debug.Log("create monododecahedron");
            //PuzzleInit(Vector3.zero);
        }        
    }
    
}
