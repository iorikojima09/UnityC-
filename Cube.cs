
//20210521現在　トップとダウンのコーディングがうまくいかない。

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Cube : MonoBehaviour
{
    bool forwardmove;
    bool backmove;
    bool rightmove;
    bool leftmove;
    bool topmove;
    bool downmove;

    Vector3 rotatePoint = Vector3.zero;  //回転の中心
    Vector3 rotateAxis = Vector3.zero;   //回転軸
    float cubeAngle = 0f;                //回転角度
    float cubeSizeHalf;                  //キューブの大きさの半分
    bool isRotate = false;               //回転中に立つフラグ。回転中は入力を受け付けない

    void Start()
    {
        cubeSizeHalf = transform.localScale.x / 2f;
    }

    void Update()
    {
        if (isRotate)
            return;

        if (forwardmove == true)
        {
            //transform.position += new Vector3(0, 0, 1 * Time.deltaTime);
            rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, cubeSizeHalf);
            rotateAxis = new Vector3(1, 0, 0);
        }
        if (backmove == true)
        {
            //transform.position += new Vector3(0, 0, -1 * Time.deltaTime);
            rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, -cubeSizeHalf);
            rotateAxis = new Vector3(-1, 0, 0);
        }
        if (rightmove == true)
        {
            //transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
            rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
            rotateAxis = new Vector3(0, 0, -1);
        }
        if (leftmove == true)
        {
            //transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);
            rotatePoint = transform.position + new Vector3(-cubeSizeHalf, -cubeSizeHalf, 0f);
            rotateAxis = new Vector3(0, 0, 1);
        }



        //編集作業始まり

        if (topmove == true)
        {
            //transform.position += new Vector3(0, 0, 1 * Time.deltaTime);
            //rotatePoint = transform.position + new Vector3(-cubeSizeHalf, 0f, cubeSizeHalf);
            //rotateAxis = new Vector3(0, 1, 0);
            transform.Translate(0f, 0.1f, 0f);
        }

        if (downmove == true)
        {
            //transform.position += new Vector3(0, 0, -1 * Time.deltaTime);
            //rotatePoint = transform.position + new
            //
            //Vector3(-cubeSizeHalf, 0f, cubeSizeHalf);
            //rotateAxis = new Vector3(0, -1, 0);
            transform.Translate(0f, -0.1f, 0f);
        }

        //編集作業終わり


        // 入力がない時はコルーチンを呼び出さないようにする
        if (rotatePoint == Vector3.zero)
            return;
        StartCoroutine(MoveCube());
    }


    IEnumerator MoveCube()
    {
        //回転中のフラグを立てる
        isRotate = true;

        //回転処理
        float sumAngle = 0f; //angleの合計を保存
        while (sumAngle < 90f)
        {
            cubeAngle = 15f; //ここを変えると回転速度が変わる
            sumAngle += cubeAngle;

            // 90度以上回転しないように値を制限
            if (sumAngle > 90f)
            {
                cubeAngle -= sumAngle - 90f;
            }
            transform.RotateAround(rotatePoint, rotateAxis, cubeAngle);

            yield return null;
        }

        //回転中のフラグを倒す
        isRotate = false;
        rotatePoint = Vector3.zero;
        rotateAxis = Vector3.zero;

        yield break;
    }


    public void forwardButtonDown()
    {
        forwardmove = true;
    }
    public void forwardButtonUp()
    {
        forwardmove = false;
    }
    public void backButtonDown()
    {
        backmove = true;
    }
    public void backButtonUp()
    {
        backmove = false;
    }
    public void rightButtonDown()
    {
        rightmove = true;
    }
    public void rightButtonUp()
    {
        rightmove = false;
    }
    public void leftButtonDown()
    {
        leftmove = true;
    }
    public void leftButtonUp()
    {
        leftmove = false;
    }

    //
    public void topButtonDown()
    {
        topmove = true;
    }
    public void topButtonUp()
    {
        downmove = false;
    }
    public void downButtonDown()
    {
        topmove = true;
    }
    public void downButtonUp()
    {
        downmove = false;
    }
    //

}