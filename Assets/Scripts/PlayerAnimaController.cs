using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Invector.vCharacterController
{
    public class PlayerAnimaController : MonoBehaviour
    {

        Animator anim;
        Rigidbody rb;
        Text placeName;
        string LastName = "";
        IEnumerator playstop;
        // Start is called before the first frame update
        void Start()
        {
            playstop = PlayerStop();
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();
            placeName = GameObject.Find("PlaceName").GetComponent<Text>();
            placeName.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("IsJump", true);
            }
            else
            {
                anim.SetBool("IsJump", false);
            }

            UpdateAnim();
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "door")
            {
                anim.SetBool("IsOpen", true);
                StartCoroutine(playstop);
                if (LastName != other.gameObject.name)
                {
                    placeName.text = other.gameObject.name;
                    placeName.gameObject.SetActive(true);
                    LastName = other.gameObject.name;
                }
            }
            else if (other.tag == "PlayGround")
            {
                placeName.text = other.gameObject.name;
                placeName.gameObject.SetActive(true);
                LastName = other.gameObject.name;
            }
        }
        public void CloseIE()
        {
            StopCoroutine(playstop);
        }
        public void AnimationPlayOver()
        {
            anim.SetBool("IsOpen", false);
        }
        void UpdateAnim()
        {
            anim.SetFloat("Speed", rb.velocity.magnitude);
        }
        IEnumerator PlayerStop()
        {
            while (true)
            {
                vThirdPersonMotor.instance.moveSpeed= 0;
                yield return new WaitForFixedUpdate();
            }
        }
    }
}

