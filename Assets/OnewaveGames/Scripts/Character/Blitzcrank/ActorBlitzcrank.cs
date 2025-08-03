using UnityEngine;
using UnityEngine.InputSystem;

public class ActorBlitzcrank : Actor
{
    public PlayerInput playerInput;

    InputAction _moveAction;
    InputAction _lookAction;
    InputAction _fireAction;

    CharacterData _characterData;


    void Awake()
    {
        var playerActionMap = playerInput.actions.FindActionMap("Player");
        _moveAction = playerActionMap.FindAction("Move");
        _lookAction = playerActionMap.FindAction("Look");
        _fireAction = playerActionMap.FindAction("Fire");
        _fireAction.performed += Fire;
    }

    void Start()
    {
        // 기획데이터 세팅
        _characterData = GameDataManager.Instance.GetCharacterData("blitzcrank");
        _acotrStat.SetStat(_characterData);
        _skill = new SkillBlitzcrank();
        _skill.Set();
        _dataReady = true;
    }

    void Update()
    {
        DoAction();
    }

    void DoAction()
    {
        if (!_dataReady) return;
        if (playerInput == null) return;
        Move();
    }

    void Move()
    {
        if (_moveAction == null) return;
        Vector2 dir = _moveAction.ReadValue<Vector2>();
        transform.Translate(_acotrStat.MoveSpeed * Time.deltaTime * new Vector3(dir.x, 0, dir.y));
    }

    void Fire(InputAction.CallbackContext context)
    {
        if (_fireAction == null) return;

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {

            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                ApplySkill(hit.collider.transform.parent.GetComponent<Actor>());
            }
        }
    }

    public override void ApplySkill(Actor target)
    {
        if (target == null) return;
        _skill.ApplyInstantSkill(this, target);
    }
}
