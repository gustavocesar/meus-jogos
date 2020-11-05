import JogoService from "../../../services/jogos.service.js";
import NotificationService from "../../../services/notification.service.js";

export default class IndexViewComponent {
  constructor() {
    this.id = $("#id");
    this.titulo = $("#titulo");
    this.plataforma = $("#plataforma");

    this.loadJogos();
    this.listeners();
  }

  listeners() {
    $("#btn-gravar").on("click", () => {
      this.gravar();
    });

    $(document).on("click", ".btn-editar", (e) => {
      this.editar($(e.target).data("id"));
    });

    $(document).on("click", ".btn-excluir", (e) => {
      this.excluir($(e.target).data("id"));
    });
  }

  excluir(id) {
    if (confirm("Confirma a exclusão deste Jogo?")) {
      JogoService.excluir(id)
        .then((r) => {
          this.loadJogos();
          NotificationService.success("Jogo excluído com sucesso");
        })
        .catch((error) => NotificationService.error(error));
    }
  }

  editar(id) {
    JogoService.getJogo(id)
      .then((r) => {
        this.id.val(r.id);
        this.titulo.val(r.titulo);
        let index = $(
          '#plataforma option:contains("' + r.plataforma + '")'
        ).val();
        this.plataforma.val(index);
      })
      .catch((e) => alert(e.responseJSON.message));
  }

  async gravar() {
    try {
      let id = this.id.val();
      let titulo = this.titulo.val();
      let plataforma = parseInt(this.plataforma.val(), 10);

      let acao = "";
      if (id) {
        await JogoService.editar(id, titulo, plataforma);
        acao = "editado";
      } else {
        await JogoService.incluir(titulo, plataforma);
        acao = "incluído";
      }

      this.id.val("");
      this.titulo.val("");
      this.plataforma.val(0);

      NotificationService.success(`Jogo ${acao} com sucesso`);
      this.loadJogos();
    } catch (error) {
      NotificationService.error(error);
    }
  }

  loadJogos() {
    JogoService.getJogos()
      .then((jogos) => {
        let lista = $("#list-jogos");

        let rows = "";
        $(jogos).each((index, jogo) => {
          rows +=
            "<tr>\
          <td>" +
            jogo.titulo +
            "</td>\
          <td>" +
            jogo.plataforma +
            "</td>\
          <td><button class='btn btn-info btn-editar' data-id='" +
            jogo.id +
            "'>Editar</button> <button class='btn btn-danger btn-excluir' data-id='" +
            jogo.id +
            "'>Excluir</button></td>\
        </tr>";
        });

        lista.html(
          "<table class='table'>\
        <thead>\
          <tr>\
            <th scope='col'>Título</th>\
            <th scope='col'>Plataforma</th>\
            <th scope='col'>&nbsp;</th>\
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
