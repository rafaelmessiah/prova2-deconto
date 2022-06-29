export class FolhaService {
    calcularSalarioBruto(horas: number, valor: number): number {
        return horas * valor;
      }
     
      calcularIRRF(bruto: number): number {
        if (bruto <= 1903.98) {
          return 0;
        } else if (bruto <= 2826.65) {
          return bruto * 0.075 - 142.8;
        } else if (bruto <= 3751.05) {
          return bruto * 0.15 - 354.8;
        } else if (bruto <= 4664.68) {
          return bruto * 0.225 - 636.13;
        }
        return bruto * 0.275 - 869.39;
      }
     
      calcularINSS(bruto: number): number {
        if (bruto <= 1693.72) {
          return bruto * 0.08;
        } else if (bruto <= 2822.9) {
          return bruto * 0.09;
        } else if (bruto <= 5645.8) {
          return bruto * 0.11;
        }
        return 621.03;
      }
     
      calcularFGTS(bruto: number): number {
        return bruto * 0.08;
      }
     
      calcularSalarioLiquido(bruto: number, irrf: number, inss: number): number {
        return bruto - irrf - inss;
      }
}
  