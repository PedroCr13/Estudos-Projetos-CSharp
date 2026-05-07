using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroducaoTestes.LibraryApp.ExtensionMethods
{
    public static class RemoverExtensions
    {
        public static RemoverString Remover(this string source)
        {
            return new RemoverString(source);
        }
    }

    public class RemoverString
    {
        private readonly string _source;
        internal RemoverString(string source)
        {
            _source = source;
        }
            
        public static implicit operator string(RemoverString removerString)
        {
            return removerString.ToString();
        }

        public override string ToString()
        {
            return _source != null ? string.Empty : null;
        }
    }
}