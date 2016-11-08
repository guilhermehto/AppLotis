using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLotis.Validation {
    public class NumericValidationBehavior : Behavior<Entry> {
        protected override void OnAttachedTo(Entry entry) {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry) {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args) {
            double result;
            bool isValid = double.TryParse(args.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }

    public class PlacaValidatorBehavior : Behavior<Entry> {
        protected override void OnAttachedTo(Entry entry) {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry) {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e) {
            ((Entry) sender).TextChanged -= OnEntryTextChanged;
            /*if (e.OldTextValue != null && e.OldTextValue.Length == 3) {
                ((Entry) sender).Text = e.NewTextValue + "-";
            }*/
            if (e.NewTextValue.Length > 7) {
                ((Entry)sender).Text = e.OldTextValue;
            }
            if (e.NewTextValue.Length > 4 &&
                !Regex.IsMatch(e.NewTextValue[e.NewTextValue.Length - 1].ToString(), @"[0-9]")) {
                ((Entry) sender).Text = e.OldTextValue;
            }
            else if (e.NewTextValue.Length < 4 && e.NewTextValue.Length != 0) {
                if (!Regex.IsMatch(e.NewTextValue[e.NewTextValue.Length - 1].ToString(), @"[a-zA-Z]")) {
                    ((Entry) sender).Text = e.OldTextValue;
                }
                else if (Regex.IsMatch(e.NewTextValue[e.NewTextValue.Length - 1].ToString(), @"[a-z]")) {
                    var novoTexto = e.OldTextValue + e.NewTextValue[e.NewTextValue.Length - 1].ToString().ToUpper();
                    ((Entry) sender).Text = novoTexto;
                }
            }

            ((Entry)sender).TextChanged += OnEntryTextChanged;
        }
    }
}
