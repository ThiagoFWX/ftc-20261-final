public class ConfiguracaoInstantanea
{
    public string estado { get; set; }
    public string entradaRestante { get; set; }
    public string conteudoPilha { get; set; }

    public ConfiguracaoInstantanea(string estado, string entradaRestante, Stack<char> pilha)
    {
        this.estado = estado;
        this.entradaRestante = entradaRestante;

        char[] pilhaArr = pilha.ToArray();
        Array.Reverse(pilhaArr);
        this.conteudoPilha = new string(pilhaArr);
    }

    public override string ToString()
    {
        return $"Estado: {this.estado} | Entrada: '{this.entradaRestante}' | Pilha: [{this.conteudoPilha}]";
    }
}