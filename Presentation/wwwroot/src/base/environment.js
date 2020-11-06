export default class Environment {
  constructor() {
    this.api = "http://localhost:5000/v1";

    //endpoints
    this.jogos = "jogos";
    this.amigos = "amigos";
    this.emprestimos = "emprestimos";
    this.login = "auth/login";
  }
}
