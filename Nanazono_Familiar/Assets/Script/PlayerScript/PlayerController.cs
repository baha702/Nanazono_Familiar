using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public float speed;
    private Transform PlayerTransform;
    private Transform CameraTransform;

    public float AngeleRotation;
   
    [SerializeField] GameObject targetObj;
    Vector3 targetPos;
    Vector3 roteuler;
    float angleH;
    float angleV;

    public Slider SensitivitySlider;//マウス調節用スライダー

    // Use this for initialization
    void Start()
    {
        AngeleRotation = 50f;
        PlayerTransform = transform.parent;
         CameraTransform = GetComponent<Transform>();
        targetPos = targetObj.transform.position;
        roteuler = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);
        SensitivitySlider.value = AngeleRotation;

    }

    // Update is called once per frame
    void Update()
    {
        SensitivitySlider.value = AngeleRotation;
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // マウスの移動量
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        


        // マウス移動量から求めた水平・垂直回転角
        //float deltaAngleH = mouseInputX * Time.deltaTime * 300f;
        //float deltaAngleV = -mouseInputY * Time.deltaTime * 300f;

        // マウス移動量から求めた水平・垂直回転角
        float deltaAngleH = mouseInputX * Time.deltaTime * AngeleRotation;
        float deltaAngleV = -mouseInputY * Time.deltaTime * AngeleRotation;

        // 角度を積算する
        angleH += deltaAngleH;
        angleV += deltaAngleV;

        // 積算角度を制限内にクランプする
        float clampedAngleH = Mathf.Clamp(angleH, -70, 70);
        float clampedAngleV = Mathf.Clamp(angleV, -45, 45);

        // クランプ前の積算角からクランプ後の積算角を引いて、どれだけ制限範囲を超えたかを求める
        // もし制限範囲内なら差は0になるが、マイナス側に越えればマイナスの、プラス側ならプラスの角度差が得られる
        float overshootH = angleH - clampedAngleH;
        float overshootV = angleV - clampedAngleV;

        // 角度差分だけ回転量を調整して、制限を超えないようにしてやる
        // 積算角度も調整後の値に上書きする
        deltaAngleH -= overshootH;
        deltaAngleV -= overshootV;
        angleH = clampedAngleH;
        angleV = clampedAngleV;

        // targetの位置のY軸を中心に、回転（公転）する
        transform.RotateAround(targetPos, Vector3.up, deltaAngleH);

        // カメラの垂直移動
        transform.RotateAround(targetPos, transform.right, deltaAngleV);
    }

    //マウス感度調整用スライダーメソッド
    public void OnEnable()
    {

        AngeleRotation = SensitivitySlider.value;
    }
}