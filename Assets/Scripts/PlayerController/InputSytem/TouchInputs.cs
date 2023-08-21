// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerController/InputSytem/TouchInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchInputs"",
    ""maps"": [
        {
            ""name"": ""PlayerActions"",
            ""id"": ""bb046a4e-d167-457c-ba2c-8e113d6d65ea"",
            ""actions"": [
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""78e57d44-e9ac-485b-8939-8e9e6dc24c1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9344aa5d-c3a3-4806-81f1-d56f80deb4f2"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_TouchPress = m_PlayerActions.FindAction("TouchPress", throwIfNotFound: true);
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

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_TouchPress;
    public struct PlayerActionsActions
    {
        private @TouchInputs m_Wrapper;
        public PlayerActionsActions(@TouchInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPress => m_Wrapper.m_PlayerActions_TouchPress;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @TouchPress.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnTouchPress;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);
    public interface IPlayerActionsActions
    {
        void OnTouchPress(InputAction.CallbackContext context);
    }
}
