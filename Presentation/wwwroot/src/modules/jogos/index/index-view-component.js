import JogoService from "../../../services/jogos.service.js";

export default class IndexViewComponent {
  constructor() {
    this.id = $('#id');
    this.titulo = $('#titulo');
    this.plataforma = $('#plataforma');

    this.loadJogos();
    this.listeners();
  }

  listeners() {
    $("#btn-gravar").on('click', () => {
      this.gravar();
    });

    $(document).on("click",".btn-editar", (e) => {
      this.editar($(e.target).data('id'));
    });
  }

  editar(id) {
    JogoService.getJogo(id)
    .then(r => {
      this.id.val(r.id);
      this.titulo.val(r.titulo);
      let index = $('#plataforma option:contains("'+r.plataforma+'")').val();
      this.plataforma.val(index);
    })
    .catch(e => alert(e.responseJSON.message));
  }

  async gravar() {
    try {
      let id = this.id.val();
      let titulo = this.titulo.val();
      let plataforma = parseInt(this.plataforma.val(), 10);

      if (id)
        await JogoService.editar(id, titulo, plataforma);
      else
        await JogoService.incluir(titulo, plataforma);

      this.id.val("");
      this.titulo.val("");
      this.plataforma.val(0);
      this.loadJogos();

    } catch (error) {
      console.log(error);
      alert(error);
    }
  }

  loadJogos() {
    JogoService.getJogos().then((jogos) => {
      let lista = $("#list-jogos");
      
      let rows = "";
      $(jogos).each((index, jogo) => {
        rows += "<tr>\
          <td>"+jogo.titulo+"</td>\
          <td>"+jogo.plataforma+"</td>\
          <td><button class='btn btn-info btn-editar' data-id='"+jogo.id+"'>Editar</button></td>\
        </tr>";
      });

      lista.html("<table class='table'>\
        <thead>\
          <tr>\
            <th scope='col'>Título</th>\
            <th scope='col'>Plataforma</th>\
            <th scope='col'>&nbsp;</th>\
          </tr>\
        </thead>\
        <tbody>\
        "+rows+"\
        </tbody>\
      </table>");

    });
  }
}
