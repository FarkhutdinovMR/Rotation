// GENERATED AUTOMATICALLY FROM 'Assets/Sources/Input/NutInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NutInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NutInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""NutInput"",
    ""maps"": [
        {
            ""name"": ""Nut"",
            ""id"": ""66d3612f-3ef3-4a8b-be0e-0b1f200485b6"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""5fe8d1c3-b7fc-4646-8c4b-e1b4b59f9227"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""35c007f0-77c0-47dc-b5ff-a302bad3aed7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""03cc72f4-9d0b-4783-8b12-58d4a97cadb0"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17b8b947-8bc1-4c2f-a91d-e45ce9b24add"",
                    ""path"": ""<Touchscreen>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fd3667c-368a-4da4-af49-2a85458ffa0b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""559e082f-e9ce-4312-bfe4-74a6690846e1"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Nut
        m_Nut = asset.FindActionMap("Nut", throwIfNotFound: true);
        m_Nut_Rotate = m_Nut.FindAction("Rotate", throwIfNotFound: true);
        m_Nut_Grab = m_Nut.FindAction("Grab", throwIfNotFound: true);
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

    // Nut
    private readonly InputActionMap m_Nut;
    private INutActions m_NutActionsCallbackInterface;
    private readonly InputAction m_Nut_Rotate;
    private readonly InputAction m_Nut_Grab;
    public struct NutActions
    {
        private @NutInput m_Wrapper;
        public NutActions(@NutInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Nut_Rotate;
        public InputAction @Grab => m_Wrapper.m_Nut_Grab;
        public InputActionMap Get() { return m_Wrapper.m_Nut; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NutActions set) { return set.Get(); }
        public void SetCallbacks(INutActions instance)
        {
            if (m_Wrapper.m_NutActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_NutActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_NutActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_NutActionsCallbackInterface.OnRotate;
                @Grab.started -= m_Wrapper.m_NutActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_NutActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_NutActionsCallbackInterface.OnGrab;
            }
            m_Wrapper.m_NutActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
            }
        }
    }
    public NutActions @Nut => new NutActions(this);
    public interface INutActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
    }
}
