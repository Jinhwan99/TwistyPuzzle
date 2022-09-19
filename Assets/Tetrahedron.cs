using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
static class Tetrahedron_Axis_Direction
{
    public static Vector3 none = Vector3.zero;
    public static Vector3 right = new Vector3(Mathf.Sqrt(2f / 3), -Mathf.Sqrt(2f / 9), 1f / 3);
    public static Vector3 left = new Vector3(-Mathf.Sqrt(2f / 3), -Mathf.Sqrt(2f / 9), 1f / 3);
    public static Vector3 up = Vector3.back;
    public static Vector3 back = new Vector3(0, Mathf.Sqrt(8f / 9), 1f / 3);
}
static class Tetrahedron_Rotation_Axis
{

}
public class Tetrahedron : TwistyPuzzle
{
    private static string path = "Object/Tetrahedron/";

    public Tetrahedron()
    {
        Debug.Log("new tetrahedron");
        shape = 1;
        count = 0;
        rightAngle = 120f;
    }

    public override void MakeAPuzzle()
    {
        if (size == 1)
        {
            PuzzleInit(Vector3.zero, path + "t_bgry");
        }
        else if (size == 2)
        {
            PuzzleInit(Vector3.zero, path + "o_bgry");
            PuzzleInit(Tetrahedron_Axis_Direction.up, path + "t_bry");
            PuzzleInit(Tetrahedron_Axis_Direction.right, path + "t_gry");
            PuzzleInit(Tetrahedron_Axis_Direction.left, path + "t_bgy");
            PuzzleInit(Tetrahedron_Axis_Direction.back, path + "t_bgr");
        }
        else
        {
            MakeCorner();
            MakeEdge();
            MakeCenter();
        }
    }
    private void MakeCorner()
    {
        PuzzleInit(Tetrahedron_Axis_Direction.up * (size - 1), path + "t_bry");
        PuzzleInit(Tetrahedron_Axis_Direction.right * (size - 1), path + "t_gry");
        PuzzleInit(Tetrahedron_Axis_Direction.left * (size - 1), path + "t_bgy");
        PuzzleInit(Tetrahedron_Axis_Direction.back * (size - 1), path + "t_bgr");
        PuzzleInit(Tetrahedron_Axis_Direction.up * (size - 2), path + "o_bry");
        PuzzleInit(Tetrahedron_Axis_Direction.right * (size - 2), path + "o_gry");
        PuzzleInit(Tetrahedron_Axis_Direction.left * (size - 2), path + "o_bgy");
        PuzzleInit(Tetrahedron_Axis_Direction.back * (size - 2), path + "o_bgr");
    }
    private void MakeEdge()
    {
        for (int i = 1; i < size - 1; i++)
        {
            PuzzleInit(Tetrahedron_Axis_Direction.up * (size - 1 - i) + Tetrahedron_Axis_Direction.right * (i), path + "t_ry");
            PuzzleInit(Tetrahedron_Axis_Direction.up * (size - 1 - i) + Tetrahedron_Axis_Direction.left * (i), path + "t_by");
            PuzzleInit(Tetrahedron_Axis_Direction.up * (size - 1 - i) + Tetrahedron_Axis_Direction.back * (i), path + "t_br");
            PuzzleInit(Tetrahedron_Axis_Direction.right * (size - 1 - i) + Tetrahedron_Axis_Direction.left * (i), path + "t_gy");
            PuzzleInit(Tetrahedron_Axis_Direction.right * (size - 1 - i) + Tetrahedron_Axis_Direction.back * (i), path + "t_gr");
            PuzzleInit(Tetrahedron_Axis_Direction.left * (size - 1 - i) + Tetrahedron_Axis_Direction.back * (i), path + "t_bg");
        }
        for (int i = 1; i < size - 2; i++)
        {
            PuzzleInit(Tetrahedron_Axis_Direction.up * (size - 2 - i) + Tetrahedron_Axis_Direction.right * (i), path + "o_ry");
            PuzzleInit(Tetrahedron_Axis_Direction.up * (size - 2 - i) + Tetrahedron_Axis_Direction.left * (i), path + "o_by");
            PuzzleInit(Tetrahedron_Axis_Direction.up * (size - 2 - i) + Tetrahedron_Axis_Direction.back * (i), path + "o_br");
            PuzzleInit(Tetrahedron_Axis_Direction.right * (size - 2 - i) + Tetrahedron_Axis_Direction.left * (i), path + "o_gy");
            PuzzleInit(Tetrahedron_Axis_Direction.right * (size - 2 - i) + Tetrahedron_Axis_Direction.back * (i), path + "o_gr");
            PuzzleInit(Tetrahedron_Axis_Direction.left * (size - 2 - i) + Tetrahedron_Axis_Direction.back * (i), path + "o_bg");
        }
    }
    private void MakeCenter()
    {
        int a, b, c;
        for (a = 1; a <= size - 3; a++)
        {
            for (b = 1; b <= size - 2 - a; b++)
            {
                c = size - 1 - a - b;
                PuzzleInit(Tetrahedron_Axis_Direction.up * a + Tetrahedron_Axis_Direction.right * b + Tetrahedron_Axis_Direction.back * c, path + "t_r");
                PuzzleInit(Tetrahedron_Axis_Direction.up * a + Tetrahedron_Axis_Direction.left * b + Tetrahedron_Axis_Direction.back * c, path + "t_b");
                PuzzleInit(Tetrahedron_Axis_Direction.up * a + Tetrahedron_Axis_Direction.right * b + Tetrahedron_Axis_Direction.left * c, path + "t_y");
                PuzzleInit(Tetrahedron_Axis_Direction.left * a + Tetrahedron_Axis_Direction.right * b + Tetrahedron_Axis_Direction.back * c, path + "t_g");
            }
        }
        for (a = 1; a <= size - 4; a++)
        {
            for (b = 1; b <= size - 3 - a; b++)
            {
                c = size - 2 - a - b;
                PuzzleInit(Tetrahedron_Axis_Direction.up * a + Tetrahedron_Axis_Direction.right * b + Tetrahedron_Axis_Direction.back * c, path + "o_r");
                PuzzleInit(Tetrahedron_Axis_Direction.up * a + Tetrahedron_Axis_Direction.left * b + Tetrahedron_Axis_Direction.back * c, path + "o_b");
                PuzzleInit(Tetrahedron_Axis_Direction.up * a + Tetrahedron_Axis_Direction.right * b + Tetrahedron_Axis_Direction.left * c, path + "o_y");
                PuzzleInit(Tetrahedron_Axis_Direction.left * a + Tetrahedron_Axis_Direction.right * b + Tetrahedron_Axis_Direction.back * c, path + "o_g");
            }
        }
    }
    public override void SetDirection()
    {
        Debug.Log("Set direction");
        if (Input.GetKeyDown(KeyCode.S))
        {
            //CCW
            Rotation_Axis = -Tetrahedron_Axis_Direction.up;
            Rotation_Sign = Tetrahedron_Axis_Direction.up;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //CW
            Rotation_Axis = Tetrahedron_Axis_Direction.up;
            Rotation_Sign = Tetrahedron_Axis_Direction.up;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            //BACK_LEFT
            Rotation_Axis = Tetrahedron_Axis_Direction.back;
            Rotation_Sign = Tetrahedron_Axis_Direction.back;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            //BACK_RIGHT
            Rotation_Axis = -Tetrahedron_Axis_Direction.back;
            Rotation_Sign = Tetrahedron_Axis_Direction.back;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //LEFT_UP
            Rotation_Axis = -Tetrahedron_Axis_Direction.left;
            Rotation_Sign = Tetrahedron_Axis_Direction.left;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            //LEFT_DOWN
            Rotation_Axis = Tetrahedron_Axis_Direction.left;
            Rotation_Sign = Tetrahedron_Axis_Direction.left;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            //RIGHT_UP
            Rotation_Axis = Tetrahedron_Axis_Direction.right;
            Rotation_Sign = Tetrahedron_Axis_Direction.right;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            //RIGHT_DOWN
            Rotation_Axis = -Tetrahedron_Axis_Direction.right;
            Rotation_Sign = Tetrahedron_Axis_Direction.right;
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
                        if (Math.Abs(dot - (size-1-4*i/3f)) < FLOAT_EPSLION || Math.Abs(dot - (size-2-4*(i-1)/3f)) < FLOAT_EPSLION) {
                            //_.transform.localScale=_.transform.lossyScale*0.5f;
                            return true;
                        }
                        else return false;
                    });

                    Debug.Log("selecte" + (1 + i));
                    break;
                }
            }
        }
        if (LinePuzzle != null) runningFlag = true;
    }
}
