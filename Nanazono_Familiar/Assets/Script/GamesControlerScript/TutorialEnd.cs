﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialEnd : MonoBehaviour
{
	// 配列（同じ種類の複数のデータを収納するための箱を作る）
	private GameObject[] enemyObjects;

	void Update()
	{

		// Enemyというタグが付いているオブジェクトのデータを箱の中に入れる。
		enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

		// データの入った箱の数をコンソール画面に表示する。
		//print(enemyObjects.Length);

		// データの入った箱のデータが０に等しくなった時（Enemyというタグが付いているオブジェクトが全滅したとき）
		if (enemyObjects.Length == 0)
		{

			// ゲームクリアーシーンに遷移する。
			SceneManager.LoadScene("Nepuri-gu");
		}
	}
}