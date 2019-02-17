using System;
using Highlight.Configuration;
using Highlight.Engines;
using Highlight.Patterns;

namespace Highlight
{
    public class Highlighter
    {
        public IEngine Engine { get; set; }
        public IConfiguration Configuration { get; set; }

        public Highlighter(IEngine engine, IConfiguration configuration)
        {
            Engine = engine;
            Configuration = configuration;
        }

        public Highlighter(IEngine engine)
            : this(engine, new DefaultConfiguration())
        {
        }

        public string Highlight(string definitionName, string input)
        {
            if (definitionName == null)
            {
                throw new ArgumentNullException("definitionName");
            }
            Definition definition = null;
            if (Configuration.Definitions.ContainsKey(definitionName))
            {
                definition = Configuration.Definitions[definitionName];
            }
            else
            {
                definition = Configuration.Definitions["None"];
            }
            return Engine.Highlight(definition, input);
        }
    }
}