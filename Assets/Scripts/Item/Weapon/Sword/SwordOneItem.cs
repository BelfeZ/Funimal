using UnityEngine;

namespace Item.Weapon.Sword
{
    public class SwordOneItem : MonoBehaviour
    {
        public bool pickUpAllowed = false;

        private PlayerInventory _playerInventory;
        private SoundManager _soundManager;
        private Animator _animator;
        private Merchant _merchant;
        private void Start()
        {
            _playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
            _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
            _animator = GameObject.FindGameObjectWithTag("PressE").GetComponent<Animator>();
            _merchant = GameObject.FindGameObjectWithTag("NPC").GetComponent<Merchant>();
        }

        private void Update()
        {
            if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _animator.SetBool("PressE",true);
                pickUpAllowed = true;
            }
        }
    
        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _animator.SetBool("PressE",false);
                pickUpAllowed = false;
            }
        }

        private void PickUp()
        {
            _playerInventory.swordOne = true;
            SoundManager.instace.Play(SoundManager.SoundName.PickUp);
            Destroy(this.gameObject);
            Debug.Log("Get item");
        }

        
    }
}
