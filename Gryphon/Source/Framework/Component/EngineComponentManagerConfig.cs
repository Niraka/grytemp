using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Framework.Component
{
    public class EngineComponentManagerConfig
    {
        private readonly EngineComponentBuilder m_builder;
        private readonly IEngineComponentDescriptorValidator m_descriptorValidator;

        public EngineComponentManagerConfig()
        {
            m_builder = null;
            m_descriptorValidator = null;
        }

        public EngineComponentManagerConfig(EngineComponentBuilder builder, 
            IEngineComponentDescriptorValidator descriptorValidator)
        {
            m_builder = builder;
            m_descriptorValidator = descriptorValidator;
        }

        public EngineComponentBuilder GetEngineComponentBuilder()
        {
            return m_builder;
        }

        public IEngineComponentDescriptorValidator GetDescriptorValidator()
        {
            return m_descriptorValidator;
        }
    }
}
