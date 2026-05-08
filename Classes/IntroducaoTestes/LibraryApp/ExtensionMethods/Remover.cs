using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroducaoTestes.LibraryApp.ExtensionMethods
{
    public static class RemoverExtensions
    {
        public static RemoverString Remover(this string source, string substring = null)
        {
            return new RemoverString(source, substring);
        }
    }

    public class RemoverString
    {
        private readonly string _source;
        private readonly string _substring;
        internal RemoverString(string source, string substring)
        {
            _source = source;
            _substring = substring;
        }
            
        public static implicit operator string(RemoverString removerString)
        {
            return removerString.ToString();
        }

        public override string ToString()
        {
            if (_substring != null)
            {
                int posicaoInicialDaSubstring = _source.IndexOf(_substring);
                return _source.Substring(posicaoInicialDaSubstring + _substring.Length);
            }
            return string.Empty;
        }
    }
}