using System.Globalization;
using System.Text;

namespace ControlsUI
{
    /// <summary>
    /// Numeric text box
    /// </summary>
    public class NumTextBox : TextBox
    {
        /// <summary>
        /// Mode
        /// </summary>
        public enum MODE
        {
            /// <summary>
            /// Binary
            /// </summary>
            BIN,

            /// <summary>
            /// Decimal
            /// </summary>
            DEC,

            /// <summary>
            /// Hexadecimal
            /// </summary>
            HEX
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public NumTextBox()
        {
            Mode = MODE.DEC;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mode">mode</param>
        public NumTextBox(MODE mode)
        {
            Mode = mode;
        }

        /// <summary>
        /// Mode
        /// </summary>
        public MODE Mode
        {
            get;
            set;
        } = MODE.DEC;

        /// <summary>
        /// Minimal Value
        /// </summary>
        public long MinValue
        {
            get;
            set;
        }

        /// <summary>
        /// Maximal Value
        /// </summary>
        public long MaxValue
        {
            get;
            set;
        }

        long _value = 0;
        /// <summary>
        /// Value
        /// </summary>
        public long Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            long value = _value;
            bool parse_res = false;
            string text = this.Text;
            byte[] bytes = Encoding.ASCII.GetBytes(text);

            switch (Mode)
            {
                case MODE.BIN:
                    {
                        parse_res = long.TryParse(bytes, System.Globalization.NumberStyles.BinaryNumber, CultureInfo.InvariantCulture, out value);
                    }
                    break;
                case MODE.DEC:
                    {
                        parse_res = long.TryParse(bytes, System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out value);
                    } break;
                case MODE.HEX:
                    {
                        parse_res = long.TryParse(bytes, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value);
                    } break;
            }



            if (value > MaxValue)
            {
                value = MaxValue;
            }

            if (value < MinValue)
            {
                value = MinValue;
            }

            if (parse_res)
            {
                _value = value;
            }

            switch (Mode)
            {
                case MODE.BIN:
                    {
                        this.Text = _value.ToString("B");
                    }
                    break;
                case MODE.DEC:
                    {
                        this.Text = _value.ToString();
                    }
                    break;
                case MODE.HEX:
                    {
                        this.Text = _value.ToString("X");
                    }
                    break;
            }
            base.OnLostFocus(e);
        }
    }
}
