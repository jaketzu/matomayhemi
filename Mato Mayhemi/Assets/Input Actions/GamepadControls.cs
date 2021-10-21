// GENERATED AUTOMATICALLY FROM 'Assets/Input Actions/GamepadControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GamepadControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GamepadControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GamepadControls"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""6287a619-d291-4ce0-83c0-40166940bd2b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""800fbf82-9bbe-4f01-a899-2d421b3ef075"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""7f397b00-8f52-4429-ae0b-3fc5f3ebf37d"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""2ff5a478-51af-43eb-81f5-cf1b395a9cda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rope"",
                    ""type"": ""Button"",
                    ""id"": ""76d150a6-ffc3-4812-9e68-daa7c2fc9942"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WeaponNext"",
                    ""type"": ""Button"",
                    ""id"": ""6d1bd159-2850-4221-9313-a75c0de9476d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WeaponBack"",
                    ""type"": ""Button"",
                    ""id"": ""bac3121d-a00b-4aee-8109-78c9a860085a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dig"",
                    ""type"": ""Button"",
                    ""id"": ""a187109d-8b49-470d-ab58-f9d9758648c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bb90fdaa-bb77-46c7-8c87-f1096f50a586"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""44597a31-9fa9-4a90-b4d2-7794ef945e81"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2f90aa0a-ca32-4096-8c27-d9e1c84e4008"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c88bd80c-be91-4bd6-bba5-2e1118a004a9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""086436a9-e96f-4995-adb0-7179857a67b5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d19c4a5a-a1e1-426e-94a7-8e64e5e88a67"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4ae9377-6f99-449f-b6e1-1b584a93b1a9"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37b8e2d5-b24c-481f-a481-10813f0efb1f"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3bbd69a-ee12-4bad-ac41-f1588002f074"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rope"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38d676bc-e4fc-400a-a8e3-e65f83980432"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponNext"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab9d7dd1-0872-4d59-b2c1-f158f1cf9ad2"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c6c9351-f191-441d-b32e-0955e7c664ab"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dig"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6898bf48-b238-42cf-a20e-a8c5806ebc74"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""751033b1-0dee-4f45-9ee4-5d34e6cc49fe"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""708e58c5-719a-4484-b8bb-8f597a79c1f6"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""3fa80912-da3f-477c-8878-1cc8b8711fe0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""298bad98-6845-4e0d-9663-71561b9f8077"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Move = m_Game.FindAction("Move", throwIfNotFound: true);
        m_Game_Aim = m_Game.FindAction("Aim", throwIfNotFound: true);
        m_Game_Shoot = m_Game.FindAction("Shoot", throwIfNotFound: true);
        m_Game_Rope = m_Game.FindAction("Rope", throwIfNotFound: true);
        m_Game_WeaponNext = m_Game.FindAction("WeaponNext", throwIfNotFound: true);
        m_Game_WeaponBack = m_Game.FindAction("WeaponBack", throwIfNotFound: true);
        m_Game_Dig = m_Game.FindAction("Dig", throwIfNotFound: true);
        m_Game_Jump = m_Game.FindAction("Jump", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Newaction = m_Menu.FindAction("New action", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Move;
    private readonly InputAction m_Game_Aim;
    private readonly InputAction m_Game_Shoot;
    private readonly InputAction m_Game_Rope;
    private readonly InputAction m_Game_WeaponNext;
    private readonly InputAction m_Game_WeaponBack;
    private readonly InputAction m_Game_Dig;
    private readonly InputAction m_Game_Jump;
    public struct GameActions
    {
        private @GamepadControls m_Wrapper;
        public GameActions(@GamepadControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Game_Move;
        public InputAction @Aim => m_Wrapper.m_Game_Aim;
        public InputAction @Shoot => m_Wrapper.m_Game_Shoot;
        public InputAction @Rope => m_Wrapper.m_Game_Rope;
        public InputAction @WeaponNext => m_Wrapper.m_Game_WeaponNext;
        public InputAction @WeaponBack => m_Wrapper.m_Game_WeaponBack;
        public InputAction @Dig => m_Wrapper.m_Game_Dig;
        public InputAction @Jump => m_Wrapper.m_Game_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_GameActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_GameActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnShoot;
                @Rope.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRope;
                @Rope.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRope;
                @Rope.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRope;
                @WeaponNext.started -= m_Wrapper.m_GameActionsCallbackInterface.OnWeaponNext;
                @WeaponNext.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnWeaponNext;
                @WeaponNext.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnWeaponNext;
                @WeaponBack.started -= m_Wrapper.m_GameActionsCallbackInterface.OnWeaponBack;
                @WeaponBack.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnWeaponBack;
                @WeaponBack.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnWeaponBack;
                @Dig.started -= m_Wrapper.m_GameActionsCallbackInterface.OnDig;
                @Dig.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnDig;
                @Dig.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnDig;
                @Jump.started -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Rope.started += instance.OnRope;
                @Rope.performed += instance.OnRope;
                @Rope.canceled += instance.OnRope;
                @WeaponNext.started += instance.OnWeaponNext;
                @WeaponNext.performed += instance.OnWeaponNext;
                @WeaponNext.canceled += instance.OnWeaponNext;
                @WeaponBack.started += instance.OnWeaponBack;
                @WeaponBack.performed += instance.OnWeaponBack;
                @WeaponBack.canceled += instance.OnWeaponBack;
                @Dig.started += instance.OnDig;
                @Dig.performed += instance.OnDig;
                @Dig.canceled += instance.OnDig;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public GameActions @Game => new GameActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Newaction;
    public struct MenuActions
    {
        private @GamepadControls m_Wrapper;
        public MenuActions(@GamepadControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Menu_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnRope(InputAction.CallbackContext context);
        void OnWeaponNext(InputAction.CallbackContext context);
        void OnWeaponBack(InputAction.CallbackContext context);
        void OnDig(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
