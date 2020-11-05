import AmigoService from "../../../services/amigo.service.js";
import NotificationService from "../../../services/notification.service.js";

export default class IndexViewComponent {
  constructor() {
    this.loadAmigos();
  }

  loadAmigos() {
    AmigoService.getAmigos()
      .then((amigos) => {

        let lista = $("#list-amigos");

        let rows = "";
        $(amigos).each((index, amigo) => {
          rows +=
            "<tr>\
          <td>" +
            amigo.nome +
            "</td>\
          <td>" +
          amigo.celular +
            "</td>\
        </tr>";
        });

        lista.html(
          "<table class='table'>\
        <thead>\
          <tr>\
            <th scope='col'>Nome</th>\
            <th scope='col'>Celular</th>\
          </tr>\
        </thead>\
        <tbody>\
        " +
            rows +
            "\
        </tbody>\
      </table>"
        );
      })
      .catch((error) => NotificationService.error(error));
  }
}
