import AuthService from "../../services/auth.service.js";
import NotificationService from "../../services/notification.service.js";

export default class IndexViewComponent {
  constructor() {
    this.listeners();
  }

  listeners() {
    $("#frm-login").on("submit", (e) => e.preventDefault());
    $("#submit").on("click", () => this.logar());
  }

  logar() {
    AuthService.login($("#username").val(), $("#password").val())
      .then((response) => {
        localStorage.setItem("meus-jogos-token", response.token);
        window.location.href = "/Home";
      })
      .catch((e) => NotificationService.error(e.responseJSON.message));
  }
}
