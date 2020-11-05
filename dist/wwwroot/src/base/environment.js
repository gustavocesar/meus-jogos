export default class Environment {
  constructor() {
    this.api = "https://localhost:5001/v1";

    //endpoints
    this.jogos = "jogos";
    this.amigos = "amigos";
    this.emprestimos = "emprestimos";
    this.login = "auth/login";
  }
}
