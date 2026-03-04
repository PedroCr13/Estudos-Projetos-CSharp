using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    TDD: Test Domain Development
    
    Escrever primeiro o teste para depois escrever o código que será testado
    Abordagem enfatiza a criação do teste antes do código funcional
 
    Teste Falha > Desenvolve código > Passa no teste

    3 etapas: 
    - Red: escrever o teste e assistir ele falhar
    - Green: Escrever o mínimo do código para passar no teste (o essencial)
    - Refactor: Melhorar o código, retornando a etapa red, reiniciand o ciclo até ter a versão final.

    baby steps: pequenas melhorias (refatoração e teste novamente)
*/

namespace TDDDemo.Test
{
    public class GiraListaTest
    {
        [Fact]
        public void DeveMoverOPrimeiroItemParaOFinalNumaListaCom4Itens()
        { 
            // arrange
            List<int> lista = new List<int> { 10, 15, 20, 30 };
            GiraLista gira = new GiraLista();

            // Act
            var result = gira.Girar(lista);

            // Assert
            Assert.Equal(15, result[0]);
            Assert.Equal(4, result.Count);
        }
    }
}
