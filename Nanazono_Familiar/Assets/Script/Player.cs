using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;//①CharacterController型の変数
    private Vector3 Velocity;//①キャラクターコントローラーを動かすためのVector3型の変数
    public float JumpPower;//①ジャンプ力
    public Transform verRot;//①縦の視点移動の変数(カメラに合わせる)
    public Transform horRot;//①横の視点移動の変数(プレイヤーに合わせる)
    public float MoveSpeed;//①移動速度

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();//①CharacterControllerを変数に代入
    }

    // Update is called once per frame
    void Update()
    {
        float X_Rotation = Input.GetAxis("Mouse X");//①X_RotationにマウスのX軸の動きを代入する
        float Y_Rotation = Input.GetAxis("Mouse Y");//①Y_RotationにマウスのY軸の動きを代入する
        horRot.transform.Rotate(new Vector3(0, X_Rotation * 2, 0));//①プレイヤーのY軸の回転をX_Rotationに合わせる
        verRot.transform.Rotate(-Y_Rotation * 2, 0, 0);//①カメラのX軸の回転をY_Rotationに合わせる

        if (Input.GetKey(KeyCode.W))//①Wキーがおされたら 
        {
            characterController.Move(this.gameObject.transform.forward * MoveSpeed * Time.deltaTime);//①前方にMoveSpeed＊Time.deltaTimeだけ動かす
        }

        if (Input.GetKey(KeyCode.S))//①Sキーがおされたら
        {
            characterController.Move(this.gameObject.transform.forward * -1f * MoveSpeed * Time.deltaTime);//①後方にMoveSpeed＊Time.deltaTimeだけ動かす
        }

        if (Input.GetKey(KeyCode.A))//①Aキーがおされたら 
        {
            characterController.Move(this.gameObject.transform.right * -1 * MoveSpeed * Time.deltaTime);//①左にMoveSpeed＊Time.deltaTimeだけ動かす
        }

        if (Input.GetKey(KeyCode.D))//①Dキーがおされたら 
        {
            characterController.Move(this.gameObject.transform.right * MoveSpeed * Time.deltaTime);//①右にMoveSpeed＊Time.deltaTimeだけ動かす
        }

        characterController.Move(Velocity);//①キャラクターコントローラーをVelocityだけ動かし続ける
        Velocity.y += Physics.gravity.y * Time.deltaTime;//①Velocityのy軸を重力*Time.deltaTime分だけ動かす

        if (characterController.isGrounded)//①キャラクターコントローラーが地面に接触している時に
        {
            if (Input.GetKeyDown(KeyCode.Space))//①スペースキーがおされたら
            {
                Velocity.y = JumpPower;//①Velocity.yをJumpPowerにする
            }
        }
    }
   /*private void OnTriggerEnter(Collider other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Item"))
        {
            // その収集アイテムを非表示にします
            other.gameObject.SetActive(false);
        }
    }*/
}