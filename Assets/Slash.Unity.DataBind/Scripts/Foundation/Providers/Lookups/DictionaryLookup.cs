namespace Slash.Unity.DataBind.Foundation.Providers.Lookups
{
    using Slash.Unity.DataBind.Core.Data;
    using Slash.Unity.DataBind.Core.Presentation;

    public class DictionaryLookup : DataProvider
    {
        #region Fields

        /// <summary>
        ///   Default value if key wasn't found in dictionary.
        /// </summary>
        public string DefaultValue;

        public DataBinding Dictionary;

        public DataBinding Key;

        private DataDictionary dataDictionary;

        #endregion

        #region Properties

        public override object Value
        {
            get
            {
                if (this.DataDictionary == null)
                {
                    return this.DefaultValue;
                }

                var key = this.Key.Value;

                object value;
                if (!this.DataDictionary.TryGetValue(key, out value))
                {
                    value = this.DefaultValue;
                }

                return value;
            }
        }

        private DataDictionary DataDictionary
        {
            get
            {
                return this.dataDictionary;
            }
            set
            {
                if (value == this.dataDictionary)
                {
                    return;
                }

                if (this.dataDictionary != null)
                {
                    this.dataDictionary.CollectionChanged -= this.OnDataDictionaryChanged;
                }

                this.dataDictionary = value;

                if (this.dataDictionary != null)
                {
                    this.dataDictionary.CollectionChanged += this.OnDataDictionaryChanged;
                }
            }
        }

        #endregion

        #region Methods

        protected void Awake()
        {
            this.AddBinding(this.Key);
            this.AddBinding(this.Dictionary);
        }

        protected void OnDestroy()
        {
            this.RemoveBinding(this.Key);
            this.RemoveBinding(this.Dictionary);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            this.Dictionary.ValueChanged -= this.OnDictionaryChanged;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            this.Dictionary.ValueChanged += this.OnDictionaryChanged;
            this.DataDictionary = this.Dictionary.GetValue<DataDictionary>();
        }

        protected override void UpdateValue()
        {
            this.OnValueChanged(this.Value);
        }

        private void OnDataDictionaryChanged()
        {
            this.UpdateValue();
        }

        private void OnDictionaryChanged(object newValue)
        {
            this.DataDictionary = this.Dictionary.GetValue<DataDictionary>();
        }

        #endregion
    }
}