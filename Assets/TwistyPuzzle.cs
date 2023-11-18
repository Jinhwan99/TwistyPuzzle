using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TwistyPuzzle
{
    protected float FLOAT_EPSLION = 0.001f;
    public bool runningFlag = false, direction_selected = false;

    protected float Angle = 0f, rightAngle;
    public float speed = 15f;
    protected Vector3 Rotation_Axis, Rotation_Sign, Center;
    public int shape { get; set; }
    public int size { get; set; }
    public bool scalability { get; set; }
    public int count;
    public GameObject SinglePuzzle;
    public List<GameObject> UnionPuzzle = new List<GameObject>();
    public List<GameObject> LinePuzzle = null;

    public virtual void MakeAPuzzle()
    {

    }
    public void Rotation()
    {
        Debug.Log("Rotation");
        if (Angle < rightAngle) Rotation(LinePuzzle, Rotation_Axis);
        else
        {
            Debug.Log("All Init");
            AllInit();
        }
    }
    public void Rotation(List<GameObject> set, Vector3 dirVec)
    {
        for (int i = 0; i < set.Count; i++)
        {
            set[i].transform.RotateAround(Vector3.zero, dirVec, speed);
            //set[i].transform.RotateAround(Center, dirVec, speed);
        }
        Angle += speed;
    }
    public virtual void SetDirection() { }
    public virtual void SelectLine() { }
    protected virtual void SelectLinePuzzle() { }
    public void clearPuzzle()
    {
        for (int i = count - 1; i >= 0; i--)
        {
            GameObject.Destroy(UnionPuzzle[i]);
        }
        SinglePuzzle = null;
        UnionPuzzle.RemoveRange(0, count);
        size = 0;
        shape = 0;
        scalability = false;
    }
    protected void PuzzleInit(Vector3 dir, string str)
    {
        GameObject t = GameObject.Instantiate(Resources.Load<GameObject>(str), dir, Quaternion.identity);
        //t.transform.localScale = t.transform.lossyScale * scale;
        UnionPuzzle.Add(t);
        count++;
    }
    private void AllInit()
    {
        if (shape == 2)
        {
            SettingRotation();
            SettingPosition();
        }
        if(shape==3){
            SettingPosition();
        }
        LinePuzzle = null;
        runningFlag = false;
        direction_selected = false;
        Rotation_Sign = Vector3.zero;
        Rotation_Axis = Vector3.zero;
        Angle = 0;

    }
    private void SettingPosition()
    {
        for (int i = 0; i < LinePuzzle.Count; i++)
        {
            LinePuzzle[i].transform.position = vRound(LinePuzzle[i].transform.position);
        }
    }
    private void SettingRotation()
    {
        for (int i = 0; i < LinePuzzle.Count; i++)
        {
            float xrot = RotationValueCheck(LinePuzzle[i].transform.eulerAngles.x);
            float yrot = RotationValueCheck(LinePuzzle[i].transform.eulerAngles.y);
            float zrot = RotationValueCheck(LinePuzzle[i].transform.eulerAngles.z);
            LinePuzzle[i].transform.eulerAngles = new Vector3(xrot, yrot, zrot);
        }
    }
    private Vector3 vRound(Vector3 vec)
    {
        float x, y, z;
        x = (float)Math.Round(vec.x, 2);
        y = (float)Math.Round(vec.y, 2);
        z = (float)Math.Round(vec.z, 2);
        return new Vector3(x, y, z);
    }
    private float RotationValueCheck(float rot)
    {
        float absrot = Mathf.Abs(rot);
        for (int i = (int)rightAngle; i <= 360; i += (int)rightAngle)
        {
            if (absrot >= i - rightAngle / 2 && absrot < i + rightAngle / 2)
            {
                absrot = i;
                if (rot < 0) return -absrot;
                else return absrot;
            }
        }
        return 0f;
    }
}