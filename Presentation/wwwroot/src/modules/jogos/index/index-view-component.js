import JogoService from "../../../services/jogos.service.js";

export default class IndexViewComponent {
  constructor() {
    this.loadJogos();
  }

  loadJogos() {
    JogoService.getJogos().then((jogos) => {
      console.log(jogos);
    });
  }
}
