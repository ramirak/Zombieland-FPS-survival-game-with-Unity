using UnityEngine;

namespace TinForge.SimpleWarships
{
	public class Rotate : MonoBehaviour
	{
		public float speed;
		void Update()
		{
			transform.Rotate(Vector3.up * speed * Time.deltaTime);
		}
	}
}