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
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimHor"",
                    ""type"": ""Value"",
                    ""id"": ""7f397b00-8f52-4429-ae0b-3fc5f3ebf37d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimVer"",
                    ""type"": ""Value"",
                    ""id"": ""4eed6e51-66fb-47ae-b0d5-0d0f0a25c80a"",
                    ""expectedControlType"": ""Axis"",
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
                    ""id"": ""c4ae9377-6f99-449f-b6e1-1b584a93b1a9"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
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
                    ""id"": ""a0066ab1-cca2-4894-a2bf-1eb8945c3eef"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd7f9ec0-4e37-4213-855e-51b5dad0038e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1ae4b23f-d169-4db3-8522-29d0fd515e13"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e6f20bd9-7510-453e-a783-a6f6da697efd"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a8ad6732-9103-4fb9-a6e1-f45c526a9f44"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""b7d3b327-8fa2-48eb-b3b9-c6c6ca1fdd47"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7a260d39-c2e2-44a5-9502-43d0f62f93d8"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""665efc8c-d64d-4f0f-af94-65c0800c2a10"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""2b866467-2bdc-4fe7-87ee-c52b07506abd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimHor"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""81aadf56-b9db-4e8e-9c8c-8216790cdf02"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimHor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cdcb3792-bda1-49a7-9fe0-866875725ee4"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimHor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""65fc0e34-79be-495e-891b-4695f844b858"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimVer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""78b0d32d-852d-42c9-beef-84ab31cbdfb1"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimVer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""52dd339d-f3ca-4d0c-8de5-cce66fafb48e"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimVer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
        m_Game_AimHor = m_Game.FindAction("AimHor", throwIfNotFound: true);
        m_Game_AimVer = m_Game.FindAction("AimVer", throwIfNotFound: true);
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
    private readonly InputAction m_Game_AimHor;
    private readonly InputAction m_Game_AimVer;
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
        public InputAction @AimHor => m_Wrapper.m_Game_AimHor;
        public InputAction @AimVer => m_Wrapper.m_Game_AimVer;
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
                @AimHor.started -= m_Wrapper.m_GameActionsCallbackInterface.OnAimHor;
                @AimHor.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnAimHor;
                @AimHor.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnAimHor;
                @AimVer.started -= m_Wrapper.m_GameActionsCallbackInterface.OnAimVer;
                @AimVer.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnAimVer;
                @AimVer.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnAimVer;
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
                @AimHor.started += instance.OnAimHor;
                @AimHor.performed += instance.OnAimHor;
                @AimHor.canceled += instance.OnAimHor;
                @AimVer.started += instance.OnAimVer;
                @AimVer.performed += instance.OnAimVer;
                @AimVer.canceled += instance.OnAimVer;
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
        void OnAimHor(InputAction.CallbackContext context);
        void OnAimVer(InputAction.CallbackContext context);
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
