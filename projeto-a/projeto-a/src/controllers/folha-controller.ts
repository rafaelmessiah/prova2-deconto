import axios from "axios";
import { Request, Response } from "express";
import { Folha } from "../models/folha";
import { FolhaRepository } from "../repositories/folha-repository.";
import { FolhaService } from "../service/folha-service";

const folhaRepository = new FolhaRepository();
const service = new FolhaService();

export class FolhaPagamentoController {
  cadastrar(request: Request, response: Response) {
    
    const folha: Folha = request.body;
    
    folha.bruto = service.calcularSalarioBruto(folha.horas,folha.valor);
    folha.irrf = service.calcularIRRF(folha.bruto);
    folha.inss = service.calcularINSS(folha.bruto);
    folha.fgts = service.calcularFGTS(folha.bruto);
    folha.liquido = service.calcularSalarioLiquido(folha.bruto, folha.irrf, folha.inss);

    const folhas = folhaRepository.cadastrar(folha);

    axios
      .post("http://localhost:5001/api/folha/cadastrar", folha)
      .then((res) => {
        return response.status(200).json(folha);
      })
      .catch((err) => {
        return response.status(500).json(err);
      });

    return response.status(201).json(folhas);
  }
}
