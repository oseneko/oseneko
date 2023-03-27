using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed; //プレイヤーの動くスピード

    // 移動キーを押したときに返すべき値
    private int NUMBER_OF_RETURN_UP_KEY = 1;
    private int NUMBER_OF_RETURN_DOWN_KEY = -1;
    private int NUMBER_OF_RETURN_RIGHT_KEY = 1;
    private int NUMBER_OF_RETURN_LEFT_KEY = -1;

    private Vector3 Player_pos; //プレイヤーのポジション
    private float horizontal; //x方向のImputの値
    private float vertical; //z方向のInputの値

    private bool activeUpKey;
    private bool activeDownKey;
    private bool activeRightKey;
    private bool activeLeftKey;

    public void ActivateUpKey()
    {
        activeUpKey = true;
    }

    public void DisActivateUpKey()
    {
        activeUpKey = false;
    }

    public void ActivateDownKey()
    {
        activeDownKey = true;
    }

    public void DisActivateDownKey()
    {
        activeDownKey = false;
    }

    public void ActivateRightKey()
    {
        activeRightKey = true;
    }

    public void DisActivateRightKey()
    {
        activeRightKey = false;
    }

    public void ActivateLeftKey()
    {
        activeLeftKey = true;
    }

    public void DisActivateLeftKey()
    {
        activeLeftKey = false;
    }


    float HorizontalProvider()
    {
        if (activeRightKey)
        {
            return NUMBER_OF_RETURN_RIGHT_KEY;
        }
        if (activeLeftKey)
        {
            return NUMBER_OF_RETURN_LEFT_KEY;
        }
        return Input.GetAxis("Horizontal"); //x方向のInputの値を取得
    }

    float VerticalProvider()
    {
        if (activeUpKey)
        {
            return NUMBER_OF_RETURN_UP_KEY;
        }
        if (activeDownKey)
        {
            return NUMBER_OF_RETURN_DOWN_KEY;
        }
        return Input.GetAxis("Vertical"); //z方向のInputの値を取得
    }

    void Start()
    {
        Player_pos = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
    }

    void Update()
    {
        horizontal = HorizontalProvider();
        vertical = VerticalProvider();

        transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime); //プレイヤーのRigidbodyに対してInputにspeedを掛けた値で更新し移動


        Vector3 diff = transform.position - Player_pos; //プレイヤーがどの方向に進んでいるかがわかるように、初期位置と現在地の座標差分を取得
        diff.y = 0; // 回転しないようにする

        if (diff.magnitude > 0.01f) //ベクトルの長さが0.01fより大きい場合にプレイヤーの向きを変える処理を入れる(0では入れないので）
        {
            transform.rotation = Quaternion.LookRotation(diff);  //ベクトルの情報をQuaternion.LookRotationに引き渡し回転量を取得しプレイヤーを回転させる
        }

        Player_pos = transform.position; //プレイヤーの位置を更新


    }

}
