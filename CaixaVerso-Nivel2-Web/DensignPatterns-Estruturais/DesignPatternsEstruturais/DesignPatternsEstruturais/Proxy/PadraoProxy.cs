using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Padrão estrutural Proxy: permite fornecer um substituto ou um espaço reservado
    para outro objeto
    Um proxy controla o acesso ao objeto original, permitindo fazer algo antes ou depois
    do pedido chegar ao objeto original

    um intermediário para um objeto
  
    exemplo: um cache local de um banco de dados: solicita a informação, se existir no cache locaa retorna, 
    se não busca no banco o dado original, o cache funciona como um proxy
 
*/

namespace DesignPatternsEstruturais.Proxy
{
    public interface IDocumento
    {
        void MostrarDocumento(string nomeUsuario);
    }

    public class DocumentoReal : IDocumento
    {
        private string conteudo;
        public DocumentoReal(string conteudo)
        { 
            this.conteudo = conteudo;
            CarregarDocumento();
        }

        private void CarregarDocumento()
        {
            Console.WriteLine("Carregando documento...");
        }

        public void MostrarDocumento(string nomeUsuario)
        { 
            Console.Write($"Documento para {nomeUsuario}: {conteudo}");
        }
    }

    public class ProxyDocumento : IDocumento
    {
        private DocumentoReal documentoReal;
        private string conteudo;
        private PermissaoUsuario permissoes;

        public ProxyDocumento(string conteudo, PermissaoUsuario permissoes)
        { 
            this.conteudo = conteudo;
            this.permissoes = permissoes;
        }

        public void MostrarDocumento(string nomeUsuario)
        {
            if (permissoes.TemPermissao(nomeUsuario))
            {
                if (documentoReal == null)
                {
                    documentoReal = new DocumentoReal(conteudo);
                }
                documentoReal.MostrarDocumento(nomeUsuario);
            }
            else 
            {
                Console.WriteLine($"\nAcesso negado para o usuário {nomeUsuario}");
            }
        }
    }

    public class PermissaoUsuario
    {
        public bool TemPermissao(string nomeUsuario) 
        {
            if (nomeUsuario.Equals("admin"))
                return true;
            else
                return false;
        }
    }
}
