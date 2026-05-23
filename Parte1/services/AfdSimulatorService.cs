using System;

public class AfdSimulatorService
{
	public AFD afdJson { get; set; }
	public Estado estadoAtual { get; set; }
	public List<Estado> rastro { get; set; }
    public AfdSimulatorService(AFD afdJson, Estado estadoAtual, List<Estado> rastro)
	{
		this.afdJson = afdJson;
		this.estadoAtual = estadoAtual;
		this.rastro = rastro;
    }
}
