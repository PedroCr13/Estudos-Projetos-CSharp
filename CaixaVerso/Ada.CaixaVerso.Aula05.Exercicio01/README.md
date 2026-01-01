# Simulador bancário - Projeto C#

Este projeto foi desenvolvido como um dos exercícios do curso **Formação Caixa Verso - ADA** nivel 1 (fundamentos).  
O objetivo é aplicar **Programação Orientada a Objetos (POO)** com foco em **Encapsulamento**, simulando operações básicas de um banco.

---

## Enunciado da atividade
Criar a classe **ContaBancaria** aplicando rigorosamente o **Encapsulamento** para garantir a integridade dos dados:

- Atributos privados: `_numeroConta` e `_saldo`.
- Construtor obrigatório: inicializa a conta com número e saldo zero.
- Acesso aos dados via **Propriedades**.
- Alterações no saldo apenas por **Métodos públicos**:
  - `Depositar(valor)`
  - `Sacar(valor)`
- Métodos devem validar:
  - Se o valor é positivo.
  - Se há saldo suficiente para saque.

---

## Funcionalidades implementadas
- Abrir nova conta.
- Realizar depósito.
- Realizar saque.
- Consultar saldo.
- Encerrar o sistema.

---

## Tecnologias utilizadas
- **C#**
- **.NET Framework / Console Application**
- Paradigma: **POO (Encapsulamento)**

---

## Como executar
1. Clone este repositório:
   ```bash
   git clone https://github.com/SEU_USUARIO/NOME_REPOSITORIO.git