using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sasha 
{
    public class WallInteract : MonoBehaviour
    {
        public bool WallJumping {  get; private set; }

        [Header("Wall Slide")]
        [SerializeField][Range(0.1f, 5f)] private float wallSlideMaxSpeed = 2f;
        [Header("Wall Jump")]
        [SerializeField] private Vector2 wallJumpClimb = new Vector2(4f,12f);
        [SerializeField] private Vector2 wallJumpBounce = new Vector2(10.7f, 10f);

        private CollisionDataRetriever collisionDataRetriever;
        private Rigidbody2D body;
        private Controller controller;

        private Vector2 velocity;
        private bool onWall;
        private bool onGround;
        private bool desiredJump;

        private float wallDirectionX;

        void Start()
        {
            collisionDataRetriever = GetComponent<CollisionDataRetriever>();
            body = GetComponent<Rigidbody2D>();
            controller = GetComponent<Controller>();
        }


        void Update()
        {
            if(onWall && !onGround)
            {
                desiredJump |= controller.input.RetrieveJumpInput();
            }
        }

        private void FixedUpdate()
        {
            velocity = body.velocity;
            onWall = collisionDataRetriever.onWall;
            onGround = collisionDataRetriever.onGround;
            wallDirectionX = collisionDataRetriever.ContactNormal.x;

            #region Wall Slide
            if(onWall)
            {
                if(velocity.y < -wallSlideMaxSpeed)
                {
                    velocity.y = -wallSlideMaxSpeed;
                }
            }
            #endregion

            #region Wall Jump

            if ((onWall && velocity.x == 0) || onGround) 
            {
                WallJumping = false;
            }

            if (desiredJump)
            {
                if (-wallDirectionX == controller.input.RetrieveMoveInput())
                {
                    velocity = new Vector2 (wallJumpClimb.x * wallDirectionX, wallJumpClimb.y);
                    WallJumping = true;
                    desiredJump = false;
                }
                else if(controller.input.RetrieveMoveInput() == 0)
                {
                    velocity = new Vector2(wallJumpBounce.x * wallDirectionX, wallJumpBounce.y);
                    WallJumping = true;
                    desiredJump = false;
                }
            }
            #endregion

            body.velocity = velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            collisionDataRetriever.EvaluateCollision(collision);
            if (collisionDataRetriever.onWall && !collisionDataRetriever.onGround && WallJumping) 
            {
                body.velocity = Vector2.zero;
            }
        }

    }

}
