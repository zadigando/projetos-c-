using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximoItem = 0;

        public ListaDeContasCorrentes(int tamanhoInicial=5)
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar(ContaCorrente item)
        {
            VerificaTamanho(_proximoItem + 1);
            Console.WriteLine($"Salvando item na posicao: {_proximoItem}");
            _itens[_proximoItem] = item;
            _proximoItem++;

        }

        private void VerificaTamanho(int tamanhoNecessario)
        {
            if(_itens.Length >= tamanhoNecessario)
            {
                return;
            }
            Console.WriteLine("Aumentando capacidade da lista!");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];
            for(int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
            }
            _itens = novoArray;
        }

        public ContaCorrente MaiorSaldo()
        {
            ContaCorrente conta = null;
            double maiorValor = 0;
            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] != null)
                {
                    if(maiorValor < _itens[i].Saldo)
                    {
                        maiorValor = _itens[i].Saldo;
                        conta = _itens[i];
                    }
                }
            }
            return conta;
        }

        public void Remover(ContaCorrente conta)
        {
            int IndiceItem = -1;
            for (int i = 0; i < _proximoItem; i++)
            {
                ContaCorrente contaAtual = _itens[i];
                if (contaAtual == conta)
                {
                    IndiceItem = i;
                    break;
                }
            }
            for (int i = 0; i < _proximoItem-1; i++)
            {
                _itens[i] = _itens[i + 1];
            }
            _proximoItem--;
            _itens[_proximoItem] = null;
        }
        public void ExibeLista()
        {
            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] != null)
                {
                    var conta = _itens[i];
                    Console.WriteLine($" Indice[{i}] = Conta:{conta.Conta} - N° da Agência: {conta.Numero_agencia}");
                }
            }
        }

        public ContaCorrente RecuperarItemIndice(int indice)
        {
            if (indice < 0 || indice >= _proximoItem)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public int Tamanho
        {
            get
            {
                return _proximoItem;
            }
        }

        public ContaCorrente this[int indice]
        {
            get
            {
                return RecuperarItemIndice(indice);
            }
        }
    }

}
