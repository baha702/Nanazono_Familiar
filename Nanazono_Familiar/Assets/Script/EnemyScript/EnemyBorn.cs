using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBorn : MonoBehaviour
{
	// Start is called before the first frame update
	// Start is called before the first frame update
	//　出現させる敵を入れておく
	[SerializeField] public GameObject[] enemys;
	//　次に敵が出現するまでの時間
	[SerializeField] float appearNextTime;
	//　大量発生が出現するまでの時間
	[SerializeField] float hugeappearTIme;
	//　この場所から出現する敵の数
	[SerializeField] int maxNumOfEnemys;
	//　今何人の敵を出現させたか（総数）
	private int numberOfEnemys;
	//　待ち時間計測フィールド
	private float elapsedTime;
	//通常湧き停止用bool
	private bool stopAppear;
	//大量発生停止用bool
	public bool stopHugeApr;
	//NameJudgeBossの変数
	NameJudgeBoss namejudgeboss;

	// Use this for initialization
	void Start()
	{
		numberOfEnemys = 0;
		elapsedTime = 0f;
		gameObject.GetComponent<NameJudgeBoss>();
	}

	void Update()
	{
		//　この場所から出現する最大数を超えてたら何もしない
		if (numberOfEnemys >= maxNumOfEnemys && !stopAppear)
		{
			return;
		}
		//　経過時間を足す
		elapsedTime += Time.deltaTime;

		//　経過時間が経ったら
		if (elapsedTime > appearNextTime && !stopAppear)
		{
			elapsedTime = 0f;

			AppearEnemy();
		}

		if (stopHugeApr==false)
		{
			if (elapsedTime == hugeappearTIme)
			{
				HugeAppearEnemy();
				if (GameObject.FindGameObjectWithTag("Enemy") == null)
				{
					stopAppear = false;
				}
			}
		}
	}
	//　敵出現メソッド
	void AppearEnemy()
	{
		//　出現させる敵をランダムに選ぶ
		var randomValue = Random.Range(0, enemys.Length);
		//　敵の向きをランダムに決定
		var randomRotationY = Random.value * 360f;

		GameObject.Instantiate(enemys[randomValue], transform.position, Quaternion.Euler(0f, randomRotationY, 0f));
		enemys[randomValue].gameObject.SetActive(true);
		
		

		numberOfEnemys++;
		elapsedTime = 0f;
	}

	//大量発生用メソッド
	void HugeAppearEnemy()
    {
		//　出現させる敵をランダムに選ぶ
		var randomValue = Random.Range(0, enemys.Length);
		//　敵の向きをランダムに決定
		var randomRotationY = Random.value * 360f;

		GameObject.Instantiate(enemys[randomValue], transform.position, Quaternion.Euler(0f, randomRotationY, 0f));
		enemys[randomValue].gameObject.SetActive(true);

		stopAppear = true;
		
	}
}