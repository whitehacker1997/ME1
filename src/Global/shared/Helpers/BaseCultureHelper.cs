using Global.Configs;
using Global.Models;
using Global.shared.Models;
using Newtonsoft.Json;
using System.Dynamic;

namespace Global.Helpers
{
    public abstract class BaseCultureHelper
        : ICultureHelper
    {
        public BaseCultureHelper(CultureConfig config)
        {
            this.config = config;
            localizeDict = new();
            Init();
        }
        private readonly CultureConfig config;

        private readonly Dictionary<string, Dictionary<string, LocalizedModel>>
                localizeDict;

        private IReadOnlyCollection<CultureModel> cultures;

        private CultureModel currentCulture;

        private CultureModel defaultCulture;
        protected abstract IEnumerable<CultureModel> GetCulture();
        protected abstract CultureModel GetDefaultCulture();
        protected abstract CultureModel GetCurrentCulture();
        public IReadOnlyCollection<CultureModel> Cultures
        {
            get
            {
                if (cultures == null)
                    cultures = Array.AsReadOnly(GetCulture()
                                                    .ToArray());

                return cultures;
            }
        }
        public CultureModel CurrentCulture
        {
            get
            {
                if (currentCulture == null)
                    currentCulture = GetCurrentCulture();

                return currentCulture;
            }
        }
        public CultureModel DefaultCulture
        {
            get
            {
                if (defaultCulture == null)
                    defaultCulture = GetDefaultCulture();

                return defaultCulture;
            }
        }
        private void Init()
        {
            try
            {
                foreach (var (text, dictionary) in from data in JsonConvert.DeserializeObject<ExpandoObject>(File.ReadAllText(this.config.JsonFilePath)) select (data.Key,
                                                        (IDictionary<string, object>)data.Value))
                {
                    if (string.IsNullOrEmpty(text))
                        continue;

                    Dictionary<string, LocalizedModel> dictionary3 
                        = (localizeDict[text] = new());
                    
                    string text2 = null;
                    
                    if (dictionary.ContainsKey("ErrorCode"))
                        text2 = (string)dictionary[text2];

                    foreach (CultureModel culture in Cultures)
                    {
                        if (dictionary.ContainsKey(culture.Code))
                        {
                            LocalizedModel localizedModel = new LocalizedModel
                            {
                                Culture = culture,
                                ErrorCode = text2
                            };
                            if (dictionary[culture.Code] is string)
                                localizedModel.Text 
                                    = (string)dictionary[culture.Code];
                            else if (dictionary[culture.Code] is ExpandoObject)
                                    _ = (IDictionary<string, object>)dictionary[culture.Code];
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

    }
}
