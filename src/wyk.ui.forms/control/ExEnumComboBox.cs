using System.Windows.Forms;
using wyk.basic;

namespace wyk.ui
{
    public class ExEnumComboBox<TEnum> : ComboBox
    {
        public ExEnumComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            _all_names = EnumUtil.allNames<TEnum>();
            _all_displays = EnumUtil.allDisplays<TEnum>();
            loadItemList();
        }

        #region private properties
        private TEnum _current_value = default(TEnum);
        private string[] _all_names = null;
        private string[] _all_displays = null;
        private bool _show_name_in_item = false;
        #endregion

        #region public properties
        public TEnum CurrentValue
        {
            get => _current_value;
            set
            {
                _current_value = value;
                selectCurrentValue();
            }
        }

        public string CurrentName
        {
            get => _current_value.ToString();
            set
            {
                _current_value = value.enumFromName<TEnum>();
                selectCurrentValue();
            }
        }
        public string CurrentDisplay
        {
            get => EnumUtil.getDisplay<TEnum>(_current_value.ToString());
            set
            {
                _current_value = value.enumFromDisplay<TEnum>();
                selectCurrentValue();
            }
        }
        public bool ShowNameInItem
        {
            get => _show_name_in_item;
            set
            {
                _show_name_in_item = value;
                loadItemList();
            }
        }
        #endregion

        #region private functions
        private void selectCurrentValue()
        {
            var idx = -1;
            var cur = _current_value.ToString();
            for (int i = 0; i < _all_names.Length; i++)
            {
                if (_all_names[i] == cur)
                {
                    idx = i;
                    break;
                }
            }
            SelectedIndex = idx;
        }
        private void loadItemList()
        {
            Items.Clear();
            try
            {
                if (_show_name_in_item)
                    Items.AddRange(_all_names);
                else
                    Items.AddRange(_all_displays);
            }
            catch { }
        }
        #endregion
    }
}
