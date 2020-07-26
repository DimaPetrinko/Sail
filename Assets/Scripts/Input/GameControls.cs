// GENERATED AUTOMATICALLY FROM 'Assets/InternalAssets/Input/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Sail.Input
{
    public class @GameControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Boat"",
            ""id"": ""f018c7a6-0f3d-481d-9994-38b0ed95b5ac"",
            ""actions"": [
                {
                    ""name"": ""Rudder"",
                    ""type"": ""PassThrough"",
                    ""id"": ""77483536-e03a-4524-840d-dcd1be0ec7b5"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SailAngle"",
                    ""type"": ""PassThrough"",
                    ""id"": ""182b4f1a-f696-4875-a193-3bd255a1c5be"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SailLevel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""85e8bfd6-e47b-4780-ac5c-14ef60b3abb2"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""baa9de6c-7366-4120-bb9b-c4d5eb70fdd1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1973e503-8441-40c1-87f6-4a2558900265"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rudder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""ef2ad9c2-47b5-485e-a0e4-bceb74338c74"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rudder"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0fbc7ab4-5a9c-481b-8e07-b54303925c11"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and keyboard"",
                    ""action"": ""Rudder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""147fb263-3eaf-4e95-be03-07321f21fd98"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and keyboard"",
                    ""action"": ""Rudder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""375e1989-de5d-494d-a78e-e7b94505e7b3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rudder"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ed807d96-82a8-4967-8460-de68d2cd72c8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and keyboard"",
                    ""action"": ""Rudder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""119d2c65-dd89-4e23-93c6-90c2b8677fa1"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and keyboard"",
                    ""action"": ""Rudder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""DPad"",
                    ""id"": ""1f55b87d-aa4f-42c1-bdef-b272a7d7ada0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SailLevel"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f594e047-c668-417c-b5a6-aebb7561c988"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SailLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fab2c94b-f4a5-4020-a244-f44b948a9e73"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SailLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""21d1be0f-f3a9-4da0-b97a-4950f09f8263"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SailLevel"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3d517572-4c1e-4c0a-bc47-053576d4f32d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and keyboard"",
                    ""action"": ""SailLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4455c7cd-5242-4d60-8b23-2da7a406b78f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and keyboard"",
                    ""action"": ""SailLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""2453122e-e511-42aa-b13e-cabc71dc203d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SailLevel"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dfdb78cc-5500-4b4f-88c4-92f0f7aa89bb"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and keyboard"",
                    ""action"": ""SailLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f74f9247-f358-49c3-944a-d824f54da036"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and keyboard"",
                    ""action"": ""SailLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""667e3a0d-ab45-4e32-b21f-39a3223d9742"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and keyboard"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4ee82db-fccc-4b67-b937-056df1c3f890"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""DPad"",
                    ""id"": ""6d1bc994-5451-4e82-acb7-e862e8a5d5a3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SailAngle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c8d9a11c-8e62-49ac-9cc0-dcbc0d68c2a3"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SailAngle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9063c14b-23be-4c77-82e2-39528d3a0883"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SailAngle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""EQ"",
                    ""id"": ""74b9b708-e539-4483-b88d-6c4eb9417f46"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SailAngle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""721b6f32-2901-4002-85c8-e69c6930e25c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and keyboard"",
                    ""action"": ""SailAngle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9a3487e4-26ba-47fd-a277-6039f1084750"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and keyboard"",
                    ""action"": ""SailAngle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse and keyboard"",
            ""bindingGroup"": ""Mouse and keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Boat
            m_Boat = asset.FindActionMap("Boat", throwIfNotFound: true);
            m_Boat_Rudder = m_Boat.FindAction("Rudder", throwIfNotFound: true);
            m_Boat_SailAngle = m_Boat.FindAction("SailAngle", throwIfNotFound: true);
            m_Boat_SailLevel = m_Boat.FindAction("SailLevel", throwIfNotFound: true);
            m_Boat_Camera = m_Boat.FindAction("Camera", throwIfNotFound: true);
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

        // Boat
        private readonly InputActionMap m_Boat;
        private IBoatActions m_BoatActionsCallbackInterface;
        private readonly InputAction m_Boat_Rudder;
        private readonly InputAction m_Boat_SailAngle;
        private readonly InputAction m_Boat_SailLevel;
        private readonly InputAction m_Boat_Camera;
        public struct BoatActions
        {
            private @GameControls m_Wrapper;
            public BoatActions(@GameControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Rudder => m_Wrapper.m_Boat_Rudder;
            public InputAction @SailAngle => m_Wrapper.m_Boat_SailAngle;
            public InputAction @SailLevel => m_Wrapper.m_Boat_SailLevel;
            public InputAction @Camera => m_Wrapper.m_Boat_Camera;
            public InputActionMap Get() { return m_Wrapper.m_Boat; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(BoatActions set) { return set.Get(); }
            public void SetCallbacks(IBoatActions instance)
            {
                if (m_Wrapper.m_BoatActionsCallbackInterface != null)
                {
                    @Rudder.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnRudder;
                    @Rudder.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnRudder;
                    @Rudder.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnRudder;
                    @SailAngle.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnSailAngle;
                    @SailAngle.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnSailAngle;
                    @SailAngle.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnSailAngle;
                    @SailLevel.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnSailLevel;
                    @SailLevel.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnSailLevel;
                    @SailLevel.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnSailLevel;
                    @Camera.started -= m_Wrapper.m_BoatActionsCallbackInterface.OnCamera;
                    @Camera.performed -= m_Wrapper.m_BoatActionsCallbackInterface.OnCamera;
                    @Camera.canceled -= m_Wrapper.m_BoatActionsCallbackInterface.OnCamera;
                }
                m_Wrapper.m_BoatActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Rudder.started += instance.OnRudder;
                    @Rudder.performed += instance.OnRudder;
                    @Rudder.canceled += instance.OnRudder;
                    @SailAngle.started += instance.OnSailAngle;
                    @SailAngle.performed += instance.OnSailAngle;
                    @SailAngle.canceled += instance.OnSailAngle;
                    @SailLevel.started += instance.OnSailLevel;
                    @SailLevel.performed += instance.OnSailLevel;
                    @SailLevel.canceled += instance.OnSailLevel;
                    @Camera.started += instance.OnCamera;
                    @Camera.performed += instance.OnCamera;
                    @Camera.canceled += instance.OnCamera;
                }
            }
        }
        public BoatActions @Boat => new BoatActions(this);
        private int m_MouseandkeyboardSchemeIndex = -1;
        public InputControlScheme MouseandkeyboardScheme
        {
            get
            {
                if (m_MouseandkeyboardSchemeIndex == -1) m_MouseandkeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse and keyboard");
                return asset.controlSchemes[m_MouseandkeyboardSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        public interface IBoatActions
        {
            void OnRudder(InputAction.CallbackContext context);
            void OnSailAngle(InputAction.CallbackContext context);
            void OnSailLevel(InputAction.CallbackContext context);
            void OnCamera(InputAction.CallbackContext context);
        }
    }
}
