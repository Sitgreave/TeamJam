using UnityEngine;

public class Weapon : MonoBehaviour
{
	public float speed = 20;// �������� ����
	public Bullet bulletPrefab; // ������ ����� ����
	public Transform gunPoint; // ����� ��������
	public Transform gunTrashBucket;
	private bool towExist = false;
	private bool reloaded = true;
	private Bullet newBullet;
	public Tow tow;




	void Update()
	{

		if (Input.GetMouseButtonDown(0) && reloaded && !towExist)
		{
			Shot();
			reloaded = false;
			Invoke("Reload", 1.5f);
		}


		if (Input.GetMouseButton(1) && towExist)
		{
			tow.ResetRope();
			towExist = false;
			if (newBullet != null) Destroy(newBullet.gameObject);

		}
		if (newBullet != null) TryTow();
	}

	private void Shot()
	{

		newBullet = Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity, gunTrashBucket);
		newBullet.Rigidbody.AddForce(gunPoint.right * speed, ForceMode2D.Impulse);
		newBullet.transform.right = gunPoint.right;

	}

	private void TryTow()
	{
		if (newBullet.CanTowed)
		{

			tow.Towing(newBullet.TowPosition);
			towExist = true;

		}
	}

	private void Reload()
	{
		reloaded = true;
	}
}

