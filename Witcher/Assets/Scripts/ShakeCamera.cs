using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shake 연출을 줄 카메라에 부착
// 플레이어가 데미지를 입을 때마다 카메라 흔들림 연출
public class ShakeCamera : MonoBehaviour
{
	// 카메라
    Vector3 m_CameraPosition;
	[SerializeField] float m_TillTime = 0.5f;
	[SerializeField] float m_ShakeSense = 0.2f;

	// 플레이어
	GameObject m_Player;

	// Attribute Set
	AttributeSet m_AttributeSet;

    private void Start()
    {
		// 카메라
		m_CameraPosition = gameObject.transform.position;

		// 플레이어
		m_Player = GameObject.FindWithTag("Player");

		// Attribute Set
		m_AttributeSet = m_Player.GetComponent<AttributeSet>();
		m_AttributeSet.OnDamaged += () => StartCoroutine(ShakeIt(m_TillTime, m_ShakeSense));
	}

    IEnumerator ShakeIt(float tillTime, float shakeSense)
	{
		float timego = 0;
		float posx = 0, posy = 0;
		while (timego < tillTime)
		{
			timego += Time.deltaTime;
			posx = Random.Range(-1 * shakeSense, shakeSense);
			posy = Random.Range(-1 * shakeSense, shakeSense);
			gameObject.transform.position = new Vector3(posx, posy, m_CameraPosition.z);

			yield return new WaitForEndOfFrame();
		}
		gameObject.transform.position = m_CameraPosition;
	}
}
