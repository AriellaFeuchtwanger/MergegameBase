// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputManager/ActionsController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ActionsController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ActionsController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActionsController"",
    ""maps"": [
        {
            ""name"": ""Items"",
            ""id"": ""5db20c7e-7ee7-4e4c-a1a2-ff558f93f2c9"",
            ""actions"": [
                {
                    ""name"": ""PrimaryFingerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""5c9a6283-c22f-45e3-a5db-f22ab402d098"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryFingerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""9d084153-9be0-4073-be25-15e4bacf7967"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryTouchContact"",
                    ""type"": ""Button"",
                    ""id"": ""c6c7b5ca-57c2-494b-bea2-97edfc3591fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MoveCamera"",
                    ""type"": ""Button"",
                    ""id"": ""f248fef4-d9df-4182-bc9c-c8c2a386dcc1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""192a0cda-7644-4235-9dda-3ac4e5bec3dd"",
                    ""path"": ""<Touchscreen>/touch0/startPosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53483f4c-5d18-4314-9cc8-fa47a391d7e1"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0be096fd-77d4-401f-ad47-7aaf57f63947"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0fd0a38d-88f1-439f-b323-a281c4d4e429"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryTouchContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5de9aeb-0cad-460e-90bf-a1b27990056c"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9c97844-8663-430c-88a2-bacdb7e80e0a"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Items
        m_Items = asset.FindActionMap("Items", throwIfNotFound: true);
        m_Items_PrimaryFingerPosition = m_Items.FindAction("PrimaryFingerPosition", throwIfNotFound: true);
        m_Items_SecondaryFingerPosition = m_Items.FindAction("SecondaryFingerPosition", throwIfNotFound: true);
        m_Items_SecondaryTouchContact = m_Items.FindAction("SecondaryTouchContact", throwIfNotFound: true);
        m_Items_MoveCamera = m_Items.FindAction("MoveCamera", throwIfNotFound: true);
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

    // Items
    private readonly InputActionMap m_Items;
    private IItemsActions m_ItemsActionsCallbackInterface;
    private readonly InputAction m_Items_PrimaryFingerPosition;
    private readonly InputAction m_Items_SecondaryFingerPosition;
    private readonly InputAction m_Items_SecondaryTouchContact;
    private readonly InputAction m_Items_MoveCamera;
    public struct ItemsActions
    {
        private @ActionsController m_Wrapper;
        public ItemsActions(@ActionsController wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryFingerPosition => m_Wrapper.m_Items_PrimaryFingerPosition;
        public InputAction @SecondaryFingerPosition => m_Wrapper.m_Items_SecondaryFingerPosition;
        public InputAction @SecondaryTouchContact => m_Wrapper.m_Items_SecondaryTouchContact;
        public InputAction @MoveCamera => m_Wrapper.m_Items_MoveCamera;
        public InputActionMap Get() { return m_Wrapper.m_Items; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ItemsActions set) { return set.Get(); }
        public void SetCallbacks(IItemsActions instance)
        {
            if (m_Wrapper.m_ItemsActionsCallbackInterface != null)
            {
                @PrimaryFingerPosition.started -= m_Wrapper.m_ItemsActionsCallbackInterface.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.performed -= m_Wrapper.m_ItemsActionsCallbackInterface.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.canceled -= m_Wrapper.m_ItemsActionsCallbackInterface.OnPrimaryFingerPosition;
                @SecondaryFingerPosition.started -= m_Wrapper.m_ItemsActionsCallbackInterface.OnSecondaryFingerPosition;
                @SecondaryFingerPosition.performed -= m_Wrapper.m_ItemsActionsCallbackInterface.OnSecondaryFingerPosition;
                @SecondaryFingerPosition.canceled -= m_Wrapper.m_ItemsActionsCallbackInterface.OnSecondaryFingerPosition;
                @SecondaryTouchContact.started -= m_Wrapper.m_ItemsActionsCallbackInterface.OnSecondaryTouchContact;
                @SecondaryTouchContact.performed -= m_Wrapper.m_ItemsActionsCallbackInterface.OnSecondaryTouchContact;
                @SecondaryTouchContact.canceled -= m_Wrapper.m_ItemsActionsCallbackInterface.OnSecondaryTouchContact;
                @MoveCamera.started -= m_Wrapper.m_ItemsActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.performed -= m_Wrapper.m_ItemsActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.canceled -= m_Wrapper.m_ItemsActionsCallbackInterface.OnMoveCamera;
            }
            m_Wrapper.m_ItemsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryFingerPosition.started += instance.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.performed += instance.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.canceled += instance.OnPrimaryFingerPosition;
                @SecondaryFingerPosition.started += instance.OnSecondaryFingerPosition;
                @SecondaryFingerPosition.performed += instance.OnSecondaryFingerPosition;
                @SecondaryFingerPosition.canceled += instance.OnSecondaryFingerPosition;
                @SecondaryTouchContact.started += instance.OnSecondaryTouchContact;
                @SecondaryTouchContact.performed += instance.OnSecondaryTouchContact;
                @SecondaryTouchContact.canceled += instance.OnSecondaryTouchContact;
                @MoveCamera.started += instance.OnMoveCamera;
                @MoveCamera.performed += instance.OnMoveCamera;
                @MoveCamera.canceled += instance.OnMoveCamera;
            }
        }
    }
    public ItemsActions @Items => new ItemsActions(this);
    public interface IItemsActions
    {
        void OnPrimaryFingerPosition(InputAction.CallbackContext context);
        void OnSecondaryFingerPosition(InputAction.CallbackContext context);
        void OnSecondaryTouchContact(InputAction.CallbackContext context);
        void OnMoveCamera(InputAction.CallbackContext context);
    }
}
