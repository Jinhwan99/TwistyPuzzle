using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePuzzle : MonoBehaviour
{
    GameObject point;
    int dropdown_size = 1;
    int dropdown_shape = 2;
    TwistyPuzzle puzzle = null;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        point=GameObject.Find("EmptyObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzle != null)
        {
            //Debug.Log("update");
            if (!(puzzle.runningFlag))
            {
                if (!(puzzle.direction_selected)) puzzle.SetDirection();
                else puzzle.SelectLine();
            }
            else
            {
                puzzle.Rotation();
                //회전이 끝나면 부동소숫점 정리
            }
        }
    }
    public void setSize(int dropdown)
    {
        dropdown_size = dropdown;
    }
    public void setShape(int dropdown)
    {
        dropdown_shape = dropdown;
    }
    
    public void onClick()
    {
        if (dropdown_shape == 0 || dropdown_size == 0)
        {
            Debug.Log("select dropdown");
            return;
        }
        if(puzzle!=null)puzzle.clearPuzzle();


        switch (dropdown_shape)
        {
            case 1:
                puzzle = new Tetrahedron();
                point.transform.eulerAngles=new Vector3(-16.283f,47.447f,-16.984f);
                break;
            case 2:
                puzzle = new Cube();
                point.transform.eulerAngles=Vector3.zero;
                break;
            case 3:
                puzzle = new Octahedron();
                point.transform.eulerAngles=new Vector3(-16.283f,47.447f,-16.984f);

                break;
            case 4:
                puzzle = new Dodecahedron();
                break;
            default:
                break;
        }
        puzzle.shape = dropdown_shape;
        puzzle.size = dropdown_size;
        puzzle.MakeAPuzzle();
        point.transform.localScale=Vector3.one*(dropdown_size/4f);
    }
}
