using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Gryphon.Framework
{
    public abstract class EngineComponent
    {
        protected enum States
        {
            CONSTRUCTED,
            INITIALISING,
            INITIALISED,
            TERMINATING,
            TERMINATED,
            PENDING_DECONSTRUCTION,
            UNKNOWN
        }

        protected delegate void OnInitialising();
        protected delegate void OnInitialised();
        protected delegate void OnTerminating();
        protected delegate void OnTerminated();

        private OnInitialising m_onInitialisingHandlers;
        private OnInitialised m_onInitialisedHandlers;
        private OnTerminating m_onTerminatingHandlers;
        private OnTerminated m_onTerminatedHandlers;

        private readonly EngineComponentId m_id;
        private readonly EngineComponentDescriptor m_descriptor;
        protected readonly Api.ApiContextManager m_apiContextManager;
        protected readonly Configuration.ConfigurationManager m_configurationManager;

        private IEngineComponentErrorCallback m_errorCallback;
        private States m_state;
        private Semaphore m_semaphore;
        private const int m_iSemaphoreTimeoutMillis = 3000;
        private static SortedDictionary<States, string> m_stateDisplayNames = 
            new SortedDictionary<States, string>()
            {
                { States.CONSTRUCTED, "constructed" },
                { States.INITIALISING, "initialising"},
                { States.INITIALISED, "initialised"},
                { States.TERMINATING, "terminating" },
                { States.TERMINATED, "terminated"},
                { States.PENDING_DECONSTRUCTION, "pending deconstruction"},
                { States.UNKNOWN, "unknown" }
            };
        
        public EngineComponent(EngineComponentConfig config)
        {
            m_state = States.CONSTRUCTED;
            m_semaphore = new Semaphore(1, 1);
            m_errorCallback = new DefaultEngineComponentErrorCallback();

            m_id = config.GetComponentId();
            m_descriptor = config.GetComponentDescriptor();

            m_apiContextManager = config.GetApiContextManager();
            m_configurationManager = config.GetConfigurationManager();
        }

        /// <summary>
        /// Gets the engine components id. This value is never null.
        /// </summary>
        /// <returns>The engine components id</returns>
        public EngineComponentId GetComponentId()
        {
            return m_id;
        }

        /// <summary>
        /// Gets the engine components descriptor. This value is never null.
        /// </summary>
        /// <returns>The engine components descriptor</returns>
        public EngineComponentDescriptor GetComponentDescriptor()
        {
            return m_descriptor;
        }

        private string GetStateName(States state)
        {
            string sTemp = string.Empty;
            if (m_stateDisplayNames.TryGetValue(state, out sTemp))
            {
                return sTemp;
            }

            return string.Empty;
        }

        private States GetState()
        {
            States state = States.UNKNOWN;
            if (m_semaphore.WaitOne(m_iSemaphoreTimeoutMillis))
            {
                state = m_state;
                m_semaphore.Release();
            }

            return state;
        }

        private void SetState(States newState)
        {
            if (m_semaphore.WaitOne(m_iSemaphoreTimeoutMillis))
            {
                m_state = newState;
                m_semaphore.Release();
            }
        }

        protected void AddEventHandler(OnInitialising handler)
        {
            if (m_semaphore.WaitOne(m_iSemaphoreTimeoutMillis))
            {
                m_onInitialisingHandlers += handler;
                m_semaphore.Release();
            }
        }

        protected void AddEventHandler(OnInitialised handler)
        {
            if (m_semaphore.WaitOne(m_iSemaphoreTimeoutMillis))
            {
                m_onInitialisedHandlers += handler;
                m_semaphore.Release();
            }
        }

        protected void AddEventHandler(OnTerminating handler)
        {
            if (m_semaphore.WaitOne(m_iSemaphoreTimeoutMillis))
            {
                m_onTerminatingHandlers += handler;
                m_semaphore.Release();
            }
        }

        protected void AddEventHandler(OnTerminated handler)
        {
            if (m_semaphore.WaitOne(m_iSemaphoreTimeoutMillis))
            {
                m_onTerminatedHandlers += handler;
                m_semaphore.Release();
            }
        }

        protected void RemoveEventHandler(OnInitialising handler)
        {
            if (m_semaphore.WaitOne(m_iSemaphoreTimeoutMillis))
            {
                m_onInitialisingHandlers -= handler;
                m_semaphore.Release();
            }
        }

        protected void RemoveEventHandler(OnInitialised handler)
        {
            if (m_semaphore.WaitOne(m_iSemaphoreTimeoutMillis))
            {
                m_onInitialisedHandlers -= handler;
                m_semaphore.Release();
            }
        }

        protected void RemoveEventHandler(OnTerminating handler)
        {
            if (m_semaphore.WaitOne(m_iSemaphoreTimeoutMillis))
            {
                m_onTerminatingHandlers -= handler;
                m_semaphore.Release();
            }
        }

        protected void RemoveEventHandler(OnTerminated handler)
        {
            if (m_semaphore.WaitOne(m_iSemaphoreTimeoutMillis))
            {
                m_onTerminatedHandlers -= handler;
                m_semaphore.Release();
            }
        }

        /// <summary>
        /// Initialises the engine component.
        /// </summary>
        public void Initialise()
        {
            if (GetState() != States.CONSTRUCTED)
            {
                m_errorCallback.OnEngineComponentError("A component attempted an illegal state transition.");
                return;
            }

            SetState(States.INITIALISING);
            if (m_onInitialisingHandlers != null)
            {
                m_onInitialisingHandlers.Invoke();
            }
            
            SetState(States.INITIALISED);
            if (m_onInitialisedHandlers != null)
            {
                m_onInitialisedHandlers.Invoke();
            }
        }

        /// <summary>
        /// Terminates the engine component.
        /// </summary>
        public void Terminate()
        {
            if (GetState() != States.INITIALISED)
            {
                m_errorCallback.OnEngineComponentError("A component attempted an illegal state transition.");
                return;
            }

            SetState(States.TERMINATING);
            if (m_onTerminatingHandlers != null)
            {
                m_onTerminatingHandlers.Invoke();
            }

            SetState(States.TERMINATED);
            if (m_onTerminatedHandlers != null)
            {
                m_onTerminatedHandlers.Invoke();
            }

            SetState(States.PENDING_DECONSTRUCTION);
        }
    }
}
