using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bytebank_ExportarDados
{
    public static class ExportarDados<T> where T : class
    {
        public static void SalvarDados(string caminho, FormatoArquivos formato, List<T> dados)
        {
            if (string.IsNullOrEmpty(caminho))
            {
                throw new Exception("Caminho não informado");
            }
            if (formato != FormatoArquivos.Xml)
            {
                if (formato != FormatoArquivos.Json)
                {
                    throw new Exception("Formato de não suportado.");
                }
            }
            ExportData(caminho, formato, dados);
        }
        public static void ExportData(string caminho, FormatoArquivos formato, List<T> dados)
        {
            if (formato== FormatoArquivos.Xml)
            {
                var serializar = new XmlSerializer(typeof(List<T>));
                try
                {
                    FileStream fs = new FileStream(caminho + "\\dados.xml", FileMode.Create);
                    using (StreamWriter streamwriter = new StreamWriter(fs))
                    {
                        serializar.Serialize(streamwriter, dados);
                    }
                    Console.WriteLine($"Arquivo salvo em {caminho}");
                }
                catch (Exception excecao)
                {

                    throw new Exception(excecao.Message);
                }
            }
            if (formato == FormatoArquivos.Json)
            {
                string json = JsonConvert.SerializeObject(dados, Newtonsoft.Json.Formatting.Indented);
                try
                {
                    FileStream fs = new FileStream(caminho + "\\dados.json", FileMode.Create);
                    using (StreamWriter streamwriter = new StreamWriter(fs))
                    {
                        streamwriter.WriteLine(json);
                    }
                    Console.WriteLine($"Arquivo salvo em {caminho}");
                }
                catch (Exception excecao)
                {

                    throw new Exception(excecao.Message);
                }
            }
        }
        
        public enum FormatoArquivos
        {
            Xml=1,
            Json=2
        }
    }
}
