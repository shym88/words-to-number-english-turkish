using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Calculator.Model
{
    public class ErrorLookup
    {

        private static Dictionary<string, Dictionary<string, string>> errorLookup =
        new Dictionary<string, Dictionary<string, string>>
        {
            {
                "en-001",
                new Dictionary<string, string>
                {
                    {"err-00","An error occurred. Please try again."},
                    {"err-01","Please enter the parameters first."},
                    {"err-02","The strings contain unknown words."},
                    {"err-03","Syntax error."},
                    {"err-04","Unable to determine ui language."},
                    {"err-05","Cannot divide by zero."}
                }
            },
            {
                "tr",
                new Dictionary<string, string>
                {
                    {"err-00","Hata oluştu. Lütfen tekrar deneyin."},
                    {"err-01","Lütfen parametreleri giriniz."},
                    {"err-02","Parametereler geçersiz kelime içermektedir."},
                    {"err-03","Söz dizimi hatalı."},
                    {"err-04","Kullanıcı arayüz dili belirlenemiyor."},
                    {"err-05","Sıfır ile bölme işlemi yapılamaz"}
                }
            },

        };

        private static string GetError(string errCode, string culture)
        {
            
            if (errorLookup[culture].ContainsKey(errCode))
                return errorLookup[culture][errCode];
            else
                return errorLookup[culture]["err-00"];
        }
        public static void ShowError(string errCode)
        {
            MessageBox.Show(GetError(errCode, Thread.CurrentThread.CurrentUICulture.Name), null, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
