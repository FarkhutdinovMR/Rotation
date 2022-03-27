// GENERATED AUTOMATICALLY FROM 'Assets/Sources/Input/SphereInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @SphereInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @SphereInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SphereInput"",
    ""maps"": [
        {
            ""name"": ""Sphere"",
            ""id"": ""66d3612f-3ef3-4a8b-be0e-0b1f200485b6"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""5fe8d1c3-b7fc-4646-8c4b-e1b4b59f9227"",
                    ""expectedControlType"": ""Vector2"",
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Sphere
        m_Sphere = asset.FindActionMap("Sphere", throwIfNotFound: true);
        m_Sphere_Rotate = m_Sphere.FindAction("Rotate", throwIfNotFound: true);
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

    // Sphere
    private readonly InputActionMap m_Sphere;
    private ISphereActions m_SphereActionsCallbackInterface;
    private readonly InputAction m_Sphere_Rotate;
    public struct SphereActions
    {
        private @SphereInput m_Wrapper;
        public SphereActions(@SphereInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Sphere_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Sphere; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SphereActions set) { return set.Get(); }
        public void SetCallbacks(ISphereActions instance)
        {
            if (m_Wrapper.m_SphereActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_SphereActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_SphereActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_SphereActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_SphereActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public SphereActions @Sphere => new SphereActions(this);
    public interface ISphereActions
    {
        void OnRotate(InputAction.CallbackContext context);
    }
}