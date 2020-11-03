export default class NotificationService {
  static success(message, title = "Sucesso") {
    Swal.fire(title, message, "success");
  }
  static info(message, title = "Informação") {
    Swal.fire(title, message, "info");
  }
  static error(message, title = "Erro") {
    Swal.fire(title, message, "error");
  }
}
