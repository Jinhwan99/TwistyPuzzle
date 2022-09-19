using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
static class Octahedron_Axis_direction{

}
public class Octahedron : TwistyPuzzle
{
    private static string path = "Object/Octahedron/";
    public Octahedron(){
        Debug.Log("new octahedron");
        shape=3;
        count=0;
        rightAngle=120f;
    }
    public override void SetDirection()
    {
        Debug.Log("Set direction");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //NW ccw
            Rotation_Axis=new Vector3(-1f,1f,-1f);
            Rotation_Sign=Rotation_Axis;

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            //NW cw
            Rotation_Axis=new Vector3(1f,-1f,1f);
            Rotation_Sign=-1*Rotation_Axis;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            //NE ccw
            Rotation_Axis=new Vector3(1f,1f,-1f);
            Rotation_Sign=Rotation_Axis;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            //NE cw
            Rotation_Axis=new Vector3(-1f,-1f,1f);
            Rotation_Sign=-1*Rotation_Axis;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //SW cw
            Rotation_Axis=new Vector3(1f,1f,1f);
            Rotation_Sign=-1*Rotation_Axis;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //SW ccw
            Rotation_Axis=new Vector3(-1f,-1f,-1f);
            Rotation_Sign=Rotation_Axis;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //SE cw
            Rotation_Axis=new Vector3(-1f,1f,1f);
            Rotation_Sign=-1*Rotation_Axis;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            //SE ccw
            Rotation_Axis=new Vector3(1f,-1f,-1f);
            Rotation_Sign=Rotation_Axis;
        }

        if (Rotation_Sign != Vector3.zero) direction_selected = true;
    }
    public override void SelectLine()
    {
        Debug.Log("Select line");
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            LinePuzzle = UnionPuzzle;
            Debug.Log("selecte total");
        }
        else
        {
            for (int i = 0; i < size; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    LinePuzzle = UnionPuzzle.FindAll(_ =>
                    {
                        float dot = Vector3.Dot(_.transform.position, Rotation_Sign);
                        if (Math.Abs(dot - (size-1-2*i)) < FLOAT_EPSLION || Math.Abs(dot - (size-1.5f-2f*i)) < FLOAT_EPSLION|| Math.Abs(dot - (size-0.5f-2f*i)) < FLOAT_EPSLION) {
                            //_.transform.localScale=_.transform.lossyScale*0.5f;
                            return true;
                        }
                        //if(i==0||i==size-1)
                        else return false;
                    });

                    Debug.Log("selecte" + (1 + i));
                    break;
                }
            }
        }
        if (LinePuzzle != null) runningFlag = true;
    }
    public override void MakeAPuzzle()
    {
        count=0;
        if(size==1){
            Debug.Log("create monooctahedron");
            PuzzleInit(Vector3.zero,path+"o_full");
        }
        else{
            MakeCorner();
            MakeEdge();
            MakeCenter();
        }

    }
    private void MakeCorner(){
        PuzzleInit(Vector3.right*(size-1),path+"right");
        PuzzleInit(Vector3.left*(size-1),path+"left");
        PuzzleInit(Vector3.up*(size-1),path+"up");
        PuzzleInit(Vector3.down*(size-1),path+"down");
        PuzzleInit(Vector3.forward*(size-1),path+"back");
        PuzzleInit(Vector3.back*(size-1),path+"forward");
    }
    private void MakeEdge(){
        for(int i=1;i<=size-2;i++){
            PuzzleInit(new Vector3(i,size-1-i,0),path+"ru");
            PuzzleInit(new Vector3(-i,size-1-i,0),path+"lu");
            PuzzleInit(new Vector3(i,-(size-1-i),0),path+"rd");
            PuzzleInit(new Vector3(-i,-(size-1-i),0),path+"ld");
            PuzzleInit(new Vector3(0,i,size-1-i),path+"bu");
            PuzzleInit(new Vector3(0,-i,size-1-i),path+"bd");
            PuzzleInit(new Vector3(0,i,-(size-1-i)),path+"fu");
            PuzzleInit(new Vector3(0,-i,-(size-1-i)),path+"fd");
            PuzzleInit(new Vector3(i,0,size-1-i),path+"br");
            PuzzleInit(new Vector3(-i,0,size-1-i),path+"bl");
            PuzzleInit(new Vector3(i,0,-(size-1-i)),path+"fr");
            PuzzleInit(new Vector3(-i,0,-(size-1-i)),path+"fl");

        }
    }
    private void MakeCenter(){
        for(int a=1;a<=size-3;a++){
            for(int b=1;b<=size-2-a;b++){
                int c=size-1-a-b;
                PuzzleInit(new Vector3(a,b,c),path+"o_yellow");
                PuzzleInit(new Vector3(a,b,-c),path+"o_red");
                PuzzleInit(new Vector3(a,-b,c),path+"o_orange");
                PuzzleInit(new Vector3(a,-b,-c),path+"o_purple");
                PuzzleInit(new Vector3(-a,b,c),path+"o_gray");
                PuzzleInit(new Vector3(-a,b,-c),path+"o_green");
                PuzzleInit(new Vector3(-a,-b,c),path+"o_blue");
                PuzzleInit(new Vector3(-a,-b,-c),path+"o_white");
            }
        }
        for(int a=0;a<size-1;a++){
            for(int b=0;b<size-1-a;b++){
                int c=size-2-a-b;
                PuzzleInit(new Vector3((a+0.5f),(b+0.5f),(c+0.5f)),path+"t_yellow");
                PuzzleInit(new Vector3((a+0.5f),(b+0.5f),-(c+0.5f)),path+"t_red");
                PuzzleInit(new Vector3((a+0.5f),-(b+0.5f),(c+0.5f)),path+"t_orange");
                PuzzleInit(new Vector3((a+0.5f),-(b+0.5f),-(c+0.5f)),path+"t_purple");
                PuzzleInit(new Vector3(-(a+0.5f),(b+0.5f),(c+0.5f)),path+"t_gray");
                PuzzleInit(new Vector3(-(a+0.5f),(b+0.5f),-(c+0.5f)),path+"t_green");
                PuzzleInit(new Vector3(-(a+0.5f),-(b+0.5f),(c+0.5f)),path+"t_blue");
                PuzzleInit(new Vector3(-(a+0.5f),-(b+0.5f),-(c+0.5f)),path+"t_white");
            }
        }
    }
}
