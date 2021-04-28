﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    //carPrefabをいれる
    public GameObject carPrefab;
    //coinPrefabをいれる
    public GameObject coinPrefab;
    //conePrefabをいれる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを生成する限界点
    private float genetatePos = 40f;
    //限界点までの距離
    private float difference = 0;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //Unityちゃんのオブジェクト
    private GameObject unitychan;


    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        this.genetatePos += this.unitychan.transform.position.z + startPos;

        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < genetatePos; i+=15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if(num <= 2)
                GenerateCone(i);
            else
            {
                //レーンごとにアイテムを生成
                for(int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%クルマ配置：10%何もなし
                    if (1 <= item && item <= 6)
                        GenerateCoin(i, j, offsetZ);
                    else if (7 <= item && item <= 9)
                        GenerateCar(i, j, offsetZ);
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        //unityちゃんと生成限界点までの距離を計算
        this.difference = this.genetatePos - this.unitychan.transform.position.z;

        if (this.difference < 45 && genetatePos < goalPos)
        {
            startPos = (int)genetatePos;
            this.genetatePos += 30;
            
            //一定の距離ごとにアイテムを生成
            for (int i = startPos; i < genetatePos; i += 15)
            {
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                    GenerateCone(i);
                else
                {
                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くz座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置：30%クルマ配置：10%何もなし
                        if (1 <= item && item <= 6)
                            GenerateCoin(i, j, offsetZ);
                        else if (7 <= item && item <= 9)
                            GenerateCar(i, j, offsetZ);

                    }
                }
            }
        }
    }

    void GenerateCone(int i)
    {
           //コーンをx軸方向に一直線に生成
           for (float j = -1; j <= 1; j += 0.4f)
           {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
           }
    }
    void GenerateCoin(int i, int j, int offsetZ)
    {
        //コイン生成
        GameObject coin = Instantiate(coinPrefab);
        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
    }
    void GenerateCar(int i, int j, int offsetZ)
    {
        //クルマを生成
        GameObject car = Instantiate(carPrefab);
        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
    }
}