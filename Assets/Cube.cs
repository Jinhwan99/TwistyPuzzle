using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

static class Cube_Rotation_Axis
{
    public static Vector3 right = Vector3.down;
    public static Vector3 left = Vector3.up;
    public static Vector3 up = Vector3.right;
    public static Vector3 down = Vector3.left;
    public static Vector3 cw = Vector3.back;
    public static Vector3 ccw = Vector3.forward;
}
static class Cube_Axis_Direction
{
    public static Vector3 VERTICAL = Vector3.right;
    public static Vector3 HORIZONTAL = Vector3.up;
    public static Vector3 PARALLEL = Vector3.back;
}
public class Cube : TwistyPuzzle
{
    private static string path = "Object/Cube/";
    float border;
    Vector3 plane;

    public Cube()
    {
        Debug.Log("new cube");
        shape = 2;
        count = 0;
        rightAngle = 90f;

    }
    public override void MakeAPuzzle()
    {

        if (size == 1)
        {
            PuzzleInit(Vector3.zero, path + "bgorwy");
        }
        else
        {
            border = (float)Math.Round((size / 2.0f - 0.5f), 2);

            MakeCorner();
            if (size > 2)
            {
                MakeEdge();
                MakeCenter();
            }
        }
    }
    private void MakeCorner()
    {
        PuzzleInit(new Vector3(border, border, border), path + "bow");
        PuzzleInit(new Vector3(border, -border, border), path + "boy");
        PuzzleInit(new Vector3(border, border, -border), path + "brw");
        PuzzleInit(new Vector3(border, -border, -border), path + "bry");
        PuzzleInit(new Vector3(-border, border, border), path + "gow");
        PuzzleInit(new Vector3(-border, -border, border), path + "goy");
        PuzzleInit(new Vector3(-border, border, -border), path + "grw");
        PuzzleInit(new Vector3(-border, -border, -border), path + "gry");
    }
    private void MakeEdge()
    {
        for (int i = 1; i < size - 1; i++)
        {
            PuzzleInit(new Vector3(border, i - border, border), path + "bo");
            PuzzleInit(new Vector3(border, i - border, -border), path + "br");
            PuzzleInit(new Vector3(border, border, i - border), path + "bw");
            PuzzleInit(new Vector3(border, -border, i - border), path + "by");
            PuzzleInit(new Vector3(-border, i - border, border), path + "go");
            PuzzleInit(new Vector3(-border, i - border, -border), path + "gr");
            PuzzleInit(new Vector3(-border, border, i - border), path + "gw");
            PuzzleInit(new Vector3(-border, -border, i - border), path + "gy");
            PuzzleInit(new Vector3(i - border, border, border), path + "ow");
            PuzzleInit(new Vector3(i - border, -border, border), path + "oy");
            PuzzleInit(new Vector3(i - border, border, -border), path + "rw");
            PuzzleInit(new Vector3(i - border, -border, -border), path + "ry");

        }

    }
    private void MakeCenter()
    {
        for (int j = 1; j < size - 1; j++)
        {
            for (int k = 1; k < size - 1; k++)
            {
                PuzzleInit(new Vector3(border, j - border, k - border), path + 'b');
                PuzzleInit(new Vector3(-border, j - border, k - border), path + 'g');
                PuzzleInit(new Vector3(j - border, border, k - border), path + 'w');
                PuzzleInit(new Vector3(j - border, -border, k - border), path + 'y');
                PuzzleInit(new Vector3(j - border, k - border, border), path + 'o');
                PuzzleInit(new Vector3(j - border, k - border, -border), path + 'r');
            }
        }

    }
    public override void SetDirection()
    {
        Debug.Log("Set direction");
        if (Input.GetKeyDown(KeyCode.D))
        {
            Rotation_Axis = Cube_Rotation_Axis.right;
            Rotation_Sign = Cube_Axis_Direction.HORIZONTAL;
            Debug.Log("right");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Rotation_Axis = Cube_Rotation_Axis.left;
            Rotation_Sign = Cube_Axis_Direction.HORIZONTAL;
            Debug.Log("left");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Rotation_Axis = Cube_Rotation_Axis.up;
            Rotation_Sign = Cube_Axis_Direction.VERTICAL;
            Debug.Log("up");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Rotation_Axis = Cube_Rotation_Axis.down;
            Rotation_Sign = Cube_Axis_Direction.VERTICAL;
            Debug.Log("down");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Rotation_Axis = Cube_Rotation_Axis.cw;
            Rotation_Sign = Cube_Axis_Direction.PARALLEL;
            Debug.Log("clockwise");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Rotation_Axis = Cube_Rotation_Axis.ccw;
            Rotation_Sign = Cube_Axis_Direction.PARALLEL;
            Debug.Log("counterclockwise");
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
                    LinePuzzle = UnionPuzzle.FindAll(x => Math.Abs(border - i - Vector3.Dot(x.transform.position, Rotation_Sign)) < float.Epsilon);
                    Debug.Log("selecte" + (1 + i));
                    break;
                }
            }
        }
        if (LinePuzzle != null) runningFlag = true;
    }

}
