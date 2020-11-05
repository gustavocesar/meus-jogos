export default class NotificationService {
  static success(message) {
    let div = $("#success-message");
    div.parent().removeClass("d-none");
    div.html(message);
  }

  static error(message) {
    let div = $("#error-message");
    div.parent().removeClass("d-none");
    div.html(message);
  }
}
