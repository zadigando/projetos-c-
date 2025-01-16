using bytebank.Modelos.Conta;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");



void TestaArray()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 20;
    idades[2] = 42;
    idades[3] = 70;
    idades[4] = 20;

    Console.WriteLine($"Tamanho do Array: {idades.Length}");

    int acumulador = 0;
    for ( int i = 0; i < idades.Length; i++ )
    {
        int idade = idades[i];
        Console.WriteLine($"Na posicao {i} temos o valor {idade}");
        acumulador+= idade;
    }
    int media = acumulador/idades.Length;
    Console.WriteLine($"A media do vetor Idades e de: {media}");
}

//TestaArray();

void BuscaPalavra()
{
    string[] conjuntoPalavras = new string[5];

    for ( int i = 0; i < conjuntoPalavras.Length; i++ )
    {
        Console.Write($"Digite a palavra numero {i}");
        var palavra = Console.ReadLine();
        conjuntoPalavras[i] = palavra;
    }

    Console.WriteLine("Digite a palavra que deseja buscar");
    var busca = Console.ReadLine();

    foreach (string palavra in conjuntoPalavras)
    {
        if(palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada! Sua palavra e: {busca}");
        }
    }
}

//BuscaPalavra();

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(4.3, 0);
amostra.SetValue(3.7, 1);
amostra.SetValue(5.1, 2);
amostra.SetValue(4.8, 3);
amostra.SetValue(3.9, 4);

void TestaMediana(Array array)
{
    if(( array == null ) || (array.Length == 0 ))
    {
        Console.WriteLine("Ta vazio ou nulo");
        return;
    }
    else
    {
        double[] arrayOrdenado = (double[])array.Clone();
        Array.Sort(arrayOrdenado);

        int tamanho = arrayOrdenado.Length;
        int meio = tamanho / 2;

        double mediana = (tamanho % 2 != 0) ? arrayOrdenado[meio] : (arrayOrdenado[meio] + arrayOrdenado[meio-1])/2;
        Console.WriteLine($"Entao vai tomando a mediana: {mediana}");
    }
}

//TestaMediana(amostra);

double[] amostraD = new double[5];
amostraD.SetValue(4.3, 0);
amostraD.SetValue(3.7, 1);
amostraD.SetValue(5.1, 2);
amostraD.SetValue(4.8, 3);
amostraD.SetValue(3.9, 4);

void AcharMedia(double[] amostra)
{
    double acumuladorNumeros = 0;
    double qtdVet = 0;
    double media = 0;
    if(( amostra == null ) || (amostra.Length == 0 ))
    {
        Console.WriteLine("bagui nao serve"); 
        return;
    }
    else
    {
        for (int i = 0; i < amostra.Length; i++)
        {
            acumuladorNumeros = acumuladorNumeros + amostra[i];
            qtdVet++;
        }
    }

    media = (acumuladorNumeros / qtdVet);

    Console.WriteLine($"A media e {media}");
}

//AcharMedia(amostraD);

void TestaArrayDeContaCorrents()
{
    ContaCorrente[] listaDeContas = new ContaCorrente[]
    {
        new ContaCorrente(874, "5679787-A"),
        new ContaCorrente(874, "4456668-B"),
        new ContaCorrente(874, "7781438-C")
    };

    for (int i = 0;i < listaDeContas.Length; i++)
    {
        ContaCorrente contaAtual = listaDeContas[i];
        Console.WriteLine($"Indice {i} - Conta {contaAtual.Conta}");
    }
}

TestaArrayDeContaCorrents();