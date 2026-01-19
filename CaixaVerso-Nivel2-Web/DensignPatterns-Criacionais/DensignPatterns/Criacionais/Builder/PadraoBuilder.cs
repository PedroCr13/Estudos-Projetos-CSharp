/*  Anotações:
 *  
 *  Padrão Builder: Padrão criacional que permite construir objetos padronizados "passo a passo"
    
    Definição: 

    O Builder é um padrão de projeto criacional que permite a você construir objetos complexos passo a passo.
    O padrão permite que você produza diferentes tipos e representações de um objeto usando o mesmo código de construção. 

    InterfaceUsuario é o objeto complexo
    - Cada tipo de cliente possui uma interface diferente
    - Cada Builder define quais telas serão adicionadas

    O Diretor (DiretorInterface):
    - Controla a ordem de construção
    - Não conhece os detalhes de cada Builder
*/

namespace Ada.DesignPatterns.Builder
{
    public class InterfaceUsuario
    {
        public List<string> Telas { get; private set; }

        public InterfaceUsuario()
        {
            Telas = new List<string>();
        }

        public void AdicionarTela(string tela)
        {
            Telas.Add(tela);
        }

        public void MostrarInterface()
        {
            Console.WriteLine("Telas disponíveis:");
            foreach (var tela in Telas)
            {
                Console.WriteLine(tela);
            }
        }
    }

    public abstract class InterfaceBuilder
    {
        protected InterfaceUsuario interfaceUsuario;

        public void CriarNovaInterface()
        {
            interfaceUsuario = new InterfaceUsuario();
        }

        public InterfaceUsuario PegarInterface()
        {
            return interfaceUsuario;
        }

        public abstract void ConstruirTelasIniciais();
        public abstract void ConstruirTelasEspeciais();
    }

    public class ClientePadraoBuilder : InterfaceBuilder
    {
        public override void ConstruirTelasIniciais()
        {
            interfaceUsuario.AdicionarTela("inicial");
        }

        public override void ConstruirTelasEspeciais()
        {
            // sem telas iniciais para cliente padrão
        }
    }

    public class ClienteVipBuilder : InterfaceBuilder
    {
        public override void ConstruirTelasIniciais()
        {
            interfaceUsuario.AdicionarTela("inicial");
        }

        public override void ConstruirTelasEspeciais()
        {
            interfaceUsuario.AdicionarTela("Beneficios");
        }
    }

    public class ClienteConsultorBuilder : InterfaceBuilder
    {
        public override void ConstruirTelasIniciais()
        {
            interfaceUsuario.AdicionarTela("inicial");
        }

        public override void ConstruirTelasEspeciais()
        {
            interfaceUsuario.AdicionarTela("Beneficios");
            interfaceUsuario.AdicionarTela("Parceiros");
        }
    }

    public class DiretorInterface
    {
        public InterfaceUsuario MostarInterface(InterfaceBuilder builder)
        {
            builder.CriarNovaInterface();
            builder.ConstruirTelasIniciais();
            builder.ConstruirTelasEspeciais();
            return builder.PegarInterface();
        }
    }
}