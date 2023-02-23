using UnityEngine;

namespace Item
{
    public class AtkBootsItem : MonoBehaviour
    {
        private PlayerInventory _playerInventory;
        private SoundManager _soundManager;
        public bool itemAllowPickUp = false;
        private Animator _animator;
        // Start is called before the first frame update
        void Start()
        {
            _playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
            _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
            _animator = GameObject.FindGameObjectWithTag("PressE").GetComponent<Animator>();
        }

        private void Update()
        {
            if (itemAllowPickUp && Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _animator.SetBool("PressE",true);
                itemAllowPickUp = true;
            }
        }
    
        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _animator.SetBool("PressE",false);
                itemAllowPickUp = false;
            }
        }

        private void PickUp()
        {
            _playerInventory.UpdateAtkBoots(1);
            SoundManager.instace.Play(SoundManager.SoundName.PickUp);
            Debug.Log("Get 1 ATK Boots");
            Destroy(this.gameObject);
        }
    }
}
