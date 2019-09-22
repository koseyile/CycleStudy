using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class button : MonoBehaviour
	{
		bool a;
		bool b;
		public void Button1_Click()
		{
			//Debug.Log("1pressed");
			a = true;
		}

		public void Button2_Click()
		{
			//Debug.Log("2pressed");
			b = true;
		}


		// Start is called before the first frame update
		void Start()
		{
			this.transform.localPosition = new Vector3(0, 1, -11);
			this.transform.rotation = new Quaternion(0, 0, 0, 0);
			a = false;
			b = false;
		}

		// Update is called once per frame
		void Update()
		{
			if (transform.localPosition.z < -22)
			{
				a = false;
			}

			if (transform.localPosition.z < -35.5)
			{
				b = false;
			}



			if (a)
			{
				transform.Translate(-transform.forward * 10 * Time.deltaTime);
			}

			if (b)
			{
				transform.Rotate(-Vector3.left * 37 * Time.deltaTime);    //x  0----32.525
				transform.Translate(-transform.forward * 20f * Time.deltaTime);     //z -22----30.41    8.41
				transform.Translate(transform.up * 0.75f * Time.deltaTime);  //y    1----8.52             7.52

			}
		}
	}
