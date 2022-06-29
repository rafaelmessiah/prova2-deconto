import { Folha } from "../models/folha";

const folhas: Folha[] = [];

export class FolhaRepository {
  cadastrar(folha: Folha) : Folha[] {
    folhas.push(folha);
    return folhas;
  }

  listar() : Folha[] {
    return folhas;
  }
}
