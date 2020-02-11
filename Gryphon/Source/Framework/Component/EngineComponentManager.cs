using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Component
{
    public class EngineComponentManager
    {
        private readonly EngineComponentBuilder m_builder;
        private readonly IEngineComponentDescriptorValidator m_descriptorValidator;
        private readonly List<EngineComponent> m_engineComponents;
        
        public EngineComponentManager(EngineComponentManagerConfig config)
        {
            m_builder = config.GetEngineComponentBuilder();
            m_descriptorValidator = config.GetDescriptorValidator();
            m_engineComponents = new List<EngineComponent>();
        }
        
        public ComponentType CreateComponent<ComponentType>(EngineComponentDescriptor componentDescriptor) where ComponentType : EngineComponent
        {
            if (m_builder == null)
            {
                return null;
            }

            // The descriptor validator is optional. If its provided, use it. If it isnt, assume the given descriptor
            // is valid and proceeed.
            if (m_descriptorValidator != null)
            {
                Tools.ValidationResult validationResult = m_descriptorValidator.Validate(componentDescriptor);
                if (!validationResult.WasValid())
                {
                    return null;
                }
            }

            ComponentType component = m_builder.Build<ComponentType>(componentDescriptor);
            if (component == null)
            {
                return null;
            }

            m_engineComponents.Add(component);
            return component;
        }

        public ComponentType CreateComponent<ComponentType, DerivedConfigType>(EngineComponentDescriptor componentDescriptor, DerivedConfigType derivedConfig) where ComponentType : EngineComponent
        {
            if (m_builder == null)
            {
                return null;
            }

            // The descriptor validator is optional. If its provided, use it. If it isnt, assume the given descriptor
            // is valid and proceeed.
            if (m_descriptorValidator != null)
            {
                Tools.ValidationResult validationResult = m_descriptorValidator.Validate(componentDescriptor);
                if (!validationResult.WasValid())
                {
                    return null;
                }
            }

            ComponentType component = m_builder.Build<ComponentType, DerivedConfigType>(componentDescriptor, derivedConfig);
            if (component == null)
            {
                return null;
            }

            m_engineComponents.Add(component);
            return component;
        }

        public void DestroyComponent(EngineComponentId id)
        {
            foreach (EngineComponent component in m_engineComponents)
            {
                if (component.GetComponentId() == id)
                {
                    m_engineComponents.Remove(component);
                    return;
                }
            }
        }

        public void InitialiseComponents()
        {
            foreach (EngineComponent component in m_engineComponents)
            {
                component.Initialise();
            }
        }

        public void TerminateComponents()
        {
            foreach (EngineComponent component in m_engineComponents)
            {
                component.Terminate();
            }
        }

        public List<EngineComponentId> GetComponentIds()
        {
            List<EngineComponentId> ids = new List<EngineComponentId>();
            foreach (EngineComponent component in m_engineComponents)
            {
                ids.Add(component.GetComponentId());
            }

            return ids;
        }

        public List<EngineComponentDescriptor> GetComponentDescriptors()
        {
            List<EngineComponentDescriptor> descriptors = new List<EngineComponentDescriptor>();
            foreach (EngineComponent component in m_engineComponents)
            {
                descriptors.Add(component.GetComponentDescriptor());
            }

            return descriptors;
        }
    }
}
