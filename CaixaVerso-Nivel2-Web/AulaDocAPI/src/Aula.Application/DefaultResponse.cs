using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Application
{
    // Resposta padrão para todos os Use Cases
    // <T> genérico
    public class DefaultResponse<T>
    {
        public bool Success { get; set; }
        public IEnumerable<string>? Messages { get; set; } // lista
        public T? Data { get; set; }

        public DefaultResponse(IEnumerable<string> messages)
        {
            Messages = messages;
            Success = false;
            Data = default(T);
        }

        public DefaultResponse(string message)
        {
            Messages = new List<string> { message };
            Success = false;
            Data = default(T);
        }

        public DefaultResponse(T data)
        {
            Data = data;
            Success = true;
            Messages = null;
        }
    }
}
