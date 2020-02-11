using System;
using System.Collections.Generic;
using System.Text;
using Gryphon.Framework.Component;
using Gryphon.Framework.Requirement;
using Gryphon.Tools;

namespace Gryphon.Framework
{
    public class Engine
    {
        public enum Profiles
        {
            DETECT,
            DEBUG,
            RELEASE
        }
        
        private static Engine m_instance;
        private EngineComponentManager m_engineComponentManager;
        private readonly Api.ApiManager m_apiManager;
        private readonly Api.ApiBuilder m_apiBuilder;
        private readonly IRequirementManager m_requirementManager;
        private readonly Configuration.ConfigurationManager m_configurationManager;
        private readonly Integration.IntegrationManager m_integrationManager;

        private Engine(IEngineConfigProvider configProvider)
        {
            if (configProvider == null)
            {
                configProvider = new ReleaseEngineConfigurationProvider();
            }

            m_requirementManager = new RequirementManager(
                new RequirementManagerConfig());
            m_integrationManager = new Integration.IntegrationManager(
                new Integration.IntegrationManagerConfig());
            m_configurationManager = new Configuration.ConfigurationManager(
                new Configuration.ConfigurationManagerConfig(
                    new DefaultEncryptor(),
                    null,
                    null));

            // Register the configuration for the engine
            m_configurationManager.AddConfigurationProvider(
                new EngineConfigurationProvider());
            m_configurationManager.LoadConfiguration();

            m_apiBuilder = new Api.ApiBuilder();
            Api.ApiContextBuilder apiContextBuilder = new Api.ApiContextBuilder(m_integrationManager);
            m_apiManager = new Api.ApiManager(
                 new Api.ApiManagerConfig(
                     m_apiBuilder,
                     apiContextBuilder));

            EngineComponentIdGenerator idGenerator = new EngineComponentIdGenerator();
            EngineComponentDescriptorValidator engineComponentDescriptorValidator = new EngineComponentDescriptorValidator();
            EngineComponentBuilder engineComponentBuilder = new EngineComponentBuilder(
                new EngineComponentBuilderConfig(
                    idGenerator,
                    m_apiManager.GetContextManager(),
                    m_configurationManager));

            m_engineComponentManager = new EngineComponentManager(
                new EngineComponentManagerConfig(
                    engineComponentBuilder,
                    engineComponentDescriptorValidator));
        }

        /// <summary>
        /// Retrieves the single Engine instance. Returns null when unintialised.
        /// </summary>
        /// <returns>A reference to the single engine instance, or null</returns>
        public static Engine GetInstance()
        {
            return m_instance;
        }

        /// <summary>
        /// Initialises the engine.
        /// </summary>
        /// <param name="configProvider">A configuration provider for the Gryphon engine</param>
        /// <exception cref="Exception">Thrown when attempting to initialise an initialised engine</exception>
        public static void Initialise(IEngineConfigProvider configProvider)
        {
            if (m_instance == null)
            {
                try
                {
                    m_instance = new Engine(configProvider);
                    m_instance.OnInitialise();
                }
                catch (Exception e)
                {
                    m_instance = null;
                    throw new Exception("Engine initialisation failed.", e);
                }
            }
            else
            {
                throw new Exception("Refused to initialise the engine because it was already initialised.");
            }
        }

        /// <summary>
        /// Terminates the engine. All modules are shut down and all resources are freed.
        /// </summary>
        /// <exception cref="Exception">Thrown when attempting to terminate an uninitialised engine</exception>
        public static void Terminate()
        {
            if (m_instance != null)
            {
                m_instance.OnTerminate();
                m_instance = null;
            }
            else
            {
                throw new Exception("Refused to terminate the engine because it was already terminated.");
            }
        }

        public void AddConfigurationProvider(Configuration.IConfigurationProvider provider)
        {
            m_configurationManager.AddConfigurationProvider(provider);
        }

        public int AddIntegrationSource(Integration.IntegrationSourceDescriptor descriptor)
        {
            return m_integrationManager.AddIntegrationSource(descriptor);
        }

        public int AddApiContext(Api.ApiConfig config)
        {
            return m_apiManager.AddApiContext(config);
        }

        public void RemoveApiContext(int iApiContextId)
        {
            m_apiManager.RemoveApiContext(iApiContextId);
        }

        public Api.Api CreateApi(int iApiContextId)
        {
            return m_apiManager.CreateApi(iApiContextId);
        }

        private void OnInitialise()
        {
            m_engineComponentManager.InitialiseComponents();
            
            
            // Evaluate the engines' requirements. The engine configuration provides an option to bypass this
            // step for debugging and development purposes.
            if (true)
            {
                RequirementEvaluation evaluation = m_requirementManager.AreRequirementsMet(false);
                if (!evaluation.HasPassed())
                {
                    string sMessage = "Engine requirements were not met. ";
                    List<string> details = evaluation.GetDetails();
                    if (details.Count > 0)
                    {
                        sMessage += "Details: ";
                        sMessage += Environment.NewLine;
                        sMessage += Environment.NewLine;
                        sMessage += "> " + details[0];

                        for (int i = 1; i < details.Count; ++i)
                        {
                            sMessage += Environment.NewLine;
                            sMessage += "> " + details[i];
                        }
                    }
                    else
                    {
                        sMessage += "No details were provided. You should definitely berate the " +
                            "developer for this.";
                    }

                    throw new Exception(sMessage);
                }
            }
        }

        private void OnTerminate()
        {
            m_engineComponentManager.TerminateComponents();
        }
    }
}
