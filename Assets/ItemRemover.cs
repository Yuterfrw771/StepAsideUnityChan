using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemover : MonoBehaviour
{
    //画面に映る可能性のあるz軸最大の場所
    private float visiblePosZ = 0;
    //画面に映る可能性のあるz軸最大の場所
    private float visibleCamera = -6f;
    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //画面に移る範囲を計算
        visiblePosZ = unitychan.transform.position.z + visibleCamera;

        //消すための条件分岐
        if (visiblePosZ > this.transform.position.z)
        {
            //アイテムを破棄する
            Destroy(this.gameObject);

        }
    }
}
