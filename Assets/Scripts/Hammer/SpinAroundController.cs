using UnityEngine;

namespace Hammer
{
    using GamepadInput;

    using UnityStandardAssets.Characters.FirstPerson;

    public class SpinAroundController : MonoBehaviour
    {

        private HingeJoint hinge;

        [SerializeField]
        private Rigidbody hammer;

        private RigidbodyFirstPersonController controller;

        public float RotateSpeed;

        void Awake()
        {
            this.hinge = this.hammer.GetComponent<HingeJoint>();

            this.controller = this.GetComponentInChildren<RigidbodyFirstPersonController>();
        }

        void Update()
        {

            // Temp solution

            if (GamePad.GetTrigger(GamePad.Trigger.LeftTrigger, GamePad.Index.Any) > 0.9f)
            {
                this.controller.movementSettings.ShouldRun = true;
            }
            else
            {
                this.controller.movementSettings.ShouldRun = false;
            }


            this.hinge.useSpring = false;
            if (Input.GetButton("Fire1") || GamePad.GetTrigger(GamePad.Trigger.RightTrigger, GamePad.Index.Any) > 0.9f)
            {
                this.hinge.useSpring = true;
            }

            this.HandleScroll();
        }

        private void HandleScroll()
        {
            var d = Input.GetAxis("Mouse ScrollWheel");

            d *= this.RotateSpeed;


            var f = d * Time.deltaTime;

            this.hammer.transform.Rotate(this.hammer.transform.right
                , f);

            //this.hammer.AddRelativeTorque( new Vector3(0, 0, f));
        }
    }
    
}
