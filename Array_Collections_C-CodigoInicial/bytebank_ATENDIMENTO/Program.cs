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