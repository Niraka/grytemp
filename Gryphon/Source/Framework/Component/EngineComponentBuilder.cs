using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Gryphon.Framework
{
    public class EngineComponentBuilder
    {
        private readonly IEngineComponentIdGenerator m_idDistributor;
        private readonly Api.ApiContextManager m_apiContextManager;
        private readonly Configuration.ConfigurationManager m_configurationManager;

        public EngineComponentBuilder(EngineComponentBuilderConfig config)
        {
            m_idDistributor = config.GetIdDistributor();
            m_apiContextManager = config.GetApiContextManager();
            m_configurationManager = config.GetConfigurationManager();
        }

        /// <summary>
        /// Attempts to construct an engine component of the given type using the given component specification.
        /// </summary>
        /// <typeparam name="ComponentType"></typeparam>
        /// <param name="constructionInput"></param>
        /// <returns></returns>
        public ComponentType Build<ComponentType>(EngineComponentDescriptor componentDescriptor) where ComponentType : EngineComponent
        {
            Type engineComponentType = typeof(ComponentType);
            Type engineComponentConfigType = typeof(EngineComponentConfig);
            ConstructorInfo[] constructorDetails = engineComponentType.GetConstructors();

            EngineComponentId componentId = m_idDistributor.GenerateId();
            EngineComponentConfig componentConfig = new
                EngineComponentConfig(
                    componentId,
                    componentDescriptor,
                    m_apiContextManager,
                    m_configurationManager);
            object[] parameters = null;

            // Locate a constructor that takes exactly one parameter of the correct type: The internal 
            // config type. If it doesnt exist, throw a tantrum.

            ConstructorInfo constructorToCall = null;
            foreach (ConstructorInfo details in constructorDetails)
            {
                ParameterInfo[] parameterDetails = details.GetParameters();
                if (parameterDetails.Length == 1 && engineComponentConfigType.IsAssignableFrom(parameterDetails[0].ParameterType))
                {
                    constructorToCall = details;
                    parameters = new object[] { componentConfig };
                    break;
                }
            }

            if (constructorToCall == null)
            {
                throw new Exception("Failed to instantiate engine component: No eligible constructor was found.");
            }

            return (ComponentType)constructorToCall.Invoke(parameters);
        }

        public ComponentType Build<ComponentType, UserConfigType>(EngineComponentDescriptor componentDescriptor, UserConfigType derivedConfig) where ComponentType : EngineComponent
        {
            Type engineComponentType = typeof(ComponentType);
            Type engineComponentConfigType = typeof(EngineComponentConfig);
            Type userDerivedConfigType = typeof(UserConfigType);
            ConstructorInfo[] constructorDetails = engineComponentType.GetConstructors();

            EngineComponentId componentId = m_idDistributor.GenerateId();
            EngineComponentConfig componentConfig = new
                EngineComponentConfig(
                    componentId,
                    componentDescriptor,
                    m_apiContextManager,
                    m_configurationManager);
            object[] parameters = null;

            // Locate a constructor that takes exactly two parameters of the correct type: The internal
            // config type and the user config type. If it doesnt exist, throw a tantrum.

            ConstructorInfo constructorToCall = null;
            foreach (ConstructorInfo details in constructorDetails)
            {
                ParameterInfo[] parameterDetails = details.GetParameters();
                if (parameterDetails.Length == 2)
                {
                    if (engineComponentConfigType.IsAssignableFrom(parameterDetails[0].ParameterType) &&
                        userDerivedConfigType.IsAssignableFrom(parameterDetails[1].ParameterType))
                    {
                        constructorToCall = details;
                        parameters = new object[] { componentConfig, derivedConfig };
                        break;
                    }
                    else if (userDerivedConfigType.IsAssignableFrom(parameterDetails[0].ParameterType) &&
                        engineComponentConfigType.IsAssignableFrom(parameterDetails[1].ParameterType))
                    {
                        constructorToCall = details;
                        parameters = new object[] { derivedConfig, componentConfig };
                        break;
                    }
                }
            }

            if (constructorToCall == null)
            {
                throw new Exception("Failed to instantiate engine component: No eligible constructor was found.");
            }

            return (ComponentType)constructorToCall.Invoke(parameters);
        }
    }
}
