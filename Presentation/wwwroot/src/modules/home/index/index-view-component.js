import EmprestimoService from "../../../services/emprestimo.service.js";
import AmigoService from "../../../services/amigo.service.js";
import NotificationService from "../../../services/notification.service.js";

export default class IndexViewComponent {
  constructor() {
    this.loadJogosEmprestados();
    this.loadJogosDisponiveis();
    this.listeners();
  }

  listeners() {
    $(document).on("click", "#btn-gravar-emprestimo", (e) => {
      this.emprestar();
    });

    $(document).on("click", ".btn-devolver", (e) => {});

    $(document).on("show.bs.modal", "#modalEmprestar", (e) => {
      let button = $(e.relatedTarget);

      let jogo = button.data("jogo-nome");
      let jogoId = button.data("jogo-id");

      $("#jogo-id").val(jogoId);
      $("#modalEmprestarLabel").html(jogo);

      this.loadAmigosModal();
    });
  }

  loadAmigosModal() {
    AmigoService.getAmigos()
      .then((amigos) => {
        $(amigos).each((index, amigo) => {
          $("#emprestar-para").append(new Option(amigo.nome, amigo.id));
        });
      });
  }

  async emprestar() {
    try {
      let jogoId = $("#jogo-id").val();
      let amigoId = $("#emprestar-para").val();
      
      $("#btn-gravar-emprestimo").attr("disabled", true);
      
      await EmprestimoService.emprestar(jogoId, amigoId);

      NotificationService.success("Jogo emprestado com sucesso");
      $("#modalEmprestar").modal('hide');
      this.loadJogosEmprestados();
      this.loadJogosDisponiveis();

      $("#btn-gravar-emprestimo").attr("disabled", false);

    } catch (error) {
      $("#btn-gravar-emprestimo").attr("disabled", false);
      NotificationService.error(error);
    }
  }

  async devolver(id) {
    try {
      await EmprestimoService.devolver(id);

      NotificationService.success("Jogo devolvido com sucesso");
      this.loadJogosEmprestados();
      this.loadJogosDisponiveis();
    } catch (error) {
      NotificationService.error(error);
    }
  }

  loadJogosEmprestados() {
    $('#list-emprestados').html("");

    EmprestimoService.getJogosEmprestados()
      .then(jogosEmprestados => {
        $(jogosEmprestados).each((index, jogoEmprestado) => {
          $('#list-emprestados').append(`
          <li class="list-group-item">
          <button class="btn btn-outline-warning btn-sm btn-devolver" data-id="${jogoEmprestado.id}">Devolver</button>
            ${jogoEmprestado.jogo}
            <small class="ml-1"> - ${jogoEmprestado.amigo}</small>
          </li>`);
        });
      })
      .catch(r => NotificationService.error(r));
  }

  loadJogosDisponiveis() {
    $('#list-disponiveis').html("");

    EmprestimoService.getJogosDisponiveis()
      .then(jogosDisponiveis => {
        $(jogosDisponiveis).each((index, jogoDisponivel) => {
          $('#list-disponiveis').append(`
          <li class="list-group-item">
            <button class="btn btn-outline-primary btn-sm btn-emprestar" data-toggle="modal" data-target="#modalEmprestar" data-jogo-id="${jogoDisponivel.id}" data-jogo-nome="${jogoDisponivel.jogo}">Emprestar</button>
            <span class="ml-2">${jogoDisponivel.jogo}</span>
          </li>`);
        });
      })
      .catch(r => NotificationService.error(r));
  }
}
