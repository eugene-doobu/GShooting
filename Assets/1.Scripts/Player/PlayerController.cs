using UnityEditor;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator), typeof(PlayerShot))]
    public class PlayerController : MonoBehaviour
    {
        
        [Header("Player Parameters")]
        [SerializeField] float speed = 4f;
        [SerializeField] float maxHp = 100f;

        private float _currHp = 100f;
    
        private Transform _tr;
        private Animator _anim;
        private PlayerShot _playerShot;

        private readonly int _hashHurt    = Animator.StringToHash("Hurt");
        private readonly int _hashDeath   = Animator.StringToHash("Death");
        private readonly int _hashVictory = Animator.StringToHash("Victory");

        private bool _canControll = true;
        private bool _isTouchTop = false;
        private bool _isTouchBot = false;
        private bool _isTouchRight = false;
        private bool _isTouchLeft = false;

        #region Properties
        public float PlayerHP
        {
            get => _currHp;
            set
            {
                _currHp += value;
                // 피격시 처리
                if (value < 0) PlayerHurt();
                else if (value > 0) PlayerHealing();
            }
        }
        #endregion

        #region UnityEventFuncs
        private void Awake()
        {
            _tr   = GetComponent<Transform>();
            _anim = GetComponent<Animator>();
            _playerShot = GetComponent<PlayerShot>();
        }

        void Update()
        {
            if (!_canControll) return;
            PlayerMovement();
            _playerShot.Fire();
            _playerShot.Reload();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("BORDER")) return;
            BorderTouchCheck(col.gameObject.name, true);
        }
    
        private void OnTriggerExit2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("BORDER")) return;
            BorderTouchCheck(col.gameObject.name, false);
        }

        #endregion

        #region PubilcFuncs
        public void Victory()
        {
            _anim.SetTrigger(_hashVictory);
            _canControll = false;
        
            // TODO: n초 대기 후 승리 이벤트
        }
        #endregion
    
        #region PrivateFuncs
        
        void PlayerHealing()
        {
        
        }
    
        void PlayerHurt()
        {
            // 사망시 처리
            if (_currHp <= 0)
            {
                _anim.SetTrigger(_hashDeath);
                _canControll = false;
            
                // TODO 사망 이벤트
            
                return;
            }
            _anim.SetTrigger(_hashHurt);
        }

        void PlayerMovement()
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");

            // Border에서 이동 제한
            if (_isTouchRight && Mathf.Approximately(h - 1, 0) || _isTouchLeft && Mathf.Approximately(h + 1, 0))
                h = 0;
            if (_isTouchTop && Mathf.Approximately(v - 1, 0) || _isTouchBot && Mathf.Approximately(v + 1, 0))
                v = 0;

            var nextPos = new Vector3(h, v, 0).normalized * speed * Time.deltaTime;
            _tr.position += nextPos;
        }

        void BorderTouchCheck(string borderName, bool state)
        {
            switch (borderName)
            {
                case "Top":
                    _isTouchTop = state;
                    break;
                case "Bottom":
                    _isTouchBot = state;
                    break;
                case "Right":
                    _isTouchRight = state;
                    break;
                case "Left":
                    _isTouchLeft = state;
                    break;
            }
        }
        #endregion
    }
}
